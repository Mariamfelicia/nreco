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

namespace NReco.Web.Site.Security {
	
	/// <summary>
	/// Fixed (preconfigured and read-only) role storage implementation.
	/// </summary>
	public class FixedRoleStorage : IRoleStorage {
		
		public Role[] Roles { get; set; }

		public void Create(Role role) {
			throw new NotSupportedException();
		}

		public Role Load(string roleName) {
			for (int i = 0; i < Roles.Length; i++)
				if (Roles[i].Name == roleName)
					return Roles[i];
			return null;
		}

		public Role[] LoadAll() {
			return (Role[])Roles.Clone();
		}

		public bool Delete(Role role) {
			throw new NotSupportedException();
		}

	}

}
