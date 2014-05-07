<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" Theme="Default" AutoEventWireup="true" CodeFile="CreateDictType.aspx.cs" Inherits="admin_DictManager_CreateDictType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>字典类型维护</title>
<base target="_self" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<script type="text/javascript">
    $(document).ready(function() {
        $("input[id$='TXT_CODE']").bind("blur", function(event) { Unique($(this)) });
    });
    function Unique(obj) {
        if (obj.val() != "") {
            $.ajax({
                url: "UniqueType.ashx",
                data: { "CODE": obj.val() },
                global: false,
                type: "POST",
                success: function(data, textStatus) {
                    if (data == "false") {
                        alert("字典类型代码必须唯一：\n您输入的字典类型代码已经存在，请重新输入！");
                        obj.val('');
                        obj.focus();
                    }
                },
                error: function() { alert("error"); obj.val(''); }
            });
        }
    }
    function validator() {
        var error = "提交数据时出现以下异常：\n";
        var flag = false;
        if ($("input[id$='TXT_CODE']").val().len() == 0) {
            error += "字典代码：必须输入！\n";
            flag = true;
        }
        if ($("input[id$='TXT_NAME']").val().len() == 0) {
            error += "字典名称：必须输入！\n";
            flag = true;
        }
        if ($("input[id$='TXT_CODE']").val().len() > 10) {
            error += "描述：输入长度为0～10个字符！\n";
            flag = true;
        }
        if ($("input[id$='TXT_NAME']").val().len() > 20) {
            error += "描述：输入长度为0～20个字符！\n";
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
            类型代码：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_CODE" runat="server"></asp:TextBox><font color="Red">*(字典代码必须唯一)</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            类型名称：</td>
        <td class="trl">
            <asp:TextBox ID="TXT_NAME" runat="server"></asp:TextBox><font color="Red">*</font>
        </td>
    </tr>
    <tr>
        <td class="trr">
            &nbsp;</td>
        <td class="trl">
            <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" OnClientClick="validator()"  />
            <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填或必选)</font></td>
    </tr>
    <tr>
        <td class="trc" colspan="2" style="height:2px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="trc" colspan="2">
            <br />
                <div class="GridViewPagerStyle">    
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Code"
                    Width="99%" PageSize="10" AllowPaging="true"
                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
                        onrowediting="GridView1_RowEditing" >
                    <Columns>
                        <asp:BoundField SortExpression="Code" DataField="Code" HeaderText="类型代码" />
                        <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="类型名称" />
                        <asp:CommandField ShowCancelButton="False" ShowEditButton="True" HeaderText="编辑" EditText="编辑" />
                        <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="True" ShowHeader="True" />
                    </Columns>
                    <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PageButtonCount="5"
                        PreviousPageText="上一页" />
                    <PagerStyle BorderColor="#66FF66" Font-Names="宋体" Font-Size="12px" />
                </asp:GridView></div>
                <br />
            </td>
    </tr>
    <tr>
        <td class="trc" colspan="2">
        <a href="#" onclick="window.close();">【关闭窗口】</a>
        </td>
    </tr>
 </table>
</asp:Content>