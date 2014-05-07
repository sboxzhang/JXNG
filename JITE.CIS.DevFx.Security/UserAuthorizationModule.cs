using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Web;
using AYJZ.DevFx.SysManage;
using System.IO;
using System.Web.Services.Protocols;
using JITE.CIS.Framework.Utilities;
namespace JITE.CIS.DevFx.Security
{
    /// <summary>
    /// 授权验证
    /// </summary>
    public sealed class UserAuthorizationModule : IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
            //throw new NotImplementedException();
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
            // If the request contains an HTTP_SOAPACTION 
            // header, look at this message.

            if (context.Request.ServerVariables["HTTP_SOAPACTION"] == null)
            {
                if(requestPage.Contains(".aspx"))
                // 检查用户是否已经登录
                if (!HttpContext.Current.User.Identity.IsAuthenticated && (!SessionHelper.Exists("UserInfo")))
                {
                    if (requestPage != "Login.aspx")
                        application.Server.Transfer("~/Login.aspx");
                }
                else if (requestPage != "Login.aspx")
                {
                    Moudle _Moudle = new Moudle();
                    string MOUDLEID = _Moudle.Exists(Url);
                    if (MOUDLEID != "")
                    {
                        string UserCode = HttpContext.Current.User.Identity.Name;
                        string Roles = Authentication.GetUserRole();
                        //if (application.Request.QueryString["MOUDLEID"] == null)
                        //{
                        //    application.CompleteRequest();
                        //    application.Response.Write(string.Format("对不起！{0}，您无权访问此模块！", UserCode));
                        //}
                        //else
                        //{
                            RoleMoudle _RoleMoudle = new RoleMoudle();
                            if (_RoleMoudle.GetRolePower(Roles, MOUDLEID).MoudleId == 0)
                            {
                                application.CompleteRequest();
                                application.Response.Write(string.Format("对不起！{0}，您无权访问此模块！", UserCode));
                            }
                        //}
                    }
                }
            }
            else
            {
                Stream HttpStream = context.Request.InputStream;
                // Save the current position of stream.
                long posStream = HttpStream.Position;
                // Load the body of the HTTP message
                // into an XML document.
                XmlDocument dom = new XmlDocument();
                string soapUser;
                string soapPassword;
                try
                {
                    dom.Load(HttpStream);
                    // Reset the stream position.
                    HttpStream.Position = posStream;
                    // Bind to the Authentication header.
                    soapUser = dom.GetElementsByTagName("User").Item(0).InnerText;
                    soapPassword = dom.GetElementsByTagName("Password").Item(0).InnerText;
                    if (Authentication.ValidUser(soapUser, soapPassword))
                    {
                        return;
                    }
                    else
                    {
                        //application.CompleteRequest();
                        //application.Response.Write(string.Format("对不起！{0}，您无权访问此服务！", soapUser));
                        throw new SoapException(string.Format("对不起！{0}，您无权访问此服务！", soapUser), SoapException.ServerFaultCode);

                    }
                    // Raise the custom global.asax event.
                    //OnAuthenticate(new WebServiceAuthenticationEvent(context, soapUser, soapPassword));
                }
                catch (Exception ex)
                { 
                    // Reset the position of stream.
                    HttpStream.Position = posStream;
                    // Throw a SOAP exception.
                    XmlQualifiedName name = new XmlQualifiedName("Load");
                    SoapException soapException = new SoapException("Unable to read SOAP request", name, ex);
                    throw soapException;
                }
            }
        }
        #endregion
    }
}