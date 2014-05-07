<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" Theme="Default" AutoEventWireup="true" CodeFile="OrderManage.aspx.cs" Inherits="business_OrderManage_OrderManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0">
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
                            <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="trc" colspan="4">
                            <br />
                            <div class="GridViewPagerStyle">
                                <asp:GridView ID="gvTable" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" DataKeyNames="id" EmptyDataText="没有查询到相关数据" 
                                    OnRowDataBound="gvTable_RowDataBound" OnRowDeleting="gvTable_RowDeleting" 
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
                                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                                        <asp:CommandField EditText="删除" HeaderText="删除" ShowDeleteButton="True" 
                                            ShowHeader="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
                                    CustomInfoClass="" InvalidPageIndexErrorMessage="页索引不是有效的数值！" LayoutType="Div" 
                                    NavigationToolTipTextFormatString="{0}" 
                                    OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="TextBox" 
                                    PageIndexOutOfRangeErrorMessage="页索引超出范围！" ShowPageIndexBox="Auto">
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
                            订单种类：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:DropDownList ID="ddlDDZL" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="trr" style="width: 10%">
                            应聘工种：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:DropDownList ID="ddlYPGZ" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtID" Style="display: none;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            联系人：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtLXR" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtEIID" Style="display: none;" runat="server"></asp:TextBox>
                        </td>
                        <td class="trr">
                            联系电话：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtLXDH" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            地址：
                        </td>
                        <td class="trl" colspan="3">
                        <asp:TextBox ID="txtLXDZ" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            应聘者姓名：
                        </td>
                        <td class="trl">
                        <asp:TextBox ID="txtAYXM" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtAYID" Style="display: none;" runat="server"></asp:TextBox>
                        </td>
                        <td class="trr">
                            年龄：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtNL" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            单价：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtDJ" runat="server"></asp:TextBox>
                        </td>
                        <td class="trr">
                            时间：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtKSSJ" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>~
                            <asp:TextBox ID="txtJSSJ" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            周期：
                        </td>
                        <td class="trl" colspan="3">
                        <asp:TextBox ID="txtZQ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            备注：
                        </td>
                        <td class="trl" colspan="3">
                        <asp:TextBox ID="txtBZ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            &nbsp;
                        </td>
                        <td class="trl" colspan="3">
                            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>

