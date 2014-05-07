using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    [Serializable]
    public class RoleMoudleInfo
    {
        #region 变量定义
		///<summary>
		///
		///</summary>
		private decimal _RoleId;
		///<summary>
		///
		///</summary>
		private decimal _MoudleId;
		///<summary>
		///
		///</summary>
		private decimal _PowerValue;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public RoleMoudleInfo()
		{
		}
		///<summary>
		///
		///</summary>
        public RoleMoudleInfo
		(
			decimal roleid,
			decimal moudleid,
			decimal powervalue
		)
		{
			_RoleId     = roleid;
			_MoudleId   = moudleid;
			_PowerValue = powervalue;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
        public decimal RoleId
		{
			get {return _RoleId;}
			set {_RoleId = value;}
		}

		///<summary>
		///
		///</summary>
        public decimal MoudleId
		{
			get {return _MoudleId;}
			set {_MoudleId = value;}
		}

		///<summary>
		///
		///</summary>
        public decimal PowerValue
		{
			get {return _PowerValue;}
			set {_PowerValue = value;}
		}
	
		#endregion
    }
}
