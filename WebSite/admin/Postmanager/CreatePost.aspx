<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" Theme="Default" AutoEventWireup="true" CodeFile="CreatePost.aspx.cs" Inherits="admin_Postmanager_CreatePost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<script type="text/javascript">
    $(document).ready(function() {
    $("input[id$='TXT_CODE']").bind("blur", function(event) { Unique($(this)) });
    });
    function Unique(obj) {
        if (obj.val() != "") {
            $.ajax({
                url: "Unique.ashx",
                data: { "CODE": obj.val() },
                global: false,
                type: "POST",
                success: function(data, textStatus) {
                    if (data == "false") {
                        alert("岗位代码必须唯一：\n您输入的岗位代码已经存在，请重新输入！");
                        obj.val('');
                        obj.focus();
                    }
                },
                error: function() { alert("error"); }
            });
        }
    }
    function validator() {
        var error = "提交数据时出现以下异常：\n";
        var flag = false;
        if ($("input[id$='TXT_CODE']").val().len() == 0) {
            error += "岗位代码：必须输入！\n";
            flag = true;
        }
        if ($("input[id$='TXT_NAME']").val().len() == 0) {
            error += "岗位名称：必须输入！\n";
            flag = true;
        }
        if ($("input[id$='TXT_CODE']").val().len() > 10) {
            error += "岗位代码：输入长度为0～10个字符！\n";
            flag = true;
        }
        if ($("input[id$='TXT_NAME']").val().len() > 20) {
            error += "岗位名称：输入长度为0～20个字符！\n";
            flag = true;
        }
        if ($("textarea[id$='TXT_REMARK']").val().len() >50) {
            error += "备注：输入长度为0～50个字符！\n";
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
</script>
<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
    <tr>
        <td class="trr">
            岗位代码：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_CODE" runat="server"></asp:TextBox><font color="Red">*(字典代码必须唯一)</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            岗位名称：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_NAME" runat="server"></asp:TextBox><font color="Red">*</font>
        </td>
    </tr>
    <tr>
     <td class="trr">
            备注：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_REMARK" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="trr">
            启用状态：</td>
        <td class="trl">
            <asp:CheckBox ID="CHB_ISENABLE" Text="是否启用" runat="server" Checked=true />
        </td>
    </tr>
    <tr>
        <td class="trr">
            &nbsp;</td>
        <td class="trl">
            <asp:Button ID="btnSave" runat="server" Text="保存并返回" onclick="btnSave_Click" OnClientClick="validator()"  />
            <asp:Button ID="btnMultipleSave" runat="server" Text="保存并继续新增" 
                onclick="btnMultipleSave_Click" OnClientClick="validator()"/>
            <asp:Button ID="btnBack" runat="server" Text="返回" onclick="btnBack_Click" />
            <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填或必选)</font></td>
    </tr>
 </table>
</asp:Content>