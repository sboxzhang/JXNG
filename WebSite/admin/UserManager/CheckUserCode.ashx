<%@ WebHandler Language="C#" Class="CheckUserCode" %>

using System;
using System.Web;
using AYJZ.DevFx.SysManage;
public class CheckUserCode : IHttpHandler {
   User _User = new User();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string Code = context.Request["UserCode"].ToString();

        string Returns = "";

        UserInfo list = _User.GetUserInfoByUserCode(Code);

        if (list != null)
        {
            Returns = "false";
        }
        else
        {
            Returns = "true";
        }
        context.Response.Write(Returns);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}