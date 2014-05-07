using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.BusinessLogic;
using AYJZ.Entities;

public partial class business_OrderManage_OrderApproval : System.Web.UI.Page
{
    ayjz_ddxx_spLogic logic = new ayjz_ddxx_spLogic();
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
            btnApproval.Visible = false;
        }
    }
    #endregion

    #region 事件
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
    protected void btnApproval_Click(object sender, EventArgs e)
    {

        if (logic.ApprovalDDXX(getData()))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单审批成功！');</script>");
            Query();
            Clear();
            TabContainer1.ActiveTabIndex = 0;
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单审批失败！');</script>");
        }
    }


    protected void gvTable_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = gvTable.DataKeys[e.NewEditIndex].Value.ToString();
        SetData(id);
    }

    private void SetData(string id)
    {
        ayjz_ddxxLogic log = new ayjz_ddxxLogic();
        ayjz_ddxxInfo info = new ayjz_ddxxInfo();
        ayjz_ddxx_spInfo infosp = new ayjz_ddxx_spInfo();
        infosp = logic.Getayjz_ddxx_sp(Convert.ToInt64(id));
        txtSPID.Text = id;
        if (infosp.ID != null)
            info = log.Getayjz_ddxx(infosp.ID);
        if (infosp != null)
        {
            lblDDZLSP.Text = infosp.DDZL;
            lblYPGZSP.Text = infosp.YPGZ;
            lblLXRSP.Text = infosp.LXR;
            lblLXDHSP.Text = infosp.LXDH;
            lblLXDZSP.Text = infosp.DZ;
            lblAYXMSP.Text = infosp.AYXM;
            lblNLSP.Text = infosp.NL.ToString();
            lblDJSP.Text = infosp.DJ.ToString();
            lblKSSJSP.Text = infosp.KSSJ;
            lblJSSJSP.Text = infosp.JSSJ;
            lblZQSP.Text = infosp.ZQ.ToString();
            txtBZSP.Text = infosp.BZ;
            TabContainer1.ActiveTabIndex = 1;
            btnApproval.Visible = true;
        }
        if (info != null)
        {
            lblDDZL.Text = info.DDZL;
            lblYPGZ.Text = info.YPGZ;
            lblLXR.Text = info.LXR;
            lblLXDH.Text = info.LXDH;
            lblLXDZ.Text = info.DZ;
            lblAYXM.Text = info.AYXM;
            lblNL.Text = info.NL.ToString();
            lblDJ.Text = info.DJ.ToString();
            lblKSSJ.Text = info.KSSJ;
            lblJSSJ.Text = info.JSSJ;
            lblZQ.Text = info.ZQ.ToString();
            txtBZ.Text = info.BZ;
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
        where += "";
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
        List<ayjz_ddxx_spInfo> list = logic.Getayjz_ddxx_spList(where);
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
        btnApproval.Visible = false;
    }

    #endregion

    private ayjz_ddxx_spInfo getData()
    {
        ayjz_ddxx_spInfo infosp = new ayjz_ddxx_spInfo();
        infosp = logic.Getayjz_ddxx_sp(Convert.ToInt64(txtSPID.Text));
        //if (infosp != null)
        //{
        //    info.AYID = infosp.AYID;
        //    info.AYXM = infosp.AYXM;
        //    info.BZ = infosp.BZ;
        //    info.DDZL = infosp.DDZL;
        //    info.DDZT = infosp.DDZT;
        //    info.DJ = infosp.DJ;
        //    info.DZ = infosp.DZ;
        //    info.EIID = infosp.EIID;
        //    info.ID = infosp.ID;
        //    info.JSSJ = infosp.JSSJ;
        //    info.KSSJ = infosp.KSSJ;
        //    info.LXDH = infosp.LXDH;
        //    info.LXR = infosp.LXR;
        //    info.NL = infosp.NL;
        infosp.SPJG = rblSPJG.SelectedValue;
        //    info.SHZH = infosp.SHZH;
        //    info.YPGZ = infosp.YPGZ;
        //    info.ZQ = infosp.ZQ;
        //}
        return infosp;
    }

    private void BindData()
    {

    }
    #endregion
    
}
