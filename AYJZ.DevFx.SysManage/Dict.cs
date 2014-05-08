using System;
using System.Collections.Generic;

using System.Text;

namespace VSM.DevFx.SysManage
{
    public class Dict
    {
        DictDao _dao = new DictDao();
        #region ======字典维护=====
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreateDict(DictInfo info)
        {
            if (info == null)
                return false;
            if (info.Code == "")
                return false;
            return _dao.CreateDict(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyDict(DictInfo info)
        {
            if (info == null)
                return false;
            if (info.Code == "")
                return false;
            return _dao.ModifyDict(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool DeleteDict(string Code,string Type)
        {
            if (Code.Trim() == "")
                return false;
            return _dao.DeleteDict(Code, Type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public DictInfo GetDictInfo(string Code, string Type)
        {
            if (Code == "")
                return null;
            return _dao.GetDictInfo(Code, Type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<DictInfo> GetDictInfoByCondition(DictInfo Condition)
        {
            return _dao.GetDictInfoByCondition(Condition);
        }
        #endregion

        #region ======字典类型维护=====

        public bool CreateDictType(DictTypeInfo info)
        {
            if (info == null)
                return false;
            if (info.Code == "")
                return false;
            return _dao.CreateDictType(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyDictType(DictTypeInfo info)
        {
            if (info == null)
                return false;
            if (info.Code == "")
                return false;
            return _dao.ModifyDictType(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool DeleteDictType(string Code)
        {
            if (Code == "")
                return false;
            return _dao.DeleteDictType(Code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public DictTypeInfo GetDictTypeInfo(string Code)
        {
            if (Code.Trim() == "")
                return null;
            return _dao.GetDictTypeInfo(Code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<DictTypeInfo> GetDictTypeInfoAll()
        {
            return _dao.GetDictTypeInfoAll();
        }

        /// <summary>
        /// 取得字典类型代码
        /// </summary>
        /// <param name="type">DictTypeEnum字典类型枚举</param>
        /// <returns>字典类型代码</returns>
        public string GetDictTypeName(DictTypeEnum type)
        {
            return Enum.GetName(typeof(DictTypeEnum), type);
        }
        #endregion
    }
}
