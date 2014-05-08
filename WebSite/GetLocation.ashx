<%@ WebHandler Language="C#" Class="GetLocation" %>

using System;
using System.Web;
using VSM.DevFx.SysManage;
public class GetLocation : IHttpHandler {
    Moudle _Moudle = new Moudle();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id = context.Request["ID"].ToString();
        string Location = _Moudle.GetCurrentLocation(id);
        context.Response.Write(Location);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}