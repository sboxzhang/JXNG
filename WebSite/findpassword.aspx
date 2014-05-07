<%@ Page Language="C#" AutoEventWireup="true" CodeFile="findpassword.aspx.cs" Inherits="findpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>：：阿姨家政后台管理系统：：</title>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="99%" >
        <tr>
            <td style="width: 10%;text-align: right;">
                邮箱地址：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtYX" Columns="50" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnBack" runat="server" Text="找回" onclick="btnBack_Click" />
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
