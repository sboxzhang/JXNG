using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    [Serializable]
    public class UserInfo
    {
        #region 变量定义
		///<summary>
		///
		///</summary>
		private decimal _UserId;
		///<summary>
		///
		///</summary>
		private string _UserCode = string.Empty;
		///<summary>
		///
		///</summary>
		private string _UserName = string.Empty;
		///<summary>
		///
		///</summary>
		private string _Password = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _DeptId;
        /// <summary>
        /// 
        /// </summary>
        private string _DeptName;
        
		///<summary>
		///
		///</summary>
		private string _Email = string.Empty;
		///<summary>
		///
		///</summary>
		private string _Address = string.Empty;
		///<summary>
		///
		///</summary>
		private string _PostCode = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _Telephone = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _Mobile = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _Company = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _PostName=string.Empty;

        private string _IsEnable = string.Empty;

        
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
        public decimal UserId
		{
			get {return _UserId;}
			set {_UserId = value;}
		}

		///<summary>
		///
		///</summary>
        public string UserCode
		{
			get {return _UserCode;}
			set {_UserCode = value;}
		}

		///<summary>
		///
		///</summary>
        public string UserName
		{
			get {return _UserName;}
			set {_UserName = value;}
		}

		///<summary>
		///
		///</summary>
        public string Password
		{
			get {return _Password;}
			set {_Password = value;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string DeptId
        {
            get { return _DeptId; }
            set { _DeptId = value; }
        }
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }
		///<summary>
		///
		///</summary>
        public string Email
		{
			get {return _Email;}
			set {_Email = value;}
		}

		///<summary>
		///
		///</summary>
        public string Address
		{
			get {return _Address;}
			set {_Address = value;}
		}

		///<summary>
		///
		///</summary>
        public string PostCode
		{
			get {return _PostCode;}
			set {_PostCode = value;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public string PostName
        {
            get { return _PostName; }
            set { _PostName = value; }
        }
        public string IsEnable
        {
            get { return _IsEnable; }
            set { _IsEnable = value; }
        }
        public string ZD { get; set; }
		#endregion
    }
}