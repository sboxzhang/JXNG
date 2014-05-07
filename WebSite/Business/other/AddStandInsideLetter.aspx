<%@ Page Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="AddStandInsideLetter.aspx.cs" Theme="Default" Inherits="business_other_AddStandInsideLetter" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
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
<table border="0" cellspacing="0" cellpadding="1" width="100%" class="StandardTable">
        <tr>
            <td class="trr">
                发送内容：</td>
            <td class="trl">
                <asp:TextBox ID="txtFSNR" TextMode="MultiLine" Rows="5" runat="server" Columns="50"></asp:TextBox><font color="#CC3300">*</font>
            </td>
        </tr>
        <tr>
            <td class="trr">
                接收人：</td>
            <td valign="top" class="trl">
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
            <td class="trr">
                &nbsp;</td>
            <td class="trl">
                <asp:Button ID="BTN_SAVEAS" runat="server" Text="保存并继续新增" 
                    onclick="BTN_SAVEAS_Click" OnClientClick="validator();"/>
                <asp:Button ID="BTN_SAVE" runat="server" Text="保存后返回" onclick="BTN_SAVE_Click" OnClientClick="validator();"/>
                <asp:Button ID="BTN_BACK" runat="server" Text="返回" onclick="Button3_Click" />
                <font style="font-style: italic; color: #FF0000">(有&quot;*&quot;标记处内容必填)</font>
            </td>
        </tr>
    </table>
</asp:Content>

