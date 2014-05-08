using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
using System.Reflection;
using System.Data;
public partial class admin_RoleManager_Default : System.Web.UI.Page
{
    Role _Role = new Role();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridViewEx();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddRole.aspx");
    }
    protected void BindGridViewEx()
    {
        this.GridView1.DataSource = this._Role.GetRoleAll();
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("EditRole.aspx?ROLEID=" + this.GridView1.DataKeys[e.NewEditIndex].Value);
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Response.Redirect("GrantMoudle.aspx?ROLEID=" + this.GridView1.DataKeys[e.NewSelectedIndex].Value + "&ROLENAME=" + Server.UrlEncode(this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Text));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string RoleId = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (_Role.DeleteRole(RoleId))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('记录删除成功！');</script>");
            this.BindGridViewEx();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('记录删除失败！');</script>");
        }
        //Response.Redirect("GrantPower.aspx?ROLEID=" + this.GridView1.DataKeys[e.RowIndex].Value + "&ROLENAME=" + Server.UrlEncode(this.GridView1.Rows[e.RowIndex].Cells[1].Text));
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGridViewEx();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbnTemp = (LinkButton)e.Row.Cells[3].Controls[0];
            lbnTemp.Attributes.Add("onclick", "javascript:return confirm('是否进行删除操作？');");
        }
    }
}