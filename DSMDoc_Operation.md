# NReco Operation DSM Documentation #


## operations ##
Operations container.
| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [operation](#operation.md) |  No          |  Define NReco operation. |
| [provider](#provider.md) |  No          |  Define NReco provider. |


---


## operation ##
Define NReco operation.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [chain](#Operation:chain.md) |  No          |                 |
| [csharp](#Operation:csharp.md) |  No          |                 |
| [lazy](#Operation:lazy.md) |  No          |                 |
| [invoke](#Operation:invoke.md) |  No          |                 |
| [transaction](#Operation:transaction.md) |  No          |                 |
| [each](#Operation:each.md) |  No          |                 |
| [throw](#Operation:throw.md) |  No          |                 |
| [set](#Operation:set.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## provider ##
Define NReco provider.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## Chain:execute ##
Call operation instruction.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| target        | xs:string | No       |                 |
| if            | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [condition](#condition.md) |  No          |                 |
| [context](#context.md) |  No          |                 |
| [if](#if.md) |  No          |                 |
| [target](#target.md) |  No          |                 |

## Chain:target ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [chain](#Operation:chain.md) |  No          |                 |
| [csharp](#Operation:csharp.md) |  No          |                 |
| [lazy](#Operation:lazy.md) |  No          |                 |
| [invoke](#Operation:invoke.md) |  No          |                 |
| [transaction](#Operation:transaction.md) |  No          |                 |
| [each](#Operation:each.md) |  No          |                 |
| [throw](#Operation:throw.md) |  No          |                 |
| [set](#Operation:set.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---



---


## Chain:provide ##
Call provider instruction.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| target        | xs:string | No       |                 |
| if            | xs:string | No       |                 |
| result        | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [condition](#condition.md) |  No          |                 |
| [context](#context.md) |  No          |                 |
| [if](#if.md) |  No          |                 |
| [target](#target.md) |  No          |                 |
| [result](#result.md) |  No          |                 |

## Chain:target ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## Chain:result ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---



---


## Provider:const ##
Constant provider
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| value         | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|


---


## Provider:ognl ##
Evaluate OGNL expression

---


## Provider:linq ##
Evaluate Dynamic LINQ expression

---


## Provider:csharp ##
Execute C# code
| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [assembly](#assembly.md) |  No          |                 |
| [namespace](#namespace.md) |  No          |                 |
| [var](#var.md) |  No          |                 |
| [variable](#variable.md) |  No          |                 |


---


## Provider:invoke ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| target        | xs:string | No       |                 |
| method        | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [target](#target.md) |  No          |                 |
| [method](#method.md) |  No          |                 |
| [args](#args.md) |  No          |                 |


---


## Provider:context ##


---


## Provider:dictionary ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [entry](#entry.md) |  No          |                 |


---


## Provider:proxy ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| target        | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [context](#context.md) |  No          |                 |
| [target](#target.md) |  No          |                 |
| [result](#result.md) |  No          |                 |


---


## Provider:chain ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| context       | xs:string | No       |                 |
| result        | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [execute](#Chain:execute.md) |  No          |  Call operation instruction. |
| [provide](#Chain:provide.md) |  No          |  Call provider instruction. |


---


## Provider:listdictionary ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [key](#key.md) |  Yes         |                 |
| [value](#value.md) |  Yes         |                 |


---


## Provider:dalc ##
DALC Provider
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| from          | xs:string | Yes      |                 |
| result        | dalcProviderResultType | No       |                 |
| query         | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [query](#query.md) |  No          |                 |


---


## Provider:relex ##
Build query from relational expression
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| resolver      | xs:string | No       |                 |
| sort          | xs:string | No       |                 |


---


## Provider:relex-condition ##
Build query condition from relational expression
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| resolver      | xs:string | No       |                 |


---


## Provider:webroute ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## Provider:userkey ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| anonymous     |          | No       |                 |
| usecontext    | xs:boolean | No       |                 |


---


## Provider:union ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| skip-null     | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## Provider:map ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| from          | xs:string | No       |                 |
| select        | xs:string | No       |                 |
| ignorenull    | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [from](#from.md) |  No          |                 |
| [select](#select.md) |  No          |                 |

## Provider:from ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## Provider:select ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---



---


## Provider:lazy ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| provider      | xs:string | Yes      |                 |
| instance-provider | xs:string | No       |                 |


---


## ref ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## Operation:chain ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| context       | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [execute](#Chain:execute.md) |  No          |  Call operation instruction. |
| [provide](#Chain:provide.md) |  No          |  Call provider instruction. |


---


## Operation:csharp ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [assembly](#assembly.md) |  No          |                 |
| [namespace](#namespace.md) |  No          |                 |
| [var](#var.md) |  No          |                 |
| [variable](#variable.md) |  No          |                 |


---


## Operation:lazy ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| operation     | xs:string | Yes      |                 |
| instance-provider | xs:string | No       |                 |


---


## Operation:invoke ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| target        | xs:string | No       |                 |
| method        | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [target](#target.md) |  No          |                 |
| [method](#method.md) |  No          |                 |
| [args](#args.md) |  No          |                 |


---


## Operation:transaction ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| operation     | xs:string | Yes      |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [begin](#begin.md) |  No          |                 |
| [commit](#commit.md) |  No          |                 |
| [abort](#abort.md) |  No          |                 |


---


## Operation:each ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| from          | xs:string | No       |                 |
| do            | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [from](#from.md) |  No          |                 |
| [do](#do.md) |  No          |                 |


---


## Operation:throw ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| message       | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [message](#message.md) |  No          |                 |


---


## Operation:set ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| target        | xs:string | Yes      |                 |
| property      | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [const](#Provider:const.md) |  No          |  Constant provider |
| [ognl](#Provider:ognl.md) |  No          |  Evaluate OGNL expression |
| [linq](#Provider:linq.md) |  No          |  Evaluate Dynamic LINQ expression |
| [csharp](#Provider:csharp.md) |  No          |  Execute C# code |
| [invoke](#Provider:invoke.md) |  No          |                 |
| [context](#Provider:context.md) |  No          |                 |
| [dictionary](#Provider:dictionary.md) |  No          |                 |
| [proxy](#Provider:proxy.md) |  No          |                 |
| [chain](#Provider:chain.md) |  No          |                 |
| [listdictionary](#Provider:listdictionary.md) |  No          |                 |
| [dalc](#Provider:dalc.md) |  No          |  DALC Provider  |
| [relex](#Provider:relex.md) |  No          |  Build query from relational expression |
| [relex-condition](#Provider:relex-condition.md) |  No          |  Build query condition from relational expression |
| [webroute](#Provider:webroute.md) |  No          |                 |
| [userkey](#Provider:userkey.md) |  No          |                 |
| [union](#Provider:union.md) |  No          |                 |
| [map](#Provider:map.md) |  No          |                 |
| [lazy](#Provider:lazy.md) |  No          |                 |
| [ref](#ref.md) |  No          |                 |


---


## name-value ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [entry](#entry.md) |  No          |                 |


---


## lookup ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | No       |                 |
| text-filter   | xs:string | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [entry](#entry.md) |  No          |                 |


---

