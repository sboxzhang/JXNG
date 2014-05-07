<%@ Page Title="" Language="C#" Theme="Default" MasterPageFile="~/Shared/MasterPage.master"
    AutoEventWireup="true" CodeFile="SystemLog.aspx.cs" Inherits="business_other_SystemLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
        <tr>
            <td class="trr" style="width: 10%">
                用户：
            </td>
            <td class="trl" style="width: 40%">
                <asp:DropDownList ID="ddlUser" runat="server">
                </asp:DropDownList>
            </td>
            <td class="trr" style="width: 10%">
                模块：
            </td>
            <td class="trl" style="width: 40%">
                <asp:DropDownList ID="ddlModule" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                时间：
            </td>
            <td class="trl" colspan="3">
                <asp:TextBox ID="txtSJS" Width="130px" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                ~
                <asp:TextBox ID="txtSJE" Width="130px" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl" colspan="3">
                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
            </td>
        </tr>
        <tr>
            <td class="trc" colspan="4">
                <br />
                <div class="GridViewPagerStyle">
                    <asp:GridView ID="gvTable" runat="server" AutoGenerateColumns="False" Width="100%"
                        PageSize="15" DataKeyNames="id" EmptyDataText="没有查询到相关数据" AllowPaging="true">
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="登陆名" />
                            <asp:BoundField DataField="MOUDLENAME" HeaderText="模块名称" />
                            <asp:BoundField DataField="sj" HeaderText="时间" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                        CustomInfoClass="" InvalidPageIndexErrorMessage="页索引不是有效的数值！" LayoutType="Div"
                        NavigationToolTipTextFormatString="" PageIndexBoxType="TextBox" PageIndexOutOfRangeErrorMessage="页索引超出范围！"
                        ShowPageIndexBox="Auto" SubmitButtonImageUrl="" UrlPageSizeName="" UrlPagingTarget="">
                    </webdiyer:AspNetPager>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
