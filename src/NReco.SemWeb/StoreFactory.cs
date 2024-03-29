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
using System.Collections;
using System.Linq;
using System.Text;
using SemWeb;

namespace NReco.SemWeb {

	public class StoreFactory {

		public Store Create(params SelectableSource[] sources) {
			return Create( (IEnumerable)sources);
		}
		public Store Create(IEnumerable sources) {
			var store = new Store();
			foreach (var s in sources)
				if (s is SelectableSource)
					store.AddSource((SelectableSource)s);
			return store;
		}
		public Store ImportXmlFiles(params string[] fileNames) {
			return ImportXmlFiles((IEnumerable)fileNames);
		}
		public Store ImportXmlFiles(IEnumerable fileNames) {
			var store = new MemoryStore();
			foreach (string fName in fileNames)
				store.Import(new RdfXmlReader(fName));
			return store;
		}


	}

}
