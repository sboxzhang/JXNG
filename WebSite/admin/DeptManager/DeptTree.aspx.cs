using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_DeptManager_DeptTree : System.Web.UI.Page
{
    Dept _Dept = new Dept();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitTree(this._Dept.GetDeptAll());
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void InitTree(List<DeptInfo> data)
    {
        this.TreeView1.Nodes.Clear();
        List<DeptInfo> ListInfo = data.FindAll(delegate(DeptInfo info)
        {
            return info.ParentId.ToString() == "0";
        });
        foreach (DeptInfo info in ListInfo)
        {
            TreeNode node = new TreeNode();
            node.Text = info.DeptName;
            node.Value = info.DeptId;
            node.NavigateUrl = "DeptManage.aspx?ID=" + node.Value;
            node.Target = "Rightbody";
            node.Expanded = true;
            this.TreeView1.Nodes.Add(node);
            AddReplies(data, node);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="node"></param>
    private void AddReplies(List<DeptInfo> data, TreeNode node)
    {
        List<DeptInfo> ListInfo = data.FindAll(delegate(DeptInfo info)
        {
            return info.ParentId.ToString() == node.Value;
        });
        foreach (DeptInfo info in ListInfo)
        {
            TreeNode replyNode = new TreeNode();
            replyNode.Text = info.DeptName;
            replyNode.Value = info.DeptId;
            replyNode.NavigateUrl = "DeptManage.aspx?ID=" + replyNode.Value;
            replyNode.Target = "Rightbody";
            replyNode.Expanded = true;
            node.ChildNodes.Add(replyNode);
            AddReplies(data, replyNode);
        }
    }
}
