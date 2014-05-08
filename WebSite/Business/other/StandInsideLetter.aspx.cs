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
using VSM.BusinessLogic;
using VSM.Entities;
using JITE.CIS.DevFx.Security;
public partial class business_other_StandInsideLetter : System.Web.UI.Page
{
    AYJZ_XXTSLogic logic = new AYJZ_XXTSLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AspNetPager1.Visible = false;
            btnSave.Visible = false;
        }
    }

    #region 事件
    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddStandInsideLetter.aspx");
    }
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Query();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Query();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ayjz_xxtsInfo info = new ayjz_xxtsInfo();
        info.CLJG = rblCLJG.SelectedValue;
        info.QLSJ = DateTime.Now;
        if (logic.Update(info) > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('处理成功！');</script>");
            Query();
            Clear();
            TabContainer1.ActiveTabIndex = 0;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('处理失败！');</script>");
        }
    }

    protected void gvTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.gvTable.DataKeys[e.RowIndex].Value.ToString();
        if (logic.Delete(id))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功！');</script>");
            this.Query();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败！');</script>");
        }
    }
    protected void gvTable_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = gvTable.DataKeys[e.NewEditIndex].Value.ToString();
        ayjz_xxtsInfo info = new ayjz_xxtsInfo();
        info.ID = Convert.ToInt64(id);
        info.BJ = "1";
        logic.Update(info);
        info = logic.Getayjz_xxts(Convert.ToInt64(id));
        txtID.Text = id;
        if (info != null)
        {
            txtFSNR.Text = info.FSNR;
            lblFSSJ.Text = info.FSSJ.HasValue ? info.FSSJ.Value.ToString("yyyy-MM-dd HH;mm:ss") : "";
            TabContainer1.ActiveTabIndex = 1;
            btnSave.Visible = true;
        }
    }

    protected void gvTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbnTemp = (LinkButton)e.Row.Cells[this.gvTable.Columns.Count - 1].Controls[0];
            lbnTemp.Attributes.Add("onclick", "javascript:return confirm('是否进行删除操作？');");
        }
    }
    #endregion

    #region 私有函数
    private void Query()
    {
        string where = "";
        where += string.Format(" and jsr='{0}'", Authentication.GetUserCode());
        if (!string.IsNullOrEmpty(txtFSSJS.Text))
        {
            where += string.Format(" and DATE_FORMAT(fssj,'%Y-%m-%d')>='{0}'",txtFSSJS.Text);
        }
        if (!string.IsNullOrEmpty(txtFSSJE.Text))
        {
            where += string.Format(" and DATE_FORMAT(fssj,'%Y-%m-%d')<='{0}'", txtFSSJE.Text);
        }
        if (!string.IsNullOrEmpty(ddlQCLJG.SelectedValue))
        {
            where += string.Format(" and cljg='{0}'", ddlQCLJG.SelectedValue);
        }
        DataTable list = logic.GetData(where);
        try
        {
            int iCount = list.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = iCount;
            pds.DataSource = list.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            if (iCount > AspNetPager1.PageSize)
            {
                AspNetPager1.Visible = true;
            }
            else
            {
                AspNetPager1.Visible = false;
            }

            gvTable.DataSource = pds;
            gvTable.DataBind();
        }
        catch (Exception)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('绑定数据时出错！');</script>");
            return;
        }
    }

    #region 清除
    /// <summary>
    /// 清除
    /// </summary>
    private void Clear()
    {
        PageBase.ClearAllContent(TabPanel2);
        btnSave.Visible = false;
    }

    #endregion
    #endregion
}
