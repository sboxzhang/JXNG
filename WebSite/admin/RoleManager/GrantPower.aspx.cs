using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_RoleManager_GrantPower : System.Web.UI.Page
{
    RoleMoudle _RoleMoudle = new RoleMoudle();
    Moudle _Moudle = new Moudle();
    Power _Power = new Power();
    List<PowerInfo> _list = new List<PowerInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();

            ViewState["ROLEID"] = Request.QueryString["ROLEID"].ToString();
            this.LAB_ROLE.Text = Server.UrlDecode(Request.QueryString["ROLENAME"].ToString());
            
            BindGrid();
            CheckRights();
        }
    }

    private void BindGrid()
    {
        List<string> list = new List<string>();
        list.Add(ViewState["ROLEID"].ToString());
        this.GridView1.DataSource = _Moudle.GetMoudleByRole(list);
        this.GridView1.DataBind();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Id = DataBinder.Eval(e.Row.DataItem, "MoudleId").ToString().Trim();
            if (DataBinder.Eval(e.Row.DataItem, "parentid").ToString().Trim()=="0")
            {
                e.Row.Cells[0].Text = "<strong>" + e.Row.Cells[0].Text.ToString() + "</strong>";
            }
            else
            {
                e.Row.Cells[0].Text = "&nbsp;&nbsp;&nbsp;&nbsp;" + e.Row.Cells[0].Text.ToString();
            }
            List<PowerInfo> ListInfo = _Power.GetPowerByMoudleId(Id);
            CheckBoxList CheckList = (CheckBoxList)e.Row.Cells[1].Controls[1];
            CheckList.DataSource = ListInfo;
            CheckList.DataTextField = "PowerName";
            CheckList.DataValueField = "PowerValue";
            CheckList.DataBind();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_SAVE_Click(object sender, EventArgs e)
    {
        RoleMoudleInfo _RoleMoudleInfo = null;
        List<RoleMoudleInfo> list = new List<RoleMoudleInfo>();
        double RightValue = 0;
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            _RoleMoudleInfo = new RoleMoudleInfo();
            _RoleMoudleInfo.MoudleId = int.Parse(this.GridView1.DataKeys[row.RowIndex].Value.ToString());
            _RoleMoudleInfo.RoleId = int.Parse(ViewState["ROLEID"].ToString());
            CheckBoxList CheckList = (CheckBoxList)row.Cells[1].Controls[1];
            if (CheckList.Items.Count > 0)
            {
                foreach (ListItem item in CheckList.Items)
                {
                    if (item.Selected)
                    {
                        RightValue = RightValue + Math.Pow(2, double.Parse(item.Value));
                    }
                }
            }
            _RoleMoudleInfo.PowerValue = (int)RightValue;
            list.Add(_RoleMoudleInfo);
            RightValue = 0;
        }
        if (_RoleMoudle.GrantRolePower(list))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('角色权限授予成功！');</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('角色权限授予失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_BACK_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }

    private void CheckRights()
    {
        List<RoleMoudleInfo> list = this._RoleMoudle.GetRoleMoudle(ViewState["ROLEID"].ToString());
        RoleMoudleInfo info = null;
        string id = "";
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            id = this.GridView1.DataKeys[row.RowIndex].Value.ToString();
            info = list.Find(delegate(RoleMoudleInfo infos)
            {
                return infos.MoudleId.ToString() == id;
            });
            CheckBoxList CheckList = (CheckBoxList)row.Cells[1].Controls[1];
            if (info != null)
                Check(CheckList, info.PowerValue.ToString());
        }
    }

    public void Check(CheckBoxList CheckList, string RightValue)
    {
        string strRight = Convert.ToString(int.Parse(RightValue), 2);
        string strOperation;
        foreach (ListItem item in CheckList.Items)
        {
            strOperation = Convert.ToString(int.Parse(Math.Pow(2, double.Parse(item.Value)).ToString()), 2);
            if ((Convert.ToInt32(strRight, 2) & Convert.ToInt32(strOperation, 2)) != 0)
                item.Selected = true;
            else
                item.Selected = false;
        }
    }
}
