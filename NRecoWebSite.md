## Control Tree Traversal ##
With C# 3.0 and LINQ ASP.NET control tree traversal can be organized in easy and native way. NReco Web Site provides easy-to-use extensions to `Control` class for single-line enumerations through controls tree structure:
  * [GetParents&lt;T&gt;](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web.Site/ControlExtensions.cs) enumerates all parents (that match specified type) of the control (like XSLT parent axis).
  * [GetChildren&lt;T&gt;](http://code.google.com/p/nreco/source/browse/trunk/src/NReco.Web.Site/ControlExtensions.cs) enumerates all children (that match specified type) of the control (like XSLT child axis)
```
var containerUserControl = (from c in this.GetParents<UserControl>() select c).Single();
var q = from c in this.GetChildren<TextBox>() where c.Text.Trim()!=String.Empty select c.Text;
```