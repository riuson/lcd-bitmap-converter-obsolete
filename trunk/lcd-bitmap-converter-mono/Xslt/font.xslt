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
		<xsl:text>//family:    </xsl:text>
		<xsl:value-of select="family"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>//size:      </xsl:text>
		<xsl:value-of select="size"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>//style:      </xsl:text>
		<xsl:value-of select="style"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>//included characters:</xsl:text>
		<xsl:value-of select="string"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>// typedef struct {&#xa;</xsl:text>
		<xsl:text>//     const long int code;&#xa;</xsl:text>
		<xsl:text>//     const tImage *image;&#xa;</xsl:text>
		<xsl:text>//     } tChar;&#xa;</xsl:text>
		<xsl:text>// typedef struct {&#xa;</xsl:text>
		<xsl:text>//     const int length;&#xa;</xsl:text>
		<xsl:text>//     const tChar *chars;&#xa;</xsl:text>
		<xsl:text>//     } tFont;&#xa;</xsl:text>
		<xsl:apply-templates select="chars"  mode="bitmaps"/>
		<xsl:apply-templates select="chars" mode="chartable"/>
		<xsl:call-template name="fontdef"/>
	</xsl:template>

	<xsl:template match="bitmap">
		<xsl:text>const unsigned char</xsl:text>
		<xsl:text> image_data_</xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>_</xsl:text>
		<xsl:apply-templates select="parent::*/encoding[@codepage=12000]"/>
		<xsl:text>[</xsl:text>
		<xsl:value-of select="count(line/column)"/>
		<xsl:text>] = </xsl:text>
		<xsl:text>{</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:apply-templates/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>};</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>const tImage </xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>_</xsl:text>
		<xsl:apply-templates select="parent::*/encoding[@codepage=12000]"/>
		<xsl:text> = { &amp;image_data_</xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>_</xsl:text>
		<xsl:apply-templates select="parent::*/encoding[@codepage=12000]"/>
		<xsl:text>[0], </xsl:text>
		<xsl:value-of select="@width"/>
		<xsl:text>, </xsl:text>
		<xsl:value-of select="@height"/>
		<xsl:text>};&#xa;</xsl:text>
	</xsl:template>

	<xsl:template match="preview">
		<xsl:text>//preview data:</xsl:text>
		<xsl:text>&#xa;</xsl:text>
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
		<!--
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>// binary to hex definitions</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:apply-templates/>
		<xsl:text>&#xa;</xsl:text>
		-->
	</xsl:template>

	<xsl:template match="definitions/value">
		<xsl:text>#define b_</xsl:text>
		<xsl:value-of select="@text"/>
		<xsl:text> 0x</xsl:text>
		<xsl:value-of select="@byte"/>
		<xsl:text>&#xa;</xsl:text>
	</xsl:template>

	<xsl:template match="string">
		<xsl:text>Included characters: </xsl:text>
		<xsl:value-of select="."/>
		<xsl:text>&#xa;</xsl:text>
	</xsl:template>

	<xsl:template match="chars" mode="bitmaps">
		<xsl:apply-templates select="char" mode="bitmaps"/>
	</xsl:template>

	<xsl:template match="chars" mode="chartable">
		<xsl:text>const tChar </xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>_array[] = </xsl:text>
		<xsl:text>{</xsl:text>
		<xsl:apply-templates select="char" mode="chartable"/>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>};</xsl:text>
	</xsl:template>

	<xsl:template match="char" mode="bitmaps">
		<xsl:apply-templates select="bitmap"/>
	</xsl:template>

	<xsl:template match="char" mode="chartable">
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>  //character: '</xsl:text>
		<xsl:value-of select="@character"/>
		<xsl:text>'</xsl:text>
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>  {</xsl:text>
		<xsl:apply-templates select="encoding[@codepage=65001]"/>
		<xsl:text>, &amp;</xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>_</xsl:text>
		<xsl:apply-templates select="encoding[@codepage=12000]"/>
		<xsl:text>}</xsl:text>
		<xsl:if test="(1 + count(parent::*/preceding-sibling::*)) != count(parent::*/parent::*/child::*)">
			<xsl:text>,</xsl:text>
		</xsl:if>
		<xsl:if test="(1 + count(parent::*/preceding-sibling::*)) = count(parent::*/parent::*/child::*)">
			<xsl:if test="position() != last()">
				<xsl:text>,</xsl:text>
			</xsl:if>
		</xsl:if>
	</xsl:template>

	<xsl:template match="encoding">
		<xsl:text>0x</xsl:text>
		<xsl:for-each select="bytes/byte">
			<xsl:value-of select="."/>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="fontdef">
		<xsl:text>&#xa;</xsl:text>
		<xsl:text>const tFont font_</xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text> = { </xsl:text>
		<xsl:value-of select="count(/data/chars/char)"/>
		<xsl:text>, </xsl:text>
		<xsl:text>&amp;</xsl:text>
		<xsl:value-of select="/data/@name"/>
		<xsl:text>_array[0] </xsl:text>
		<xsl:text>};</xsl:text>
	</xsl:template>
</xsl:stylesheet>
