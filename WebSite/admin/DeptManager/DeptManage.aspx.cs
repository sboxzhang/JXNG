using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
public partial class admin_DeptManager_DeptManage : System.Web.UI.Page
{
    Dept _dept = new Dept();

    /// <summary>
    /// 
    /// </summary>
    public enum enuDisplayMode
    {
        Add = 0,
        Edit = 1,
        Del = 2,
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
                this.TXT_DEPTID.Enabled = true;
            }
            if (_DisplayMode == enuDisplayMode.Edit)
            {
                this.BTN_ADD.Enabled = false;
                this.BTN_UPD.Enabled = true;
                this.BTN_DEL.Enabled = true;
                this.TXT_DEPTID.Enabled = false;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ViewState["DEPTID"] = "";
            BuildTree(this._dept.GetDeptAll());
            BindDDL();
            if (Request.QueryString["ID"] != null)
            {
                this.ViewState["DEPTID"] = Request.QueryString["ID"].ToString();
                GetInfo(Request.QueryString["ID"].ToString());
                this.DisplayMode = enuDisplayMode.Edit;
            }
            else
            {
                this.DisplayMode = enuDisplayMode.Add;
            }
            
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_ADD_Click(object sender, EventArgs e)
    {
        if (_dept.CreateDept(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增部门保存成功！');parent.leftbody.location.reload();</script>");
            BuildTree(this._dept.GetDeptAll());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增部门保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_DEL_Click(object sender, EventArgs e)
    {
        if (_dept.DeleteDept(this.ViewState["DEPTID"].ToString()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('部门删除成功！');parent.leftbody.location.reload();</script>");
            BuildTree(this._dept.GetDeptAll());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('部门删除失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_UPD_Click(object sender, EventArgs e)
    {
        if (_dept.ModifyDept(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('部门信息修改成功！');parent.leftbody.location.reload();</script>");
            BuildTree(this._dept.GetDeptAll());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('部门信息修改失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_CANCEL_Click(object sender, EventArgs e)
    {
        
        ClearPage();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private DeptInfo SetInfo()
    {
        DeptInfo info = new DeptInfo();
        info.DeptName = this.TXT_DEPTNAME.Text.Trim();
        info.ParentId = this.DDL_DEPT.SelectedValue;
        info.Remark = this.TXT_REMARK.Text.Trim();
        info.DeptId = this.TXT_DEPTID.Text.Trim();
        info.DeptType = this.DDL_DEPTTYPE.SelectedValue;
        return info;
    }
    /// <summary>
    /// 
    /// </summary>
    private void GetInfo(string DeptId)
    {
        DeptInfo info = _dept.GetDeptInfo(DeptId);
        this.TXT_DEPTNAME.Text = info.DeptName;
        this.TXT_REMARK.Text = info.Remark;
        this.DDL_DEPT.SelectedValue = info.ParentId;
        this.TXT_DEPTID.Text = info.DeptId;
        this.DDL_DEPTTYPE.SelectedValue = info.DeptType;
    }
    /// <summary>
    /// 
    /// </summary>
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
        this.DisplayMode = enuDisplayMode.Add;
    }
    /// <summary>
    /// 
    /// </summary>
    private void BindDDL()
    {
        Dict _Dict = new Dict();
        DictInfo _info = new DictInfo();
        _info.TypeCode = "BMLX";
        this.DDL_DEPTTYPE.DataSource = _Dict.GetDictInfoByCondition(_info);
        this.DDL_DEPTTYPE.DataTextField = "Name";
        this.DDL_DEPTTYPE.DataValueField = "Code";
        this.DDL_DEPTTYPE.DataBind();
        this.DDL_DEPTTYPE.Items.Insert(0, new ListItem("---请选择---", ""));
    }
    /// <summary>
    /// 创建树
    /// </summary>
    /// <param name="sqlstring">查询字符串</param>
    private void BuildTree(List<DeptInfo> data)
    {
        this.DDL_DEPT.Items.Clear();
        //加载树
        this.DDL_DEPT.Items.Add(new ListItem("---请选择---", ""));
        List<DeptInfo> ListInfo = data.FindAll(delegate(DeptInfo info)
                {
                    return info.ParentId.ToString() =="0";
                });
        foreach (DeptInfo info in ListInfo)
        {
            string nodeid = info.DeptId;
            string text = info.DeptName;
            text = "╋" + text;
            this.DDL_DEPT.Items.Add(new ListItem(text, nodeid));
            string sonparentid = nodeid;
            string blank = "├";
            BindNode(sonparentid, data, blank);
        }
        this.DataBind();
    }


    /// <summary>
    /// 创建树结点
    /// </summary>
    /// <param name="sonparentid">当前数据项</param>
    /// <param name="dt">数据表</param>
    /// <param name="blank">空白符</param>
    private void BindNode(string sonparentid, List<DeptInfo> data, string blank)
    {
        List<DeptInfo> ListInfo = data.FindAll(delegate(DeptInfo info)
        {
            return info.ParentId.ToString() == sonparentid;
        });

        foreach (DeptInfo info in ListInfo)
        {
            string nodevalue = info.DeptId;
            string text = info.DeptName;
            text = blank + "『" + text + "』";
            this.DDL_DEPT.Items.Add(new ListItem(text, nodevalue));
            string blankNode = blank + "─";
            BindNode(nodevalue, data, blankNode);
        }
    }
}
