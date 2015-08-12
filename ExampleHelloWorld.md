# Hello world Application #
Lets start from classic example 'Hello World'. How MDD can be used for such simple application? It's possible because our 'hello world' logic is little bit more complicated than usual: actually it's a simple 'chat bot' (not very intelligent as you'll see). Lets start it before investigating how it works (**[NReco.Examples.HelloWorld](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.Hello/)** from NReco repository). This is usual console application; just run it and you should see something like this:

![http://sites.google.com/site/fedorchenko/projects/nreco/nreco_hello_world_console.gif](http://sites.google.com/site/fedorchenko/projects/nreco/nreco_hello_world_console.gif)

Looks funny; lets look inside where most interesting things are happen. Any console program has it's static 'main' method - here it is:
```
static void Main(string[] args) {
    IComponentsConfig config = ConfigurationSettings.GetConfig("components") as IComponentsConfig;
    INamedServiceProvider srvPrv = new NReco.Winter.ServiceProvider(config);
    .....
}
```
In first two lines IoC container is created using configuration from application config (NReco uses free Winter4NET IoC container by default):
```
<configuration>
	<configSections>
		<section name="components" type="NReco.Winter.WinterConfigSectionHandler,NReco.Winter"/>
	</configSections>
	<components>
		<xsl-transform>
			<xml file="config/modelA.xml"/>
			<xsl file="config/xsl/choose.xsl"/>
		</xsl-transform>
	</components>
</configuration>
```
Most interesting thing here is < xsl-transform > tag. Winter4NET IoC container by itself expects only < component > tags inside its configuration section; but NReco pre-process its config and this tag is instruction for this macro processing. It says to NReco that it should read XML from "config/modelA.xml" file and transform it using "config/xsl/choose.xsl" definition and use result as IoC container configuration (**note**: NReco uses application directory as 'base path'). Specified XML-file contains our 'bot behaviour' domain-specific model:
```
<components>
	<choose name="A">
			<if msg="helo"><answer>helo human!</answer></if>
			<if msg="hello"><answer>hi!</answer></if>
			<if msg="who"><answer>some entity from deep space</answer></if>
			<if msg="name"><answer>My name is Unnamed 8-]</answer></if>
			<if msg="nreco"><answer>NReco makes me alive!</answer></if>
			<if msg="die"><exit/></if>
			<if msg="exit"><exit/></if>
			<default><answer>what-what? :-)</answer></default>
	</choose>       
</components>
```
It looks very native isn't it? Just imagine that even some complex behavior may be defined with one tag. In this sample meta-model definition wasn't defined formally but in real applications it's good practice to define it for documenting / verification purposes. Following transformation makes this model alive (fragment, [see also whole XSL](http://code.google.com/p/nreco/source/browse/trunk/examples/NReco.Examples.Hello/config/xsl/choose.xsl)):
```
<xsl:import href="nreco.xsl"/>
<xsl:template match='choose'>
	<xsl:variable name='model'>
		<chain name="{@name}">
			<prv-call result="state">
				<target><const-prv/></target>
			</prv-call>
			<xsl:apply-templates select="if" mode="choose"/>
			<xsl:if test="default">
				<prv-call if="#state==null or #state==''" result="state">
					<target>
						<xsl:apply-templates select="default/*" mode="choose-op"/>
					</target>
				</prv-call>
			</xsl:if>
		</chain>
	</xsl:variable>
	<xsl:apply-templates select='msxsl:node-set($model)/*'/>
</xsl:template>
```
You may note that template for < choose > generates another model. This generated model refers to standard NReco components ( [see XSL](http://code.google.com/p/nreco/source/browse/trunk/xsl/nreco.xsl)) like 'chain', 'const-prv', 'prv-call'. Actually transformation logic is very simple: chain operation contains sequence of conditional calls. Condition for each call checks operation parameter ('msg' key in context) and each call may set internal operation state ('state' key in context). Finally 'default' provider is called when operation state still wasn't defined. That's all ;) last thing is how this operation is used from main program:
```
IOperation<IDictionary<string,object>> a = srvPrv.GetService("A") as IOperation<IDictionary<string,object>>;
NameValueContext c = new NameValueContext();
while (true) {
	c["msg"] = Console.ReadLine();
	a.Execute(c);
	if (c.ContainsKey("state") && Convert.ToString( c["state"] )=="exit")
		return;
}
```
Code is very simple and easy to understand: one cycle that reads input from console and passes it to our operation genenerated from model; after call operation context is examined for 'exit' state.
--- TBD ---

## Conclusion ##
Bot logic in this sample is very easy; but lets assume that it can be rather complex in the future. Using model instead of imperative program for describing bot logic dramatically increases its clearness, extensibility and maintainability.