# Tools #
As any true open source project NReco supposes using only free and/or open source tools for development environment:
  * [Subversion version control](http://subversion.tigris.org/) for repository
  * [Visual Studio 2008 Express edition](http://www.microsoft.com/exPress/download/) as primary editor for source code / domain specific models (XML-editor)
  * [Notepad++](http://notepad-plus.sourceforge.net/) as supporting editor for files of any kind
  * [TopCoder UML Tool](http://www.topcoder.com/wiki/display/tc/TopCoder+UML+Tool) as UML-models editor (Poseidon for UML is no longer free)
  * [NUnit](http://www.nunit.org) for running unit tests.
  * see also [list of external libraries used by NReco](ExternalLibs.md)

# Configuration #
### How to build examples ###
First of all open tools/NReco.Tools.sln and build it.

### How to enable intellisense for XML ###
NReco contains a set of XML-based domain specific models specifications; VS 2008 suits ideally for creating and maintaining them. It's very handy to register their XML Schemas in VS 2008 to enable intellisense mechanizm:
  1. Find **catalog.xml** file in VS 2008 folder (usually it is located in "C:\Program Files\Microsoft Visual Studio 9.0\Xml\Schemas\" folder)
  1. Add following nodes (replace %NRECO\_REPO\_ROOT% with your local path to NReco repository)
```
  <Schema href="%NRECO_REPO_ROOT%\shared\schemas\NRecoDalc.xsd" 
          targetNamespace="urn:schemas-nreco:nicnet:dalc:v1" />
  <Schema href="%NRECO_REPO_ROOT%\shared\schemas\NRecoCore.xsd" 
          targetNamespace="urn:schemas-nreco:nreco:core:v1" />
  <Schema href="%NRECO_REPO_ROOT%\shared\schemas\NRecoWeb.xsd" 
          targetNamespace="urn:schemas-nreco:nreco:web:v1" />
  <Schema href="%NRECO_REPO_ROOT%\shared\schemas\NRecoWebLayout.xsd" 
          targetNamespace="urn:schemas-nreco:nreco:web:layout:v1" />
  <Schema href="%NRECO_REPO_ROOT%\shared\schemas\NRecoEntity.xsd" 
          targetNamespace="urn:schemas-nreco:nreco:entity:v1" />
  <Schema href="%NRECO_REPO_ROOT%\shared\schemas\NRecoLucene.xsd" 
          targetNamespace="urn:schemas-nreco:nreco:lucene:v1" />
```
  1. enjoy!

### How to register NUnit as external tool ###
  1. Open 'External Tools' dialogue
  1. in 'Command' textbox specify path to `nunit-gui.exe`
  1. in 'Arguments' specify: `$(BinDir)/$(TargetName)$(TargetExt)`
  1. This will run NUnit for selected project.