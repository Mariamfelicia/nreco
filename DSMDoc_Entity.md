# NReco Entity DSM Documentation #


## entity ##
Abstract entity (structure)
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| versions      | xs:boolean | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|

## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |
| type          | entityFieldValueType | Yes      |                 |
| nullable      | xs:boolean | No       |                 |
| pk            | xs:boolean | No       |                 |
| default       | xs:string | No       |                 |
| maxlength     | xs:int   | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [action](#action.md) |  No          |                 |


---


## data ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [entry](#entry.md) |  No          |                 |
| [index](#index.md) |  No          |                 |

## entry ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| add           |          | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#field.md) |  No          |                 |

## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---



---


## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## index ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#field.md) |  No          |                 |

## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---



---


## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---



---


## entry ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| add           |          | No       |                 |

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#field.md) |  No          |                 |

## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---



---


## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---


## index ##

| **Child** | **Required** | **Description** |
|:----------|:-------------|:----------------|
| [field](#field.md) |  No          |                 |

## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---



---


## field ##

| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---



---


## Field Action:set-datetimenow ##
Sets current datetime value.

---


## Field Action:set-username ##
Sets context user identity name.

---


## Field Action:set-userkey ##
Sets context user key.

---


## Field Action:set-guid ##
Set new GUID value.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| if            | entitySetGuidIfType | No       |                 |


---


## Field Action:set-provider ##
Sets provider result.
| **Attribute** | **Type** | Required | **Description** |
|:--------------|:---------|:---------|:----------------|
| name          | xs:string | Yes      |                 |


---

