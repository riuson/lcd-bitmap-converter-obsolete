<xsl:stylesheet version = '1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
	<xsl:output method="text" omit-xml-declaration="yes"/>

	<xsl:template match="/data">
		<xsl:text>//data type: </xsl:text>
		<xsl:value-of select="@type"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>//filename:  </xsl:text>
		<xsl:value-of select="@filename"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>//name:      </xsl:text>
		<xsl:value-of select="@name"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:apply-templates/>
	</xsl:template>

	<xsl:template match="bitmap">
		<xsl:text>const unsigned char [</xsl:text>
		<xsl:value-of select="count(/data/bitmap/line/column)"/>
		<xsl:text>]</xsl:text>
		<xsl:text> image_</xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>{</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:apply-templates/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>};</xsl:text>
	</xsl:template>

	<xsl:template match="preview">
		<xsl:text>//preview data:</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:apply-templates/>
	</xsl:template>

	<xsl:template match="preview/line">
		<xsl:text>//    </xsl:text>
		<xsl:value-of select="."/>
		<xsl:text>&#xa;</xsl:text>
	</xsl:template>

	<xsl:template match="bitmap/line">
		<xsl:for-each select="column">
			<xsl:call-template name="column"/>
		</xsl:for-each>
		<xsl:text>&#xa;</xsl:text>
	</xsl:template>

	<xsl:template name="column">
		<xsl:text>b_</xsl:text>
		<xsl:value-of select="."/>
		<xsl:if test="(1 + count(parent::*/preceding-sibling::*)) != count(parent::*/parent::*/child::*)">
			<xsl:text>,</xsl:text>
		</xsl:if>
		<xsl:if test="(1 + count(parent::*/preceding-sibling::*)) = count(parent::*/parent::*/child::*)">
			<xsl:if test="position() != last()">
				<xsl:text>,</xsl:text>
			</xsl:if>
		</xsl:if>
		<xsl:text>  </xsl:text>
	</xsl:template>

	<xsl:template match="definitions">
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>// binary to hex definitions</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:apply-templates/>
		<xsl:text>&#xa;</xsl:text>
	</xsl:template>

	<xsl:template match="definitions/value">
		<xsl:text>#define b_</xsl:text>
		<xsl:value-of select="@text"/>
		<xsl:text> 0x</xsl:text>
		<xsl:value-of select="@byte"/>
		<xsl:text>&#xa;</xsl:text>
	</xsl:template>
</xsl:stylesheet>
