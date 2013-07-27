<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
      <html>
        <body>
          <h1>Students</h1>
          <table cellspacion="1">
            <tr>
              <td><b>Name</b></td>
              <td><b>Sex</b></td>
              <td><b>Birth Date</b></td>
              <td><b>Phone</b></td>
              <td><b>Email</b></td>
              <td><b>Course</b></td>
              <td><b>Specialty</b></td>
              <td><b>Faculty Number</b></td>
              <td><b>Exams</b></td>
            </tr>
            <xsl:for-each select="/students/student">
              <tr>
                <td><xsl:value-of select="name"/></td>
                <td><xsl:value-of select="sex"/></td>
                <td><xsl:value-of select="birth-date"/></td>
                <td><xsl:value-of select="phone"/></td>
                <td><xsl:value-of select="email"/></td>
                <td><xsl:value-of select="course"/></td>
                <td><xsl:value-of select="specialty"/></td>
                <td><xsl:value-of select="faculty-number"/></td>
                <td>
                  <table>
                    <xsl:for-each select="/students/student/exams/exam">
                      <tr>
                        <td><xsl:value-of select="name"/></td>
                        <td><xsl:value-of select="tutor"/></td>
                        <td><xsl:value-of select="score"/></td>
                      </tr>
                    </xsl:for-each>
                  </table>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
