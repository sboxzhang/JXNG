<%@ Page Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="AyglAdd.aspx.cs" Inherits="aygl_AyglAdd" Theme="Default" %>    

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">
    <script type="text/javascript">
    
        $(document).ready(function(){            
            
            $(".btnAddItem").click(function(){
                var itemHtml = $(this).parent().find(".divItem").html();
                $(this).parent().find(".divItem").append($(this).parent().find("input:hidden").val());                            
            });
            
            $(".btnAddItem").each(function(){
                var itemHtml = $(this).parent().find(".divItem").html();
                if ($.trim(itemHtml) == "" || $.trim(itemHtml) == "\n"){
                    $(this).parent().find(".divItem").append($(this).parent().find("input:hidden").val());                            
                }
            });
            
            $(".btnlxdhDel,.btnlxsjDel,.btnyhzhDel,.btnfwsjdDel").live('click', function(){
                if (confirm("确认要删除么？")){                    
                    $(this).parent().remove();     
                }           
            });
        });    
    </script>
    
    
    <table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr" style="width:15%">
                姓名：
            </td>
            <td class="trl" style="width:35%">
                <asp:TextBox ID="TXT_USERNAME" require="true" dataType="Require" CssClass="textbox" runat="server"></asp:TextBox>
                <font color="Red">*</font>
            </td>
            <td class="trr" style="width:15%">
                性别：
            </td>
            <td class="trl" style="width:35%">
                <asp:DropDownList ID="DDL_GENDER" CssClass="select" runat="server">
                </asp:DropDownList>
                <font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                身份证号：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_USERID" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                婚姻状况：
            </td>
            <td class="trl">
                <asp:DropDownList ID="DDL_MARY" CssClass="select" runat="server">
                </asp:DropDownList>
                <font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                民族：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_FOLK" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                文化程度：
            </td>
            <td class="trl">
                <asp:DropDownList ID="DDL_WHCD" CssClass="select" runat="server">
                </asp:DropDownList>
                <font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                联系电话：
            </td>
            <td class="trl" colspan="3">
                <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_LXDH" class="divItem" runat="server">
                </div>
                <input type="hidden" value="<div><input type='text' name='lxdh' class='textbox' /><input type='button' value='删除' class='btnlxdhDel button' /></div>" />
            </td>
        </tr>
        <tr>
            <td class="trr">
                联系手机：
            </td>
            <td class="trl" colspan="3">
                <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_LXSJ" class="divItem" runat="server">
                </div>
                <input type="hidden" value="<div><input type='text' name='lxsj' class='textbox' /><input type='button' value='删除' class='btnlxsjDel button' /></div>" />
            </td>
        </tr>
        <tr>
            <td class="trr">
                身高：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_SG" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                体重：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_TZ" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                家庭成员：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_JTCY" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                加入黑名单：
            </td>
            <td class="trl">
                <asp:CheckBox runat="server" ID="CB_HMD" />
            </td>
        </tr>
        <tr>
            <td class="trr">
                健康证到期日：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_JKZDQR" CssClass="datetextbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                健康证编号：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_JKZBH" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                办理医院：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_BLYY" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                保险有效期：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_BXYXQ" CssClass="datetextbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                保险购买处：
            </td>
            <td class="trl">
                <asp:TextBox ID="TXT_BXGMC" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr">
                属相：
            </td>
            <td class="trl">
                <asp:DropDownList runat="server" CssClass="select" ID="DDL_SX"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">
                现住址：
            </td>
            <td class="trl" colspan="3">
                <asp:TextBox ID="TXT_XZZ" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>            
        </tr>
        <tr>
            <td class="trr">
                户籍地址：
            </td>
            <td class="trl" colspan="3"> 
                <asp:TextBox ID="TXT_HJDZ" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                银行账号：
            </td>
            <td class="trl" colspan="3">
                <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_YHZH" class="divItem" runat="server">
                </div>
                <input type="hidden" value="<div>银行帐号：<input type='text' name='yhzh' class='textbox' style='width:35%' />&nbsp;开户行：<input type='text' name='khh' class='textbox' style='width:35%' />&nbsp;<input type='button' value='删除' class='btnyhzhDel button' /></div>" />
            </td>
        </tr>       
         <tr>
            <td class="trr">
                服务工种：
            </td>
            <td class="trl">
                <asp:DropDownList ID="DDL_FWGZ" runat="server" CssClass="select">
                </asp:DropDownList>                
            </td>
            <td class="trr">
                服务内容：
            </td>
            <td class="trl">
                <asp:DropDownList ID="DDL_FWNR" runat="server" CssClass="select">
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="trr">
                服务时间段：
            </td>
            <td class="trl" colspan="3">
                <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_FWSJD" class="divItem" runat="server">
                
                </div>
                <input type="hidden" value="<div><input type='text' name='fwsjd' class='textbox' /><input type='button' value='删除' class='btnfwsjdDel button' /></div>" />                
            </td>
        </tr>
         <tr>
            <td class="trr">
                部门：
            </td>
            <td class="trl">
                <asp:TextBox runat="server" CssClass="textbox" ID="TXT_DEPT"></asp:TextBox>
            </td>
            <td class="trr">
                是否共享：
            </td>
            <td class="trl">
                <asp:CheckBox runat="server" ID="CB_GX" />
            </td>
        </tr>
        <tr>
            <td class="trr">
                分配：
            </td>
            <td class="trl" colspan="3">
                <asp:DropDownList ID="DDL_FP" runat="server" CssClass="select">
                </asp:DropDownList>
            </td>            
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td class="trl" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />                
                <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />                
            </td>
        </tr>
    </table>
</asp:Content>
