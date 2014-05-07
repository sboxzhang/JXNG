<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoudleManage.aspx.cs" Inherits="admin_ModuleManager_ModuleManage" Theme="Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function imgchang() {
            if (document.getElementById("DDL_IMG").selectedIndex != 0) {
                document.getElementById("imgview").src = "../../" + document.getElementById("DDL_IMG").options[document.getElementById("DDL_IMG").selectedIndex].value;
                document.getElementById("hideimgurl").value = "../../" + document.getElementById("DDL_IMG").options[document.getElementById("DDL_IMG").selectedIndex].value;
            }
            else {
                document.getElementById("imgview").src = '../../images/icon/1.png';
                document.getElementById("hideimgurl").value = '../../images/icon/1.png';
            }
        }
    </script>
</head>
<body style="margin:4px">
    <form id="form1" runat="server">
    <script type="text/javascript">
        function validator() {
            var error = "提交数据时出现以下异常：\n";
            var flag = false;
            if (document.getElementById('<%=TXT_MOUDLENAME.ClientID %>').value == "") {
                error += "模块名称：必须输入！\n";
                flag = true;
            }
            else if (document.getElementById('<%=TXT_MOUDLENAME.ClientID %>').value.len() > 20) {
                error += "模块名称：输入长度为0～20个字符！\n";
                flag = true;
            }
            if (document.getElementById('<%=TXT_SORT.ClientID %>').value.len() > 5) {
                error += "排序：输入长度为0～5个字符！\n";
                flag = true;
            }
            if (flag) {
                alert(error);
                event.returnValue = false;
                return;
            }
            if (confirm("确定要保存吗？")) {
                event.returnValue = true;
            } else {
                event.returnValue = false;
            }
        }
        String.prototype.len = function() {
            var str = this;
            return str.replace(/[^\x00-\xff]/g, "**").length
        }
        function Delete() {
            if (confirm("确定要进行删除操作吗？")) {
                event.returnValue = true;
            } else {
                event.returnValue = false;
            }
        }
    </script>
    <div>
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr" style="width:20%">
                模块名称：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_MOUDLENAME" runat="server" Width="250px"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                页面地址：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_URL" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                上级模块：</td>
            <td class="trl">
                <asp:DropDownList ID="DDL_PARENTID" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                图片：</td>
            <td class="trl">
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                <td align="left" style="width:65px;"><asp:DropDownList ID="DDL_IMG" runat="server" Width="152px"></asp:DropDownList>
                </td>
                <td align="left"><img alt="" id="imgview" src="../../images/icon/1.png" runat="server" style="border:0"/>
                <input id="hideimgurl" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server" name="hideimgurl" value="../../images/Menus/icon/desktop.gif" />
                    </td>
                    </tr>
                    </table>
                
            </td>
        </tr>
        <tr>
            <td class="trr">
                是否可用：</td>
            <td class="trl">
                <asp:DropDownList ID="DDL_ISENABLE" runat="server" Width="50px">
                    <asp:ListItem Value="Y">可用</asp:ListItem>
                    <asp:ListItem Value="N">不可用</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                是否跟节点：</td>
            <td class="trl">
                <asp:DropDownList ID="DDL_ISROOT" runat="server" Width="50px">
                    <asp:ListItem Value="N">否</asp:ListItem>
                    <asp:ListItem Value="Y">是</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                排序：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_SORT" runat="server" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;</td>
            <td class="trl">
                <asp:Button ID="BTN_ADD" runat="server" Text="新增保存" onclick="BTN_ADD_Click"  OnClientClick="validator();"/>
                <asp:Button ID="BTN_DEL" runat="server" Text="删除" onclick="BTN_DEL_Click" OnClientClick="Delete();" />
                <asp:Button ID="BTN_UPD" runat="server" Text="修改保存" onclick="BTN_UPD_Click"  OnClientClick="validator();"/>
                <asp:Button ID="BTN_CANCEL" runat="server" Text="撤销" onclick="BTN_CANCEL_Click"/>
                <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填)</font>
            </td>
        </tr>
     </table>
    </div>
    </form>
</body>
</html>