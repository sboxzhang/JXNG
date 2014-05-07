using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_Postmanager_CreatePost : System.Web.UI.Page
{
    Post _Post = new Post();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CODE"] != null)
            {
                GetPostInfo(Request.QueryString["CODE"].ToString());
                this.TXT_CODE.Enabled = false;
                this.btnMultipleSave.Visible = false;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PostInfo info = new PostInfo();
        info.Code = this.TXT_CODE.Text.Trim();
        info.Name = this.TXT_NAME.Text.Trim();
        info.Remark = this.TXT_REMARK.Text.Trim();
        info.IsEnable = this.CHB_ISENABLE.Checked ? "Y" : "N";
        if (this.TXT_CODE.Enabled)
        {
            if (_Post.CreatePost(info))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位信息新增成功！');</script>");
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位信息新增失败！');</script>");
            }
        }
        else
        {
            if (_Post.ModifyPost(info))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位信息修改成功！');</script>");
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位信息修改失败！');</script>");
            }
        }
    }
    protected void btnMultipleSave_Click(object sender, EventArgs e)
    {
        PostInfo info = new PostInfo();
        info.Code = this.TXT_CODE.Text.Trim();
        info.Name = this.TXT_NAME.Text.Trim();
        info.Remark = this.TXT_REMARK.Text.Trim();
        info.IsEnable = this.CHB_ISENABLE.Checked ? "Y" : "N";
        if (_Post.CreatePost(info))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位信息新增成功！');</script>");
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('岗位信息新增失败！');</script>");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Code"></param>
    private void GetPostInfo(string Code)
    {
        PostInfo info=_Post.GetPostInfo(Code);
        if (info != null)
        {
            this.TXT_CODE.Text = info.Code;
            this.TXT_NAME.Text = info.Name;
            this.TXT_REMARK.Text = info.Remark;
            this.CHB_ISENABLE.Checked = info.IsEnable == "Y" ? true : false;
        }
    }
}
