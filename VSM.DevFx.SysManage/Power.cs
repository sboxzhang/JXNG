using System;
using System.Collections.Generic;

using System.Text;

namespace VSM.DevFx.SysManage
{
    public class Power
    {
        PowerDao _Dao = new PowerDao();
        public bool CreatePower(PowerInfo info)
        {
            return _Dao.CreatePower(info);
        }
        public bool ModifyPower(PowerInfo info)
        {
            return _Dao.ModifyPower(info);
        }
        public bool DeletePower(string PowerId)
        {
            return _Dao.DeletePower(PowerId);
        }
        public PowerInfo GetPowerInfo(string PowerId)
        {
            return _Dao.GetPowerInfo(PowerId);
        }
        public List<PowerInfo> GetPowerByMoudleId(string MoudleId)
        {
            return _Dao.GetPowerByMoudleId(MoudleId);
        }
    }
}
