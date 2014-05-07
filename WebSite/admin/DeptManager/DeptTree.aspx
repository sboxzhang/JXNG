<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeptTree.aspx.cs" Inherits="admin_DeptManager_DeptTree" Theme="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left:5px">
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                 <asp:TreeView ID="TreeView1" runat="server" Target="Rightbody"
                     EnableViewState="False" >
                 </asp:TreeView>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>