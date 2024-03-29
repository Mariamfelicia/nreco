﻿<%@ Control Language="c#" AutoEventWireup="false" CodeFile="FlexBoxRelationEditor.ascx.cs" Inherits="FlexBoxRelationEditor" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Dalc" Namespace="NI.Data.Dalc.Web" assembly="NI.Data.Dalc" %>

<span id="<%=ClientID %>" class="flexBoxRelationEditor">
	<input type="hidden" runat="server" class="selectedValues" id="selectedValues" value='<%# GetSelectedItemsJson() %>'/>
	<div id="<%=ClientID %>List" class="flexBoxRelationEditorSelectedItems"></div>
	<div class="flexBoxRelationEditorSelector">
		<div id="<%=ClientID %>flexBox" ></div>
	</div>
	<div id="<%=ClientID %>flexBoxMaxNumberMessage" style="display:none;" class="flexboxMaxNumberMessage"><%= WebManager.GetLabel(MaxRowsReachedMessage) %></div>
</span>

<script language="javascript">
window.<%=ClientID %>FlexBoxRelationEditor = {
	triggerChange: function(previousValues, currentValues) {
			jQuery("#<%=ClientID %>").trigger(
			"flexboxSelectedItemChanged", [
				previousValues, 
				currentValues
			]);
		},
		
	selectedItems: function(items){
        var selectedListElem = jQuery('#<%=selectedValues.ClientID %>');
        if (items==undefined)           
            return eval(selectedListElem.val());
        else
            selectedListElem.val(JSON.stringify(items));
    },

	addItem: function(itemId, itemValue) {
		var addFlag = true;
		var selectedListElem = jQuery('#<%=selectedValues.ClientID %>');
		var selectedList = eval( selectedListElem.val() );
		var prevSelectedList = selectedList;
		var newSelectedList = selectedList;
		for (var idx=0; idx<selectedList.length; idx++)
			if (selectedList[idx]['<%=ValueFieldName %>']==itemId)
				addFlag = false;

		if (addFlag){
			newSelectedList.push({'<%=ValueFieldName %>':itemId,'<%=TextFieldName %>':itemValue});
			selectedListElem.val( JSON.stringify(newSelectedList) );
			<%=ClientID %>FlexBoxRelationEditor.maxRowsHandler(newSelectedList, function() {<%=ClientID %>FlexBoxRelationEditor.showMaxRowsValidationMessage();}, function() {<%=ClientID %>FlexBoxRelationEditor.hideMaxRowsValidationMessage();});
			<%=ClientID %>FlexBoxRelationEditor.triggerChange(prevSelectedList,newSelectedList);
			relEditor<%=ClientID %>RenderList();
		}
	},
	
	removeItem: function(itemId) {
		var selectedListElem = jQuery('#<%=selectedValues.ClientID %>');
		var selectedList = eval( selectedListElem.val() );
		var prevSelectedList = selectedList;
		var newSelectedList = [];
		for (var idx=0; idx<selectedList.length; idx++)
			if (selectedList[idx]['<%=ValueFieldName %>']!=itemId)
				newSelectedList.push(selectedList[idx]);
		selectedListElem.val( JSON.stringify(newSelectedList) );
		<%=ClientID %>FlexBoxRelationEditor.maxRowsHandler(newSelectedList, function() {<%=ClientID %>FlexBoxRelationEditor.showMaxRowsValidationMessage();}, function() {<%=ClientID %>FlexBoxRelationEditor.hideMaxRowsValidationMessage();});
		<%=ClientID %>FlexBoxRelationEditor.triggerChange(prevSelectedList,newSelectedList);
		relEditor<%=ClientID %>RenderList();
	},
	
	checkMaxRows : function(selectedValuesLength) {
		var isValid = true;
		<% if (CheckMaxRows) { %>
			if (selectedValuesLength < <%=MaxRows.Value%> - 1) { isValid = false; } 
			else { isValid = true; }
		<% } %>
		return isValid;
	},
	maxRowsHandler: function(selectedValuesLength, maxRowsReachedAction, maxRowsNotReachedAction) {
			<% if (CheckMaxRows) { %>
				if (selectedValuesLength > <%=MaxRows.Value%> - 1) { maxRowsReachedAction() } 
				else { maxRowsNotReachedAction(); }
			<% } %>
		},
	showMaxRowsValidationMessage: function() {
			jQuery('#<%=ClientID %>flexBox').hide();
			jQuery('div#<%=ClientID %>flexBoxMaxNumberMessage').show();
		},
	hideMaxRowsValidationMessage: function() {
			jQuery('div#<%=ClientID %>flexBoxMaxNumberMessage').hide();
			jQuery('#<%=ClientID %>flexBox').show();
		},
	reset : function() {
		var selectedListElem = jQuery('#<%=selectedValues.ClientID %>');
		var selectedList = eval( selectedListElem.val() );
		jQuery.each(selectedList, function(idx,elem) {
			relEditor<%=ClientID %>Remove(elem['<%=ValueFieldName %>']);
		});
	}
};

window.relEditor<%=ClientID %>Remove = function(elemId) {
	window.<%=ClientID %>FlexBoxRelationEditor.removeItem(elemId);
};

window.relEditor<%=ClientID %>RenderList = function() {
	var cont = jQuery('#<%=ClientID %>List');
	cont.html('');
	var selectedList = eval( jQuery('#<%=selectedValues.ClientID %>').val() );
	for (var elemIdx=0; elemIdx<selectedList.length; elemIdx++)
		cont.append('<div class="selectedElement">'+selectedList[elemIdx]['<%=TextFieldName %>']+'&nbsp;<a class="remove" href="javascript:void(0)" onclick="relEditor<%=ClientID %>Remove(\''+selectedList[elemIdx]['<%=ValueFieldName %>']+'\')">[x]</a></div>');
};

jQuery(function(){
	jQuery('#<%=ClientID %>').data(
		'setFlexboxValue', 
		function(values) {
			if (!values) {
				values = [];
			}
			var selector = 'span#<%=ClientID %>';
			var prevValues = JSON.parse($(selector + " input.selectedValues").val());
			
			$(selector + " input.selectedValues").val(JSON.stringify(values));
			window.relEditor<%=ClientID %>RenderList();
			window.<%=ClientID %>FlexBoxRelationEditor.triggerChange(prevValues, values);
		}
	);

	jQuery('#<%=ClientID %>flexBox').flexbox(
		'FlexBoxAjaxHandler.axd?validate=<%=FlexBoxAjaxHandler.GenerateValidationCode(DalcServiceName,Relex) %>&dalc=<%=DalcServiceName %>&relex=<%# HttpUtility.UrlEncode(Relex).Replace("'","\\'") %>&label=<%=TextFieldName %>',
		{ 
			method : 'POST', 
			maxCacheBytes:0,
			initialValue : '',
			displayValue : '<%=TextFieldName %>',
			hiddenValue : '<%=ValueFieldName %>',
			resultTemplate : '{<%=TextFieldName %>}',
			showArrow : true,
			queryDelay : 500,
			<% if (Width>0)  { %>width: <%=Width %>,<% } %>
			maxVisibleRows : 0,
			noResultsText : '<%=WebManager.GetLabel("No matching results",this).Replace("'","\\'") %>',
			paging : {
				style : 'links',
				pageSize : <%=RecordsPerPage%>,
				summaryTemplate : '{start}-{end} of {total}'
			},
			onSelect : function() {
				var idVal = this.getAttribute('hiddenValue');
				var textVal = this.value;
				var selectedListElem = jQuery('#<%=selectedValues.ClientID %>');
				var selectedList = eval( selectedListElem.val() );
				var prevSelectedList = selectedList;
				var isUnique = true;
				jQuery.each( prevSelectedList, function() {
					if (this.<%=ValueFieldName %>==idVal) isUnique = false;
				});				
				if (isUnique && <%=ClientID %>FlexBoxRelationEditor.checkMaxRows(selectedList.length+1)) {
					selectedList.push( { '<%=ValueFieldName %>' : idVal, '<%=TextFieldName %>' : textVal } );
				}
				<%=ClientID %>FlexBoxRelationEditor.maxRowsHandler(selectedList.length, function() {<%=ClientID %>FlexBoxRelationEditor.showMaxRowsValidationMessage();}, function() {<%=ClientID %>FlexBoxRelationEditor.hideMaxRowsValidationMessage();})
				selectedListElem.val( JSON.stringify(selectedList) );
				<%=ClientID %>FlexBoxRelationEditor.triggerChange(prevSelectedList,selectedList);
				relEditor<%=ClientID %>RenderList();
				this.value = ''; /*clear after selection*/
			},
			<% if (AddEnabled) { %>
			addNewEntry : {
				onAdd : function(newVal, addCallback) {
					<% if (AddJsFunction==null) { %>
					$.ajax({type: "POST", async: true,
						url: <%=JsHelper.ToJsonString( ComposeAddUrl() ) %>,
						data : { value : newVal },
						success : function(res) {
							var data = JSON.parse(res);
							addCallback(data['<%=ValueFieldName %>'], data['<%=TextFieldName %>']);
						}
					});
					<% } else { %>
					<%=AddJsFunction %>(newVal, addCallback);
					<% } %>
					return true;
				},
				cssClass : "addNewEntry",				
				entryTextTemplate : <%=JsHelper.ToJsonString(this.GetLabel("Create \"{q}\"...") ) %>
			},
			<% } %>			
			onComposeParams : function(params) {
				var p = <%#DataContextJs ?? "{}" %>;
				p = jQuery.extend( p, <%# JsHelper.ToJsonString(DataContext) %>);
				var legacyContext = p.context;
				delete p.context;
				var newContext = p;
				var result = {"context_json" : JSON.stringify(newContext)};
				if (legacyContext) {
					result["context"] = legacyContext;
				}
				return result;
			}
		}
	);

	relEditor<%=ClientID %>RenderList();
	
	<% if (CheckMaxRows) { %>
		<%=ClientID %>FlexBoxRelationEditor.maxRowsHandler(
						eval( jQuery('#<%=selectedValues.ClientID %>').val() ).length, 
						function() {<%=ClientID %>FlexBoxRelationEditor.showMaxRowsValidationMessage();}, 
						function() {<%=ClientID %>FlexBoxRelationEditor.hideMaxRowsValidationMessage();}
					);
	<% } %>
});
</script>