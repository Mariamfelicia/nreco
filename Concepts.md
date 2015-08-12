  * [Background](Background.md)


# Overview #
NReco introduces a number of techniques for organizing effective component-based and domain-specific model-driven development:
  * bottom-up domain-specific modeling process
  * lightweight XML-models transformation approach
  * components composition model
  * concept merging build approach (generalization tree)
  * semantic search engine
![http://nreco.googlecode.com/svn/wiki/img/NRecoDeveloperUcDiagram.gif](http://nreco.googlecode.com/svn/wiki/img/NRecoDeveloperUcDiagram.gif)

## Lightweight XML-models Transformations ##
Main idea is using [IoC](http://en.wikipedia.org/wiki/Inversion_of_Control)-container XML-configuration as final model in transformation chain. This approach offers a lot of benefits:
  * transformation rules could be expressed using powerful and well-known [XSLT](http://www.w3.org/TR/xslt)
  * requires only XML-to-XML transformations
    * easy to maintain (changes, versions, etc)
    * great opportunity for transformation rules reuse (recursive transformations)
  * efficient model interpretation (no code generation!)
  * supports [domain-specific multimodeling](http://en.wikipedia.org/wiki/Domain-specific_multimodeling) paradigm (when used as common _final_ model representation)
![http://nreco.googlecode.com/svn/wiki/img/XmlModelsTransformDiagram.gif](http://nreco.googlecode.com/svn/wiki/img/XmlModelsTransformDiagram.gif)

This approach to XML-models transformation based on assumption that model in form of domain-specific concept map (semantic network) ideally suits for describing domain knowledge (facts/rules etc). IoC-container XML configuration also can be treated as trivial kind of concept map (where objects are 'concepts' and arcs are relations of only one kind: 'depends from' ('uses')). Objects (concepts) actually are organized into [taxonomy](http://en.wikipedia.org/wiki/Taxonomy) (classes hierarchy); by their nature in this case objects could represent almost any basic concept. It's very easy to prove that any concept map may be represented as IoC container XML configuration; this means that custom domain-specific XML-schema may be used for describing XML-models and it always can be transformed to IoC container configuration (using XSL for instance).
Overall model complexity can be divided between 2 layers: transformation definitions and concept classes. Trivial transformation rules could be used when classes are very close to domain concepts; transformation rules may become very complex in conditions when limited amount of abstract classes used for representing domain concepts. Actually this is one more parameter available for software developers; it affects such aspects as performance, reusability, maintainability, interoperability etc.

## Bottom-up Domain-Specific Modeling ##
Term "bottom-up" refers to process of creating domain-specific model specification. It supposes that DSM specification should be designed in respect to existent DSM models and components: actually it represents pragmatic approach to model driven development.
![http://nreco.googlecode.com/svn/wiki/img/BottomupDsmActivityDiagram.gif](http://nreco.googlecode.com/svn/wiki/img/BottomupDsmActivityDiagram.gif)

# Links #
  * [Agile style modeling](http://www.agilemodeling.com/)
  * [Domain-specific multimodeling](http://en.wikipedia.org/wiki/Domain-specific_multimodeling)