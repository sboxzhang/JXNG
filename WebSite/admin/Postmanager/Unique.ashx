<%@ WebHandler Language="C#" Class="Unique" %>

using System;
using System.Web;
using AYJZ.DevFx.SysManage;
public class Unique : IHttpHandler {
    Post _Post = new Post();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _Code = context.Request["CODE"].ToString();

        string Returns = "";
        PostInfo info = _Post.GetPostInfo(_Code);

        if (info != null)
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