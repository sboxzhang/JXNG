using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using VSM.DevFx.SysManage;
using System.Data;

public partial class Shared_MasterPage : System.Web.UI.MasterPage
{
    //PubicMethods pb = new PubicMethods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string url = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
            if (Session["UserInfo"] == null && JITE.CIS.DevFx.Security.Authentication.GetUserCode().Equals(""))
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Clear();
                Response.Write("<script defer>window.alert('您没有权限进入本页或当前登录用户已过期！\\n请重新登录或与管理员联系！');parent.location='" + url + "';</script>");
                Response.End();
            }
            
        }
    }
}
