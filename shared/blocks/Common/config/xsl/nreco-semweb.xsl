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
				xmlns:xsl='http://www.w3.org/1999/XSL/Transform' 
				xmlns:msxsl="urn:schemas-microsoft-cosw:xslt" 
				xmlns:sw="urn:schemas-nreco:nreco:semweb:v1"
				exclude-result-prefixes="msxsl">


<xsl:template match="sw:store">
	<xsl:call-template name='component-definition'>
		<xsl:with-param name='name' select='@name'/>
		<xsl:with-param name='type'>NI.Winter.MethodInvokingFactory</xsl:with-param>
		<xsl:with-param name='injections'>
			<property name="TargetObject">
				<component type="NReco.SemWeb.StoreFactory" singleton="false"/> 
			</property>
			<property name="TargetMethod"><value>Create</value></property>
			<property name="TargetMethodArgs">
				<list>
					<entry>
						<list>
							<xsl:for-each select="node()">
								<entry>
									<xsl:apply-templates select="."/>
								</entry>
							</xsl:for-each>
						</list>
					</entry>
				</list>
			</property>
		</xsl:with-param>
	</xsl:call-template>	
</xsl:template>
				
<xsl:template match='sw:dalc-rdf-store'>
	<xsl:param name="dalcName">
		<xsl:choose>
			<xsl:when test="@dalc"><xsl:value-of select="@dalc"/></xsl:when>
			<xsl:otherwise><xsl:message terminate = "yes">DALC service name is required</xsl:message></xsl:otherwise>
		</xsl:choose>
	</xsl:param>	
	
	<xsl:call-template name='component-definition'>
		<xsl:with-param name='name' select='@name'/>
		<xsl:with-param name='type'>NReco.SemWeb.Dalc.DalcRdfStore,NReco.SemWeb</xsl:with-param>
		<xsl:with-param name="initMethod">Init</xsl:with-param>
		<xsl:with-param name='injections'>
			<property name="Dalc"><ref name="{$dalcName}"/></property>
			<property name="Sources">
				<list>
					<xsl:variable name="baseNs" select="@rdf-ns"/>
					<xsl:for-each select="sw:source">
						<entry>
							<xsl:apply-templates select="." mode="dalc-rdf-source-descriptor">
								<xsl:with-param name="baseNs"><xsl:value-of select="$baseNs"/></xsl:with-param>
							</xsl:apply-templates>
						</entry>
					</xsl:for-each>
				</list>
			</property>
		</xsl:with-param>
	</xsl:call-template>

</xsl:template>

<xsl:template match="sw:source" mode="dalc-rdf-source-descriptor">
	<xsl:param name="baseNs"/>
	<xsl:variable name="sourceNs">
		<xsl:choose>
			<xsl:when test="@rdf-ns"><xsl:value-of select="@rdf-ns"/></xsl:when>
			<xsl:otherwise><xsl:value-of select="$baseNs"/><xsl:value-of select="@name"/></xsl:otherwise>
		</xsl:choose>
	</xsl:variable>
	<component type="NReco.SemWeb.Dalc.DalcRdfStore+SourceDescriptor,NReco.SemWeb" singleton="false">
		<property name="SourceName"><value><xsl:value-of select="@name"/></value></property>
		<property name="Ns"><value><xsl:value-of select="$sourceNs"/></value></property>
		<property name="IdFieldName"><value><xsl:value-of select="@id"/></value></property>
		<xsl:if test="@id-type">
			<property name="IdFieldType">
				<type><xsl:call-template name="getDotNetTypeString"><xsl:with-param name="type" select="@id-type"/></xsl:call-template></type>
			</property>
		</xsl:if>		
		<property name="RdfType">
			<xsl:choose>
				<xsl:when test="@rdf-type"><value><xsl:value-of select="@rdf-type"/></value></xsl:when>
				<xsl:otherwise><value>http://www.w3.org/2000/01/rdf-schema#Class</value></xsl:otherwise>
			</xsl:choose>
		</property>
		<xsl:if test="@rdfs-label">
			<property name="RdfsLabel"><value><xsl:value-of select="@rdfs-label"/></value></property>
		</xsl:if>
		<xsl:if test="@rdfs-comment">
			<property name="RdfsComment"><value><xsl:value-of select="@rdfs-comment"/></value></property>
		</xsl:if>
		<property name="Fields">
			<list>
				<xsl:for-each select="sw:field">
					<entry>
						<xsl:apply-templates select="." mode="dalc-rdf-field-descriptor">
							<xsl:with-param name="sourceNs" select="$sourceNs"/>
						</xsl:apply-templates>
					</entry>
				</xsl:for-each>				
			</list>
		</property>
	</component>
</xsl:template>

<xsl:template match="sw:field" mode="dalc-rdf-field-descriptor">
	<xsl:param name="sourceNs"/>
	<component type="NReco.SemWeb.Dalc.DalcRdfStore+FieldDescriptor,NReco.SemWeb" singleton="false">
		<property name="FieldName"><value><xsl:value-of select="@name"/></value></property>
		<property name="Ns">
			<xsl:choose>
				<xsl:when test="@rdf-ns"><value><xsl:value-of select="@rdf-ns"/></value></xsl:when>
				<xsl:otherwise><value><xsl:value-of select="$sourceNs"/>_<xsl:value-of select="@name"/></value></xsl:otherwise>
			</xsl:choose>
		</property>
		<xsl:if test="@type">
			<property name="FieldType">
				<type><xsl:call-template name="getDotNetTypeString"><xsl:with-param name="type" select="@type"/></xsl:call-template></type>
			</property>
		</xsl:if>
		<property name="RdfType">
			<xsl:choose>
				<xsl:when test="@rdf-type"><value><xsl:value-of select="@rdf-type"/></value></xsl:when>
				<xsl:otherwise><value>http://www.w3.org/2000/01/rdf-schema#Property</value></xsl:otherwise>
			</xsl:choose>
		</property>
		<xsl:if test="@rdfs-label">
			<property name="RdfsLabel"><value><xsl:value-of select="@rdfs-label"/></value></property>
		</xsl:if>
		<xsl:if test="@rdfs-comment">
			<property name="RdfsComment"><value><xsl:value-of select="@rdfs-comment"/></value></property>
		</xsl:if>
		<xsl:if test="@fk-sourcename">
			<property name="FkSourceName">
				<value><xsl:value-of select="@fk-sourcename"/></value>
			</property>
		</xsl:if>
		<xsl:if test="@comparable">
			<property name="Comparable">
				<value><xsl:value-of select="@comparable"/></value>
			</property>
		</xsl:if>
	</component>
</xsl:template>

<xsl:template name="getDotNetTypeString">
	<xsl:param name="type"/>
	<xsl:choose>
		<xsl:when test="$type='string'">System.String,mscorlib</xsl:when>
		<xsl:when test="$type='int'">System.Int32,mscorlib</xsl:when>
		<xsl:when test="$type='decimal'">System.Decimal,mscorlib</xsl:when>
		<xsl:when test="$type='datetime'">System.DateTime,mscorlib</xsl:when>
		<xsl:when test="$type='double'">System.Double,mscorlib</xsl:when>
		<xsl:when test="$type='bool'">System.Boolean,mscorlib</xsl:when>
	</xsl:choose>	
</xsl:template>

</xsl:stylesheet>