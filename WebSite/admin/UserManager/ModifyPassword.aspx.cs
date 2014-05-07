using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JITE.CIS.DevFx.Security;
using AYJZ.DevFx.SysManage;
public partial class admin_UserManager_ModifyPassword : System.Web.UI.Page
{
    User _User = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.TXT_USERCODE.Focus();
            this.TXT_USERCODE.Text = Authentication.GetUserCode();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (_User.ModifyPassword(this.TXT_USERCODE.Text.Trim(), this.TXT_PASSWORD.Text.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('密码修改成功！');</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('密码修改失败！');</script>");
        }
    }
}
