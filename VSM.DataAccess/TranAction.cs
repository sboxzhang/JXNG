using System;
using System.Collections.Generic;
using System.Reflection;
using VSM.Entities;
using System.Data;
using JITE.CIS.Framework.DBProviders;
namespace VSM.DataAccess
{
    public class TranAction
    {
        protected List<BaseEntitie> sqlColltion = null;
        protected System.Data.IDbTransaction trans = null;
        public TranAction()
        {
            sqlColltion = new List<BaseEntitie>();
        }
        public void Add(BaseEntitie obj)
        {
            sqlColltion.Add(obj);
            return;
        }

        public void Add(List<BaseEntitie> obj)
        {
            sqlColltion.AddRange(obj);
            return;
        }
        public int Excute()
        {
            IDbConnection conn = DataBaseManage.GetdbConnection();
            int i_Return = 0;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                Tran();
                trans.Commit();
                return i_Return;
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                ex.ToString();
                return i_Return;
            }
            finally
            {
                if (trans != null) trans.Dispose();
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void Tran()
        {
            for (int i = 0; i < sqlColltion.Count; i++)
            {
                BaseEntitie obj = sqlColltion[i];
                Type type;
                type = obj.GetType();
                FastInvoke.FastInvokeHandler fastInvoker = FastInvoke.GetMethodInvoker(type.GetMethod("get_Action"));
                object o = fastInvoker(obj, null);
                string s_ClassName = type.Name.Replace("Info","Dao");
                IDataAccess o_Class = (IDataAccess)CacheFactory.CreateObject("AYJZ.DataAccess." + s_ClassName);
                int iReturn = 0;
                switch (Convert.ToInt16(o))
                {
                    case DatabaseActions.Insert:
                        iReturn = o_Class.Insert(obj, trans);
                        break;
                    case DatabaseActions.Update:
                        iReturn = o_Class.Update(obj, trans);
                        break;
                    case DatabaseActions.Delete:
                        iReturn = o_Class.Delete(obj, trans);
                        break;
                    case DatabaseActions.Query:
                        iReturn = o_Class.Insert(obj, trans);
                        break;
                    case DatabaseActions.Ingore:
                        iReturn = o_Class.Insert(obj, trans);
                        break;
                    default:
                        iReturn = 0;
                        break;
                }
            }
        }
    }
}