using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_UserManager_EditUser : System.Web.UI.Page
{
    User _User = new User();
    Dept _Dept = new Dept();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindPost();
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            BuildTree(this._Dept.GetDeptAll());
            if (Request.QueryString["USERID"] != null)
            {
                ViewState["USERID"] = Request.QueryString["USERID"].ToString();
                GetInfo();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (_User.ModifyUser(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('用户信息修改成功！');</script>");
            //Response.Redirect(ViewState["UrlReferrer"].ToString());
            //this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('用户信息修改失败！');</script>");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
        //this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");

    }
    private void GetInfo()
    {
        UserInfo info = _User.GetUserInfo(ViewState["USERID"].ToString());
        if (info != null)
        {
            this.TXT_USERCODE.Text = info.UserCode;
            this.TXT_USERNAME.Text = info.UserName;
            this.TXT_TELEPHONE.Text = info.Telephone;
            this.DDL_POST.SelectedValue = info.PostCode;
            this.TXT_MOBILE.Text = info.Mobile;
            this.TXT_EMAIL.Text = info.Email;
            this.TXT_ADDRESS.Text = info.Address;
            this.DDL_DEPT.SelectedValue = info.DeptId.ToString();
        }
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
        info.UserId = int.Parse(ViewState["USERID"].ToString());
        info.ZD = "";
        return info;
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
        this.DDL_DEPT.DataBind();
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
    private void BindPost()
    {
        Post _Post = new Post();
        this.DDL_POST.DataSource = _Post.GetPostInfoAll();
        this.DDL_POST.DataTextField = "Name";
        this.DDL_POST.DataValueField = "Code";
        this.DDL_POST.DataBind();
        this.DDL_POST.Items.Insert(0, new ListItem("---请选择---", ""));
    }
}
