using System;
using System.Collections.Generic;

using System.Text;

namespace VSM.DevFx.SysManage
{
    [Serializable]
    public class RoleInfo
    {
        private int _RoleId;

        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }
        private string _RoleName;

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
