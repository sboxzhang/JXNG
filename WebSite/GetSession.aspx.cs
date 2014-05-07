using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;

public partial class GetSession : System.Web.UI.Page
{
    UserInfo _user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserInfo"] != null)
        {
            _user = (UserInfo)Session["UserInfo"];
            if (_user != null)
            {
                if (_user.DeptId.Length < 0)
                {
                    Response.Write("");
                }
                else
                {
                    //Response.Write(KhbxJxdBiz.GetHfgdbh(_user.DeptId));
                }
                //Response.Write(_user.DeptId);
            }
        }
    }
}
