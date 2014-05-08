using System;

namespace VSM.DevFx.SysManage
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DictInfo
    {
        private string _Code = string.Empty;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Remark = string.Empty;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        private string _TypeCode = string.Empty;

        public string TypeCode
        {
            get { return _TypeCode; }
            set { _TypeCode = value; }
        }
        private string _TypeName = string.Empty;
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        private decimal _Sort;

        public decimal Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }
        private string _IsEnable = string.Empty;

        public string IsEnable
        {
            get { return _IsEnable; }
            set { _IsEnable = value; }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DictTypeInfo
    {
        private string _Code = string.Empty;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
