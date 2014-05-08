using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VSM.DevFx.SysManage;
using System.Collections.Generic;
using VSM.Entities;
using VSM.BusinessLogic;
using JITE.CIS.DevFx.Security;

public partial class business_other_AddStandInsideLetter : System.Web.UI.Page
{
    Dept _dape = new Dept();
    User _user = new User();
    List<UserInfo> _Info = new List<UserInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
           List<DeptInfo> deptInfo = _dape.GetDeptAll();
           _Info = _user.GetUserAll();
           InitTree(deptInfo);
        }
        this.TreeView1.Attributes.Add("OnClick", "OnTreeNodeChecked(event)");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }

    protected void BTN_SAVEAS_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    private void Save()
    {
        AYJZ_XXTSLogic logic = new AYJZ_XXTSLogic();
        GetCheckedValue(this.TreeView1.Nodes);
        if (logic.Add(SetInfo(), _list))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('站内短信发送成功！');</script>");
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('站内短信发送失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
    }
    private ayjz_xxtsInfo SetInfo()
    {
        ayjz_xxtsInfo info = new ayjz_xxtsInfo();
        info.FSNR = txtFSNR.Text;
        info.FSSJ = DateTime.Now;
        info.FSR = Authentication.GetUserCode();
        return info;
    }
    List<string> _list = new List<string>();
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
                    if (node.Value != "")
                        _list.Add(node.Value);
                }
                GetCheckedValue(node.ChildNodes);
            }
            else
            {
                if (node.Checked)
                {
                    if (node.Value != "")
                        _list.Add(node.Value);
                }
            }
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
            node.Value = "";
            node.NavigateUrl = "#";
            node.Expanded = true;
            node.ShowCheckBox = true;
            this.TreeView1.Nodes.Add(node);
            List<UserInfo> ListInfo2 = _Info.FindAll(delegate(UserInfo info2)
            {
                return info2.DeptId == info.DeptId;
            });
            foreach (UserInfo o in ListInfo2)
            {
                TreeNode replyNode = new TreeNode();
                replyNode.Text = o.UserName;
                replyNode.Value = o.UserCode;
                replyNode.NavigateUrl = "#";
                replyNode.Expanded = true;
                replyNode.ShowCheckBox = true;
                node.ChildNodes.Add(replyNode);
            }
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
            node.Text = info.DeptName;
            node.Value = "";
            replyNode.NavigateUrl = "#";
            replyNode.Expanded = true;
            replyNode.ShowCheckBox = true;
            node.ChildNodes.Add(replyNode);
            AddReplies(data, replyNode);
            List<UserInfo> ListInfo2 = _Info.FindAll(delegate(UserInfo info3)
            {
                return info3.DeptId == info.DeptId;
            });
            foreach (UserInfo o in ListInfo2)
            {
                TreeNode replyNode2 = new TreeNode();
                replyNode2.Text = o.UserName;
                replyNode2.Value = o.UserCode;
                replyNode2.NavigateUrl = "#";
                replyNode2.Expanded = true;
                replyNode2.ShowCheckBox = true;
                node.ChildNodes.Add(replyNode);
            }
        }
    }
}
