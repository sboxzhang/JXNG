<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="UsersManage.aspx.cs" Inherits="admin_UsersManage" Theme="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" runat="Server">
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr">
                姓名：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_USERNAME" runat="server"></asp:TextBox>
            </td>
            <td class="trr">
                帐号：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_USERCODE" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                部门：
            </td>
            <td class="trl">
                <asp:DropDownList ID="DDL_DEPT" runat="server">
                </asp:DropDownList>
            </td>
            <td class="trr">
                岗位：
            </td>
            <td class="trl">
                 <asp:DropDownList ID="DDL_POST" runat="server">
                </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl" colspan="3">
                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClear" runat="server" onclick="btnClear_Click" Text="重置" />
            </td>
            
        </tr>
        <tr>
            <td class="trc" colspan="4">
                <br />
                <div class="GridViewPagerStyle">    
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId"
                    Width="99%" PageSize="15" AllowPaging="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
                        onrowediting="GridView1_RowEditing" 
                        onselectedindexchanging="GridView1_SelectedIndexChanging" >
                    <Columns>
                        <asp:BoundField SortExpression="UserCode" DataField="UserCode" HeaderText="帐号" />
                        <asp:BoundField SortExpression="UserName" DataField="UserName" HeaderText="姓名" />
                        <asp:BoundField SortExpression="DeptName" DataField="DeptName" HeaderText="部门" />
                        <asp:BoundField SortExpression="PostName" DataField="PostName" HeaderText="岗位" />
                        <asp:BoundField SortExpression="Address" DataField="Address" HeaderText="联系地址" Visible="false"/>
                        <asp:BoundField SortExpression="Telephone" DataField="Telephone" HeaderText="电话" />
                        <asp:BoundField SortExpression="Mobile" DataField="Mobile" HeaderText="移动电话" Visible="false"/>
                        <asp:BoundField SortExpression="Email" DataField="Email" HeaderText="电子邮件" />
                        <asp:TemplateField HeaderText="所属角色" HeaderStyle-Width="105px">
                            <ItemTemplate>
                                <asp:DropDownList ID="drpRole" runat="server" CssClass="select" Width="100px">
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle Width="105px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:CommandField SelectText="赋予角色" ShowSelectButton="True" HeaderText="赋予角色" />
                        <asp:CommandField ShowCancelButton="False" ShowEditButton="True" HeaderText="编辑" EditText="编辑" />
                        <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="True" ShowHeader="True" />
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
