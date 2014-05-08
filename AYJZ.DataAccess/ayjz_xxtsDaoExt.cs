using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JITE.CIS.Framework.DBProviders;
using VSM.Entities;

namespace VSM.DataAccess
{
    public partial class ayjz_xxtsDao
    {
        public DataTable GetData(string where)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("  select a.* ");
            sb.Append(",(select username from userinfo t where a.fsr=t.usercode ) fsrmc ");
            sb.Append(" from AYJZ_XXTS a where 1=1 ");
            sb.Append(where);
            DataSet ds = DataBaseManage.ExecuteDataSet(sb.ToString());
            if(ds!=null && ds.Tables.Count>0)
                return ds.Tables[0];
            return new DataTable();
        }
        public bool Add(ayjz_xxtsInfo info, List<string> users)
        {
            TranAction t = new TranAction();
            List<ayjz_xxtsInfo> list = new List<ayjz_xxtsInfo>();
            foreach (string o in users)
            {
                ayjz_xxtsInfo a = new ayjz_xxtsInfo();
                a.FSR = info.FSR;
                a.FSSJ = info.FSSJ;
                a.FSNR = info.FSNR;
                a.JSR = o;
                t.Add(a);
            }
            return t.Excute() > 0;
        }
    }
}
