using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_RoleManager_EditRole : System.Web.UI.Page
{
    Role _Role = new Role();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            if (Request.QueryString["ROLEID"] != null)
            {
                ViewState["ROLEID"] = Request.QueryString["ROLEID"].ToString();
                GetInfo(ViewState["ROLEID"].ToString());
            }
        }
    }
    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        if (_Role.ModifyRole(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('角色信息修改成功！');</script>");
            Response.Redirect(ViewState["UrlReferrer"].ToString());
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('角色信息修改失败！');</script>");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }

    private void GetInfo(string Id)
    {
        RoleInfo info = _Role.GetRoleById(Id);
        this.TXT_REMARK.Text = info.Remark;
        this.TXT_ROLENAME.Text = info.RoleName;
    }

    private RoleInfo SetInfo()
    {
        RoleInfo info = new RoleInfo();
        info.RoleName = this.TXT_ROLENAME.Text.Trim();
        info.Remark = this.TXT_REMARK.Text.Trim();
        info.RoleId = int.Parse(ViewState["ROLEID"].ToString());
        return info;
    }
}
