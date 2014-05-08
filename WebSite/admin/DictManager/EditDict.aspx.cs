using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_DictManager_EditDict : System.Web.UI.Page
{
    Dict _Dict = new Dict();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDictType();
            if (Request.QueryString["CODE"] != null)
            {
                GetDictInfo(Request.QueryString["CODE"].ToString(), Request.QueryString["TYPE"].ToString());
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    /// <summary>
    /// 
    /// </summary>
    private void BindDictType()
    {
        this.DDL_TYPE.DataSource = this._Dict.GetDictTypeInfoAll();
        this.DDL_TYPE.DataTextField = "Name";
        this.DDL_TYPE.DataValueField = "Code";
        this.DDL_TYPE.DataBind();
        this.DDL_TYPE.Items.Insert(0, new ListItem("---请选择---", ""));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DictInfo info = new DictInfo();
        info.Code = this.TXT_CODE.Text.Trim();
        info.Name = this.TXT_NAME.Text.Trim();
        info.TypeCode = this.DDL_TYPE.SelectedValue;
        info.Remark = this.TXT_REMARK.Text.Trim();
        info.IsEnable = this.CHB_ISENABLE.Checked ? "Y" : "N";
        if (this.TXT_SORT.Text.Trim() != "")
            info.Sort = int.Parse(this.TXT_SORT.Text.Trim());
        else
            info.Sort = 0;
        if (_Dict.ModifyDict(info))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增字典保存成功！');</script>");
            Response.Redirect("Default.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增字典保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void GetDictInfo(string Code,string Type)
    {
        DictInfo info = _Dict.GetDictInfo(Code, Type);
        if (info != null)
        {
            this.TXT_CODE.Text = info.Code;
            this.TXT_NAME.Text = info.Name;
            this.TXT_SORT.Text = info.Sort.ToString();
            this.TXT_REMARK.Text = info.Remark;
            this.DDL_TYPE.SelectedValue = info.TypeCode;
            this.CHB_ISENABLE.Checked = info.IsEnable == "Y" ? true : false;
        }
    }
}
