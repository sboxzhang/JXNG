<%@ Page Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    Theme="Default" CodeFile="IncomeSpending.aspx.cs" Inherits="business_other_IncomeSpending"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">

    <script type="text/javascript">
    function ChangYHLX()
    {
        $("#<%=txtXM.ClientID %>").val("");
        $("#<%=txtEIID.ClientID %>").val("");
    }
    $(document).ready(function() {
        $("<%=txtID.ClientID %>").change( function() {
                alert('11');
              
            }); 
        });
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="查 询">
            <ContentTemplate>
                <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
                    <tr>
                        <td class="trr" style="width: 10%">
                            姓名：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:TextBox ID="txtQXM" runat="server"></asp:TextBox>
                        </td>
                        <td class="trr" style="width: 10%">
                            时间：
                        </td>
                        <td class="trl" style="width: 40%;">
                            <asp:TextBox ID="txtJSSJS" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                            ～
                            <asp:TextBox ID="txtJSSJE" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr" style="width: 10%">
                            类型：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:DropDownList ID="ddlQLX" runat="server">
                                <asp:ListItem Text="全部" Value=""></asp:ListItem>
                                <asp:ListItem Text="收入" Value="0"></asp:ListItem>
                                <asp:ListItem Text="支出" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="trr" style="width: 10%">
                            用户类型：
                        </td>
                        <td class="trl" style="width: 40%;">
                            <asp:DropDownList ID="ddlQYHLX" runat="server">
                                <asp:ListItem Text="全部" Value=""></asp:ListItem>
                                <asp:ListItem Text="用户" Value="0"></asp:ListItem>
                                <asp:ListItem Text="阿姨" Value="1"></asp:ListItem>
                            </asp:DropDownList>
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
                                <asp:GridView ID="gvTable" runat="server" AutoGenerateColumns="False" Width="100%"
                                    PageSize="15" DataKeyNames="id" EmptyDataText="没有查询到相关数据" OnRowDataBound="gvTable_RowDataBound"
                                    OnRowDeleting="gvTable_RowDeleting" AllowPaging="true" OnRowEditing="gvTable_RowEditing">
                                    <Columns>
                                        <asp:BoundField DataField="lx" HeaderText="类型" />
                                        <asp:BoundField DataField="yhlx" HeaderText="用户类型" />
                                        <asp:BoundField DataField="km" HeaderText="科目" />
                                        <asp:BoundField DataField="fs" HeaderText="收入/支出方式" />
                                        <asp:BoundField DataField="je" HeaderText="金额" />
                                        <asp:BoundField DataField="tt" HeaderText="发票抬头" />
                                        <asp:BoundField DataField="jssj" HeaderText="支出/收入时间" />
                                        <asp:CommandField ShowCancelButton="False" ShowEditButton="True" EditText="处理" HeaderText="处理" />
                                        <asp:CommandField HeaderText="删除" EditText="删除" ShowDeleteButton="True" ShowHeader="True" />
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
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="收入/支出信息">
            <ContentTemplate>
                <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
                    <tr>
                        <td class="trr" style="width: 10%">
                            用户类型：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:DropDownList ID="ddlYHLX" onchange="ChangYHLX();" runat="server">
                                <asp:ListItem Text="用户" Value="0"></asp:ListItem>
                                <asp:ListItem Text="阿姨" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="trr" style="width: 10%">
                            姓名：
                        </td>
                        <td class="trl" style="width: 40%">
                            <asp:TextBox ID="txtXM" runat="server"></asp:TextBox><asp:Button ID="btnSelect" runat="server"
                                Text="选择" />
                            <asp:TextBox ID="txtID" Style="display: none;" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtEIID" Style="display: none;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            类型：
                        </td>
                        <td class="trl">
                            <asp:DropDownList ID="ddlLX" runat="server">
                                <asp:ListItem Text="收入" Value="0"></asp:ListItem>
                                <asp:ListItem Text="支出" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="trr">
                            支出/收入时间：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtSJ" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            收入/支出方式：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtFS" runat="server"></asp:TextBox>
                        </td>
                        <td class="trr">
                            发票抬头：
                        </td>
                        <td class="trl">
                            <asp:TextBox ID="txtTT" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            金额：
                        </td>
                        <td class="trl" colspan="3">
                            <asp:TextBox ID="txtJE" runat="server"></asp:TextBox>
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
