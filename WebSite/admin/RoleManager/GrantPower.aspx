<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="GrantPower.aspx.cs" Theme="Default" Inherits="admin_RoleManager_GrantPower" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" runat="Server">
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr" style="width: 15%">
                角色：
            </td>
            <td class="trl">
                <asp:Label ID="LAB_ROLE" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl">
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%"
                    DataKeyNames="MoudleId" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="MoudleName" HeaderText="模块名称" ReadOnly="True" SortExpression="MoudleName" />
                        <asp:TemplateField HeaderText="功能" ItemStyle-Height="26px">
                            <ItemTemplate>
                                <asp:CheckBoxList ID="Right" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </ItemTemplate>
                            <ItemStyle Height="26px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl">
                <asp:Button ID="BTN_SAVE" runat="server" Text="保存" OnClick="BTN_SAVE_Click" />
                <asp:Button ID="BTN_BACK" runat="server" Text="返回" OnClick="BTN_BACK_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
