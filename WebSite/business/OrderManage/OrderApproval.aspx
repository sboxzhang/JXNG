<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="OrderApproval.aspx.cs" Inherits="business_OrderManage_OrderApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="1">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="查 询">
            <HeaderTemplate>
                查 询
            </HeaderTemplate>
            <ContentTemplate>
                <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
                    <tr>
                        <td class="trr" style="width: 10%">
                            订单状态：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:DropDownList ID="ddlQDDZT" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="trr" style="width: 10%">
                            订单类型：
                        </td>
                        <td class="trl" style="width: 40%;">
                            <asp:DropDownList ID="ddlQDDLX" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            应聘者名字：
                        </td>
                        <td class="trl" colspan="3">
                            <asp:TextBox ID="txtXM" runat="server"></asp:TextBox>
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
                                <asp:GridView ID="gvTable" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="spid" EmptyDataText="没有查询到相关数据" OnRowDataBound="gvTable_RowDataBound"
                                    OnRowEditing="gvTable_RowEditing" PageSize="15" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="lx" HeaderText="订单编号" />
                                        <asp:BoundField DataField="yhlx" HeaderText="订单类型" />
                                        <asp:BoundField DataField="km" HeaderText="应聘者姓名" />
                                        <asp:BoundField DataField="fs" HeaderText="身份证号" />
                                        <asp:BoundField DataField="je" HeaderText="年龄" />
                                        <asp:BoundField DataField="tt" HeaderText="应聘工种" />
                                        <asp:BoundField DataField="jssj" HeaderText="联系人" />
                                        <asp:BoundField DataField="jssj" HeaderText="地址" />
                                        <asp:BoundField DataField="jssj" HeaderText="开始时间" />
                                        <asp:BoundField DataField="jssj" HeaderText="结束时间" />
                                        <asp:BoundField DataField="czlx" HeaderText="操作类型" />
                                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                                        <asp:CommandField EditText="删除" HeaderText="删除" ShowDeleteButton="True" ShowHeader="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoClass="" InvalidPageIndexErrorMessage="页索引不是有效的数值！"
                                    LayoutType="Div" NavigationToolTipTextFormatString="{0}" OnPageChanged="AspNetPager1_PageChanged"
                                    PageIndexBoxType="TextBox" PageIndexOutOfRangeErrorMessage="页索引超出范围！" ShowPageIndexBox="Auto">
                                </webdiyer:AspNetPager>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="订单信息">
            <ContentTemplate>
                <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
                    <tr>
                        <td class="trr" style="width: 10%">
                        </td>
                        <td class="trc">
                            旧信息
                        </td>
                        <td class="trc">
                            新信息
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            订单种类：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblDDZL" runat="server"></asp:Label>
                            <asp:TextBox ID="txtSPID" style="display:none" runat="server"></asp:TextBox>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblDDZLSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            应聘工种：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblYPGZ" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblYPGZSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            联系人：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblLXR" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblLXRSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            联系电话：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblLXDH" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblLXDHSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            地址：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblLXDZ" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblLXDZSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            应聘者姓名：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblAYXM" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblAYXMSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            年龄：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblNL" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblNLSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            单价：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblDJ" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblDJSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            时间：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblKSSJ" runat="server"></asp:Label>~<asp:Label ID="lblJSSJ" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblKSSJSP" runat="server"></asp:Label>~<asp:Label ID="lblJSSJSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            周期：
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblZQ" runat="server"></asp:Label>
                        </td>
                        <td class="trc">
                            <asp:Label ID="lblZQSP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            备注：
                        </td>
                        <td class="trc">
                            <asp:TextBox ID="txtBZ" runat="server"></asp:TextBox>
                        </td>
                        <td class="trc">
                            <asp:TextBox ID="txtBZSP" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td class="trr">
                             审核结果：
                        </td>
                        <td class="trl" colspan="2">
                            <asp:RadioButtonList ID="rblSPJG" RepeatLayout="Table" RepeatDirection="Vertical" runat="server">
                            <asp:ListItem Text="不通过" Value="0"></asp:ListItem>
                             <asp:ListItem Text="通过" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td class="trr">
                           
                        </td>
                        <td class="trl" colspan="2">
                            <asp:Button ID="btnApproval" runat="server" Text="审　核" OnClick="btnApproval_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
