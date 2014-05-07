using System;
using System.Collections.Generic;

using System.Text;
using System.Transactions;

namespace AYJZ.DevFx.SysManage
{
    public class User
    {
        UserDao _user = new UserDao();
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUser(UserInfo user)
        {
            if (user != null)
                return _user.CreateUser(user);
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyUser(UserInfo user)
        {
            if (user != null)
                return _user.ModifyUser(user);
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteUser(string UserId)
        {
            if (UserId.Trim() != "")
                return _user.DeleteUser(UserId);
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserAll()
        {
            return _user.GetUserAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserByCondition(UserInfo Condition)
        {
            return _user.GetUserByCondition(Condition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string id)
        {
            if (id.Trim() != "")
                return _user.GetUserInfo(id);
            else
                return null;
        }
        public UserInfo GetUserInfoByUserCode(string UserCode)
        {
            if (UserCode.Trim() != "")
                return _user.GetUserInfoByUserCode(UserCode);
            else
                return null;
        }
        public UserInfo Login(string UserCode, string Password)
        {
            return _user.Login(UserCode, Password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OldPassword"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        public bool ModifyPassword(string UserCode, string NewPassword)
        {
            return _user.ModifyPassword(UserCode, NewPassword);
        }
    }
}