<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_DeptManager_Default" Theme="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
   <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%; padding-top: 0px;">
    <tr>
        <td style="width:200px">
            <iframe src="DeptTree.aspx" name="leftbody" id="leftbody" width="100%" height="100%" scrolling="yes" style="visibility: inherit" frameborder="0"></iframe>
        </td>
        <td>
            <iframe src="DeptManage.aspx" name="Rightbody" id="Rightbody" width="100%" height="100%" scrolling="auto" style="visibility: inherit" frameborder="0"></iframe>
        </td>
    </tr>
   </table>
</asp:Content>