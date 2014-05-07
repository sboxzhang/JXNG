<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" Theme="Default" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_DictManager_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr">
                字典代码：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_CODE" runat="server"></asp:TextBox>
            </td>
            <td class="trr">
                字典名称：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_NAME" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                字典类型：
            </td>
            <td class="trl">
                <asp:DropDownList ID="DDL_TYPE" runat="server">
                </asp:DropDownList>
            </td>
            <td class="trr">
                字典状态：</td>
            <td class="trl">
                <asp:CheckBox ID="CHB_ISENABLE" Text="是否启用" runat="server" Checked=true /></td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl">
                <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click"/>
            </td>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="trc" colspan="4">
                <br />
                <div class="GridViewPagerStyle">    
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Code,TypeCode"
                    Width="99%" PageSize="15" AllowPaging="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
                        onrowediting="GridView1_RowEditing" >
                    <Columns>
                        <asp:BoundField SortExpression="TypeName" DataField="TypeName" HeaderText="类型" />
                        <asp:BoundField SortExpression="Code" DataField="Code" HeaderText="字典代码" />
                        <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="字典名称" />
                        <asp:BoundField SortExpression="Remark" DataField="Remark" HeaderText="说明" />
                        <asp:BoundField SortExpression="IsEnable" DataField="IsEnable" HeaderText="是否可用" />
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