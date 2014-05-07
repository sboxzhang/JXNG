using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    [Serializable]
    public class PowerInfo
    {
        #region 变量定义
		///<summary>
		///
		///</summary>
        private string _PowerId = string.Empty;
		///<summary>
		///
		///</summary>
		private string _PowerName = string.Empty;
		///<summary>
		///
		///</summary>
		private int _PowerValue;
		///<summary>
		///
		///</summary>
        private string _MoudleId = string.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public PowerInfo()
		{
		}
		///<summary>
		///
		///</summary>
        public PowerInfo
		(
            string powerid,
			string powername,
			int powervalue,
            string moudleid
		)
		{
			_PowerId    = powerid;
			_PowerName  = powername;
			_PowerValue = powervalue;
			_MoudleId   = moudleid;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
        public string PowerId
		{
			get {return _PowerId;}
			set {_PowerId = value;}
		}

		///<summary>
		///
		///</summary>
        public string PowerName
		{
			get {return _PowerName;}
			set {_PowerName = value;}
		}

		///<summary>
		///
		///</summary>
        public int PowerValue
		{
			get {return _PowerValue;}
			set {_PowerValue = value;}
		}

		///<summary>
		///
		///</summary>
        public string MoudleId
		{
			get {return _MoudleId;}
			set {_MoudleId = value;}
		}
	
		#endregion
    }
}
