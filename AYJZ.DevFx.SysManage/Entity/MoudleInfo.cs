using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    [Serializable]
    public class MoudleInfo
    {
        #region 变量定义
		///<summary>
		///
		///</summary>
        private string _MoudleId = string.Empty;
		///<summary>
		///
		///</summary>
		private string _MoudleName = string.Empty;
		///<summary>
		///
		///</summary>
		private string _Url = string.Empty;
		///<summary>
		///
		///</summary>
        private string _ParentId = string.Empty;
		///<summary>
		///
		///</summary>
		private string _Img = string.Empty;
		///<summary>
		///
		///</summary>
		private string _IsEnable = string.Empty;
		///<summary>
		///
		///</summary>
		private string _IsRoot = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _Sort = string.Empty;

        
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public MoudleInfo()
		{
		}
		///<summary>
		///
		///</summary>
        public MoudleInfo
		(
            string moudleid,
			string moudlename,
			string url,
            string parentid,
			string img,
			string isenable,
			string isroot,
            string sort
		)
		{
			_MoudleId   = moudleid;
			_MoudleName = moudlename;
			_Url        = url;
			_ParentId   = parentid;
			_Img        = img;
			_IsEnable   = isenable;
			_IsRoot     = isroot;
            _Sort = sort;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
        public string MoudleId
		{
			get {return _MoudleId;}
			set {_MoudleId = value;}
		}

		///<summary>
		///
		///</summary>
        public string MoudleName
		{
			get {return _MoudleName;}
			set {_MoudleName = value;}
		}

		///<summary>
		///
		///</summary>
		public string Url
		{
			get {return _Url;}
			set {_Url = value;}
		}

		///<summary>
		///
		///</summary>
        public string ParentId
		{
			get {return _ParentId;}
			set {_ParentId = value;}
		}

		///<summary>
		///
		///</summary>
        public string Img
		{
			get {return _Img;}
			set {_Img = value;}
		}

		///<summary>
		///
		///</summary>
        public string IsEnable
		{
			get {return _IsEnable;}
			set {_IsEnable = value;}
		}

		///<summary>
		///
		///</summary>
        public string IsRoot
		{
			get {return _IsRoot;}
			set {_IsRoot = value;}
		}
        public string Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }
        public string YWLX { get; set; }
		#endregion
    }
}