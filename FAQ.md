

Cannot find answer for you question? Feel free to post comment here or send email to [project's owner](mailto:fedorchenko+nreco@gmail.com).

# General Questions #

### What is "Lego programming"? ###
This means possibility of constructing application as simple as constructing something using Lego blocks (even without deep technology knowledge).
More info about lego programming:
  * [Lego Programming](http://www.joelonsoftware.com/items/2006/12/05.html)
  * [Software Engineering's Missing Link: Replaceable Components](http://www.cbsdf.com/ps_blog/SE-MissingLink.htm)
NReco is technology that brings this dream to life. Really.

### Is NReco approach tested for real projects? ###
Yes. Its main concepts and ideas where implemented and used for building more than 100 projects since 2004 in [NewtonIdeas company](http://www.newtonideas.com). NReco is free and open-source implementation of this approach and includes only time-proven approaches.
For now more than 10 commercial projects are based on NReco.

### What is major benefits of using NReco? ###
  * NReco is truly _working_ technology for rapid MDD development
  * ultimate level flexibility, maintainability and conceptual simplicity
  * non-intrusive framework: may be used with legacy / existing projects
  * access to ready-to-use library (see [models](Models.md) of shaped domain-specific knowledge
  * more important: you can shape _your own specific_ knowledge with NReco in easy way
  * free, open-source, vendor-independent solution
    * development environment can be organized only with free tools (full version of  Visual Studio is not needed).

### Can I use NReco in commercial projects? ###
YES: current version of NReco is distributed under LGPL license that allows usage in proprietary/non-free projects.
Also it would be nice (but not obligatory) to place "powered by" logo (linked to nreco.googlecode.com):

![http://nreco.googlecode.com/svn-history/r775/wiki/img/NRecoPoweredBy.gif](http://nreco.googlecode.com/svn-history/r775/wiki/img/NRecoPoweredBy.gif)

# Technical Questions #
### Can I use NReco on shared hosting? ###
Yes. It needs at least medium trust. Some (optional) 3rd-party libraries may require full-trust (for example, MS Charts).

### Login box "remember me" functionality doesn't work ###
Don't forget to generate constant web-application keys and extend forms authentication timeout:
  * [How To: Configure MachineKey in ASP.NET 2.0](http://msdn.microsoft.com/en-us/library/ms998288.aspx)
  * [ASP.NET machineKey Generator](http://www.codeproject.com/KB/aspnet/machineKey.aspx)
  * [xplained: Forms Authentication in ASP.NET 2.0](http://msdn.microsoft.com/en-us/library/aa480476.aspx)