using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_Postmanager_Default : System.Web.UI.Page
{
    Post _Post = new Post();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridViewEx();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreatePost.aspx");
    }
    protected void BindGridViewEx()
    {
        this.GridView1.DataSource = this._Post.GetPostInfoAll();
        GridView1.DataBind();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("CreatePost.aspx?CODE=" + this.GridView1.DataKeys[e.NewEditIndex].Value);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Code = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (_Post.DeletePost(Code))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位删除成功！');</script>");
            this.BindGridViewEx();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位删除失败！');</script>");
        }
     }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            LinkButton lbnTemp = (LinkButton)e.Row.Cells[this.GridView1.Columns.Count - 1].Controls[0];
            lbnTemp.Attributes.Add("onclick", "javascript:return confirm('是否进行删除操作？');");
        }
    }
}