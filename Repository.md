## Folders ##
  * [src](http://code.google.com/p/nreco/source/browse/#svn/trunk/src) - reusable common libraries
  * [lib](http://code.google.com/p/nreco/source/browse/#svn/trunk/lib) - binary libraries
  * [shared](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared) - shared resources (templates, codebehinds, js-files etc)
    * [shared/blocks](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks) - common web-application pluggable building blocks
    * [shared/schemas](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/schemas) - XML Schemas for XML-based DSMs
  * [examples](http://code.google.com/p/nreco/source/browse/#svn/trunk/examples) - examples
  * [build](http://code.google.com/p/nreco/source/browse/#svn/trunk/build) - build scripts and custom build tools

## Blocks ##
Block is just a some set of shared resources (+integration rules)
  * [Common](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/Common) - basic set of model transformations and required resources (like editors)
  * [JQuery](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/JQuery) - core and jqueryui framework integration
  * [JQueryMarkItUp](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/JQueryMarkItUp) - JQuery-based MarkItUp editor integration
  * [JQueryWysiwyg](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/JQueryWysiwyg) - JQuery-based Wysiwyg editor integration
  * [JQueryMultiselect](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/JQueryMultiselect) - JQuery-based Multiselect editor integration
  * [JQueryFlexBox](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/JQueryFlexBox) - JQuery-based webcombo control integration
  * [JQueryVfs](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/JQueryVfs) - JQuery-based virtual filesystem (VFS) UI (file manager, upload controls etc)
  * [GoogleCharts](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/GoogleCharts) - Google Charts API integration
  * [MSCharts](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/MSCharts) - MS Charts integration
  * [Lucene](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/Lucene) - Lucene.NET integration
  * [RdfBrowser](http://code.google.com/p/nreco/source/browse/#svn/trunk/shared/blocks/RdfBrowser) - embedded RDF-browser integration (experimental)

## Web App Dependencies ##
![http://yuml.me/diagram/scale:55/usecase/(WebApp)%3E(%20...%20Block%20),(WebApp)%3E(Common%20Block),%20(WebApp)%3E(JQuery%20Block)?ext=.png](http://yuml.me/diagram/scale:55/usecase/(WebApp)%3E(%20...%20Block%20),(WebApp)%3E(Common%20Block),%20(WebApp)%3E(JQuery%20Block)?ext=.png)

## NReco Project File ##
Typical NReco web-project file should contain following "extensions".
**Common properties**:
```
<PropertyGroup>
    <NRecoRepoRootDirectory>$(ProjectDir)..\..</NRecoRepoRootDirectory> <!-- path to NReco repository root -->
    <NRecoTargetDirectory>$(ProjectDir)web</NRecoTargetDirectory> <!-- web root will be here -->
  </PropertyGroup>
```
**References to shared blocks**:
```
<ItemGroup>
    <BlockReference Include="Common">
	<Visible>false</Visible>
    </BlockReference>
    <BlockReference Include="JQuery">
	<Visible>false</Visible>
    </BlockReference>
</ItemGroup>
```
**Include NReco targets**:
```
  <Import Project="$(NRecoRepoRootDirectory)\build\NReco.Common.targets" />
  <Import Project="$(NRecoRepoRootDirectory)\build\NReco.Blocks.targets" />
```
**Register project befor/after targets**:
```
 <Target Name="BeforeBuild" DependsOnTargets="NRecoCopyBlocks"/> <!-- merge with blocks -->
 <Target Name="AfterBuild" DependsOnTargets="NRecoPrepareWebapp;NRecoApplyTransformRules"/> <!-- merge itself and apply rules -->
```