<%@ WebHandler Language="C#" Class="Unique" %>

using System;
using System.Web;
using AYJZ.DevFx.SysManage;
public class Unique : IHttpHandler {
    Dict _Dict = new Dict();
    /// <summary>
    /// 字典代码唯一性检测
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _Code = context.Request["CODE"].ToString();
        string _Type = context.Request["TYPE"].ToString();
        string Returns = "";
        DictInfo info = _Dict.GetDictInfo(_Code, _Type);

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