using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;

namespace JITE.CIS.DevFx.Security
{
    /// NonReduplicatePostModule 的摘要说明。
    /// </summary>
    public class NonReduplicatePostModule : System.Web.IHttpModule
    {
        private const string hiddenFileName = "__NonReduplicatePostModule__";
        private const string maskdivScriptRelativeUrl = "~/Scripts/maskDiv.js";
        private const string onformSubmit = "Evlon.MaskDiv.Instance.show();";
        private HttpApplication context = null;

        #region IHttpModule 成员

        public void Init(HttpApplication context)
        {
            this.context = context;
            this.context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
        }

        public void Dispose()
        {
            this.context.PreRequestHandlerExecute -= new EventHandler(context_PreRequestHandlerExecute);
        }

        #endregion

        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication webApp = sender as HttpApplication;
            if (webApp != null)
            {
                //已经处理过,提示用户不要重复提交
                Page page = webApp.Context.Handler as Page;
                if (page != null)
                {
                    page.PreRender += new EventHandler(page_PreRender);

                    //找到Page,添加时间
                    if (webApp.Request.Form[hiddenFileName] != null)
                    {
                        string flag = webApp.Request.Form[hiddenFileName].ToString();
                        if (webApp.Context.Cache.Get(flag) != null)
                        {
                            if (page is IReduplicatePostHandler)
                            {
                                webApp.Context.Handler = new ReduplicatePostHandler((IReduplicatePostHandler)page);
                            }
                            else
                            {
                                webApp.Context.Handler = new ReduplicatePostHandler();
                            }
                        }
                        else
                        {
                            //放进缓存中,表示已经被处理过,在一分钟后自动移聊(可再次提交)
                            webApp.Context.Cache.Add(flag, DateTime.Now, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(1), System.Web.Caching.CacheItemPriority.Normal, null);
                        }
                    }
                }
            }

        }



        private void page_PreRender(object sender, EventArgs e)
        {
            Page page = sender as Page;
            if (page != null)
            {
                //找到Page,添加时间
                page.RegisterHiddenField(hiddenFileName, string.Format("{0}_{1}_{2}", page.Session.SessionID.GetHashCode(), page.GetType().GetHashCode(), DateTime.Now.Ticks));
                //表单UI显示　MASKDIV
                page.RegisterClientScriptBlock("maskdiv_include", "<script type='text/javascript' src='" + page.ResolveUrl(maskdivScriptRelativeUrl) + "' ></script>");
                page.RegisterOnSubmitStatement("maskdiv", onformSubmit);
            }

        }
    }

    public interface IReduplicatePostHandler
    {
        void OnReduplicatePost(HttpContext context, EventArgs e);
    }

    internal class ReduplicatePostHandler : IHttpHandler
    {
        private IReduplicatePostHandler handler = null;
        internal ReduplicatePostHandler(IReduplicatePostHandler handler)
        {
            this.handler = handler;
        }

        internal ReduplicatePostHandler()
        {

        }

        #region IHttpHandler 成员

        public void ProcessRequest(HttpContext context)
        {
            if (handler != null)
            {
                handler.OnReduplicatePost(context, new EventArgs());
            }
            else
            {
                context.Response.Write("不要重复提交");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion

    }

}
