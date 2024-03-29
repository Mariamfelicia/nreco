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
using System.Configuration;
using System.Web;
using System.Web.UI;

using NReco.Converting;
using NReco.Logging;

namespace NReco.Web {
	
	/// <summary>
	/// NReco web layer manager.
	/// </summary>
	public static class WebManager {

		static ILog log = LogManager.GetLogger(typeof(WebManager));
		static WebManagerCfg Config = new WebManagerCfg();

		static WebManager() {
		}

		public static void Configure() {
			string sectionName = typeof(WebManager).Namespace;
			object config = ConfigurationSettings.GetConfig(sectionName);
			if (config == null)
				config = ConfigurationSettings.GetConfig(sectionName.ToLower());
			if (config != null) {
				WebManagerCfg webCfg = config as WebManagerCfg;
				if (config == null) {
					log.Write(LogEvent.Warn, "Invalid WebManager configuration type: {0}", config.GetType());
				} else {
					Config = webCfg;
				}
			} else {
				log.Write(LogEvent.Warn, "WebManager configuration section not found in application config");
			}
		}

		public static void Configure(WebManagerCfg cfg) {
			Config = cfg;
		}

		public static string BasePath {
			get {
				if (Config.HttpRoot != null)
					return VirtualPathUtility.AppendTrailingSlash( (new Uri(Config.HttpRoot)).AbsolutePath );
				return VirtualPathUtility.AppendTrailingSlash( System.Web.HttpRuntime.AppDomainAppVirtualPath );
			}
		}

		public static string BaseUrl {
			get {
				if (Config.HttpRoot!=null)
					return Config.HttpRoot;
				return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + BasePath;
			}
		}

		/// <summary>
		/// Web layer current service provider instance
		/// </summary>
		public static IProvider<object,object> ServiceProvider {
			get { return HttpContext.Current.Items[Config.ServiceProviderContextKey] as IProvider<object, object>; }
			set { HttpContext.Current.Items[Config.ServiceProviderContextKey] = value; }
		}
		
		/// <summary>
		/// Make full URL
		/// </summary>
		/// <param name="url">partial URL part</param>
		/// <returns>full URL</returns>
		public static string MakeFullUrl(string url) {
			if (url.StartsWith("/")) {
				var baseUri = new Uri(BaseUrl);
				return baseUri.GetLeftPart(UriPartial.Authority) + url;
			} else {
				if (Uri.IsWellFormedUriString(url,UriKind.Absolute))
					return url;
			}
			return VirtualPathUtility.AppendTrailingSlash(BaseUrl) + url;
		}

		/// <summary>
		/// Get service by name
		/// </summary>
		/// <param name="serviceName">name of the service</param>
		/// <returns>service instance or null</returns>
		public static object GetService(string serviceName) {
			object service = ServiceProvider.Provide(serviceName);
			if (service == null)
				log.Write(LogEvent.Warn, "Service with name '{0}' not found.", serviceName);
			return service;
		}

		/// <summary>
		/// Get service by name
		/// </summary>
		/// <param name="serviceName">name of the service</param>
		/// <param name="t">desired type</param>
		/// <returns>service compatible with desired type or null</returns>
		/// <exception cref="InvalidCastException">thrown when service could not be converted to desired type</exception>
		public static object GetService(string serviceName, Type t) {
			object service = GetService(serviceName);
			return t.IsInstanceOfType(service) ? service : ConvertManager.ChangeType(service,t);
		}

		/// <summary>
		/// Get service by name
		/// </summary>
		/// <typeparam name="T">desired service type</typeparam>
		/// <param name="serviceName">service name</param>
		/// <returns>service instance or null</returns>
		/// <exception cref="InvalidCastException">thrown when service could not be converted to desired service type</exception>
		public static T GetService<T>(string serviceName) {
			return (T)GetService(serviceName, typeof(T));
		}

		/// <summary>
		/// Get any service of specified type
		/// </summary>
		/// <param name="serviceType">service type</param>
		/// <returns>service instance or null</returns>
		public static object GetService(Type serviceType) {
			return ServiceProvider.Provide(serviceType);
		}

		/// <summary>
		/// Get any service of specified type
		/// </summary>
		/// <typeparam name="T">service type</typeparam>
		/// <returns></returns>
		public static T GetService<T>() {
			return (T)ServiceProvider.Provide(typeof(T));
		}

		/// <summary>
		/// Execute UI action entry point.
		/// </summary>
		/// <param name="context">action context</param>
		public static void ExecuteAction(ActionContext context) {
			var controller = GetService<IOperation<ActionContext>>(Config.ActionDispatcherName);
			if (controller!=null) {
				controller.Execute(context);
			} else {
				log.Write(LogEvent.Warn, "Action controller not found");
			}
		}

		public static string GetLabel(string label) {
			if (Config.LabelFilterName != null) {
				return GetLabel(new LabelContext(label));
			}
			return label;
		}

		public static string GetLabel(string label, Control originCtrl) {
			if (Config.LabelFilterName != null) {
				return GetLabel(new LabelContext(label, originCtrl));
			}
			return label;
		}

		public static string GetLabel(string label, string origin) {
			if (Config.LabelFilterName != null) {
				return GetLabel(new LabelContext(label, origin));
			}
			return label;
		}

		public static string GetLabel(LabelContext context) {
			if (Config.LabelFilterName != null && context.Label!=null) {
				var labelContextFilter = GetService<IProvider<LabelContext, string>>(Config.LabelFilterName);
				if (labelContextFilter != null)
					return labelContextFilter.Provide(context);
			}
			return context.Label;			
		}


	}
}
