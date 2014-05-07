using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_RoleManager_GrantMoudle : System.Web.UI.Page
{
    Moudle _Moudle = new Moudle();
    Power _Power = new Power();
    RoleMoudle _RoleMoudle = new RoleMoudle();
    private List<string> _list = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            InitTree(_Moudle.GetMoudleAll());
            ViewState["ROLEID"] = Request.QueryString["ROLEID"].ToString();
            this.TextBox1.Text = Server.UrlDecode(Request.QueryString["ROLENAME"].ToString().Trim().Replace("&nbsp;",""));
            ///
            ChoiceTreeNode(this.TreeView1.Nodes, _RoleMoudle.GetRoleMoudle(ViewState["ROLEID"].ToString()));
        }
        this.TreeView1.Attributes.Add("OnClick", "OnTreeNodeChecked(event)");
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
            node.NavigateUrl = "#";
            node.Expanded = true;
            node.ShowCheckBox = true;
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
            replyNode.NavigateUrl = "#";
            replyNode.Expanded = true;
            replyNode.ShowCheckBox = true;
            node.ChildNodes.Add(replyNode);
            AddReplies(data, replyNode);
        }
    }
    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        GetCheckedValue(this.TreeView1.Nodes);
        if (this._RoleMoudle.GrantRoleMoudle(int.Parse(ViewState["ROLEID"].ToString()),this._list))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('角色权限保存成功！');</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('角色权限保存失败！');</script>");
        }
    }
    protected void BTN_CANCEL_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }

    /// <summary>
    /// 取得选中得树节点
    /// </summary>
    /// <param name="tnc"></param>
    /// <returns></returns>
    protected void GetCheckedValue(TreeNodeCollection tnc)
    {
        foreach (TreeNode node in tnc)
        {
            if (node.ChildNodes.Count != 0)
            {
                if (node.Checked)
                {
                    this._list.Add(node.Value);
                }
                GetCheckedValue(node.ChildNodes);
            }
            else
            {
                if (node.Checked)
                {
                    this._list.Add(node.Value);
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tnc"></param>
    protected void ChoiceTreeNode(TreeNodeCollection tnc,List<RoleMoudleInfo> info)
    {
        foreach (TreeNode node in tnc)
        {
            RoleMoudleInfo Info = info.Find(delegate(RoleMoudleInfo info1)
            {
                return info1.MoudleId == int.Parse(node.Value);
            });
            if (node.ChildNodes.Count != 0)
            {
                if (Info!=null)
                {
                    node.Checked = true;
                }
                ChoiceTreeNode(node.ChildNodes, info);
            }
            else
            {
                if (Info != null)
                {
                    node.Checked = true;
                }
            }
        }
    }
}