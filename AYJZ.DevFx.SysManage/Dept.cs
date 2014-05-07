using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
namespace AYJZ.DevFx.SysManage
{
    public class Dept
    {
        DeptDao _dept = new DeptDao();

        public bool CreateDept(DeptInfo info)
        {
            return _dept.CreateDept(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyDept(DeptInfo info)
        {
            return _dept.ModifyDept(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteDept(string DeptId)
        {
           return _dept.DeleteDept(DeptId);
        }
         /// <summary>
        /// 根据部门类型取得部门列表
        /// </summary>
        /// <param name="Type">部门类型(YXFZX--营销分中心、ZRDW--责任单位)，如何参数为空则返回所有类型的部门</param>
        /// <returns></returns>
        public List<DeptInfo> GetDeptByType(string Type)
        {
            if (Type.Trim() == "")
                return _dept.GetDeptAll();
            else
                return _dept.GetDeptByType(Type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MoudleId"></param>
        /// <returns></returns>
        public DeptInfo GetDeptInfo(string DeptId)
        {
           return _dept.GetDeptInfo(DeptId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DeptInfo> GetDeptAll()
        {
          return _dept.GetDeptAll();
        }
    }
}