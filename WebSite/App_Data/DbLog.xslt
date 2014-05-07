<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
          <table border="0" cellspacing="0" cellpadding="1" width="100%" height="100%" class="StandardTable">
            <tr>
              <td class="trc">
                <b>操作时间</b>
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
                <b>是否异常</b>
              </td>
              <td class="trc">
                <b>异常信息</b>
              </td>
              <td class="trc">
                <b>异常跟踪信息</b>
              </td>
            </tr>
            <xsl:for-each select="SQL语句执行记录">
              <tr>
                <td class="trc" colspan="7">
                  <xsl:value-of select="@执行日期"/>
                </td>
              </tr>
            </xsl:for-each>
            <xsl:for-each select="SQL语句执行记录/时间">
              <tr>
                <td class="trc">
                  <xsl:value-of select="@Value"/>
                </td>
                <td class="trc">
                  <xsl:value-of select="方法"/>
                </td>
                <td class="trl" style="word-wrap: break-word;width:200px">
                  <xsl:value-of select="参数"/>
                </td>
                <td class="trc">
                  <xsl:value-of select="执行人"/>
                </td>
                <td class="trc">
                  <xsl:value-of select="是否异常"/>
                </td>
                <td class="trc" style="word-wrap: break-word;width:100px">
                  <xsl:value-of select="异常信息"/>
                </td>
                <td class="trc" style="word-wrap: break-word;width:200px">
                  <xsl:value-of select="异常跟踪信息"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
  </xsl:template>
</xsl:stylesheet>
