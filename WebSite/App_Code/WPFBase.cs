using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///WPFBase 的摘要说明
/// </summary>
public static class WPFBase
{

    /// <summary>
    /// 发件人地址
    /// </summary>
    public static string From { get { return System.Configuration.ConfigurationManager.AppSettings["From"]; } }

    /// <summary>
    /// 发件邮箱smtp服务器
    /// </summary>
    public static string SMTP { get { return System.Configuration.ConfigurationManager.AppSettings["SMTP"]; } }

    /// <summary>
    /// 发件人邮箱密码
    /// </summary>
    public static string PassWord { get { return System.Configuration.ConfigurationManager.AppSettings["PassWord"]; } }

    /// <summary>
    /// 收件人邮箱,多个邮箱用英文分号隔开
    /// </summary>
    //public static string To { get { return ""; } }

    /// <summary>
    /// 测试地址
    /// </summary>
    public static string To { get { return ""; } }

    /// <summary>
    /// 抄送地址
    /// </summary>
    public static string Cc { get { return ""; } }

}
