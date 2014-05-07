<%@ Page Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="StandInsideLetter.aspx.cs" Theme="Default"  Inherits="business_other_StandInsideLetter" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">

  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" 
        ActiveTabIndex="1">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="留言">
            <ContentTemplate>
            <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
                <tr>
                    <td class="trr" style="width:10%">
                        状态：
                    </td>
                    <td class="trl" style="width:40%">
                        <asp:DropDownList runat="server" ID="ddlQCLJG" Width="100px">
                        <asp:ListItem Text="全部" Value=""></asp:ListItem>
                        <asp:ListItem Text="未解决" Value="0"></asp:ListItem>
                        <asp:ListItem Text="已解决" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="trr" style="width:10%">
                        时间：
                    </td>
                    <td class="trl" style="width:40%;">
                     <asp:TextBox ID="txtFSSJS" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        ～
                        <asp:TextBox ID="txtFSSJE" runat="server" OnClick="new WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="trr">&nbsp;
                    </td>
                    <td class="trl" colspan="3"  >
                        <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td class="trc"  colspan="4">
                    <br />
                        <div class="GridViewPagerStyle">
                            <asp:GridView ID="gvTable" runat="server" AutoGenerateColumns="False"
                                Width="100%" PageSize="15" DataKeyNames="id" EmptyDataText="没有查询到相关数据" 
                                onrowdatabound="gvTable_RowDataBound" onrowdeleting="gvTable_RowDeleting"  AllowPaging="true"
                                onrowediting="gvTable_RowEditing">
                                <Columns>
                                    <asp:BoundField DataField="FSRMC" HeaderText="发送人" />
                                    <asp:BoundField DataField="fssj" HeaderText="发送时间" />
                                     <asp:BoundField DataField="fsnr" HeaderText="发送内容" />
                                     <asp:BoundField DataField="cljg" HeaderText="处理结果" />
                                     <asp:BoundField DataField="qlsj" HeaderText="处理时间" />
                                    <asp:CommandField ShowCancelButton="False" ShowEditButton="True" EditText="处理" HeaderText="处理" />
                                    <asp:CommandField HeaderText="删除" EditText="删除" ShowDeleteButton="True" ShowHeader="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                                OnPageChanged="AspNetPager1_PageChanged" CustomInfoClass="" 
                                InvalidPageIndexErrorMessage="页索引不是有效的数值！" LayoutType="Div" 
                                NavigationToolTipTextFormatString="" PageIndexBoxType="TextBox" 
                                PageIndexOutOfRangeErrorMessage="页索引超出范围！" ShowPageIndexBox="Auto" 
                                SubmitButtonImageUrl="" UrlPageSizeName="" UrlPagingTarget="">
                        </webdiyer:AspNetPager>
                    </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2"  runat="server" HeaderText="留言信息">
            <ContentTemplate>
            
                <table border="0" cellspacing="0" cellpadding="1" width="99%" class="StandardTable">
                <tr>
                <td class="trr">留言</td>
                <td class="trl"><asp:TextBox ID="txtFSNR" ReadOnly="true" TextMode="MultiLine" Rows="5" runat="server" Columns="50"></asp:TextBox>
                <asp:TextBox ID="txtID" runat="server" style="display:none;"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="trr">发送时间</td>
                <td class="trl">
                    <asp:Label ID="lblFSSJ" runat="server"></asp:Label></td>
                </tr>
                <tr>
                <td class="trr">处理</td>
                <td class="trl">
                    <asp:RadioButtonList ID="rblCLJG" RepeatDirection="Horizontal" RepeatLayout="Table" runat="server">
                    <asp:ListItem Text="未解决" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已解决" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                </tr>
                <tr>
                <td class="trr">&nbsp;</td>
                <td class="trl"><asp:Button ID="btnSave" runat="server" Text="保存" 
                        onclick="btnSave_Click" />
                    </td>
                </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>

