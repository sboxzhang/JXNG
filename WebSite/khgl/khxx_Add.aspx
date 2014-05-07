<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="khxx_Add.aspx.cs" Inherits="khgl_khxx_Add" Title="客户信息录入" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">

 <script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>
 <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
 <script type="text/javascript" src="../Scripts/Validator.js"></script>
 
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
        
            $('#<%=DDL_FWNR.ClientID.ToString() %>').change(function(){
                $('#div_BJ').css("display","none");
                $('#div_ZGET').css("display","none");
                $('#div_ZGYE').css("display","none");
                $('#div_YS').css("display","none");
                $('#div_ZGLR').css("display","none");
                $('#div_QT').css("display","none");
                switch($(this).children('option:selected').val())
                {
                    case "BJ":
                        $('#div_BJ').css("display","inline");
                         break;
                    case "ZGET":
                        $('#div_ZGET').css("display","inline");
                        break;
                    case "ZGYYR":
                        $('#div_ZGYE').css("display","inline");
                        break;
                    case "YS":
                        $('#div_YS').css("display","inline");
                        break;
                    case "ZGLR":
                        $('#div_ZGLR').css("display","inline");
                        break;
                    case "FWNRQT":
                        $('#div_QT').css("display","inline");
                        break;
                 }
            });
        });
  </script>

<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr" style="width:15%" >姓名：</td>
            <td class="trl"   style="width:35%">
                <asp:TextBox ID="TXT_USERNAME" dataType="Require" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr" style="width:15%" >服务工种：</td>
            <td class="trl"  style="width:35%">
                <asp:DropDownList ID="DDL_FWGZ" CssClass="select" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr" >身份证号：</td>
            <td class="trl" >
                <asp:TextBox ID="TXT_SFZH" dataType="Require" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr" >客户状态：</td>
            <td class="trl" >
                <asp:CheckBox  runat="server" ID="CB_KHZT" />
            </td>
        </tr>
        <tr>
            <td class="trr" >联系电话：</td>
            <td class="trl" >
                <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_LXDH" class="divItem" runat="server">
                </div>
                <input type="hidden" value="<div><input type='text' name='lxdh' class='textbox' /><input type='button' value='删除' class='btnlxdhDel button' /></div>" />
            </td>
            <td class="trr" >客户有效日期：</td>
            <td class="trl" >
                <asp:TextBox ID="TXT_KHYXRQ" CssClass="datetextbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr" >联系手机：</td>
            <td class="trl" >
                <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_LXSJ" class="divItem" runat="server">
                </div>
                <input type="hidden" value="<div><input type='text' name='lxsj' class='textbox' /><input type='button' value='删除' class='btnlxsjDel button' /></div>" 
            </td>
            <td class="trr" >加入黑名单：</td>
            <td class="trl" >
                <asp:CheckBox  runat="server" ID="CB_HMD" />
            </td>
        </tr>
        <tr>
            <td class="trr" >客户服务地址：</td>
            <td class="trl" colspan="3" >
                <asp:TextBox ID="TXT_KHFWDZ" dataType="Require" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr" >客户户籍地址：</td>
            <td class="trl" colspan="3" >
                <asp:TextBox ID="TXT_KHHJDZ" dataType="Require" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr" >银行信息：</td>
            <td class="trl" colspan="3">
                 <input type="button" class="btnAddItem button" value="添加" />
                <div id="DIV_YHXX" class="divItem" runat="server">
                </div>
                <input type="hidden" value="<div>银行帐号：<input type='text' name='yhzh' class='textbox' style='width:35%' />&nbsp;开户行：<input type='text' name='khh' class='textbox' style='width:35%' />&nbsp;<input type='button' value='删除' class='btnyhzhDel button' /></div>" />
            </td>
        </tr>
        <tr>
            <td class="trr" >服务内容：</td>
            <td class="trl" colspan="3">
                <asp:DropDownList ID="DDL_FWNR" CssClass="select" runat="server" Width="15%">
                </asp:DropDownList>
                服务详细：
                <div id="div_BJ" style="display:none">
                    <asp:DropDownList ID="DDL_BJCH" CssClass="select" runat="server" Width="15%">
                        <asp:ListItem Text="套房" Value="套房"></asp:ListItem>
                        <asp:ListItem Text="别墅" Value="别墅"></asp:ListItem>
                        <asp:ListItem Text="办公室" Value="办公室"></asp:ListItem>
                    </asp:DropDownList>
                    面积：<asp:TextBox ID="TXT_MJ" dataType="Require" CssClass="textbox" runat="server" Width="10%"></asp:TextBox>
                </div>
                <div id="div_ZGET" style="display:none">
                    <asp:TextBox ID="TXT_ETZS" dataType="Require" CssClass="textbox" runat="server" Width="5%"></asp:TextBox>周岁上学接送
                </div>
                <div id="div_ZGYE" style="display:none">
                    <asp:TextBox ID="TXT_YENL" dataType="Require" CssClass="textbox" runat="server" Width="5%"></asp:TextBox>个月
                </div>
                <div id="div_YS" style="display:none;" >
                    预产期<asp:TextBox ID="TXT_YCQ" dataType="Require" CssClass="datetextbox" runat="server" Width="10%"></asp:TextBox>
                    到岗日期<asp:TextBox ID="TXT_DGRQ" dataType="Require" CssClass="datetextbox" runat="server" Width="10%"></asp:TextBox>
                    到岗地点<asp:TextBox ID="TXT_DGDD" dataType="Require" CssClass="textbox" runat="server" Width="20%"></asp:TextBox>
                </div>
                <div id="div_ZGLR" style="display:none;">
                    性别
                    <asp:DropDownList ID="DDL_SEX" CssClass="select" runat="server" Width="15%">
                        <asp:ListItem Text="男" Value="男"></asp:ListItem>
                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    </asp:DropDownList>
                    年龄
                    <asp:TextBox ID="TXT_NL" dataType="Require" CssClass="textbox" runat="server" Width="5%"></asp:TextBox>
                    <asp:DropDownList ID="DDL_ZLZT" CssClass="select" runat="server" Width="15%">
                        <asp:ListItem Text="能自理" Value="能自理"></asp:ListItem>
                        <asp:ListItem Text="半自理" Value="半自理"></asp:ListItem>
                        <asp:ListItem Text="不能自理" Value="不能自理"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="div_QT" style="display:none;">
                    <asp:TextBox ID="TXT_QT" dataType="Require" CssClass="textbox" runat="server" Width="50%"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="trr" >部门：</td>
            <td class="trl" >
                <asp:TextBox ID="TXT_DEPT" dataType="Require" CssClass="textbox" runat="server"></asp:TextBox><font color="Red">*</font>
            </td>
            <td class="trr" >管理费：</td>
            <td class="trl" >
                <asp:DropDownList ID="DDL_GLF" CssClass="select" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr" >会员类型：</td>
            <td class="trl" colspan="3" >
                <asp:DropDownList ID="DDL_HYLX" CssClass="select" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="trr">&nbsp;</td>
            <td class="trl"  colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />                
                <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />     
            </td>
        </tr>
    </table>
</asp:Content>

