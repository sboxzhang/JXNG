<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="GrantMoudle.aspx.cs" Theme="Default" Inherits="admin_RoleManager_GrantMoudle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" runat="Server">

    <script type="text/javascript">
    function OnTreeNodeChecked() 
        { 
            var element = window.event.srcElement; 
            if (!IsCheckBox(element)) 
                return;
            var isChecked = element.checked;
            var tree = TV2_GetTreeById("<%=TreeView1.ClientID %>"); 
            var node = TV2_GetNode(tree,element); 

            TV2_SetChildNodesCheckStatus(node,isChecked); 

            var parent = TV2_GetParentNode(tree,node); 
            TV2_NodeOnChildNodeCheckedChanged(tree,parent,isChecked); 

        } 
    </script>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 0px;"
        class="StandardTable">
        <tr>
            <td class="trr" style="width: 15%; height: 26px">
                角色名称：
            </td>
            <td class="trl">
                <asp:TextBox ID="TextBox1" runat="server" Enabled=false></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="trr">
                &nbsp;
            </td>
            <td valign="top" class="trl" style="height: 400px">
                <asp:TreeView ID="TreeView1" runat="server" Target="Rightbody" NodeIndent="15" EnableViewState="true"
                    ImageSet="XPFileExplorer" ShowLines="True" ShowCheckBoxes="All">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                        NodeSpacing="0px" VerticalPadding="2px" />
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td class="trr" style="width: 15%; height: 26px">
                &nbsp;
            </td>
            <td class="trl">
                <asp:Button ID="BTN_SAVE" runat="server" Text="保存" OnClick="BTN_SAVE_Click" />
                <asp:Button ID="BTN_CANCEL" runat="server" Text="返回" OnClick="BTN_CANCEL_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
