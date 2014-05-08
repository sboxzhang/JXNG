<%@ WebHandler Language="C#" Class="Unique" %>

using System;
using System.Web;
using VSM.DevFx.SysManage;
public class Unique : IHttpHandler {
    Dept _Dept = new Dept();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _Id = context.Request["DEPTID"].ToString();

        string Returns = "";
        DeptInfo info = _Dept.GetDeptInfo(_Id);

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