<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="admin_RoleManager_Default" Theme="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" runat="Server">
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl">
                <asp:Button ID="btnAdd" runat="server" Text="新增角色" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td class="trc" colspan="2">
                <br />
                <div class="GridViewPagerStyle">    
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RoleId"
                    Width="99%" PageSize="15" AllowPaging="True" 
                        OnPageIndexChanging="GridView1_PageIndexChanging" onrowdeleting="GridView1_RowDeleting" 
                        onrowediting="GridView1_RowEditing" 
                        onselectedindexchanging="GridView1_SelectedIndexChanging" 
                        onrowdatabound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField SortExpression="RoleName" DataField="RoleName" HeaderText="角色名称" />
                        <asp:BoundField SortExpression="Remark" DataField="Remark" HeaderText="备注" />
                        <asp:CommandField ShowCancelButton="False" SelectText="编辑" ShowEditButton="True" HeaderText="编辑"  />
                        <asp:CommandField ShowDeleteButton="True"  HeaderText="删除"  DeleteText="删除" />
                        <asp:CommandField ShowCancelButton="False" ShowSelectButton="True" HeaderText="模块权限" SelectText="授权"/>
                        <asp:CommandField DeleteText="授权" ShowDeleteButton="True" HeaderText="功能权限" Visible=false />
                    </Columns>
                    <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PageButtonCount="5"
                        PreviousPageText="上一页" />
                    <PagerStyle BorderColor="#66FF66" Font-Names="宋体" Font-Size="12px" />
                </asp:GridView></div>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
