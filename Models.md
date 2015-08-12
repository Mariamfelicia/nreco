

# Model Specification #
At this moment NReco works only with models in XML representation. This offers a lot of benefits because of XML-related standards maturity and their implementations availability. Custom domain-specific XML model can be defined in following steps:
  1. Define XML model. Usually it's enough to define terms and relations between them.
  1. Decide how to reflect your model using composition of existing .NET classes. Write additional classes in case when your model require something non-trivial or if composition of existing classes will be too complex.
  1. XSL transformation to IoC-container XML configuration (that uses classes from step #2). By itself this transformation will refer to model schema defined in step #1.
  1. Define XML Schema for model (optional). This schema may be used for models validation and enabling Visual Studio intellisense for your models.

# NReco Domain Specific Models #
NReco also includes a set of domain specific models that could be reused in different projects.

## DSM: NReco Composition ##
NReco introduces its own composition model (conceptually like BPEL but much simpler of course) for constructing composite components. This model is useful for describing context-dependent logic that have high probability of changes (for instance, _business logic_):
```
<invoke-operation method="set_Item">
	<target><linq>var["row"]</linq></r:target>
	<args>
		<const value="creation_date"/>
		<ognl>@DateTime@Now</r:ognl>
	</args>
</invoke-operation>
```
  * [Transformation to IoC-configuration (Winter.NET)](http://code.google.com/p/nreco/source/browse/trunk/shared/xsl/nreco.xsl)
  * [XML Schema](http://nreco.googlecode.com/svn/trunk/shared/schemas/NRecoCore.xsd)

## DSM: Web Forms Layout ##
```
<form name="Page" caption="Page"> 
	<datasource>
		<dalc id="pageDS" sourcename="pages"/>
	</datasource>
	<field name="title" caption="Title">
		<editor>
			<textbox/>
			<validators>
				<required/>
				<regex>^[a-zA-Z][a-zA-Z0-9_-]*$</regex>
			</validators>
		</editor>
	</field>
	<field name="content_type" caption="Type">
		<editor>
			<dropdownlist lookup="pageTypesLookup"/>
		</editor>
	</field>
</form>
```
  * [Real-life model sample](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/layouts.xml)
  * [XML Schema](http://nreco.googlecode.com/svn/trunk/shared/schemas/NRecoWebLayout.xsd)
  * [Transformation to ASP.NET Templates](http://nreco.googlecode.com/svn/trunk/shared/xsl/aspnet-ascx-models.xsl)

## DSM: URL Routing ##
.NET 3.5 contains special URL routing mechanism (System.Web.Routing). It can be configured by creating instances of Route class; but it's much more flexible to use DSM for describing routing table:
```
<route pattern="account.aspx/{id}" handler="sitePageRouteHandler">
	<token key="main">~/templates/AccountDetails.ascx</token>
	<value key="id" regex="[0-9]+"/>
</route>
```
  * [Transformation to IoC-configuration (Winter.NET)](http://nreco.googlecode.com/svn/trunk/shared/xsl/web-routing.xsl)

## DSM: Abstract Entity ##
```
<e:entity name="account_phones">
	<e:field name="id" type="autoincrement" pk="true"/>
	<e:field name="account_id" type="int"/>
	<e:field name="phone_number" type="string" maxlength="250" default=""/>
</e:entity>
```
  * [Real-life model sample](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/entities.xml)
  * [XML Schema](http://nreco.googlecode.com/svn/trunk/shared/schemas/NRecoEntity.xsd)

## DSM: Data Access (Open NIC.NET Dalc) ##
Open NIC.NET library includes powerful data access layer based on ADO.NET. But its proper configuration may be painful; following DSM helps do that in easy way and hides DALC configuration complexity:
```
<db-dalc name="db" xmlns="urn:schemas-nreco:nicnet:dalc:v1">
	<driver>
		<mssql><connection><string name="mainDb"/></connection></mssql>			
	</driver>
	<permissions/>
	<dataviews/>
	<triggers/>
</db-dalc>	
```
  * [Transformation to IoC-configuration (Winter.NET)](http://nreco.googlecode.com/svn/trunk/shared/xsl/nicnet-dalc.xsl)
  * [XML Schemas](http://nreco.googlecode.com/svn/trunk/shared/schemas/NRecoDalc.xsd)
  * [Model sample](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/db.xml)

## DSM: Relational-to-RDF Data Mapping ##
```
<dalc-rdf-store name="dbRdfStore" dalc="db" rdf-ns="http://www.nreco.qsh.eu/rdf/">
	<source name="pages" id="id">
		<field name="id" type="int"/>
		<field name="title" type="string"/>
		<field name="content_type" type="string"/>
	</source>
	<source name="page_visibility" id="page_id" id-type="int"
		rdf-ns="http://www.nreco.qsh.eu/rdf/pages">
		<field name="account_id" type="int" 
			fk-sourcename="accounts" rdf-ns="http://www.nreco.qsh.eu/rdf/pages_visible_to"/>
	</source>
</dalc-rdf-store>
```
  * [Transformation to IoC-configuration (Winter.NET)](http://nreco.googlecode.com/svn/trunk/shared/xsl/nreco-semweb.xsl)
  * [XML Schemas](http://nreco.googlecode.com/svn/trunk/shared/schemas/NRecoSemWeb.xsd)
  * [Model sample](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/dbRdf.xml)