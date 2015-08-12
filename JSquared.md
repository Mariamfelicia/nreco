## Overview ##
This plugin allows you to organize advanced search user interface like in [Google Squared](http://www.google.com/squared/).

## Screenshot ##
![http://nreco.googlecode.com/svn/wiki/img/JSquaredDemoScreenshot.gif](http://nreco.googlecode.com/svn/wiki/img/JSquaredDemoScreenshot.gif)

## How to Use ##
```
<table id="squared" border="1">
</table>
<script language="javascript">
$('#squared').jSquared( { 
	onRowAdded  : function(textCell, text, dataCells) { 
		// you may perform your ajax calls here
		// just a stub
		dataCells.each( function() { $(this).html(text+' data'); } ); 
	},
	onColumnAdded  : function(textCell, text, dataCells) { 
		// you may perform your ajax calls here
		// just a stub
		dataCells.each( function() { $(this).html(text+' data'); } ); 
	},
} );
</script>
```

  * [Download v0.1 for JQuery 1.3.x (4kb js)](http://nreco.googlecode.com/svn/trunk/shared/blocks/JQuerySquared/js/jquery.jsquared-0.1.js)