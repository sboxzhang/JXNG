using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    public class Moudle
    {
        MoudleDao _Dao = new MoudleDao();

        public bool CreateMoudle(MoudleInfo info)
        {
            return _Dao.CreateMoudle(info);
        }

        public bool ModifyMoudle(MoudleInfo info)
        {
            return _Dao.ModifyMoudle(info);
        }
        public bool DeleteMoudle(string MoudleId)
        {
            return _Dao.DeleteMoudle(MoudleId);
        }
        public bool ModifyMoudleSort(Dictionary<string, string> Dic)
        {
            return _Dao.ModifyMoudleSort(Dic);
        }
        public MoudleInfo GetMoudleInfo(string MoudleId)
        {
            return _Dao.GetMoudleInfo(MoudleId);
        }
        public List<MoudleInfo> GetMoudleAll()
        {
            return _Dao.GetMoudleAll();
        }

        public List<MoudleInfo> GetMoudleByRole(List<string> RoleId)
        {
            return _Dao.GetMoudleByRole(RoleId);
        }

        public List<MoudleInfo> GetMoudleByRole(string RoleId)
        {
            return _Dao.GetMoudleByRole(RoleId);
        }

        public string GetCurrentLocation(string MoudleId)
        {
            return _Dao.GetCurrentLocation(MoudleId);
        }
        public string Exists(string strUsl)
        {
            if (strUsl.Trim() == "")
                return "";
            return _Dao.Exists(strUsl);
        }
    }
}
