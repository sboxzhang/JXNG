using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_ModuleManager_ModuleTree : System.Web.UI.Page
{
    Moudle _Moudle = new Moudle();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitTree(this._Moudle.GetMoudleAll());
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void InitTree(List<MoudleInfo> data)
    {
        this.TreeView1.Nodes.Clear();
        List<MoudleInfo> ListInfo = data.FindAll(delegate(MoudleInfo info)
        {
            return info.ParentId.ToString() == "0";
        });
        foreach (MoudleInfo info in ListInfo)
        {
            TreeNode node = new TreeNode();
            node.Text = info.MoudleName;
            node.Value = info.MoudleId;
            node.NavigateUrl = "MoudleManage.aspx?ID=" + node.Value;
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
    private void AddReplies(List<MoudleInfo> data, TreeNode node)
    {
        List<MoudleInfo> ListInfo = data.FindAll(delegate(MoudleInfo info)
        {
            return info.ParentId.ToString() == node.Value;
        });
        foreach (MoudleInfo info in ListInfo)
        {
            TreeNode replyNode = new TreeNode();
            replyNode.Text = info.MoudleName;
            replyNode.Value = info.MoudleId;
            replyNode.NavigateUrl = "MoudleManage.aspx?ID=" + replyNode.Value;
            replyNode.Target = "Rightbody";
            replyNode.Expanded = true;
            node.ChildNodes.Add(replyNode);
            AddReplies(data, replyNode);
        }
    }
}
