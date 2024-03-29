﻿#region License
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
using System.Globalization;

using NReco;
using NReco.Converting;
using NReco.Collections;
using NReco.Web;
using NReco.Web.Site;
using NReco.Web.Site.Controls;
using NI.Data.Dalc;
using NI.Data.Dalc.Web;
using NI.Data.Dalc.Linq;
using NI.Data.RelationalExpressions;

[ValidationProperty("Value")]
public partial class McDropDownEditor : System.Web.UI.UserControl {
	
	public string JsScriptName { get; set; }
	public bool RegisterJs { get; set; }
	
	public string LookupServiceName { get; set; }
	public string TextFieldName { get; set; }
	public string ValueFieldName { get; set; }
	public string ParentFieldName { get; set; }
	
	public object DataContext { 
		get { return ViewState["DataContext"]; }
		set { ViewState["DataContext"] = value; } 
	}

	public bool AllowParentSelect { get; set; }
	
	public string Value {
		get { return selectedValue.Value!="" ? selectedValue.Value : null; }
		set { selectedValue.Value = value; }
	}
	
	public McDropDownEditor() {
		RegisterJs = true;
		JsScriptName = "js/jquery.mcdropdown.min.js";
		AllowParentSelect = true;
	}
	
	protected override void OnLoad(EventArgs e) {
		if (RegisterJs) {
			JsHelper.RegisterJsFile(Page,JsScriptName);
		}
	}
	
	IEnumerable _Data;
	protected IEnumerable Data {
		get { return _Data ?? (_Data=DataSourceHelper.GetProviderDataSource(LookupServiceName,DataContext)); }
	}
	
	protected IEnumerable GetLevelData(object parent) {
		foreach (var item in Data)
			if (AssertHelper.AreEquals( DataBinder.Eval(item,ParentFieldName), parent))
				yield return item;
	}
	
	protected void RenderHierarchyLevel(StringBuilder sb, object parent, bool renderList) {
		bool isFirst = true;
		foreach (var item in GetLevelData(parent)) {
			if (isFirst && renderList) {
				sb.Append("<ul class='ui-widget-content'>");
				isFirst = false;
			}
			var uid = DataBinder.Eval(item,ValueFieldName);
			sb.AppendFormat("<li rel='{0}'>{1}", uid,DataBinder.Eval(item,TextFieldName));
			RenderHierarchyLevel( sb, uid, true );
			sb.Append("</li>");
		}
		if (!isFirst && renderList)
			sb.Append("</ul>");
	}
	
	protected string RenderHierarchy() {
		var sb = new StringBuilder();
		RenderHierarchyLevel(sb, DBNull.Value,false);
		return sb.ToString();
	}
	
	protected FilterView FindFilter() {
		return this.GetParents<FilterView>().FirstOrDefault();
	}
	
	protected void HandleSelectedChanged(object sender,EventArgs e) {
		var filter = FindFilter();
		if (filter!=null)
			filter.ApplyFilter();
	}	
	
}
