<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="EditRole.aspx.cs" Theme="Default" Inherits="admin_RoleManager_EditRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<script type="text/javascript">
        function validator() {
            var error = "提交数据时出现以下异常：\n";
            var flag = false;
            if (document.getElementById('<%=TXT_ROLENAME.ClientID %>').value == "") {
                error += "角色名称：必须输入！\n";
                flag = true;
            }
            else if (document.getElementById('<%=TXT_ROLENAME.ClientID %>').value.len() > 20) {
                error += "角色名称：输入长度为0～20个字符！\n";
                flag = true;
            }
            if (document.getElementById('<%=TXT_REMARK.ClientID %>').value.len() > 100) {
                error += "备注：输入长度为0～100个字符！\n";
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
        String.prototype.len = function() {
            var str = this;
            return str.replace(/[^\x00-\xff]/g, "**").length
        }
    </script>
<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr">
                角色名称：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_ROLENAME" runat="server" Width="250px"></asp:TextBox><font color="#CC3300">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                备注：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_REMARK" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;</td>
            <td class="trl">
                <asp:Button ID="BTN_SAVE" runat="server" Text="保存后返回" onclick="BTN_SAVE_Click" OnClientClick="validator();" />
                <asp:Button ID="BTN_BACK" runat="server" Text="返回" onclick="Button3_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

