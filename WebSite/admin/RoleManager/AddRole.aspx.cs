using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_RoleManager_AddRole : System.Web.UI.Page
{
    Role _Role = new Role();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    protected void BTN_SAVEAS_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    private void Save()
    {
        if (_Role.CreateRole(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增角色保存成功！');</script>");
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增角色保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
    }
    private RoleInfo SetInfo()
    {
        RoleInfo info = new RoleInfo();
        info.RoleName = this.TXT_ROLENAME.Text.Trim();
        info.Remark = this.TXT_REMARK.Text.Trim();
        return info;
    }
}
