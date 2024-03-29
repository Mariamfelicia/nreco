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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NReco.Web.Site.Controls {
	
	/// <summary>
	/// Special placeholder that performs databinding for itself.
	/// </summary>
	public class DataBindHolder : PlaceHolder {

		public bool AutoBind { get; set; }

		protected bool IsBinded {
			get { return ViewState["isBinded"] != null ? (bool)ViewState["isBinded"] : false; }
			set { ViewState["isBinded"] = value; }
		}

		public DataBindHolder() {
			AutoBind = true;
		}

		public override void  DataBind() {
			IsBinded = true;
			base.DataBind();
		}

		protected override void OnPreRender(EventArgs e) {
			if (AutoBind && !IsBinded) {
				DataBind();
			}
			base.OnPreRender(e);
		}

	}
}
