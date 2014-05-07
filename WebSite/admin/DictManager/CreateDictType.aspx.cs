using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_DictManager_CreateDictType : System.Web.UI.Page
{
    Dict _Dict = new Dict();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Response.Expires = 0;
        if (!Page.IsPostBack)
        {
            BindGridView();
            Page.Title = "字典类型维护";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGridView();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DictTypeInfo info = new DictTypeInfo();
        info.Code = this.TXT_CODE.Text.Trim();
        info.Name = this.TXT_NAME.Text.Trim();
        if (this.TXT_CODE.Enabled)
        { 
            if (_Dict.CreateDictType(info))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典类型新增成功！');</script>");
                BindGridView();
                ClearPage();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典类型新增失败！');</script>");
            }
        }
        else
        {
            if (_Dict.ModifyDictType(info))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典类型编辑成功！');</script>");
                BindGridView();
                ClearPage();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典类型编辑失败！');</script>");
            }
        }
        
        this.TXT_CODE.Enabled = true;
        
    }
    private void BindGridView()
    {
        this.GridView1.DataSource = _Dict.GetDictTypeInfoAll();
        this.GridView1.DataBind();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Code = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (_Dict.DeleteDictType(Code))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典类型删除成功！');</script>");
            this.BindGridView();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典类型删除失败！');</script>");
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.TXT_CODE.Enabled = false;
        this.TXT_CODE.Text = this.GridView1.DataKeys[e.NewEditIndex].Value.ToString();
        this.TXT_NAME.Text = this.GridView1.Rows[e.NewEditIndex].Cells[1].Text;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbnTemp = (LinkButton)e.Row.Cells[this.GridView1.Columns.Count - 1].Controls[0];
            lbnTemp.Attributes.Add("onclick", "javascript:return confirm('是否进行删除操作？');");
        }
    }
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
    }
}
