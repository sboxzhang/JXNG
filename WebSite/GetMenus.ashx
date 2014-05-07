<%@ WebHandler Language="C#" Class="GetMenus" %>

using System;
using System.Web;
using AYJZ.DevFx.SysManage;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class GetMenus : IHttpHandler {

    Moudle _Moudle = new Moudle();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string id = context.Request["ID"].ToString();

        StringBuilder sb = new StringBuilder("");

        List<MoudleInfo> list = this._Moudle.GetMoudleByRole(JITE.CIS.DevFx.Security.Authentication.GetUserRole());

        list = list.FindAll(delegate(MoudleInfo info1)
        {
            return info1.ParentId == id;
        });
        foreach (MoudleInfo info in list)
        {
            sb.Append(@"<a href='" + info.Url.Replace("~\\", "") + "?MoudleId=" + info.MoudleId + "' onclick='GetLocation(" + info.MoudleId + ");' target='PageFrame'><img src='" + info.Img + "' alt='' />" + info.MoudleName + "</a> ");
        }

        context.Response.Write(sb.ToString());
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}