
## Introduction ##
[Model transformation](http://en.wikipedia.org/wiki/Model_transformation) can be performed either on build or run time (compilation or interpretation). Build time transformations are less restrictive: nothing special is needed at run time (so huge amount of existing components could be reused without any adaptation) and usual build tools could be used for performing transformations. But in real life build-time transformation processor should meet specific functional and non-functional requirements:
  * ability to process a lot of transformation rules in reliable time
  * incremental transformations support
  * extensible and configurable
As a result custom tool usually is used as transformation rules processor (instead of using existing tasks of such tools like NANT or MSBuild). NReco contains special command-line ([NReco.Transform.Tool](http://code.google.com/p/nreco/source/browse/#svn/trunk/src/NReco.Transform.Tool)) that supports batch processing of transformation rules at build time. It may be called either manually (from command line) or as task in your favourite build tool (NANT or MSBuild).

## Transform Tool ##
Rules are usual project XML-files. Only convention is to start their names with '@' char (like _@addConnectionString.xml_). Each file may contain more than one rule (see examples), XInclude instructions may be used inside rule XML.
Main features:
  * extensible: you may wrote and add for processing your own rules
  * designed for performance: it's can be easily used for projects with more than 5000 files and can process hundreds of rules per second (TBD: stats)
  * supports incremental and 'watch' processing mode
  * integrated with MSBuild
By default it can process following rule types:
  * text file modification (insert/replace/remove by substring/regex)
  * xml file modification (insert/replace/remove nodes by XPath)
  * xml file xsl transformation
**Note**: rules are processed _always_ in exact order (rule files are sorted by their names; this is useful when one rule uses output of another).
Tool command line parameters:
| -b | path to folder | specify base path where rule files are located |
|:---|:---------------|:-----------------------------------------------|
| -i | true|false     | enable or disable incremental processing mode  |
| -w | true|false     | enable or disable watch mode (tool watches for changes in base folder and executes dependent rules on-fly) |

Example:
```
NReco.Transform.Tool.exe -w true -i true -b ./
```
See also [transform tool usage sample](http://code.google.com/p/nreco/source/browse/#svn/trunk/examples/NReco.Examples.TransformTool).

### Text Modification Rule ###
This rule used for changing existing text files (from 'Hello World' example, [@appConfig.xml](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Examples.Hello/%40appConfig.xml)):
```
<text-insert file="NReco.Examples.Hello.exe.config" start="&lt;configuration&gt;">
<![CDATA[ <!-- my comment --> ]]>
</text-insert>

<text-replace file="NReco.Examples.Hello.exe.config" regex="-- my comment">-- my replaced comment</text-replace>

<text-replace file="NReco.Examples.Hello.exe.config" start="&lt;!-- my" end="comment">
 <xi:include xmlns:xi="http://www.w3.org/2001/XInclude" parse="text"  href="config/variable_Name.txt" />
</text-replace>
```
Note that if 'file' attribute is optional; when it is not specified target file is calculated from rule file name (just name without '@' suffix char). This rule is useful in cases when the same text file used in many projects and with small modifications.

### XML Modification Rule ###
```
<xml-insert file="Web.config" xpath="/configuration/connectionStrings">
	<add name="mainDb" 
	connectionString="Data Source=.\SQLEXPRESS;AttachDbFilename=mainDb.mdf;User Instance=True"/>
</xml-insert>
<xml-remove file="Web.config" xpath="/configuration/configSections"/>
<xml-replace file="Web.config" xpath="/configuration/nreco.converters/converter[position()=1]">
</xml-replace> 
```

### XSL Transform Rule ###
XSL transformation rule can be used for generating files by XML models (from 'Hello World' example, [@modelA\_transform.xml](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Examples.Hello/config/%40modelA_transform.xml)):
```
<xsl-transform>
	<xml file="config/modelA.xml"/>
	<xsl file="config/xsl/choose.xsl"/>
	<result file="config/modelA_transformed.xml.config"/>
</xsl-transform>
```
Multiple files generation using one rule is also possible:
```
<xsl-transform>
	<xml file="config/layoutModels.xml"/>
	<xsl file="config/xsl/aspnet-ascx-models.xsl"/>
	<result>
		<file xpath="/files/file">
			<name xpath="@name"/>
			<content xpath="content"/>
		</file>
	</result>
</xsl-transform>
```
In this sample amount of files is determined by `/files/file` xpath expression; file name and content is also determined by xpath-expressions.
Important notes:
  * all pathes (including xsl:import inside XSL files) should be relative to transform root directory.
  * this transformer uses following considerations useful for generating non-XML content:
    * `@@lt;` means non-escaped `<`
    * `@@gt;` means non-escaped `>`
    * `@@` means non-escaped `&`
    * `@@@` means just `@`
    * `urn:remove` namespace declaration is just removed from output. This is useful for generating non-XML file like ASCX templates.
This rule is useful for generating XML configuration files, ASP.NET templates etc.