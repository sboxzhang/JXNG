using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JITE.CIS.DevFx.Security;
using AYJZ.DevFx.SysManage;
using JITE.CIS.Framework.Utilities;
using System.Text;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this.TXT_USERCODE.Focus();
            Session["UserInfo"] = null;
            SessionHelper.Clear();
            Server.MapPath("~");
            Response.Cookies.Add(new HttpCookie("CheckCode", ""));
            Cookie = Request.Cookies["UserInfo"];
            if (Cookie != null)
            {
                TXT_USERCODE.Text = Cookie.Values["userName"];
                TXT_PASSWORD.Attributes.Add("value", CookieHelper.DecryptQueryString(Cookie.Values["Pwd"].ToString()));
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //if (Request.Cookies["CheckCode"] == null)
        //{

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。');</script>");
        //    return;
        //}

        //if (String.Compare(Request.Cookies["CheckCode"].Value, txtCode.Text.ToString().Trim(), true) != 0)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('对不起，验证码错误！');</script>");
        //    return;
        //}
        if (Authentication.ValidUser(this.TXT_USERCODE.Text.Trim(), this.TXT_PASSWORD.Text.Trim()))
        {

            if (Session["UserInfo"] == null)
                Session["UserInfo"] = SessionHelper.Get("UserInfo");
            if(cbMM.Checked)
                this.SaveCookie(TXT_USERCODE.Text, CookieHelper.EncryptQueryString(Server.UrlEncode(TXT_PASSWORD.Text)));
            Context.Response.Redirect("Default.html"); // 重定向到用户申请的初始页面
        }
        else
        {
            // 用户身份未被确认时的代码
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('登录失败，用户名或密码错误！！');</script>");
        }
    }

    private HttpCookie Cookie = null;

    /// <summary>
    /// 记住用户名和密码
    /// </summary>
    private void SaveCookie(string userName, string Pwd)
    {
        Cookie = Request.Cookies["UserInfo"];

        if (Cookie == null || !Cookie.Values["userName"].Equals(userName))
        {
            Cookie = new HttpCookie("UserInfo");
            Cookie.Values.Add("userName", userName);
            Cookie.Values.Add("Pwd", Pwd);
            Cookie.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Add(Cookie);
        }
    }
}