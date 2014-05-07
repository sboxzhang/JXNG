using System;
using System.Reflection;
namespace AYJZ.DataAccess
{
	public class CacheFactory
    {

        public static object CreateObject(string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);//????????
            if (objType == null)
            {
                try
                {
                    //Assembly ass = new Assembly();
                    objType = Assembly.GetExecutingAssembly().CreateInstance(CacheKey);//??????
                    DataCache.SetCache(CacheKey, objType);// ??????
                }
                catch (System.Exception ex)
                {
                    string str = ex.Message;//
                }
            }
            return objType;
        }
    }
}