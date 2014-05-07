<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <table border="0" cellspacing="0" cellpadding="1" width="100%" height="100%" class="StandardTable">
      <tr>
        <td class="trc">
          <b>执行时间</b>
        </td>
        <td class="trc">
          <b>模块</b>
        </td>
        <td class="trc">
          <b>方法</b>
        </td>
        <td class="trc">
          <b>参数</b>
        </td>
        <td class="trc">
          <b>执行人</b>
        </td>
        <td class="trc">
          <b>是否成功</b>
        </td>
      </tr>
      <xsl:for-each select="Log">
        <tr>
          <td class="trc" colspan="6">
            <xsl:value-of select="@执行日期"/>
          </td>
        </tr>
      </xsl:for-each>
      <xsl:for-each select="Log/执行时间">
        <tr>
          <td class="trc">
            <xsl:value-of select="@Value"/>
          </td>
          <td class="trc">
            <xsl:value-of select="模块"/>
          </td>
          <td class="trl" style="word-wrap: break-word;width:200px">
            <xsl:value-of select="方法"/>
          </td>
          <td class="trc" style="word-wrap: break-word;width:200px">
            <xsl:value-of select="参数"/>
          </td>
          <td class="trc">
            <xsl:value-of select="执行人"/>
          </td>
          <td class="trc">
            <xsl:value-of select="是否成功"/>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
