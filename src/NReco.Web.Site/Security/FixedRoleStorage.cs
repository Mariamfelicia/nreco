﻿#region License
/*
 * NReco library (http://code.google.com/p/nreco/)
 * Copyright 2008 Vitaliy Fedorchenko
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

namespace NReco.Web.Site.Security {
	
	/// <summary>
	/// Fixed (preconfigured and read-only) role storage implementation.
	/// </summary>
	public class FixedRoleStorage : IRoleStorage {
		
		public Role[] Roles { get; set; }

		public void Create(Role role) {
			
		}

		public Role Load(string roleName) {
			
		}

		public Role[] LoadAll() {
			throw new NotImplementedException();
		}

		public bool Delete(Role role) {
			throw new NotImplementedException();
		}

	}

}
