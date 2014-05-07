<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeptManage.aspx.cs" Inherits="admin_DeptManager_DeptManage" Theme="Default" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Scripts/jquery-1.3.2.min.js"></script>
</head>
<body style="margin:5px">
    <form id="form1" runat="server">
    <script type="text/javascript">
        function validator() {
            var error = "提交数据时出现以下异常：\n";
            var flag = false;
            if ($("input[id$='TXT_DEPTID']").val().len() == 0) {
                error += "部门代码：必须输入！\n";
                flag = true;
            }
            if ($("input[id$='TXT_DEPTNAME']").val().len() == 0) {
                error += "部门名称：必须输入！\n";
                flag = true;
            }
            else if ($("input[id$='TXT_DEPTNAME']").val().len() > 50) {
                error += "部门名称：输入长度为0～50个字符！\n";
                flag = true;
            }
            if ($("textarea[id$='TXT_REMARK']").val().len() > 50) {
                error += "描述：输入长度为0～50个字符！\n";
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
            if (confirm("确定要进行删除此部门及其子部门吗？\n 如果该部门删除，该部门所属人员单位将置空！")) {
                event.returnValue = true;
            } else {
                event.returnValue = false;
            }
        }
        $(document).ready(function() {
            $("input[id$='TXT_DEPTID']").bind("blur", function(event) { Unique($(this)) });
        });
        function Unique(obj) {
            if (obj.val() != "") {
                $.ajax({
                    url: "Unique.ashx",
                    data: { "DEPTID": obj.val() },
                    global: false,
                    type: "POST",
                    success: function(data, textStatus) {
                        if (data == "false") {
                            alert("部门代码必须唯一：\n您输入的部门代码已经存在，请重新输入！");
                            obj.val('');
                            obj.focus();
                        }
                    },
                    error: function() { alert("error"); }
                });
            }
        }
</script>
    <div>
        <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr" style="width:20%">
                部门代码：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_DEPTID" runat="server" Width="152px"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr" style="width:20%">
                部门名称：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_DEPTNAME" runat="server" Width="152px"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                上级部门：</td>
            <td class="trl">
                <asp:DropDownList ID="DDL_DEPT" runat="server" Width="152px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                部门类型：</td>
            <td class="trl">
                <asp:DropDownList ID="DDL_DEPTTYPE" runat="server" Width="152px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                描述：</td>
            <td class="trl">
                <asp:TextBox ID="TXT_REMARK" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;</td>
            <td class="trl">
                <asp:Button ID="BTN_ADD" runat="server" Text="新增保存" onclick="BTN_ADD_Click" OnClientClick="validator();" />
                <asp:Button ID="BTN_DEL" runat="server" Text="删除" onclick="BTN_DEL_Click" OnClientClick="Delete();" />
                <asp:Button ID="BTN_UPD" runat="server" Text="修改保存" onclick="BTN_UPD_Click" OnClientClick="validator();"/>
                <asp:Button ID="BTN_CANCEL" runat="server" Text="撤销"  onclick="BTN_CANCEL_Click" />
                <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填)</font>
            </td>
        </tr>
     </table>
    </div>
    </form>
</body>
</html>