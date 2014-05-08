<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using VSM.DevFx.SysManage;
using JITE.CIS.Framework.Utilities;
using System.Web.Security;
using JITE.CIS.DevFx.Security;


public class Handler : IHttpHandler {
    Moudle _Moudle = new Moudle();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string strTitle = "";
        string strMenus = "";
        //string strUserName = "Admin";
        StringBuilder str = new StringBuilder();
        
        GetMenuHtml( (long)100, ref strTitle, ref strMenus);
        str.Append("<div id=\"htmlSubHeader\" class=\"subHeader\" >");
        str.Append("<div style='text-align:center; '>功能列表</div>");
        str.Append("</div>");
        str.Append("<div id=\"htmlMenuPanel\" class=\"navPanel\" >");
        str.Append(strTitle);
        str.Append("</div>");
        str.Append("<div id=\"htmlMenuSelect\" class=\"navSelect\">");
        str.Append("<div class=\"navSeparator\"> </div>");
        str.Append("<div id='htmlMenu' style='vertical-align :middle;'>");
        str.Append(strMenus);
        str.Append("</div>");
        str.Append("</div>");
        context.Response.Write(str.ToString());
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
    /// <summary>
    /// 获取普通用户菜单HTML
    /// </summary>
    /// <param name="lngUserID"></param>
    /// <param name="strHeader"></param>
    /// <param name="strMens"></param>
    public void GetMenuHtml(long lngUserID, ref string strHeader, ref string strMens)
    {
        StringBuilder sb = new StringBuilder("");

        StringBuilder sbTitle = new StringBuilder("");

        List<MoudleInfo> list = this._Moudle.GetMoudleByRole(JITE.CIS.DevFx.Security.Authentication.GetUserRole());

        List<MoudleInfo> list1 = list.FindAll(delegate(MoudleInfo info1)
        {
            return info1.ParentId == "0";
        });

        List<MoudleInfo> list2 = list.FindAll(delegate(MoudleInfo info2)
        {
            return info2.ParentId == list1[0].MoudleId;
        });

        foreach (MoudleInfo info in list1)
        {
            sb.Append(@"<a href='#' onclick='GetMune(" + info.MoudleId + ");'><img src='" + info.Img + "' alt='' />" + info.MoudleName + "</a> ");
        }
        foreach (MoudleInfo info3 in list2)
        {
            sbTitle.Append(@"<a href='" + info3.Url + "?MoudleId=" + info3.MoudleId + "' onclick='GetLocation(" + info3.MoudleId + ");' target='PageFrame'><img src='" + info3.Img + "' alt='' />" + info3.MoudleName + "</a> ");
        }

        strHeader = sbTitle.ToString();
        strMens = sb.ToString();
    }

}