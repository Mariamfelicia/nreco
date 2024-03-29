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
using NReco.Web;
using NReco.Web.Site;
using NReco.Web.Site.Controls;

[ValidationProperty("ObjectValue")]
public partial class DatePickerEditor : NReco.Web.ActionUserControl, IDateBoxControl {
	
	bool _RegisterJs = false;
	string _JsScriptName = "jquery-ui-1.7.1.custom.min.js";
	
	public bool YearSelection { get; set; }
	public bool MonthSelection { get; set; }
	public bool ClearButton { get; set; }
	public string YearRange { get; set; }
	public int Width { get; set; }
	public bool Autofilter { get; set; }
	public DayOfWeek FirstDayOfWeek { get; set; }
	
	public string JsScriptName { 
		get { return _JsScriptName; }
		set { _JsScriptName = value; }
	}
	
	public bool RegisterJs {
		get { return _RegisterJs; }
		set { _RegisterJs = value; }
	}
	
	public DateTime DateTimeValue {
		get {
			return (DateTime)( ObjectValue ?? DateTime.MinValue );
		}
		set {
			ObjectValue = value;
		}
	}
	
	public DateTime? Date {
		get { return (DateTime?)ObjectValue; }
		set { ObjectValue = value; }
	}	
	
	public object ObjectValue {
		get {
			DateTime postedValue;
			if (dateValue.Value.Trim()!=String.Empty) {
				if (DateTime.TryParse(dateValue.Value, out postedValue)) {
					return postedValue;
				} else {
					throw new Exception( WebManager.GetLabel("Invalid date format") );
				}
			}
			return null;
		}
		set {
			if (value == DBNull.Value)
				value = null;
			dateValue.Value = GetFormattedDate(value);
		}
	}

	public DatePickerEditor() {
		YearSelection = false;
		MonthSelection = false;
		ClearButton = false;
		Autofilter = false;
		FirstDayOfWeek = DayOfWeek.Monday;
	}
	
	protected string GetDateJsPattern() {
		string s = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToLower();
		if (s.IndexOf('m') == s.LastIndexOf('m')) s.Replace("m", "mm");
		if (s.IndexOf('d') == s.LastIndexOf('d')) s.Replace("d", "dd");
		return s.Replace("yyyy","yy");
    }

	protected string GetFormattedDate(object dt) {
		if (dt is DateTime)
			return ((DateTime)dt).ToString("d", CultureInfo.CurrentCulture);
		return String.Empty;
	}
	
	protected override void OnLoad(EventArgs e) {
		if (RegisterJs) {
			var scriptTag = "@@lt;s"+"cript language='javascript' src='"+JsScriptName+"'@@gt;@@lt;/s"+"cript@@gt;";
			if (!Page.ClientScript.IsStartupScriptRegistered(Page.GetType(), JsScriptName)) {
				Page.ClientScript.RegisterStartupScript(Page.GetType(), JsScriptName, scriptTag, false);
			}
			// one more for update panel
			System.Web.UI.ScriptManager.RegisterClientScriptInclude(Page, Page.GetType(), JsScriptName, "ScriptLoader.axd?path="+JsScriptName);
		}
	}

	protected FilterView FindFilter() {
		return this.GetParents<FilterView>().FirstOrDefault();
	}	
	
	protected void HandleLazyFilter(object sender, EventArgs e) {
		var filter = FindFilter();
		if (filter!=null && Autofilter) {
			filter.ApplyFilter();
		}
	}	
}
