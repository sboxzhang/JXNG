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
using AYJZ.BusinessLogic;
using AYJZ.Entities;
using System.Collections.Generic;

public partial class business_other_IncomeSpending : System.Web.UI.Page
{
    ayjz_xrzcLogic logic = new ayjz_xrzcLogic();
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AspNetPager1.Visible = false;
            btnSave.Visible = false;
        }
        UGridView oView = new UGridView(gvTable);
    }
    #endregion

    #region 事件
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool bReturn = false;
        if (txtID.Text.Length == 0)
        {
            bReturn = logic.Add(GetXRZC());
        }
        else
        {
            bReturn = logic.Update(GetXRZC());
        }
        if (bReturn)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('信息保存成功！');</script>");
            Query();
            Clear();
            TabContainer1.ActiveTabIndex = 0;

        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('信息保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Query();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Clear();
        TabContainer1.ActiveTabIndex = 1;
        btnSave.Visible = true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTable_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Clear();
        string id = gvTable.DataKeys[e.NewEditIndex].Values["id"].ToString();
        LoadData(id);
        TabContainer1.ActiveTabIndex = 1;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Query();
    }
    #endregion

    #region 私有函数

    private void Query()
    {
        string where = "";
        if (!string.IsNullOrEmpty(txtJSSJS.Text))
        {
            where += string.Format(" and DATE_FORMAT(fssj,'%Y-%m-%d')>='{0}'", txtJSSJS.Text);
        }
        if (!string.IsNullOrEmpty(txtJSSJE.Text))
        {
            where += string.Format(" and DATE_FORMAT(fssj,'%Y-%m-%d')<='{0}'", txtJSSJE.Text);
        }
        if (!string.IsNullOrEmpty(ddlQLX.SelectedValue))
        {
            where += string.Format(" and lx='{0}'", ddlQLX.SelectedValue);
        }
        if (!string.IsNullOrEmpty(ddlQYHLX.SelectedValue))
        {
            where += string.Format(" and yhlx='{0}'", ddlQLX.SelectedValue);
        }
        if (!string.IsNullOrEmpty(txtQXM.Text))
        {
            where += string.Format(" and xm like '%{0}%'", txtQXM.Text);
        }

        List<ayjz_xrzcInfo> list = logic.Getayjz_xrzcList(where);
        try
        {
            int iCount = list.Count;
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = iCount;
            pds.DataSource = list;
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

    private ayjz_xrzcInfo GetXRZC()
    {
        ayjz_xrzcInfo info = new ayjz_xrzcInfo();
        if (txtID.Text.Length != 0)
            info.ID = Convert.ToInt64(txtID.Text);
        info.EIID = Convert.ToInt64(txtEIID.Text);
        info.YHLX = ddlYHLX.SelectedValue ;
        info.LX = ddlLX.SelectedValue ;
        info.XM= txtXM.Text ;
        info.JSSJ = txtSJ.Text;
        info.FS = txtFS.Text;
        info.TT = txtTT.Text ;
        info.JE = Convert.ToDecimal(txtJE.Text);
        return info;
    }
    private void LoadData(string id)
    {
        ayjz_xrzcInfo info = logic.Getayjz_xrzc(Convert.ToInt64(id));
        if (info != null)
        {
            txtID.Text = id;
            txtEIID.Text = info.EIID.ToString();
            ddlYHLX.SelectedValue = info.YHLX;
            ddlLX.SelectedValue = info.LX;
            txtXM.Text = info.XM;
            txtSJ.Text = info.JSSJ;
            txtFS.Text = info.FS;
            txtTT.Text = info.TT;
            txtJE.Text = info.JE.ToString() ;
            btnSave.Visible = true;
        }
    }

    #endregion
}
