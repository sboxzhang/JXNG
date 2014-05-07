<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" Theme="Default" CodeFile="ModifyPassword.aspx.cs" Inherits="admin_UserManager_ModifyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<script type="text/javascript">
    function validator() {
        var error = "提交数据时出现以下异常：\n";
        var flag = false;
        if (document.getElementById('<%=TXT_PASSWORD.ClientID %>').value == "") {
            error += "新密码不能为空！\n";
            flag = true;
        }
        if (document.getElementById('<%=TXT_PASSWORD.ClientID %>').value.len() > 50) {
            error += "新密码长度为0～50个字符！\n";
            flag = true;
        }
        if (document.getElementById('<%=TXT_REPASSWORD.ClientID %>').value == "") {
            error += "重复新密码必须输入！\n";
            flag = true;
        }
        if (document.getElementById('<%=TXT_REPASSWORD.ClientID %>').value.len() > 50) {
            error += "重复新密码长度为0～50个字符！\n";
            flag = true;
        }
        if (document.getElementById('<%=TXT_REPASSWORD.ClientID %>').value != document.getElementById('<%=TXT_PASSWORD.ClientID %>').value) {
            error += "两次输入的密码不一致！\n";
            flag = true;
        }
        if (flag) {
            alert(error);
            event.returnValue = false;
            return;
        }
        if (confirm("确定要修改密码吗？")) {
            event.returnValue = true;
        } else {
            event.returnValue = false;
        }
    }
    String.prototype.len = function() {
        var str = this;
        return str.replace(/[^\x00-\xff]/g, "**").length
    }
</script>
<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
    <tr>
        <td class="trr">
            用户帐号：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_USERCODE" runat="server" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="trr">
            新密码：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_PASSWORD" runat="server" TextMode="Password"></asp:TextBox><font color="Red">*</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            重复新密码：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_REPASSWORD" runat="server" TextMode="Password"></asp:TextBox><font color="Red">*</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            &nbsp;</td>
        <td class="trl">
            <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" OnClientClick="validator();" />
            <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填)</font></td>
    </tr>
 </table>
</asp:Content>

