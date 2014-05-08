using System;
using System.Collections.Generic;

using System.Text;

namespace VSM.DevFx.SysManage
{
    [Serializable]
    public class DeptInfo
    {
        private string _DeptId = string.Empty;

        public string DeptId
        {
            get { return _DeptId; }
            set { _DeptId = value; }
        }

        private string _DeptName = string.Empty;

        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }

        private string _ParentId = string.Empty;

        public string ParentId
        {
            get { return _ParentId; }
            set { _ParentId = value; }
        }

        private string _Remark = string.Empty;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _DeptType = string.Empty;
        public string DeptType
        {
            get { return _DeptType; }
            set { _DeptType = value; }
        }
    }
}
