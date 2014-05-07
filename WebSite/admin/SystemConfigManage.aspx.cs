using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SystemConfigManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetConfig();
        }
    }
    protected void btnImgOK_Click(object sender, EventArgs e)
    {
        HttpCookie acookie = new HttpCookie("ImgOpen", fuImg.PostedFile.FileName);
        acookie.Expires = DateTime.Now.AddDays(30);//失效时间为1天
        //acookie.Value="aaaa"; 也可以这样给cookie赋值
        Response.Cookies.Add(acookie);//然后写入到浏览器中
        lblImg.Text = fuImg.PostedFile.FileName;
    }
    protected void btnVideoOK_Click(object sender, EventArgs e)
    {
        HttpCookie acookie = new HttpCookie("VideoOpen", fuVideo.PostedFile.FileName);
        acookie.Expires = DateTime.Now.AddDays(30);//失效时间为1天
        //acookie.Value="aaaa"; 也可以这样给cookie赋值
        Response.Cookies.Add(acookie);//然后写入到浏览器中
        lblVideo.Text = fuVideo.PostedFile.FileName;
    }

    #region 设置
    /// <summary>
    /// 设置
    /// </summary>
    private void SetConfig()
    {
        if (Request.Cookies["ImgOpen"] != null)
        {
            lblImg.Text = Request.Cookies["ImgOpen"].Value;
        }
        if (Request.Cookies["VideoOpen"] != null)
        {
            lblVideo.Text = Request.Cookies["VideoOpen"].Value;
        }
    }
    #endregion
}
