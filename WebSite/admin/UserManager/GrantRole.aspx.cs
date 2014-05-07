using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_UserManager_GrantRole : System.Web.UI.Page
{
    Role _Role = new Role();
    UserRole _UserRole = new UserRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            this.CBL_ROLE.DataSource = this._Role.GetRoleAll();
            this.CBL_ROLE.DataTextField = "RoleName";
            this.CBL_ROLE.DataValueField = "RoleId";
            this.CBL_ROLE.DataBind();

            if (Request.QueryString["USERID"] != null)
            {
                ViewState["USERID"] = Request.QueryString["USERID"].ToString();
                Check();
            }
            if (Request.QueryString["USERNAME"] != null)
                this.TXT_USERNAME.Text = Server.UrlDecode(Request.QueryString["USERNAME"].ToString());
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        foreach (ListItem item in CBL_ROLE.Items)
        {
            if (item.Selected)
            {
                list.Add(item.Value);
            }
        }
        if (_UserRole.ModifyUserRole(int.Parse(ViewState["USERID"].ToString()), list))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('用户角色赋予成功！');</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('用户角色赋予失败！');</script>");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    private void Check()
    {
        List<UserRoleInfo> list = _UserRole.GetUserRole(ViewState["USERID"].ToString());
        foreach (ListItem item in CBL_ROLE.Items)
        {
            UserRoleInfo info = list.Find(delegate(UserRoleInfo info2)
            {
                return info2.RoleId == item.Value;
            });
            if (info != null)
            {
                item.Selected = true;
            }
        }
    }
}