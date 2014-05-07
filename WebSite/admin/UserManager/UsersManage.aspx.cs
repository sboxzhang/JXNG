using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using AYJZ.DevFx.SysManage;
public partial class admin_UsersManage : System.Web.UI.Page
{
    User _User = new User();
    Dept _Dept = new Dept();
    UserRole _UserRole = new UserRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindPost();
            BuildTree(this._Dept.GetDeptAll());
            BindGridViewEx();
        }
    }
    protected void BindGridViewEx()
    {
        UserInfo info = new UserInfo();
        info.UserCode = this.TXT_USERCODE.Text.Trim();
        info.UserName = this.TXT_USERNAME.Text.Trim();
        info.Mobile = "";
        info.PostCode = this.DDL_POST.SelectedValue;
        info.Telephone = "";
        info.Email = "";
        info.DeptId = this.DDL_DEPT.SelectedValue;
        info.Address = "";
        info.IsEnable = "";

        this.GridView1.DataSource = this._User.GetUserByCondition(info);
        this.GridView1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindGridViewEx();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUsers.aspx");
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGridViewEx();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("EditUser.aspx?USERID=" + this.GridView1.DataKeys[e.NewEditIndex].Value);
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Response.Redirect("GrantRole.aspx?USERID=" + this.GridView1.DataKeys[e.NewSelectedIndex].Value + "&USERNAME=" + Server.UrlEncode(this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Text));
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string UserId = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (_User.DeleteUser(UserId))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('记录删除成功！');</script>");
            this.BindGridViewEx();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('记录删除失败！');</script>");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //
            string UserId = DataBinder.Eval(e.Row.DataItem, "UserId").ToString().Trim();
            DropDownList mDropDownList = (DropDownList)e.Row.Cells[8].Controls[1];
            mDropDownList.DataSource = _UserRole.GetUserRole(UserId); ;
            mDropDownList.DataTextField = "RoleName";
            mDropDownList.DataBind();
            //
            LinkButton lbnTemp = (LinkButton)e.Row.Cells[this.GridView1.Columns.Count - 1].Controls[0];
            lbnTemp.Attributes.Add("onclick", "javascript:return confirm('是否进行删除操作？');");
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        PageBase.ClearAllContent(this.Page);
    }
}