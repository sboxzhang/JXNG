<%@ Page Title="" Language="C#" Theme="Default" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="SystemConfigManage.aspx.cs" Inherits="admin_SystemConfigManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function CheckFileType() {
        var objButton = document.getElementById("ctl00_MainPage_btnImgOK"); //上传按钮
        var objFileUpload = document.getElementById('ctl00_MainPage_fuImg'); //FileUpload
        var objMSG = document.getElementById('msg'); //显示提示信息用的DIV
        var FileName = new String(objFileUpload.value); //文件名
        var extension = new String(FileName.substring(FileName.lastIndexOf(".") + 1, FileName.length)); //文件扩展名

        if (extension == "exe" || extension == "EXE")//你可以添加扩展名
        {
           
        }
        else {
            objFileUpload.outerHTML = objFileUpload.outerHTML;
            alert("请选择图片浏览程序(*.exe|*.EXE)!");
        }
    }

    function CheckFileType2() {
        var objButton = document.getElementById("ctl00_MainPage_btnImgOK"); //上传按钮
        var objFileUpload = document.getElementById('ctl00_MainPage_fuVideo'); //FileUpload
        var objMSG = document.getElementById('msg'); //显示提示信息用的DIV
        var FileName = new String(objFileUpload.value); //文件名
        var extension = new String(FileName.substring(FileName.lastIndexOf(".") + 1, FileName.length)); //文件扩展名

        if (extension == "exe" || extension == "EXE")//你可以添加扩展名
        {

        }
        else {
            objFileUpload.outerHTML = objFileUpload.outerHTML;
            alert("请选择图片浏览程序(*.exe|*.EXE)!");
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" Runat="Server">
<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
    <tr>
        <td class="trr">
            图片浏览程序：</td>
        <td class="trl">
            <asp:Label ID="lblImg" runat="server" Text=""></asp:Label><br />
            <asp:FileUpload ID="fuImg" Width="400px" runat="server" onChange="CheckFileType();" />
            <asp:Button ID="btnImgOK" runat="server"  Text="确定" onclick="btnImgOK_Click" />
        </td>
    </tr>
    <tr>
        <td class="trr">
            视频/音频播发程序：</td>
        <td class="trl">
        <asp:Label ID="lblVideo" runat="server" Text=""></asp:Label><br />
             <asp:FileUpload ID="fuVideo" Width="400px" runat="server" onChange="CheckFileType2();" />
            <asp:Button ID="btnVideoOK" runat="server"  Text="确定" onclick="btnVideoOK_Click" 
                 style="height: 26px" /><div id="Div1"></div>
        </td>
    </tr>
 </table>
</asp:Content>

