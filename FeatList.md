&lt;wiki:gadget url="http://www.ohloh.net/p/21906/widgets/project\_languages.xml" width="350px" height="190px" /&gt;

# Features List #
## Internal infrastructure ##
**Logging infrastructure that can be used either with .NET logging or log4net** Automatic complex types (like collections and dictionaries) convertors and extensible converting infrastructure

## UI: WebForms-based XML model ##
  * Views routing (based on ASP.NET Routing)
  * ASP.NET Membership and Profile (implementations that use NReco DALC for accessing and storing data)
  * Editors
    * Textbox (based on ASP.NET Textbox control) + extensions: filtertextbox, numbertextbox, passwordtextbox
    * checkbox
    * dropdownlist (based on ASP.NET DropDownList); supports dependent dropdowns and dependent from dropdown visibility
    * radiobuttonlist (based on ASP.NET RadioButtonList)
    * checkboxlist (based on ASP.NET CheckBoxList)
    * checkboxtree (based on JQuery CheckboxTree plugin) for hierarchical selections
    * multiselect (based on JQuery multiselect plugin) for editing data relations (supports selection order)
    * checklist (based on JQuery checklist plugin) for selecting multiple values (looks like dropdown + checkboxlist)
    * datepicker (based on JQueryUI datepicker)
    * timepicker
    * markitup (based on JQuery Markitup editor) for editing HTML markup
    * jwysiwyg (based on JQuery jWysiwyg plugin) for editing HTML markup
    * flexbox (based on JQuery flexbox plugin) for selecting values from huge datasets using combobox; supports multiple values selection
    * multifile (based on JQuery fileupload plugin) for uploading and attaching files; supports HTML5 features
    * singlefile for uploading one file; supports ajax-based upload
    * mcdropdown (based on JQuery plugin mcDropDown) for selecting from hierarchy
    * jcolorpicker - just color picker
    * custom usercontrol-based editor (extension point)
  * Form (based on FormView)
    * adding, editing and removing individual records
    * multicolumn layout support
    * fields visibility conditions
  * List (based on ListView)
    * adding, editing, and removing rows
    * pagination and custom DataPager templates
    * multiple rows selection and custom mass operations
    * custom data filters (see Editors)
    * columns visibility conditions
    * custom pre-post actions
  * Action Form (based on NReco-specific component; suitable for generating UI form without datasource)
  * Dialogs (based on JQuery UI dialog); content of dialog is rendered in the iframe



  1. Transformation services
    * XSL transform rule (supports XInclude, multiple files generation by one rule)
    * Modify text file rule (insert/replace/remove)
    * Modify XML file rule (insert/replace/remove)
    * Console tool that performs build-time rule processing (optimized with huge amount of rules/models)
      * supports 'watch' mode (watches for filesystem changes and performs incremental transformations on-fly)
  1. [OGNL library](http://www.opensymphony.com/ognl/) integration
    * OGNL expression evaluation (OGNL expression in context)
    * OGNL code execution provider (fixed OGNL code)
  1. DynamicQuery
    * dynamic linq expression evaluation
    * dynamic linq expression code execution provider
  1. [Open NIC.NET](http://nicnet.googlecode.com/) library integration
    * converters for compatible interfaces (NReco from/to NIC.NET)
    * Winter (IoC container)
      * runtime type conversions mechanism for IoC container (allows 'non-strict' injections)
      * XInclude support in IoC configuration
      * XSL transform rule processing available directly from IoC configuration
    * DALC DSM that covers DALC configuration complexity and supports permissions, dataviews, triggers
    * VFS UI/editors/renderers
  1. ASP.NET integration (common infrastructure for web applications)
    * labels resolving mechanism
    * Services injection from IoC container
    * Unified UI actions processing mechanism
    * System.Web.Routing DSM and infrastructure support
    * MembershipProvider + RoleProvider implementation based on NIC.NET DALC
    * ProfileProvider implementation based on DALC
    * UI
      * [JQuery](http://jquery.com/)-based UI
      * Various jQuery-plugins (FlexBox, Multiselect, JWysiwyg, JGrow, etc)
      * Layout model transformation: user-control templates (ASCX) generation (lists, forms, etc)
      * [Google Charts](http://code.google.com/apis/chart/)
      * [MS Charts.NET](http://www.microsoft.com/downloads/details.aspx?FamilyId=130F7986-BF49-4FE5-9CA8-910AE6EA442C&displaylang=en#Overview)
  1. [Lucene.NET](http://incubator.apache.org/lucene.net/) integration
    * data indexing triggers
    * lucene API facade
  1. [SemWeb](http://razor.occams.info/code/semweb/) integration (semantic metadata)
    * export system metadata to RDF
    * RDBS-to-RDF readonly bridge (relational data source as RDF source)
    * RDF Browser WebApp (TBD)