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
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Diagnostics;
using System.Reflection.Emit;

using NReco.Logging;

namespace NReco.Composition {
	
	/// <summary>
	/// Compiles runtime assembly from given code.
	/// </summary>
	public class CompileCodeAssembly : IProvider<string,Assembly> {
		
		CodeDomProvider _DomProvider;
		string[] _RefAssemlies = null;
		static ILog log = LogManager.GetLogger(typeof(CompileCodeAssembly));

		/// <summary>
		/// Get or set referenced assemblies list.
		/// </summary>
		/// <remarks>List should look like: 'System.Configuration.dll','System.Web.dll'.</remarks>
		public string[] RefAssemblies {
			get { return _RefAssemlies; }
			set { _RefAssemlies = value; }
		}

		/// <summary>
		/// Get or set code DOM provider used for building runtime assembly.
		/// </summary>
		public CodeDomProvider DomProvider {
			get { return _DomProvider; }
			set { _DomProvider = value; }
		}

		public CompileCodeAssembly() {
		}

		public CompileCodeAssembly(CodeDomProvider codeDomPrv) {
			DomProvider = codeDomPrv;
		}

		public CompileCodeAssembly(CodeDomProvider codeDomPrv, string[] refAssemblies) {
			DomProvider = codeDomPrv;
			RefAssemblies = refAssemblies;
		}


		public object Provide(object context) {
			return Provide( (string)context );
		}
		
		protected string LocateByLoadedAssemblies(string assemblyRef, string[] loadedLocations) {
			for (int i = 0; i < loadedLocations.Length; i++)
				if (loadedLocations[i].ToLower().EndsWith(assemblyRef.ToLower()))
					return loadedLocations[i];
			// lets try to load this assembly
			if (assemblyRef.EndsWith(".dll"))
				assemblyRef = assemblyRef.Substring(0, assemblyRef.Length - 4);
			var assembly = Assembly.Load(assemblyRef);
			return assembly.Location;
		}
        
        protected bool IsAssemblyDynamic(Assembly a)  {
            //required for .NET4.x environments
            bool result = false;
            var prop = a.GetType().GetProperty("IsDynamic");
            if (prop != null) {
                result = Convert.ToBoolean(prop.GetValue(a, null));
            }
            return result;
        }

		protected string[] GetLoadedAssembliesLocations(Assembly[] loadedAssemblies) {
			List<string> res = new List<string>();
			for (int i=0; i<loadedAssemblies.Length; i++)
				if ( !(loadedAssemblies[i] is AssemblyBuilder) && !IsAssemblyDynamic(loadedAssemblies[i]) && !String.IsNullOrEmpty(loadedAssemblies[i].Location))
					res.Add( loadedAssemblies[i].Location );
			return res.ToArray();
		}

		public Assembly Provide(string code) {
			CompilerParameters cp = new CompilerParameters();
			Assembly[] knownLoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			string[] knownLocations = GetLoadedAssembliesLocations(knownLoadedAssemblies);
			if (RefAssemblies!=null) 
				for (int i = 0; i < RefAssemblies.Length; i++) {
					string assemblyRef = RefAssemblies[i];
					if (!assemblyRef.ToLower().StartsWith("system."))
						assemblyRef = LocateByLoadedAssemblies(assemblyRef, knownLocations);
					cp.ReferencedAssemblies.Add(assemblyRef);
				}
			cp.CompilerOptions = "/t:library";
			cp.GenerateInMemory = true;
			cp.IncludeDebugInformation = false;
			StringBuilder sb = new StringBuilder();
			if (log.IsEnabledFor(LogEvent.Debug))
				log.Write(LogEvent.Debug,new{Action="compile",Code=code});
			CompilerResults cr = DomProvider.CompileAssemblyFromSource(cp, code);
			if (cr.Errors.Count > 0) {
				log.Write(
					LogEvent.Error,
					new { Action = "compile", Msg = cr.Errors[0].ErrorText, Code = code });
				throw new Exception(cr.Errors[0].ErrorText);
			}
			Assembly a = cr.CompiledAssembly;
			return a;
		}

	}
}
