<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerManage.aspx.cs" Inherits="admin_PowerManager_PowerManage" Theme="Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin:5px">
    <form id="form1" runat="server">
                <input id="hideimgurl" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server" name="hideimgurl" value="../../images/Menus/icon/desktop.gif" />
    <div>
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr" style="width:20%">
                模块名称：</td>
            <td class="trl">
                <asp:Label ID="lab_MoudleName" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="trr" style="width:20%">
                模块功能名称：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_POWERNAME" runat="server" Width="250px"></asp:TextBox><font style="color: #FF0000; ">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                权限值：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_POWERVALUE" runat="server" Width="50px"></asp:TextBox><font style="color: #FF0000; ">*(权限值必须唯一)</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;</td>
            <td class="trl">
                <asp:Button ID="BTN_ADD" runat="server" Text="新增保存" onclick="BTN_ADD_Click" />
                <asp:Button ID="BTN_DEL" runat="server" Text="删除" onclick="BTN_DEL_Click"  />
                <asp:Button ID="BTN_UPD" runat="server" Text="修改保存" onclick="BTN_UPD_Click" />
                <asp:Button ID="BTN_CANCEL" runat="server" Text="撤销" onclick="BTN_CANCEL_Click" />
                <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填)</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;</td>
            <td class="trl">
            <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PowerId" 
                    Width="70%" CellPadding="4" 
                    onselectedindexchanging="GridView1_SelectedIndexChanging" 
                    ForeColor="#333333">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField HeaderText="功能名称" DataField="PowerName" ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField HeaderText="权限值" DataField="PowerValue" ItemStyle-HorizontalAlign="Center"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText="操作" SelectText="操作" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="30px" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <RowStyle Height="26px" />
                </asp:GridView>&nbsp;
            </td>
        </tr>
     </table>
    </div>
    </form>
</body>
</html>
