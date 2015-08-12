NReco extends standard ASP.NET infrastructure with set of enhancements:
  * access to external services (for instance configured using IoC container)
  * unified UI Actions processing mechanism
  * UI labels resolving mechanism
  * extensible implementations of membership and role providers
  * web-routing mechanism integration
Note that NReco-Web is _not_ Web UI framework (like [MVC.NET](http://www.asp.net/mvc/) for instance): it neither specifies how to organize UI layer nor applies any restrictions to it.

## Services ##
[WebManager](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/WebManager.cs) defines GetService method for accessing various services from underlying layers:
```
var myPrv = WebManager.GetService<IProvider<string,string>>("myPrvName");
```
Another best practice of using services is declaring dependency inside user controls (just public properties that reflects desired service type). In this case [ServiceExpressionBuilder](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ServiceExpressionBuilder.cs) may be used for pubshing services in declarative way:
```
<CTRL:MyUserControl runat="server" MyPrv="<%$ service: myPrvName %>"/>
```

## UI Actions ##
[Web action](NRecoWebAction.md) is a calls from UI layer described by [ActionContext](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionContext.cs). Its purpose to support different aspects (like transactions, logging etc) that usually exist between UI layer and underlying layers.

Fore more details refer to [web action overview page](NRecoWebAction.md).

## Labels Resolving ##
Very often UI labels should not be static (for instance in case of localization). [WebManager](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/WebManager.cs) defines GetLabel method (overloaded) that may be used for resolving text labels:
```
<%= WebManager.GetLabel("My text") %>
```
In really WebManager tries to locate appropriate label provider using WebManager.GetService method (label provider name may be defined in web manager configuration). This provider should expect LabelContext (that may contain not only original label but also information about label origin etc) and return resolved label value.
Note that you can resolve text properties in server controls using [LabelExpressionBuilder](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/LabelExpressionBuilder.cs):
```
<asp:Label runat="server" Text="<%$ label: Label Text %>"/>
```