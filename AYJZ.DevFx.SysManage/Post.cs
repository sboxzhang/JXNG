using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    public class Post
    {
        PostDao _dao = new PostDao();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreatePost(PostInfo info)
        {
            if (info == null)
                return false;
            else
                return _dao.CreatePost(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyPost(PostInfo info)
        {
            if (info == null)
                return false;
            else
                return _dao.ModifyPost(info);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool DeletePost(string Code)
        {
            if (Code.Trim() == "")
                return false;
            else
                return _dao.DeletePost(Code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public PostInfo GetPostInfo(string Code)
        {
            if (Code.Trim() == "")
                return null;
            else
                return _dao.GetPostInfo(Code);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PostInfo> GetPostInfoAll()
        {
            return _dao.GetPostInfoAll();
        }
    }
}
