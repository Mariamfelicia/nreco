# Introduction #
This sample illustrates how NReco framework can be used with ASP.NET (3.5) for building flexible, maintainable and extensible applications. Application features:
  * logging with Log4Net
  * web routing [controlled by DSM](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/webRouting.xml) (based on ASP.NET 3.5 Web Routing)
  * data layer based on Open NIC.NET DALC with **permissions** and **triggers** [controlled by DSM](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/db.xml)
  * authentication/authorization (based on ASP.NET membership infrastructure)
  * localization (labels, dates/times) (TBD)
  * simple wiki ([Creole wiki parser](http://www.codeplex.com/CreoleParser)) with permissions
  * user interface generated from [Layout DSM](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/config/dsm/layouts.xml)
  * RDB-to-RDF mapping + embedded RDF browser
  * File Manager block (based on jquery and Open NIC.NET VFS)
    * full set of functions: delete, rename, create folder, move file by drag-and-drop
    * handy preview
    * files multiupload based on [uploadify](http://www.uploadify.com/)
![http://nreco.googlecode.com/svn/wiki/img/webAppNrecoAllMed.jpg](http://nreco.googlecode.com/svn/wiki/img/webAppNrecoAllMed.jpg)

# Quick Start #
  * [Source files (NReco repository)](http://code.google.com/p/nreco/source/browse/#svn%2Ftrunk%2Fexamples%2FNReco.Examples.WebApp)

# Configuring Web Sample #
Web app sample is usual VS project with custom post-build actions (don't worry about VS exclamation and choose 'Load Project Normally'). Just build it; new folder named 'web' will appear (at the same level where 'bin' and 'obj' are located). Configure this folder as web application root.
Last thing is SQLExpress database. Just create empty database and fix connection string ([@webConfigRules.xml](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.WebApp/%40webConfigRules.xml)).