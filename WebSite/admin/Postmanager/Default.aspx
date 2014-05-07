<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" Theme="Default" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Postmanager_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Code"
                    Width="99%" PageSize="15" AllowPaging="True" 
                        OnPageIndexChanging="GridView1_PageIndexChanging" onrowdeleting="GridView1_RowDeleting" 
                        onrowediting="GridView1_RowEditing" 
                        onrowdatabound="GridView1_RowDataBound" >
                    <Columns>
                        <asp:BoundField SortExpression="Code" DataField="Code" HeaderText="岗位代码" />
                        <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="岗位名称" />
                        <asp:BoundField SortExpression="Remark" DataField="Remark" HeaderText="说明" />
                        <asp:BoundField SortExpression="IsEnable" DataField="IsEnable" HeaderText="是否启用" />
                        <asp:CommandField ShowCancelButton="False" ShowEditButton="True" CancelText="编辑" HeaderText="编辑"  />
                        <asp:CommandField DeleteText="删除" ShowDeleteButton="True" HeaderText="删除" />
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