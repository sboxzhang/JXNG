<%@ WebHandler Language="C#" Class="UniqueType" %>

using System;
using System.Web;
using AYJZ.DevFx.SysManage;
public class UniqueType : IHttpHandler {
    Dict _Dict = new Dict();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _Code = context.Request["CODE"].ToString();

        string Returns = "";
        DictTypeInfo info = _Dict.GetDictTypeInfo(_Code);

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