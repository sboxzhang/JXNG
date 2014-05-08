using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using JITE.CIS.Framework.Utilities;
using VSM.DevFx.SysManage;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.RemoveAll();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthentication.SignOut();
            //authCookie.Domain = "/";
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);
            Response.Redirect("Login.aspx");
            Response.End();
        }
        catch(Exception ex)
        {
            var x = ex;
        }
        finally{
            Response.Redirect("Login.aspx");
            Response.End();
        }
    }
}