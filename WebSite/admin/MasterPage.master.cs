using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (!Authentication.IsAuthenticated())
            //{
            //    FormsAuthentication.SignOut();
            //    Session.Clear();
            //    Session.Abandon();
            //    Response.Clear();
            //    Response.Write("<script defer>window.alert('您没有权限进入本页或当前登录用户已过期！\\n请重新登录或与管理员联系！');</script>");            
            //    Response.Redirect("~/Login.aspx");
            //    Response.End();
            //}
        }
    }
}
