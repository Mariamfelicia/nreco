## Action ##
UI actions are usuall calls from UI layer. [WebManager](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/WebManager.cs) class defines ExecuteAction method that actually is entry point for such calls.

In most cases there is no need to call it manually because [ActionUserControl](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionUserControl.cs) and [ActionDataSource](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionDataSource.cs) already implement all handlers for typical usage scenarios.

## Action Dispatcher ##
Default action processing logic is represented by [ActionDispatcher](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionDispatcher.cs) class. It providers flexible mechanism for processing UI actions using handlers and filters:
  1. dispatcher calls registered handlers and builds initial operations list
  1. dispatcher calls registered filters over current operations list
  1. dispatcher invokes operations from the list
  1. optionally, if redirect was requested, dispatchers performs redirect

### Handlers ###
Handlers can return `IOperation<ActionContext>` for given ActionContext. Such way of obtaining operations for concrete ActionContext gives a lot of benefits: instead of trying to filter a huge amount of possible operations its possible to construct only matched operations in efficient way. Standard UI action handlers are:
  * [ControlTreeHandler](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionHandlers/ControlTreeHandler.cs) tries to find special public methods in UI action origin control and its children. This allows you to define some UI logic inside controls (by writing methods using naming convention like `Execute_MyActionName(ActionContext context)`; it's very handy to write such ad-hoc handlers without carrying up about transactions and other aspects b/c they are executed as usual action operations.
  * [DataSourceHandler](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionHandlers/DataSourceHandler.cs) should be used in conjunction with [ActionDataSource](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionDataSource.cs). It wraps another IDataSource instance and invokes its Select, Insert, Update and Delete as UI actions (and original Select/Insert/Update/Delete method are converted to action operations by DataSourceHandler). This allows you to work with data sources in standard manner.
  * [ServiceHandler](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionHandlers/ServiceHandler.cs) gives ability to invoke operations using external provider (for instance, IoC container).

### Filters ###
Filters can affect on operations list composed from handlers. Filters can add, remove or replace operations from list. Standard filters are:
  * [TransactionFilter](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web/ActionFilters/TransactionFilter.cs) wraps all operations with transactional control defined by external transaction.

## Action Execution Flow ##
Following diagram illustrate how WebManager processes UI actions
![http://nreco.googlecode.com/svn/wiki/img/WebActionDiagram.gif](http://nreco.googlecode.com/svn/wiki/img/WebActionDiagram.gif)

![http://nreco.googlecode.com/svn/wiki/img/ActionDispatcherDiagram.gif](http://nreco.googlecode.com/svn/wiki/img/ActionDispatcherDiagram.gif)