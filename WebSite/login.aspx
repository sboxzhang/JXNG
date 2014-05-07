<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    Theme="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes/login/login.css" rel="stylesheet" type="text/css" />
    <title>::车辆调度监控管理系统::</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="height: 130px;">
        </div>
        <div id="login">
            <div id="ayjz">
            </div>
            <div style="height: 64px;">
            </div>
            <div style="text-align: center">
                <div id="divUserNameInput">
                    <asp:TextBox ID="TXT_USERCODE" runat="server" CssClass="textbox" Columns="12"></asp:TextBox></div>
            </div>
            <div id="divPassword">
                <div id="divPasswordInput">
                    <asp:TextBox ID="TXT_PASSWORD" runat="server" CssClass="textbox" TextMode="Password"
                        Columns="12"></asp:TextBox></div>
            </div>
            <div id="divCode">
                <span id="divCodeInput">
                    <asp:TextBox ID="txtCode" runat="server" CssClass="textbox2" Columns="4"></asp:TextBox>
                    <img id="imgVerify" src="VerifyCode.aspx?" alt="看不清？点击更换" onclick="this.src=this.src+'?'" />
                </span>
            </div>
            <div id="divBtn">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td style="">
                            <asp:CheckBox ID="cbMM" runat="server" Text="记住密码" />
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/login/image/btnLogin.png"
                                OnClick="ImageButton1_Click" />
                            <br />
                            <a href="findpassword.aspx">忘了密码？</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
