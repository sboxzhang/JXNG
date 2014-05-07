<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage2.master" AutoEventWireup="true" CodeFile="QueryEmployeeInfo.aspx.cs" Inherits="business_other_QueryEmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Master22" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
        <tr>
            <td class="trr" style="width: 10%">
                姓名：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtXM" runat="server"></asp:TextBox><asp:Button ID="btnQuery" runat="server"
                    Text="查询" OnClick="btnQuery_Click" />
            </td>
        </tr>
        <tr>
            <td class="trc" colspan="4">
                <br />
                <div class="GridViewPagerStyle">
                    <asp:GridView ID="gvTable" runat="server" AutoGenerateColumns="False" Width="100%"
                        PageSize="15" DataKeyNames="id" EmptyDataText="没有查询到相关数据" OnRowDataBound="gvTable_RowDataBound"
                        >
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbSelect" GroupName="AYZH" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                            <asp:BoundField DataField="xm" HeaderText="姓名" />
                            <asp:BoundField DataField="SFZH" HeaderText="身份证号" />
                            <asp:BoundField DataField="KHZT" HeaderText="客户状态" />
                            <asp:BoundField DataField="KHYXQ" HeaderText="客户有效期" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
        <td></td><td colspan="3" class="trl">
            <asp:Button ID="btnOK" runat="server" Text="确定" onclick="btnOK_Click" /></td>
        </tr>
    </table>
</asp:Content>

