using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    public class ayjz_ddxx_spLogic
    {
        ayjz_ddxx_spDao dao = new ayjz_ddxx_spDao();
        public List<ayjz_ddxx_spInfo> Getayjz_ddxx_spList(string Where)
        {
            return dao.Getayjz_ddxx_spList(Where);
        }
        public ayjz_ddxx_spInfo Getayjz_ddxx_sp(long SPID)
        {
            return dao.Getayjz_ddxx_sp(SPID);
        }


        public bool ApprovalDDXX(ayjz_ddxx_spInfo ent)
        {
            ayjz_ddxx_spInfo infosp = new ayjz_ddxx_spInfo();
            ayjz_ddxxInfo info = new ayjz_ddxxInfo();
            TranAction o = new TranAction();
            infosp.SPID = ent.SPID;
            infosp.Action = 2;
            infosp.SPJG = ent.SPJG;
            o.Add(infosp);
            if (ent.SPJG.Equals("0"))
            {

                info.ID = ent.ID;
                info.Action = 2;
                info.SFSP = "0";
                o.Add(info);
                    
            }
            else
                switch (ent.CZLX)
                {
                    case "0":
                        info.AYID = ent.AYID;
                        info.AYXM = ent.AYXM;
                        info.BZ = ent.BZ;
                        info.DDZL = ent.DDZL;
                        info.DDZT = ent.DDZT;
                        info.DJ = ent.DJ;
                        info.DZ = ent.DZ;
                        info.EIID = ent.EIID;
                        info.ID = ent.ID;
                        info.JSSJ = ent.JSSJ;
                        info.KSSJ = ent.KSSJ;
                        info.LXDH = ent.LXDH;
                        info.LXR = ent.LXR;
                        info.NL = ent.NL;
                        infosp.SPJG = "0";
                        info.SHZH = ent.SHZH;
                        info.YPGZ = ent.YPGZ;
                        info.ZQ = ent.ZQ;
                        info.Action = 1;
                        o.Add(info);
                        break;
                    case "1":
                        info.AYID = ent.AYID;
                        info.AYXM = ent.AYXM;
                        info.BZ = ent.BZ;
                        info.DDZL = ent.DDZL;
                        info.DDZT = ent.DDZT;
                        info.DJ = ent.DJ;
                        info.DZ = ent.DZ;
                        info.EIID = ent.EIID;
                        info.ID = ent.ID;
                        info.JSSJ = ent.JSSJ;
                        info.KSSJ = ent.KSSJ;
                        info.LXDH = ent.LXDH;
                        info.LXR = ent.LXR;
                        info.NL = ent.NL;
                        infosp.SPJG = "0";
                        info.SHZH = ent.SHZH;
                        info.YPGZ = ent.YPGZ;
                        info.ZQ = ent.ZQ;
                        info.Action = 2;
                        o.Add(info);
                        break;
                    case "2":
                        info.ID = ent.ID;
                        info.Action = 3;
                        o.Add(info);
                        break;
                    default:
                        break;
                }
            return o.Excute() > 0;
            
        }
    }
}
