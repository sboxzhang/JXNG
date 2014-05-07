using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;

public partial class findpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        User _user = new User();
        List<UserInfo> list = _user.GetUserByCondition(new UserInfo() { Email=txtYX.Text.Trim() });
        if (list != null && list.Count > 0)
        {
            NetMail nm = new NetMail();
            //服务器信息
            nm.From = WPFBase.From;
            nm.SMTP = WPFBase.SMTP;
            nm.PassWord = WPFBase.PassWord;
            //收信人信息
            nm.To = list[0].Email;
            //nm.Cc = WPFBase.Cc;
            //邮件内容
            nm.Body = string.Format("亲爱的{0},您的用户名{1};密码:{2}", "曾地理", "123", "123");
            nm.Subject = "帐号密码找回";
            bool result = nm.SenMail();
            if (result)
            {
                Response.Write("<script type='text/javascript'>alert('发送成功！');</script>");//发送成功则提示返回当前页面；

            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('发送失败！');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('抱歉，没找到您输入的帐号信息，请确认后重新输入！');</script>");
        }
    }
}
