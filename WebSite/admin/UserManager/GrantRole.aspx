<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" Theme="Default" CodeFile="GrantRole.aspx.cs" Inherits="admin_UserManager_GrantRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
    <tr>
        <td class="trr">
            姓名：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_USERNAME" runat="server" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="trr">
            角色：</td>
        <td class="trl">
            <asp:CheckBoxList ID="CBL_ROLE" runat="server" RepeatColumns="5" 
                RepeatDirection="Horizontal">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="trr">
            &nbsp;</td>
        <td class="trl">
            <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
            <asp:Button ID="btnBack" runat="server" Text="返回" onclick="btnBack_Click" />
        </td>
    </tr>
 </table>
</asp:Content>