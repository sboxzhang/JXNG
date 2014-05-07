using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.BusinessLogic;
using AYJZ.Entities;

public partial class business_other_QueryAYZHXX : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion 

    #region  
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ayjz_ayzhxxLogic logic = new ayjz_ayzhxxLogic();
        List<ayjz_ayzhxxInfo> list = logic.Getayjz_ayzhxxList(string.Format(" And xm like '%{0}%'",txtXM.Text));
        gvTable.DataSource = list;
        gvTable.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string sReturn = "";
        for (int i = 0; i < gvTable.Rows.Count; i++)
        {
            RadioButton rb = gvTable.Rows[i].FindControl("rbSelect") as RadioButton;
            if (rb != null)
            {
                sReturn = gvTable.Rows[i].Cells[0].Text;
                sReturn += "||" + gvTable.Rows[i].Cells[1].Text;
            }
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "returnValue='" + sReturn + "';window.opener =null;window.close();</script>");
    }
    protected void gvTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    #endregion
}
