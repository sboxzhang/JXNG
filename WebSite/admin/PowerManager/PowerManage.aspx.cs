using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VSM.DevFx.SysManage;
public partial class admin_PowerManager_PowerManage : System.Web.UI.Page
{
    Power _Power = new Power();
    /// <summary>
    /// 
    /// </summary>
    public enum enuDisplayMode
    {
        Add = 0,
        Edit = 1,
        Init = 2,
        Cancel = 3,
    }
    private enuDisplayMode _DisplayMode;
    /// <summary>
    /// 
    /// </summary>
    public enuDisplayMode DisplayMode
    {
        get
        {
            _DisplayMode = (enuDisplayMode)this.ViewState["vDisplayMode"];
            return _DisplayMode;
        }
        set
        {
            _DisplayMode = value;
            this.ViewState["vDisplayMode"] = _DisplayMode;
            if (_DisplayMode == enuDisplayMode.Add)
            {
                this.BTN_ADD.Enabled = true;
                this.BTN_UPD.Enabled = false;
                this.BTN_DEL.Enabled = false;
            }
            if (_DisplayMode == enuDisplayMode.Edit)
            {
                this.BTN_ADD.Enabled = false;
                this.BTN_UPD.Enabled = true;
                this.BTN_DEL.Enabled = true;
            }
            if (_DisplayMode == enuDisplayMode.Init)
            {
                this.BTN_ADD.Enabled = false;
                this.BTN_UPD.Enabled = false;
                this.BTN_DEL.Enabled = false;
                this.BTN_CANCEL.Enabled = false;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                this.ViewState["ID"] = Server.UrlDecode(Request.QueryString["ID"].ToString());
                this.lab_MoudleName.Text = Server.UrlDecode(Request.QueryString["NAME"].ToString());
                BuildGrid(this.ViewState["ID"].ToString());
                this.DisplayMode = enuDisplayMode.Add;
            }
            else
            {
                this.DisplayMode = enuDisplayMode.Init;
            }
        }
    }
    protected void BTN_ADD_Click(object sender, EventArgs e)
    {
        PowerInfo info = new PowerInfo();
        info.MoudleId = this.ViewState["ID"].ToString();
        info.PowerName = this.TXT_POWERNAME.Text;
        info.PowerValue = int.Parse(this.TXT_POWERVALUE.Text.Trim());

        if (this._Power.CreatePower(info))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块功能保存成功！');</script>");
            BuildGrid(this.ViewState["ID"].ToString());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块功能保存失败！');</script>");
        }
    }
    protected void BTN_DEL_Click(object sender, EventArgs e)
    {
        if (this._Power.DeletePower(this.ViewState["POWERID"].ToString()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块功能删除成功！');</script>");
            BuildGrid(this.ViewState["ID"].ToString());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块功删除改失败！');</script>");
        }
    }
    protected void BTN_UPD_Click(object sender, EventArgs e)
    {
        PowerInfo info = new PowerInfo();
        info.PowerId = this.ViewState["POWERID"].ToString();
        info.PowerName = this.TXT_POWERNAME.Text;
        info.PowerValue = int.Parse(this.TXT_POWERVALUE.Text.Trim());

        if (this._Power.ModifyPower(info))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块功能修改成功！');</script>");
            BuildGrid(this.ViewState["ID"].ToString());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块功能修改失败！');</script>");
        }
    }
    protected void BTN_CANCEL_Click(object sender, EventArgs e)
    {
        ClearPage();
    }
    private void BuildGrid(string MoudleId)
    {
        this.GridView1.DataSource = this._Power.GetPowerByMoudleId(MoudleId);
        this.GridView1.DataBind();
    }
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
        this.DisplayMode = enuDisplayMode.Add;
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        this.DisplayMode = enuDisplayMode.Edit;
        this.ViewState["POWERID"] = this.GridView1.DataKeys[e.NewSelectedIndex].Value;
        this.TXT_POWERNAME.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[0].Text.Trim();
        this.TXT_POWERVALUE.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.Trim();
    }
}