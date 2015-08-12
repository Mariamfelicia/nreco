## Core ##
NReco core ([NReco assembly](http://code.google.com/p/nreco/source/browse/#svn/trunk/src/NReco)) defines minimal infrastructure required for all components:
  * common interfaces
  * run-time type conversion module
  * vendor-independent logging module
### Type Conversion ###
This subsystem provides flexible and extensible mechanism for run-time types conversion (just as System.Convert for simple types). It simplifies components interaction (especially when their configuration was automatically generated from models) by encapsulating all work related to types casting and conversion. ConvertManager class provides simple access to this mechanism:
```
var h = new Hashtable { {"a", "b"} };
var dict = ConvertManager.ChangeType<IDictionary<string,string>>( h );
```
Standard converters are:
  * between ICollection and ICollection<> interfaces
  * between IList and IList<> interfaces
  * between IDictionary and IDictionary<> interfaces
  * between different IProvider<,> interfaces
  * between different IOperation<,> interfaces
Additionally it's possible to add custom converters using application config:
```
<configSections>
	<section name="nreco.converting" type="NReco.Converting.ConvertManagerCfgHandler,NReco"/>
</configSections>
<nreco.converting>
	<converter>NReco.Winter.Converting.NiOperationConverter,NReco.Winter</converter>
</nreco.converting>
```
Don't forget to initialize you configuration:
`ConvertManager.Configure();`

### Logging ###
Because of a lot of abstraction layers models debugging may become an nontrivial task. .NET platform has at least 2 approaches to do that:
  * use time-proven but external approach like [log4net](http://logging.apache.org/log4net/index.html). It's great but... _external_.
  * use embedded into framework tracing mechanism. As a lot of things inside framework it often charged with lack of flexibility and extensibility.
That's why all NReco classes uses internal extra-lightweight logging mechanism. By internal organization it is similar to log4net; interfaces are extremely lightweight. In any case it didn't reinvent a wheel and redirects all log event to either log4net or internal .NET logging. But right now you have a choice. Here is typical usage scenario:
```
class MyClass {
	static ILog log = LogManager.GetLogger(typeof(MyClass));
	protected void MyMethod() {
		int myVar = 0;
		log.Write(
			LogEvent.Error,
			new{Action="some event description",myVar=myVar} );
	}
}
```

## Component Composition ##
[NReco.Composition](http://code.google.com/p/nreco/source/browse/#svn/trunk/src/NReco.Composition) introduces POCO-components composition model. Central interfaces are [IProvider<,>](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/IProvider.cs) and [IOperation<>](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/IOperation.cs). They represents 2 main concepts from NReco upper-level ontology:
  * provider is an _object_ that performs transportation/convertation/transformation function over some _object_. By its semantics it is similar to [math function](http://en.wikipedia.org/wiki/Function_(mathematics)) in some sense.
  * operation is an _object_ that represents some action in the system.

### Providers ###
Standard providers are:
  * [LazyProvider](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/LazyProvider.cs) used for organizing lazy providers
  * [ConstProvider](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/ConstProvider.cs) used for providing constant value
  * [ContextProvider](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/ContextProvider.cs) used when context should be returned as result
  * [ProviderCall](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/ProviderCall.cs) used for calling another provider with optional context/result filtering
  * [DictionaryProvider](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/DictionaryProvider.cs) used for composing dictionary from context values
Additional providers are:
  * [EvalDynamicCode](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.LinqDynamic/EvalDynamicCode.cs) used for evaluating dynamic expression
  * [EvalOgnlCode](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.OGNL/EvalOgnlCode.cs) used for evaluating OGNL expression

### Operations ###
Standard operations are:
  * [Chain](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/Chain.cs) used for organizing sequential calls to another providers and operations
  * [InvokeMethod](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/InvokeMethod.cs) / [DynamicInvokeMethod](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/DynamicInvokeMethod.cs) used for invoking another object's method as operation
  * [EvalCsCode](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/EvalCsCode.cs) used for C#-code based operations that compiled on-fly (note: ensure that your application security policy allows that)
  * [Transaction](http://code.google.com/p/nreco/source/browse/trunk/src/NReco/Composition/Transaction.cs) used for wrapping another operation with transactional logic