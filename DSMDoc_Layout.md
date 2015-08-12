# NReco Layout DSM Documentation #


## view ##
Basic UI view.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      | Unique view name. It can be used for view route, for instance. |
| sessiondatacontext | xs:boolean | No       |                 |
| caption       | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [datasources](#datasources.md) |  No          |  View data sources. |
| [action](#action.md) |  No          |  View actions.  |
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |

## datasources ##
View data sources.
| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [Source:dalc dalc](#Data.md) |  No          |                 |


---


## action ##
View actions.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | viewActionNameType | Yes      | Action name determines when it should be executed. |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [redirect](#Operation:redirect.md) |  No          |                 |
| [set](#Operation:set.md) |  No          |                 |
| [databind](#Operation:databind.md) |  No          |                 |
| [operation](#Operation:operation.md) |  No          |                 |
| [jscallback](#Operation:jscallback.md) |  No          |                 |
| [importdatacontext](#Operation:importdatacontext.md) |  No          |                 |
| [code](#Operation:code.md) |  No          |  Custom C# code expression. |


---



---


## Data Source:dalc ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| id            | xs:string | Yes      | Data Source ID. It should be unique in the view scope. |
| sourcename    | xs:string | Yes      | Data source name (database table name or data view name) for select/update/insert/delete operations. |
| selectsourcename | xs:string | No       | Data source name for select operation. |
| condition     | xs:string | No       | Data condition (relex syntax). |
| insertmode    | xs:boolean | No       | Determines whether datasource should return empty new row for select operation if no resoults found. |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [condition](#condition.md) |  No          |                 |

## Data Source:condition ##


---



---


## Renderer:field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      | Field name (usually it is refers to database table field name or object property). |
| format        | xs:string | No       | Format expression. |
| lookup        | xs:string | No       | Provider name that should be used as 'lookup'. |


---


## Renderer:list ##
Generic ASP.NET ListView
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| edit          | xs:boolean | No       |                 |
| add           | xs:boolean | No       |                 |
| headers       | xs:boolean | No       |                 |
| datasource    | xs:string | No       |                 |
| datakey       | xs:string | No       |                 |
| name          | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [datasource](#datasource.md) |  No          |                 |


---


## Renderer:form ##
Generic ASP.NET FormView
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| caption       | xs:string | No       |                 |
| datasource    | xs:string | No       |                 |
| view          | xs:boolean | No       |                 |
| edit          | xs:boolean | No       |                 |
| add           | xs:boolean | No       |                 |
| widget        | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [caption](#caption.md) |  No          |                 |
| [datasource](#datasource.md) |  No          |                 |
| [action](#action.md) |  No          |                 |
| [header](#header.md) |  No          |                 |
| [footer](#footer.md) |  No          |                 |


---


## Renderer:usercontrol ##
Custom ASP.NET user control
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| src           | xs:string | Yes      |                 |


---


## Renderer:repeater ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| separator     | xs:string | No       |                 |
| datasource    | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [provider](#provider.md) |  No          |                 |
| [header](#header.md) |  No          |                 |
| [footer](#footer.md) |  No          |                 |
| [separator](#separator.md) |  No          |                 |
| [item](#item.md) |  No          |                 |

## Renderer:provider ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:header ##


---


## Renderer:footer ##


---


## Renderer:separator ##


---


## Renderer:item ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Renderer:ul ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| datasource    | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [provider](#provider.md) |  No          |                 |
| [item](#item.md) |  No          |                 |

## Renderer:provider ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:item ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Renderer:ol ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| datasource    | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [provider](#provider.md) |  No          |                 |
| [item](#item.md) |  No          |                 |

## Renderer:provider ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:item ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Renderer:updatepanel ##
ASP.NET Update Panel.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| refresh       |          | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---


## Renderer:expression ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:linkbutton ##
ASP.NET Link Button.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| caption       | xs:string | No       | Fixed caption   |
| command       | xs:string | Yes      | Command name (depends from context). Possible values for linkbuttons inside "form"/"list" are "insert", "edit", "cancel", etc. |
| validate      | xs:boolean | No       | Enables "form" validation for this linkbutton |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [caption](#caption.md) |  No          |                 |
| [arg](#arg.md) |  No          |                 |

## Renderer:caption ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:arg ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Renderer:link ##
HTML link.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| url           | xs:string | No       | Fixed url       |
| caption       | xs:string | No       | Fixed caption   |
| target        |          | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [url](#url.md) |  No          |                 |
| [caption](#caption.md) |  No          |                 |

## Renderer:url ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:caption ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Renderer:googlechart ##
Google Chart
| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [bar](#googlechartGroup:bar.md) |  No          |                 |
| [pie](#googlechartGroup:pie.md) |  No          |                 |
| [line](#googlechartGroup:line.md) |  No          |                 |


---


## Renderer:mschart ##
MS Chart
| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [bar](#mschartGroup:bar.md) |  No          |                 |
| [pie](#mschartGroup:pie.md) |  No          |                 |
| [line](#mschartGroup:line.md) |  No          |                 |


---


## Renderer:tabs ##
JQuery UI Tabs Control
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| selected      |          | No       |                 |
| name          | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [tab](#tab.md) |  No          |                 |

## Renderer:tab ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| caption       | xs:string | No       | Fixed tab caption |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [caption](#caption.md) |  No          |                 |
| [visible](#visible.md) |  No          |                 |
| [renderer](#renderer.md) |  No          |                 |

## Renderer:caption ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:visible ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:renderer ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Renderer:caption ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:visible ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:renderer ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Renderer:widget ##
JQuery UI Widget
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| caption       | xs:string | No       | Fixed widget caption |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---


## Renderer:toolbox ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---


## Renderer:listdisplayindex ##


---


## Renderer:placeholder ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [renderer](#renderer.md) |  Yes         |                 |
| [visible](#visible.md) |  No          |                 |

## Renderer:renderer ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---


## Renderer:visible ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Renderer:vfsmanager ##
VFS-based file manager
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| filesystem    | xs:string | Yes      | Filesystem component name |


---


## Renderer:filepreview ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| filesystem    | xs:string | Yes      | Filesystem component name |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Renderer:dashboard ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [row](#dashboardWidgetGroup:row.md) |  No          |                 |
| [widget](#dashboardWidgetGroup:widget.md) |  No          |                 |


---


## Renderer:jfullcalendar ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| title         | xs:string | Yes      |                 |
| start         | xs:string | Yes      |                 |
| end           | xs:string | No       |                 |
| css           | xs:string | No       |                 |
| url           | xs:string | No       |                 |
| width         | xs:int   | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [provider](#provider.md) |  No          |                 |

## Renderer:provider ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [context](#context.md) |  No          |                 |

## Renderer:context ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Renderer:context ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Renderer:newline ##


---


## dashboardWidgetGroup:row ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [row](#dashboardWidgetGroup:row.md) |  No          |                 |
| [widget](#dashboardWidgetGroup:widget.md) |  No          |                 |


---


## dashboardWidgetGroup:widget ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| caption       | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [visible](#visible.md) |  No          |                 |
| [renderer](#renderer.md) |  No          |                 |

## dashboardWidgetGroup:visible ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## dashboardWidgetGroup:renderer ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#Renderer:field.md) |  No          |                 |
| [list](#Renderer:list.md) |  No          |  Generic ASP.NET ListView |
| [form](#Renderer:form.md) |  No          |  Generic ASP.NET FormView |
| [usercontrol](#Renderer:usercontrol.md) |  No          |  Custom ASP.NET user control |
| [repeater](#Renderer:repeater.md) |  No          |                 |
| [ul](#Renderer:ul.md) |  No          |                 |
| [ol](#Renderer:ol.md) |  No          |                 |
| [updatepanel](#Renderer:updatepanel.md) |  No          |  ASP.NET Update Panel. |
| [expression](#Renderer:expression.md) |  No          |                 |
| [linkbutton](#Renderer:linkbutton.md) |  No          |  ASP.NET Link Button. |
| [link](#Renderer:link.md) |  No          |  HTML link.     |
| [googlechart](#Renderer:googlechart.md) |  No          |  Google Chart   |
| [mschart](#Renderer:mschart.md) |  No          |  MS Chart       |
| [tabs](#Renderer:tabs.md) |  No          |  JQuery UI Tabs Control |
| [widget](#Renderer:widget.md) |  No          |  JQuery UI Widget |
| [toolbox](#Renderer:toolbox.md) |  No          |                 |
| [listdisplayindex](#Renderer:listdisplayindex.md) |  No          |                 |
| [placeholder](#Renderer:placeholder.md) |  No          |                 |
| [vfsmanager](#Renderer:vfsmanager.md) |  No          |  VFS-based file manager |
| [filepreview](#Renderer:filepreview.md) |  No          |                 |
| [dashboard](#Renderer:dashboard.md) |  No          |                 |
| [jfullcalendar](#Renderer:jfullcalendar.md) |  No          |                 |
| [newline](#Renderer:newline.md) |  No          |                 |


---



---


## Editor:textbox ##
ASP.NET TextBox Control
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| empty-is-null | xs:boolean | No       |                 |
| width         | xs:string | No       |                 |


---


## Editor:numbertextbox ##
ASP.NET TextBox Control for number input
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| format        | xs:string | No       |                 |
| type          |          | No       |                 |
| width         | xs:string | No       |                 |


---


## Editor:textarea ##
ASP.NET multiline TextBox Control
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| rows          | xs:integer | No       |                 |


---


## Editor:passwordtextbox ##
TextBox-based password editor
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| encrypter     | xs:integer | No       |                 |


---


## Editor:checkbox ##
ASP.NET CheckBox Control

---


## Editor:dropdownlist ##
ASP.NET DropDownList Control
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| lookup        | xs:string | Yes      | "Lookup" provider name (should return entries list) |
| value         | xs:string | No       | Entry member name that should be used as value |
| text          | xs:string | No       | Entry member name that should be used as visible text |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [context](#context.md) |  No          |                 |

## Editor:context ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Editor:checkboxlist ##
ASP.NET CheckBoxList-based relation editor.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| id            | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [relation](#relation.md) |  Yes         |                 |
| [lookup](#lookup.md) |  Yes         |                 |

## Editor:relation ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| sourcename    | xs:string | Yes      |                 |
| left          | xs:string | Yes      |                 |
| right         | xs:string | Yes      |                 |


---


## Editor:lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| text          | xs:string | Yes      |                 |
| value         | xs:string | Yes      |                 |


---



---


## Editor:multiselect ##
JQuery Multiselect-based relation editor.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| id            | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [relation](#relation.md) |  Yes         |                 |
| [lookup](#lookup.md) |  Yes         |                 |

## Editor:relation ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| sourcename    | xs:string | Yes      |                 |
| left          | xs:string | Yes      |                 |
| right         | xs:string | Yes      |                 |
| position      | xs:string | No       |                 |


---


## Editor:lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| text          | xs:string | Yes      |                 |
| value         | xs:string | Yes      |                 |


---



---


## Editor:checklist ##
JQuery checklist-based relation editor.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| id            | xs:string | Yes      |                 |
| width         | xs:int   | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [relation](#relation.md) |  Yes         |                 |
| [lookup](#lookup.md) |  Yes         |                 |
| [default](#default.md) |  No          |                 |

## Editor:relation ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| sourcename    | xs:string | Yes      |                 |
| left          | xs:string | Yes      |                 |
| right         | xs:string | Yes      |                 |


---


## Editor:lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| text          | xs:string | Yes      |                 |
| value         | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Editor:default ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| provider      | xs:string | No       |                 |


---



---


## Editor:datepicker ##
JQuery DatePicker.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| year          | xs:boolean | No       |                 |
| year-range    | xs:string | No       |                 |
| width         | xs:int   | No       |                 |


---


## Editor:timepicker ##
JQuery TimePicker.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| seconds       | xs:boolean | No       |                 |
| datatype      |          | No       |                 |


---


## Editor:usercontrol ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| src           | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|


---


## Editor:markitup ##
JQuery MarkItUp Textarea editor.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| rows          | xs:integer | No       |                 |


---


## Editor:jwysiwyg ##
JQuery Wysiwyg Textarea HTML-editor.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| rows          | xs:integer | No       |                 |
| cols          | xs:integer | No       |                 |
| resize        | xs:boolean | No       |                 |
| max-height    | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [plugins](#plugins.md) |  No          |                 |

## Editor:plugins ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [vfs-insert-image](#vfs-insert-image.md) |  No          |                 |
| [usercontrol](#usercontrol.md) |  No          |                 |

## Editor:vfs-insert-image ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| filesystem    | xs:string | Yes      |                 |
| toolbar       | xs:string | Yes      |                 |
| uploadpath    | xs:string | No       |                 |


---


## Editor:usercontrol ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| src           | xs:string | Yes      |                 |
| toolbar       | xs:string | Yes      |                 |


---



---


## Editor:vfs-insert-image ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| filesystem    | xs:string | Yes      |                 |
| toolbar       | xs:string | Yes      |                 |
| uploadpath    | xs:string | No       |                 |


---


## Editor:usercontrol ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| src           | xs:string | Yes      |                 |
| toolbar       | xs:string | Yes      |                 |


---



---


## Editor:singlefile ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| filesystem    | xs:string | Yes      |                 |
| basepath      | xs:string | Yes      |                 |


---


## Editor:flexbox ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [lookup](#lookup.md) |  Yes         |                 |
| [relation](#relation.md) |  No          |                 |
| [context](#context.md) |  No          |                 |

## Editor:lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| text          | xs:string | Yes      |                 |
| value         | xs:string | Yes      |                 |
| relex         | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [relex](#relex.md) |  No          |                 |

## Editor:relex ##


---



---


## Editor:relex ##


---


## Editor:relation ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| sourcename    | xs:string | Yes      |                 |
| left          | xs:string | Yes      |                 |
| right         | xs:string | Yes      |                 |
| id            | xs:string | Yes      |                 |


---


## Editor:context ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [js](#js.md) |  No          |                 |

## Editor:js ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Editor:js ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Editor:jgrowtextarea ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| rows          | xs:integer | No       |                 |
| cols          | xs:integer | No       |                 |
| maxheight     | xs:integer | No       |                 |


---


## Editor:multifile ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| filesystem    | xs:string | Yes      |                 |
| basepath      | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [relation](#relation.md) |  Yes         |                 |

## Editor:relation ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| sourcename    | xs:string | Yes      |                 |
| left          | xs:string | Yes      |                 |
| right         | xs:string | Yes      |                 |
| id            | xs:string | Yes      |                 |


---



---


## Editor:mcdropdown ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| allowparentselect | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [lookup](#lookup.md) |  Yes         |                 |

## Editor:lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| text          | xs:string | Yes      |                 |
| value         | xs:string | Yes      |                 |
| name          | xs:string | Yes      |                 |
| parent        | xs:string | Yes      |                 |


---



---


## Editor:jcolorpicker ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| lowercase     | xs:boolean | No       |                 |
| prefix        | xs:string | No       |                 |


---


## Validator:required ##


---


## Validator:regex ##


---


## Validator:chooseone ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| group         | xs:string | Yes      |                 |


---


## Validator:maxlength ##


---


## Validator:decimal ##


---


## Validator:email ##


---


## formFieldGroup:field ##
Form field
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       | Context object member name for the field |
| caption       | xs:string | No       | Fixed caption   |
| format        | xs:string | No       | Format string for the field value (like '{0:d}') |
| lookup        | xs:string | No       | "Lookup" provider name |
| view          | xs:boolean | No       | Enables field for view (readonly) form |
| edit          | xs:boolean | No       | Enables field for edit form |
| add           | xs:boolean | No       | Enables field for add form |
| layout        | formFieldLayoutType | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [group](#group.md) |  No          |                 |
| [editor](#editor.md) |  No          |  Editor for the field |
| [renderer](#renderer.md) |  No          |  Custom renderer for the field |
| [visible](#visible.md) |  No          |                 |


---


## views ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [view](#view.md) |  No          |  Basic UI view. |


---


## Expression:route ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:context ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## Expression:request ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## Expression:const ##


---


## Expression:format ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| str           | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## Expression:control ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## Expression:get ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:ognl ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [expression](#expression.md) |  Yes         |                 |
| [context](#context.md) |  No          |                 |

## Expression:expression ##


---


## Expression:context ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Expression:lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| service       | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:provider ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:dictionary ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [entry](#entry.md) |  No          |                 |

## Expression:entry ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| key           | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Expression:eq ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:not ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:and ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:or ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:isempty ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Expression:isinrole ##
Checks context user role.

---


## Expression:code ##
Custom C# code expression.

---


## Expression:listrowcount ##
List rows count value.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## Operation:redirect ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| url           | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Operation:set ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Operation:databind ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| mode          |          | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [list](#controlInstanceExprGroup:list.md) |  No          |                 |


---


## Operation:operation ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Operation:jscallback ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [function](#function.md) |  No          |                 |
| [arg](#arg.md) |  No          |                 |

## Operation:function ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---


## Operation:arg ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [route](#Expression:route.md) |  No          |                 |
| [context](#Expression:context.md) |  No          |                 |
| [request](#Expression:request.md) |  No          |                 |
| [const](#Expression:const.md) |  No          |                 |
| [format](#Expression:format.md) |  No          |                 |
| [field](#Expression:field.md) |  No          |                 |
| [control](#Expression:control.md) |  No          |                 |
| [get](#Expression:get.md) |  No          |                 |
| [ognl](#Expression:ognl.md) |  No          |                 |
| [lookup](#Expression:lookup.md) |  No          |                 |
| [provider](#Expression:provider.md) |  No          |                 |
| [dictionary](#Expression:dictionary.md) |  No          |                 |
| [eq](#Expression:eq.md) |  No          |                 |
| [not](#Expression:not.md) |  No          |                 |
| [and](#Expression:and.md) |  No          |                 |
| [or](#Expression:or.md) |  No          |                 |
| [isempty](#Expression:isempty.md) |  No          |                 |
| [isinrole](#Expression:isinrole.md) |  No          |  Checks context user role. |
| [code](#Expression:code.md) |  No          |  Custom C# code expression. |
| [listrowcount](#Expression:listrowcount.md) |  No          |  List rows count value. |


---



---


## Operation:importdatacontext ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| from          |          | Yes      |                 |


---


## Operation:code ##
Custom C# code expression.

---


## Form Operation:save ##


---


## controlInstanceExprGroup:list ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## baseListElemsGroup:pager ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| allow         | xs:boolean | No       |                 |
| pagesize      | xs:integer | No       |                 |


---


## baseListElemsGroup:sort ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| field         | xs:string | Yes      |                 |
| direction     | sortDirectionType | Yes      |                 |


---


## baseListElemsGroup:filter ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#field.md) |  No          |                 |

## baseListElemsGroup:field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       | Context object member name for the field |
| caption       | xs:string | No       | Fixed caption   |
| format        | xs:string | No       | Format string for the field value (like '{0:d}') |
| lookup        | xs:string | No       | "Lookup" provider name |
| view          | xs:boolean | No       | Enables field for view (readonly) form |
| edit          | xs:boolean | No       | Enables field for edit form |
| add           | xs:boolean | No       | Enables field for add form |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [group](#group.md) |  No          |                 |
| [editor](#editor.md) |  No          |  Editor for the field |
| [renderer](#renderer.md) |  No          |  Custom renderer for the field |
| [visible](#visible.md) |  No          |                 |


---



---


## baseListElemsGroup:action ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | listActionNameType | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [redirect](#Operation:redirect.md) |  No          |                 |
| [set](#Operation:set.md) |  No          |                 |
| [databind](#Operation:databind.md) |  No          |                 |
| [operation](#Operation:operation.md) |  No          |                 |
| [jscallback](#Operation:jscallback.md) |  No          |                 |
| [importdatacontext](#Operation:importdatacontext.md) |  No          |                 |
| [code](#Operation:code.md) |  No          |  Custom C# code expression. |


---


## baseListElemsGroup:field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       | Context object member name for the field |
| caption       | xs:string | No       | Fixed caption   |
| format        | xs:string | No       | Format string for the field value (like '{0:d}') |
| lookup        | xs:string | No       | "Lookup" provider name |
| view          | xs:boolean | No       | Enables field for view (readonly) form |
| edit          | xs:boolean | No       | Enables field for edit form |
| add           | xs:boolean | No       | Enables field for add form |
| sort          | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [group](#group.md) |  No          |                 |
| [editor](#editor.md) |  No          |  Editor for the field |
| [renderer](#renderer.md) |  No          |  Custom renderer for the field |
| [visible](#visible.md) |  No          |                 |


---


## googlechartGroup:bar ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | Yes      |                 |
| height        | xs:integer | Yes      |                 |
| title         | xs:string | No       |                 |
| type          | chartBasicBarTypeEnum | No       |                 |
| orientation   | chartBasicBarOrientationEnum | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [data](#data.md) |  Yes         |                 |
| [dataset](#dataset.md) |  Yes         |                 |
| [label](#label.md) |  No          |                 |


---


## googlechartGroup:pie ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | Yes      |                 |
| height        | xs:integer | Yes      |                 |
| title         | xs:string | No       |                 |
| type          | chartBasicPieTypeEnum | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [data](#data.md) |  Yes         |                 |
| [dataset](#dataset.md) |  Yes         |                 |
| [label](#label.md) |  No          |                 |


---


## googlechartGroup:line ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | Yes      |                 |
| height        | xs:integer | Yes      |                 |
| title         | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [data](#data.md) |  Yes         |                 |
| [dataset](#dataset.md) |  Yes         |                 |
| [label](#label.md) |  No          |                 |


---


## mschartGroup:bar ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | Yes      |                 |
| height        | xs:integer | Yes      |                 |
| title         | xs:string | No       |                 |
| type          | chartBasicBarTypeEnum | No       |                 |
| orientation   | chartBasicBarOrientationEnum | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [data](#data.md) |  Yes         |                 |
| [dataset](#dataset.md) |  Yes         |                 |
| [label](#label.md) |  No          |                 |


---


## mschartGroup:pie ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | Yes      |                 |
| height        | xs:integer | Yes      |                 |
| title         | xs:string | No       |                 |
| type          | chartBasicPieTypeEnum | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [data](#data.md) |  Yes         |                 |
| [dataset](#dataset.md) |  Yes         |                 |
| [label](#label.md) |  No          |                 |


---


## mschartGroup:line ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| width         | xs:integer | Yes      |                 |
| height        | xs:integer | Yes      |                 |
| title         | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [data](#data.md) |  Yes         |                 |
| [dataset](#dataset.md) |  Yes         |                 |
| [label](#label.md) |  No          |                 |


---

