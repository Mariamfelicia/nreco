<!--
NReco library (http://nreco.googlecode.com/)
Copyright 2008,2009 Vitaliy Fedorchenko
Distributed under the LGPL licence
 
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
-->	
<xsl:stylesheet version='1.0' 
				xmlns:e="urn:schemas-nreco:nreco:entity:v1"
				xmlns:l="urn:schemas-nreco:nreco:web:layout:v1"
				xmlns:xsl='http://www.w3.org/1999/XSL/Transform' 
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" 
				xmlns:Dalc="urn:remove"
				xmlns:NReco="urn:remove"
				xmlns:asp="urn:remove"
				exclude-result-prefixes="msxsl">

	<xsl:output method='xml' indent='yes' />

	<xsl:template match="l:vfsmanager" mode="aspnet-renderer">
		@@lt;%@ Register TagPrefix="Plugin" tagName="VfsManager" src="~/templates/renderers/VfsManager.ascx" %@@gt;
		<Plugin:VfsManager runat="server" xmlns:Plugin="urn:remove" FileSystemName="{@filesystem}"/> 
	</xsl:template>

	<xsl:template match="l:vfs-insert-image" mode="register-jwysiwyg-plugin-control">
		@@lt;%@ Register TagPrefix="Plugin" tagName="VfsSelector" src="~/templates/renderers/VfsSelector.ascx" %@@gt;
	</xsl:template>	

	<xsl:template match="l:vfs-insert-image" mode="register-editor-css">
		<link rel="stylesheet" type="text/css" href="css/jqueryFileTree/jqueryFileTree.css" />
	</xsl:template>
	
	<xsl:template match="l:vfs-insert-image" mode="editor-jwysiwyg-plugin">
		<xsl:param name="openJsFunction"/>
		<Plugin:VfsSelector runat="server" xmlns:Plugin="urn:remove" 
			OpenJsFunction="{$openJsFunction}"
			FileSystemName="{@filesystem}">
			<xsl:if test="@uploadpath">
				<xsl:attribute name="UploadFolderPath"><xsl:value-of select="@uploadpath"/></xsl:attribute>
			</xsl:if>
		</Plugin:VfsSelector>
	</xsl:template>
	
	
	<xsl:template match="l:field[l:editor/l:singlefile]" mode="register-editor-control">
		@@lt;%@ Register TagPrefix="Plugin" tagName="SingleFileEditor" src="~/templates/editors/SingleFileEditor.ascx" %@@gt;
	</xsl:template>
	
	<xsl:template match="l:field[l:editor/l:multifile]" mode="register-editor-control">
		@@lt;%@ Register TagPrefix="Plugin" tagName="VfsFileRelationEditor" src="~/templates/editors/VfsFileRelationEditor.ascx" %@@gt;
	</xsl:template>

	<xsl:template match="l:field[l:editor/l:singlefile]" mode="form-view-editor">
		<Plugin:SingleFileEditor runat="server" xmlns:Plugin="urn:remove"
			id="{@name}"
			FileSystemName="{l:editor/l:singlefile/@filesystem}"
			BasePath="{l:editor/l:singlefile/@basepath}"
		>
			<xsl:if test="l:editor/l:singlefile/l:image/@compressed='1' or l:editor/l:singlefile/l:image/@compressed='true'">
				<xsl:attribute name="EnsureCompressedImage">True</xsl:attribute>
			</xsl:if>
			<xsl:if test="l:editor/l:singlefile/l:image/@maxwidth">
				<xsl:attribute name="ImageMaxWidth"><xsl:value-of select="l:editor/l:singlefile/l:image/@maxwidth"/></xsl:attribute>
			</xsl:if>
			<xsl:if test="l:editor/l:singlefile/l:image/@maxheight">
				<xsl:attribute name="ImageMaxHeight"><xsl:value-of select="l:editor/l:singlefile/l:image/@maxheight"/></xsl:attribute>
			</xsl:if>	
			<xsl:if test="l:editor/l:singlefile/l:image/@format">
				<xsl:attribute name="ImageFormat"><xsl:value-of select="l:editor/l:singlefile/l:image/@format"/></xsl:attribute>
			</xsl:if>
			
			<xsl:if test="not(l:editor/l:singlefile/@bind) or l:editor/l:singlefile/@bind='true' or l:editor/l:singlefile/@bind='1'">
				<xsl:attribute name="Value">@@lt;%# Bind("<xsl:value-of select="@name"/>") %@@gt;</xsl:attribute>
			</xsl:if>
			
			<xsl:if test="l:editor/l:singlefile/@select">
				<xsl:attribute name="ShowSelect">
					<xsl:choose>
						<xsl:when test="l:editor/l:singlefile/@select='1' or l:editor/l:singlefile/@select='true'">True</xsl:when>
						<xsl:otherwise>False</xsl:otherwise>
					</xsl:choose>
				</xsl:attribute>
			</xsl:if>
			
		</Plugin:SingleFileEditor>
	</xsl:template>
	
	<xsl:template match="l:field[l:editor/l:multifile]" mode="form-view-editor">
		<Plugin:VfsFileRelationEditor runat="server" xmlns:Plugin="urn:remove"
			DalcServiceName="{$dalcName}"
			DsFactoryServiceName="{$datasetFactoryName}"
			FileSystemName="{l:editor/l:multifile/@filesystem}"
			BasePath="{l:editor/l:multifile/@basepath}"
			RelationSourceName="{l:editor/l:multifile/l:relation/@sourcename}"
			LFieldName="{l:editor/l:multifile/l:relation/@left}"
			RFieldName="{l:editor/l:multifile/l:relation/@right}"
		>
			<xsl:attribute name="EntityId">@@lt;%# Eval("<xsl:value-of select="l:editor/l:multifile/l:relation/@id"/>") %@@gt;</xsl:attribute>
			<xsl:attribute name="EntityIdField"><xsl:value-of select="l:editor/l:multifile/l:relation/@id"/></xsl:attribute>
			<xsl:if test="l:editor/l:multifile/l:relation/@editor">
				<xsl:attribute name="RelationEditor">@@lt;%$ service:<xsl:value-of select="l:editor/l:multifile/l:relation/@editor"/> %@@gt;</xsl:attribute>
			</xsl:if>
			<xsl:if test="l:editor/l:multifile/l:image/@thumb='true' or l:editor/l:multifile/l:image/@thumb='1'">
				<xsl:attribute name="ThumbImage">true</xsl:attribute>
			</xsl:if>
			<xsl:if test="l:editor/l:multifile/l:image/@thumb-width">
				<xsl:attribute name="ThumbImageWidth"><xsl:value-of select="l:editor/l:multifile/l:image/@thumb-width"/></xsl:attribute>
			</xsl:if>
			<xsl:if test="l:editor/l:multifile/@select">
				<xsl:attribute name="ShowSelect">
					<xsl:choose>
						<xsl:when test="l:editor/l:multifile/@select='0' or l:editor/l:multifile/@select='false'">False</xsl:when>
						<xsl:otherwise>True</xsl:otherwise>
					</xsl:choose>
				</xsl:attribute>
			</xsl:if>
			
			
		</Plugin:VfsFileRelationEditor>
	</xsl:template>
	
	<xsl:template match="l:field[l:editor/l:singlefile]" mode="aspnet-renderer">
		<Plugin:SingleFileEditor runat="server" xmlns:Plugin="urn:remove"
			id="{@name}"
			ReadOnly="true"
			FileSystemName="{l:editor/l:singlefile/@filesystem}"
			BasePath="{l:editor/l:singlefile/@basepath}"
			Value='@@lt;%# Eval("{@name}") %@@gt;'
		/>		
	</xsl:template>
	
	<xsl:template match="l:filepreview" mode="register-renderer-control">
		@@lt;%@ Register TagPrefix="Plugin" tagName="VfsFilePreview" src="~/templates/renderers/VfsFilePreview.ascx" %@@gt;
	</xsl:template>
	
	<xsl:template match="l:filepreview" mode="aspnet-renderer">
		<xsl:param name="context"/>
		<xsl:variable name="valExpr">
			<xsl:apply-templates select="l:*" mode="csharp-expr">
				<xsl:with-param name="context" select="$context"/>
			</xsl:apply-templates>
		</xsl:variable>	
		<Plugin:VfsFilePreview runat="server" xmlns:Plugin="urn:remove"
			FileSystemName="{@filesystem}"
			FileName='@@lt;%# {$valExpr} %@@gt;'/>
	</xsl:template>	
	
	

	
	
</xsl:stylesheet>