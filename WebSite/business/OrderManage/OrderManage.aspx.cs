using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AYJZ.Entities;
using AYJZ.BusinessLogic;

public partial class business_OrderManage_OrderManage : System.Web.UI.Page
{
    ayjz_ddxxLogic logic = new ayjz_ddxxLogic();

    #region Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AspNetPager1.Visible = false;
            btnSave.Visible = false;
        }
    }
    #endregion

    #region 事件
    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
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
        if (logic.Insert(getData()))
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

    protected void gvTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.gvTable.DataKeys[e.RowIndex].Value.ToString();
        if (true)
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
        SetData(id);
    }

    private void SetData(string id)
    {
        ayjz_ddxxInfo info = new ayjz_ddxxInfo();

        info = logic.Getayjz_ddxx(Convert.ToInt64(id));
        txtID.Text = id;
        if (info != null)
        {
            ddlDDZL.SelectedValue = info.DDZL;
            ddlYPGZ.SelectedValue = info.YPGZ;
            txtEIID.Text = info.EIID.ToString();
            txtLXR.Text = info.LXR;
            txtLXDZ.Text = info.DZ;
            txtAYID.Text = info.AYID.ToString();
            txtAYXM.Text = info.AYXM;
            txtNL.Text = info.NL.ToString();
            txtDJ.Text = info.DJ.ToString();
            txtKSSJ.Text = info.KSSJ;
            txtJSSJ.Text = info.JSSJ;
            txtZQ.Text = info.ZQ.ToString();
            txtBZ.Text = info.BZ;
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
    #region  查询
    private void Query()
    {
        string where = "";
        if (!string.IsNullOrEmpty(txtXM.Text))
        {
            where += string.Format(" and ayxm like '%{0}%'", txtXM.Text);
        }
        if (!string.IsNullOrEmpty(ddlQDDLX.SelectedValue))
        {
            where += string.Format(" and ddlx='{0}'", ddlQDDLX.SelectedValue);
        }
        if (!string.IsNullOrEmpty(ddlQDDZT.SelectedValue))
        {
            where += string.Format(" and ddzt='{0}'", ddlQDDZT.SelectedValue);
        }
        List<ayjz_ddxxInfo> list = logic.Getayjz_ddxxList(where);
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
    #endregion

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

    private ayjz_ddxx_spInfo getData()
    {
        ayjz_ddxx_spInfo info = new ayjz_ddxx_spInfo();
        if (txtID.Text.Length != 0)
        {
            info.ID = Convert.ToInt64(txtID.Text);
            info.CZLX = "2";//修改
        }
        else
            info.CZLX = "1";//新增
        if (info != null)
        {
            info.DDZL = ddlDDZL.SelectedValue;
            info.YPGZ = ddlYPGZ.SelectedValue;
            if(txtEIID.Text != "") info.EIID = Convert.ToInt64(txtEIID.Text);
            info.LXR = txtLXR.Text ;
            info.DZ = txtLXDZ.Text;
            if (txtAYID.Text != "") info.AYID = Convert.ToInt64(txtAYID.Text);
            info.AYXM = txtAYXM.Text ;

            if (txtNL.Text.Trim() != "") info.NL = Convert.ToInt64(txtNL.Text.Trim());
            if (txtDJ.Text.Trim() != "") info.DJ = Convert.ToDecimal(txtDJ.Text.Trim());

            info.KSSJ = txtKSSJ.Text;
            info.JSSJ = txtJSSJ.Text;
            if (txtZQ.Text != "") info.ZQ = Convert.ToInt64(txtZQ.Text);
            info.BZ = txtBZ.Text ;
        }
        return info;
    }

    private void BindData()
    {
        
    }
    #endregion
}
