using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    [Serializable]
    public class UserRoleInfo
    {
        #region 变量定义
		///<summary>
		///
		///</summary>
		private string _UserId;
		///<summary>
		///
		///</summary>
        private string _RoleId;

        private string _RoleName;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public UserRoleInfo()
		{
		}
		///<summary>
		///
		///</summary>
        public UserRoleInfo
		(
            string userid,
            string roleid,
            string rolename
		)
		{
			_UserId = userid;
			_RoleId = roleid;
            _RoleName = rolename;
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
        public string UserId
		{
			get {return _UserId;}
			set {_UserId = value;}
		}

		///<summary>
		///
		///</summary>
        public string RoleId
		{
			get {return _RoleId;}
			set {_RoleId = value;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
		#endregion
    }
}
