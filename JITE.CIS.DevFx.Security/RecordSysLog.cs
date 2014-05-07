using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using AYJZ.BusinessLogic;
using AYJZ.Entities;

namespace JITE.CIS.DevFx.Security
{
    public sealed class RecordSysLog : IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }
        void context_AcquireRequestState(object sender, EventArgs e)
        {
            // 获取应用程序
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            // 获取Url
            string requestUrl = application.Request.Url.ToString();
            string AppRelative = application.Request.AppRelativeCurrentExecutionFilePath;
            string Url = AppRelative.Substring(2);
            string requestPage = requestUrl.Substring(requestUrl.LastIndexOf('/') + 1);
            if (!string.IsNullOrEmpty(context.Request.QueryString["MoudleId"]))
            {
                try
                {
                    string Usercode = Authentication.GetUserCode();
                    string MoudleId = context.Request.QueryString["MoudleId"];
                    syslogLogic logic = new syslogLogic();
                    syslogInfo info = new syslogInfo();
                    info.MOUDLEID = Convert.ToInt64(MoudleId);
                    info.USERCODE = Usercode;
                    info.SJ = DateTime.Now;
                    logic.Insert(info);
                }
                catch (Exception ex)
                { 
                }
            }
            
        }
        #endregion
    }
}
