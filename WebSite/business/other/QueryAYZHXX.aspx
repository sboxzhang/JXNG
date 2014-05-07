<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage2.master" Theme="Default"
    AutoEventWireup="true" CodeFile="QueryAYZHXX.aspx.cs" Inherits="business_other_QueryAYZHXX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Master22" runat="Server">
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
                            <asp:BoundField DataField="XB" HeaderText="性别" />
                            <asp:BoundField DataField="HYZK" HeaderText="婚姻状况" />
                            <asp:BoundField DataField="YHCD" HeaderText="文化程度" />
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
