#region License
/*
 * NReco library (http://nreco.googlecode.com/)
 * Copyright 2008,2009 Vitaliy Fedorchenko
 * Distributed under the LGPL licence
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

using NReco;
using NReco.Collections;
using NReco.Converting;
using NReco.Web;
using NReco.Web.Site;
using NReco.Web.Site.Data;
using NReco.Web.Site.Controls;
using NI.Data.Dalc;
using NI.Data.Dalc.Web;
using NI.Data.Dalc.Linq;
using System.ComponentModel;

public abstract class CommonRelationEditor : ActionUserControl, IBindableControl {

	public string EntityIdField { get; set; }
	public string DalcServiceName { get; set; }
	public string DsFactoryServiceName { get; set; }
	
	public string LookupServiceName { get; set; }
	public string TextFieldName { get; set; }
	public string ValueFieldName { get; set; }
	public object LookupDataContext { get; set; }

	public string RelationSourceName { get; set; }
	public string LFieldName { get; set; }
	public string RFieldName { get; set; }
	public string PositionFieldName { get; set; }
	public string DefaultValueServiceName { get; set; }
	public object DefaultDataContext { get; set; }
	
	[TypeConverterAttribute(typeof(StringArrayConverter))]
	public string[] DependentFromControls { get; set; }
	public string DataContextControl { get; set; }	
	
	IOperation<LogRelationEditorWrapper.LogContext> _LogOperation = null;
	public IOperation<LogRelationEditorWrapper.LogContext> LogOperation {
		get {
			if (_LogOperation==null && LogOperationName!=null)
				_LogOperation = WebManager.GetService<IOperation<LogRelationEditorWrapper.LogContext>>(LogOperationName);
			return _LogOperation;
		}
		set { _LogOperation = value; }
	}
	
	public string LogOperationName { get; set; }
	public string LogRelationName { get; set; }
	
	
	IRelationEditor _RelationEditor = null;
	IRelationEditor _RelationEditorWithLogger = null;
	public IRelationEditor RelationEditor {
		get { 
			if (_RelationEditor==null && !String.IsNullOrEmpty(RelationSourceName) ) {
				// auto-compose from properties
				var dalcMgr = DsFactoryServiceName != null ? new DalcManager(Dalc, WebManager.GetService<IDataSetProvider>(DsFactoryServiceName) ) : null;
				var useDalcMgr = UseDataRow && dalcMgr != null;
				if (useDalcMgr) {
					_RelationEditor = new DalcManagerRelationEditor() {
						DalcManager = dalcMgr,
						FromFieldName = LFieldName,
						ToFieldName = RFieldName,
						PositionFieldName = PositionFieldName,
						RelationSourceName = RelationSourceName
					};
				} else {
					_RelationEditor = new DalcRelationEditor() {
						Dalc = Dalc,
						FromFieldName = LFieldName,
						ToFieldName = RFieldName,
						PositionFieldName = PositionFieldName,
						RelationSourceName = RelationSourceName
					};
				}
			}
			if (_RelationEditorWithLogger==null && _RelationEditor!=null && LogOperation!=null) {
				_RelationEditorWithLogger = new LogRelationEditorWrapper() {
					RelationEditor = _RelationEditor,
					RelationName = LogRelationName ?? (RelationSourceName ?? ID),
					WriteLog = LogOperation
				};
			}
			return _RelationEditorWithLogger ?? _RelationEditor;
		}
		set { _RelationEditor = value; }
	}
	
	private bool _UseDataRow = true;
	public bool UseDataRow {
		get { return _UseDataRow; }
		set { _UseDataRow = value; }
	}
	
	public object EntityId {
		get { return ViewState["EntityId"]; }
		set { ViewState["EntityId"] = value; }
	}
	
	private IDalc Dalc {
		get { return WebManager.GetService<IDalc>(DalcServiceName); }
	}

	protected override void OnLoad(EventArgs e) {
		if (DependentFromControls!=null) 
			foreach (var depCtrlId in DependentFromControls)
				if ( (NamingContainer.FindControl(depCtrlId) as IEditableTextControl)!=null) {
					((IEditableTextControl)NamingContainer.FindControl(depCtrlId)).TextChanged += new EventHandler(DependentFromControlChangedHandler);
				}
	
	}
	
	protected void DependentFromControlChangedHandler(object sender, EventArgs e) {
		// find data control
		if (DataContextControl!=null && (NamingContainer.FindControl(DataContextControl) as DataContextHolder)!=null) {
			LookupDataContext = ((DataContextHolder)NamingContainer.FindControl(DataContextControl)).GetDataContext();
			foreach (Control childCtrl in Controls)
				childCtrl.DataBind();
		}
	}	

	public void ExecuteAfter_Select(ActionContext e) {
		if (!(e.Args is ActionDataSource.SelectEventArgs) || !CheckDataSource(e) || RelationEditor==null) return;
		var data = ((ActionDataSource.SelectEventArgs)e.Args).Data;
		if (data != null)
			foreach (object o in data) {
				var record = ConvertManager.ChangeType<IDictionary<string, object>>(o);
				EntityId = record[EntityIdField];
			}
	}

	public void ExecuteAfter_Insert(ActionContext e) {
		if (!(e.Args is ActionDataSource.InsertEventArgs) || !CheckDataSource(e) || RelationEditor==null) return;
		EntityId = ((ActionDataSource.InsertEventArgs)e.Args).Values[EntityIdField];
		Save();
	}
	public void ExecuteAfter_Update(ActionContext e) {
		if (!(e.Args is ActionDataSource.UpdateEventArgs) || !CheckDataSource(e) || RelationEditor==null) return;
		var updateArgs = (ActionDataSource.UpdateEventArgs)e.Args;
		object contextEntityId;
		if (updateArgs.Keys.Contains(EntityIdField))
			contextEntityId = updateArgs.Keys[EntityIdField];
		else
			contextEntityId = updateArgs.Values[EntityIdField];
		// plugin can be used inside list. Lets check with saved id
		if (EntityId!=null && EntityId!=DBNull.Value && !AssertHelper.AreEquals(EntityId,contextEntityId) )
			return;
		EntityId = contextEntityId;
		Save();
	}
	
	public void Save(object leftUid) {
		EntityId = leftUid;
		Save();
	}
	
	public IEnumerable GetDataSource() {
		return DataSourceHelper.GetProviderDataSource(LookupServiceName,LookupDataContext);
	}
	
	protected bool CheckDataSource(ActionContext e) {
		var parentDataboundCtrl = this.GetParents<BaseDataBoundControl>().FirstOrDefault();
		if (e.Sender is Control && parentDataboundCtrl != null && !String.IsNullOrEmpty(parentDataboundCtrl.DataSourceID)) {
			return ((Control)e.Sender).ID == parentDataboundCtrl.DataSourceID;
		}
		return true;
	}
	
	public void ExtractValues(System.Collections.Specialized.IOrderedDictionary dictionary) {
		if (RelationEditor==null) {
			dictionary[ ID ] = GetControlSelectedIds();
		}
	}

	abstract protected IEnumerable GetControlSelectedIds();

	protected void Save() {
		RelationEditor.Set( EntityId, GetControlSelectedIds() );
	}

	public string[] GetSelectedIds() {
		//non-relational mode
		if (RelationEditor==null) {
			var values = Eval( ID ) as IEnumerable;
			if (values!=null) {
				return values.Cast<object>().Select( v => Convert.ToString(v) ).ToArray();
			} else {
				return new string[0];
			}
		}
		
		bool isEmptyId = AssertHelper.IsFuzzyEmpty(EntityId);
		// special hack for autoincrement "new row" ids... TBD: refactor
		if (EntityId is int || EntityId is long) {
			if ( Convert.ToInt64( EntityId )==0)
				isEmptyId = true;
		}
		if (isEmptyId) {
			if (DefaultValueServiceName!=null) {
				var defaultValuePrv = WebManager.GetService<IProvider<object,object>>(DefaultValueServiceName);
				var defaultValues = defaultValuePrv.Provide( DefaultDataContext ?? this.GetContext() );
				if (defaultValues!=null) {
					var list = new List<string>();
					if (defaultValues is IList)
						foreach (object defaultVal in (IList)defaultValues) {
							list.Add(Convert.ToString(defaultVal));
						}
					else
						list.Add( Convert.ToString(defaultValues) );
					return list.ToArray();
				}
			}
			return new string[0];
		}
		// select visible ids
		return RelationEditor.GetToKeys(EntityId).Select( o=>Convert.ToString(o) ).ToArray();
	}

}
