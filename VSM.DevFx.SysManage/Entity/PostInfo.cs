using System;

namespace VSM.DevFx.SysManage
{
    [Serializable]
    public class PostInfo
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
        private string _IsEnable = string.Empty;

        public string IsEnable
        {
            get { return _IsEnable; }
            set { _IsEnable = value; }
        }
        private string _Remark = string.Empty;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
