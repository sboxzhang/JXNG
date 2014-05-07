<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddUsers.aspx.cs" Inherits="admin_AddUsers"  Theme="Default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<script type="text/javascript" src="../../Scripts/jquery-1.3.2.min.js"></script>
<script type="text/javascript">
    function validator() {
        var error = "提交数据时出现以下异常：\n";
        var flag = false;
        if (document.getElementById('<%=TXT_USERCODE.ClientID %>').value == "") {
            error += "帐号：必须输入！\n";
            flag = true;
        }
        else if (document.getElementById('<%=TXT_USERCODE.ClientID %>').value.len() > 20) {
        error += "帐号：输入长度为0～20个字符！\n";
            flag = true;
        }
        if (document.getElementById('<%=TXT_USERNAME.ClientID %>').value == "") {
            error += "姓名：必须输入！\n";
            flag = true;
        }
        else if (document.getElementById('<%=TXT_USERNAME.ClientID %>').value.len() > 20) {
        error += "姓名：输入长度为0～20个字符！\n";
            flag = true;
        }
        if (document.getElementById('<%=DDL_DEPT.ClientID %>').value == "0") {
            error += "部门：必须选择！\n";
            flag = true;
        }
        if (flag) {
            alert(error);
            event.returnValue = false;
            return;
        }
        if (confirm("确定要保存吗？")) {
            event.returnValue = true;
        } else {
            event.returnValue = false;
        }
    }
    $(document).ready(function() {
        $("input[id$='TXT_USERCODE']").bind("blur", function(event) { CheckUserCode($(this)) });
    });
    function CheckUserCode(obj) {
        if (obj.val() != "") {
            $.ajax({
                url: "CheckUserCode.ashx",
                data: { "UserCode": obj.val() },
                global: false,
                type: "POST",
                success: function(data, textStatus) {
                    if (data == "false") {
                        alert("用户帐号必须唯一：\n您输入的用户代码已经存在！");
                        obj.focus();
                    }
                },
                error: function() { alert("error"); }
            });
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
            帐号：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_USERCODE" runat="server"></asp:TextBox><font color="Red">*(用户帐号必须唯一)</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            姓名：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_USERNAME" runat="server"></asp:TextBox><font color="Red">*</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            部门：</td>
        <td class="trl">
            <asp:DropDownList ID="DDL_DEPT" runat="server" Width="250px">
            </asp:DropDownList><font color="Red">*</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            岗位：</td>
        <td class="trl">
            <asp:DropDownList ID="DDL_POST" runat="server" Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
     <td class="trr">
            地址：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_ADDRESS" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td class="trr">
            电子邮件：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_EMAIL" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="trr">
            电话：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_TELEPHONE" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="trr">
            手机：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_MOBILE" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="trr">
            &nbsp;</td>
        <td class="trl">
            <asp:Button ID="btnSave" runat="server" Text="保存并返回" onclick="btnSave_Click" OnClientClick="validator();" />
            <asp:Button ID="btnMultipleSave" runat="server" Text="保存并继续新增" 
                onclick="btnMultipleSave_Click" OnClientClick="validator();"/>
            <asp:Button ID="btnBack" runat="server" Text="返回" onclick="btnBack_Click" />
            <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填)</font></td>
    </tr>
 </table>
</asp:Content>

