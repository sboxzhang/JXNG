using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_DictManager_Default : PageBase
{
    Dict _Dict = new Dict();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDictType();
            BindGridView();
        }
        UGridView gv = new UGridView(this.GridView1);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGridView();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
    /// <summary>
    /// 
    /// </summary>
    private void BindGridView()
    {
        DictInfo info = new DictInfo();
        info.Code = this.TXT_CODE.Text.Trim();
        info.Name = this.TXT_NAME.Text.Trim();
        info.TypeCode = this.DDL_TYPE.SelectedValue;
        info.IsEnable = this.CHB_ISENABLE.Checked ? "Y" : "N";
        this.GridView1.DataSource = _Dict.GetDictInfoByCondition(info);
        this.GridView1.DataBind();
    }
    /// <summary>
    /// 
    /// </summary>
    private void BindDictType()
    {
        this.DDL_TYPE.DataSource = this._Dict.GetDictTypeInfoAll();
        this.DDL_TYPE.DataTextField = "Name";
        this.DDL_TYPE.DataValueField = "Code";
        this.DDL_TYPE.DataBind();
        this.DDL_TYPE.Items.Insert(0, new ListItem("---请选择---", ""));
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbnTemp = (LinkButton)e.Row.Cells[this.GridView1.Columns.Count - 1].Controls[0];
            lbnTemp.Attributes.Add("onclick", "javascript:return confirm('是否进行删除操作？');");
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("EditDict.aspx?CODE=" + this.GridView1.DataKeys[e.NewEditIndex]["Code"].ToString() + "&TYPE=" + this.GridView1.DataKeys[e.NewEditIndex]["TypeCode"].ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Code = this.GridView1.DataKeys[e.RowIndex]["Code"].ToString();
        string TypeCode = this.GridView1.DataKeys[e.RowIndex]["TypeCode"].ToString();
        if (_Dict.DeleteDict(Code, TypeCode))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典删除成功！');</script>");
            this.BindGridView();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('字典删除失败！');</script>");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateDict.aspx");
    }
}
