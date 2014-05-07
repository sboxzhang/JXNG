using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
using JITE.CIS.Framework.Utilities;
using JITE.CIS.DevFx.Security;
public partial class LoadUserName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo info = new UserInfo();
        //info = (UserInfo)SessionHelper.Get("UserInfo");
        info = (UserInfo)Session["UserInfo"];
        if (info != null && (!string.IsNullOrEmpty(info.UserCode)))
            Response.Write(info.UserName);
        else
            Response.Write(Authentication.GetUserName());
    }
}
