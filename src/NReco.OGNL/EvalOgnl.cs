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
using System.Collections.Generic;
using System.Collections;
using System.Text;

using NReco;
using NReco.Collections;
using NReco.Logging;
using ognl;

namespace NReco.OGNL {
	
	public class EvalOgnl {
		static ClassResolver DefaultClassResolverInstance = new HelpersClassResolver( new DefaultClassResolver() );
		static ILog log = LogManager.GetLogger(typeof(EvalOgnl));

		ClassResolver _ClassResolver = DefaultClassResolverInstance;

		public ClassResolver TypeResolver {
			get { return _ClassResolver; }
			set { _ClassResolver = value; }
		}


		public object Eval(string code, IDictionary<string,object> context) {
			object root = context;
			IDictionary dictContext = new DictionaryWrapper<string, object>(context);
			IDictionary variables = Ognl.addDefaultContext(root, TypeResolver, dictContext);
			try {
				object res = Ognl.getValue(code, variables, root);
				if (log.IsEnabledFor(LogEvent.Debug))
					log.Write(
						LogEvent.Debug,
						new{Action="getting value",Expression=code,Result=res,Context=context}
					);
				return res;
			} catch (Exception ex) {
				log.Write(
					LogEvent.Error,
					new { Action = "getting value", Exception = ex, Expression = code, Context = context });
				throw new Exception("OGNL code evaluation failed (" + code + "): " + ex.Message, ex);
			}
		}

	}
}
