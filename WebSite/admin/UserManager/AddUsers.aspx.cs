using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_AddUsers : System.Web.UI.Page
{
    User _User = new User();
    Dept _Dept = new Dept();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            BuildTree(_Dept.GetDeptAll());
            BindPost();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (_User.CreateUser(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增用户保存成功！');</script>");
            Response.Redirect(ViewState["UrlReferrer"].ToString());
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增用户保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMultipleSave_Click(object sender, EventArgs e)
    {
        if (_User.CreateUser(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增用户保存成功！');</script>");
            this.ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增用户保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private UserInfo SetInfo()
    {
        UserInfo info = new UserInfo();
        info.UserCode = this.TXT_USERCODE.Text.Trim();
        info.UserName = this.TXT_USERNAME.Text.Trim();
        info.Mobile = this.TXT_MOBILE.Text.Trim();
        info.PostCode = this.DDL_POST.SelectedValue;
        info.Telephone = this.TXT_TELEPHONE.Text.Trim();
        info.Email = this.TXT_EMAIL.Text.Trim();
        info.DeptId = this.DDL_DEPT.SelectedValue;
        info.Address = this.TXT_ADDRESS.Text.Trim();
        info.ZD = "";
        return info;
    }
    /// <summary>
    /// 
    /// </summary>
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
    }
    private void BindPost()
    { 
        Post _Post=new Post();
        this.DDL_POST.DataSource = _Post.GetPostInfoAll();
        this.DDL_POST.DataTextField = "Name";
        this.DDL_POST.DataValueField = "Code";
        this.DDL_POST.DataBind();
        this.DDL_POST.Items.Insert(0,new ListItem("---请选择---", ""));
    }
    /// <summary>
    /// 创建树
    /// </summary>
    /// <param name="sqlstring">查询字符串</param>
    private void BuildTree(List<DeptInfo> data)
    {
        this.DDL_DEPT.Items.Clear();
        //加载树
        this.DDL_DEPT.Items.Add(new ListItem("---请选择---", "0"));
        List<DeptInfo> ListInfo = data.FindAll(delegate(DeptInfo info)
        {
            return info.ParentId.ToString() == "0";
        });
        foreach (DeptInfo info in ListInfo)
        {
            string nodeid = info.DeptId;
            string text = info.DeptName;
            text = "╋" + text;
            this.DDL_DEPT.Items.Add(new ListItem(text, nodeid));
            string sonparentid = nodeid;
            string blank = "├";
            BindNode(sonparentid, data, blank);
        }
        this.DataBind();
    }


    /// <summary>
    /// 创建树结点
    /// </summary>
    /// <param name="sonparentid">当前数据项</param>
    /// <param name="dt">数据表</param>
    /// <param name="blank">空白符</param>
    private void BindNode(string sonparentid, List<DeptInfo> data, string blank)
    {
        List<DeptInfo> ListInfo = data.FindAll(delegate(DeptInfo info)
        {
            return info.ParentId.ToString() == sonparentid;
        });

        foreach (DeptInfo info in ListInfo)
        {
            string nodevalue = info.DeptId;
            string text = info.DeptName;
            text = blank + "『" + text + "』";
            this.DDL_DEPT.Items.Add(new ListItem(text, nodevalue));
            string blankNode = blank + "─";
            BindNode(nodevalue, data, blankNode);
        }
    }
}