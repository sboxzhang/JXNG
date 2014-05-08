using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using VSM.DevFx.SysManage;
using JITE.CIS.Framework.Utilities;
namespace JITE.CIS.DevFx.Security
{
    /// <summary>
    /// 用户登录验证模块
    /// </summary>
    public class Authentication
    {
        public Authentication()
        {
            
        }
        /// <summary>
        /// 取得用户角色
        /// </summary>
        /// <returns></returns>
        public static string GetUserRole()
        {
            string Role = "";
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                        (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        // 取存储在票据中的用户数据，在这里其实就是用户的角色 
                        Role = ticket.UserData;
                    }
                }
            }
            return Role;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetUserCode()
        {
            string UserCode = "";
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                        (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        // 取存储在票据中的用户数据，在这里其实就是用户的角色 
                        UserCode = ticket.Name;
                    }
                }
            }
            return UserCode;
        }
        /// <summary>
        /// 验证用户是否经过登录认证
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidUser(string userName, string password)
        {
            
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                User _User = new User();
                UserInfo info = _User.Login(userName, password);
                //password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                //string realPassword = Users.GetUser(userName).Password;
                if (info != null)
                {
                    SessionHelper.Add("UserInfo", info);
                    //if(!GenericCache<string, UserInfo>.ContainsKey(info.UserCode))
                    //    GenericCache<string, UserInfo>.Add(info.UserCode, info);
                    string userRoles = UserToRole(info.UserId.ToString()); //调用UserToRole方法来获取role字符串
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        info.UserCode.ToString(),
                        DateTime.Now,
                        DateTime.Now.AddDays(1),
                        false,
                        userRoles//可以将Roles按","分割成字符串，写入cookie
                        );
                    string data = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, data);
                    cookie.Path = FormsAuthentication.FormsCookiePath;
                    cookie.Domain = FormsAuthentication.CookieDomain;
                    cookie.Expires = ticket.Expiration;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 此方法用来获得的用户对应的所有的role用逗号分割的一个字符串
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        private static string UserToRole(string UserId)
        {
            string Roles = "";
            UserRole _UserRole = new UserRole();
            List<UserRoleInfo> list = _UserRole.GetUserRole(UserId);
            //相应的代码
            foreach (UserRoleInfo info in list)
            {
                if (Roles == "")
                    Roles = info.RoleId;
                else
                    Roles = Roles + "," + info.RoleId;
            }
            return Roles;
        }

        public static string GetUserName()
        {
            User _User= new User();
            string UserCode = GetUserCode();
            UserInfo info = _User.GetUserInfoByUserCode(UserCode);
            if (info != null)
                return info.UserName;
            return "";
        }
    }
}