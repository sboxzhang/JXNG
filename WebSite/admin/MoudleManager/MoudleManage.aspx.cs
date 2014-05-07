using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.DevFx.SysManage;
using System.IO;

public partial class admin_ModuleManager_ModuleManage : System.Web.UI.Page
{
    Moudle _Moudle = new Moudle();
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
            }
            if (_DisplayMode == enuDisplayMode.Edit)
            {
                this.BTN_ADD.Enabled = false;
                this.BTN_UPD.Enabled = true;
                this.BTN_DEL.Enabled = true;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DDL_IMG.Attributes.Add("onclick", "imgchang();return false;");
        this.DDL_IMG.Attributes.Add("onchange", "imgchang();return false;");
        if (!Page.IsPostBack)
        {
            BindImages();
            BuildTree(this._Moudle.GetMoudleAll());
            //BuildTree(logic.GetJTDJ_DAYWLXAll());
            if (Request.QueryString["ID"] != null)
            {
                this.ViewState["ID"] = Request.QueryString["ID"].ToString();
                GetInfo(this.ViewState["ID"].ToString());
                this.DisplayMode = enuDisplayMode.Edit;
            }
            else
            {
                this.ViewState["ID"] = "0";
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
        if (_Moudle.CreateMoudle(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增模块保存成功！');parent.leftbody.location.reload();</script>");
            BuildTree(this._Moudle.GetMoudleAll());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('新增模块保存失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_DEL_Click(object sender, EventArgs e)
    {
        if (_Moudle.DeleteMoudle(this.ViewState["ID"].ToString()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块删除成功！');parent.leftbody.location.reload();</script>");
             BuildTree(this._Moudle.GetMoudleAll());
             ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块删除失败！');</script>");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_UPD_Click(object sender, EventArgs e)
    {
        if (_Moudle.ModifyMoudle(SetInfo()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块信息修改成功！');parent.leftbody.location.reload();</script>");
            BuildTree(this._Moudle.GetMoudleAll());
            ClearPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('模块信息修改失败！');</script>");
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
    /// 加载图片
    /// </summary>
    private void BindImages()
    {
        string dirpath = Server.MapPath("~/images/icon");
        
        DirectoryInfo di = new DirectoryInfo(dirpath);
        if (!di.Exists)
            return;
        //FileInfo[] rgFiles = di.GetFiles("*.jpg");
        this.DDL_IMG.Items.Clear();
        //foreach (FileInfo fi in rgFiles)
        //{
        //    ListItem item = new ListItem(fi.Name, "../images/LEFT/" + fi.Name);
        //    this.ddl_img.Items.Add(item);
        //}
        FileInfo[] rgFiles2 = di.GetFiles("*.png");
        foreach (FileInfo fi in rgFiles2)
        {
            ListItem item = new ListItem(fi.Name, "images/icon/" + fi.Name);
            this.DDL_IMG.Items.Add(item);
        }
        ListItem Item = new ListItem("默认图标", "images/icon/1.png");
        this.DDL_IMG.Items.Insert(0, Item);
        this.DDL_IMG.DataBind();
    }
    /// <summary>
    /// 创建树
    /// </summary>
    /// <param name="sqlstring">查询字符串</param>
    private void BuildTree(List<MoudleInfo> data)
    {
        this.DDL_PARENTID.Items.Clear();
        //加载树
        this.DDL_PARENTID.Items.Add(new ListItem("---根节点---", "0"));
        List<MoudleInfo> ListInfo = data.FindAll(delegate(MoudleInfo info)
        {
            return info.ParentId.ToString() == "0";
        });
        foreach (MoudleInfo info in ListInfo)
        {
            string nodeid = info.MoudleId.ToString();
            string text = info.MoudleName;
            text = "╋" + text;
            this.DDL_PARENTID.Items.Add(new ListItem(text, nodeid));
            string sonparentid = nodeid;
            string blank = "├";
            BindNode(sonparentid, data, blank);
        }
        this.DataBind();
    }

    #region 绑定业务类型
    /// <summary>
    /// 创建树
    /// </summary>
    /// <param name="sqlstring">查询字符串</param>
    //private void BuildTree(List<JTDJ_DAYWLXInfo> data)
    //{
    //    this.ddlYWLX.Items.Clear();
    //    //加载树
    //    this.ddlYWLX.Items.Add(new ListItem("---请选择---", ""));
    //    List<JTDJ_DAYWLXInfo> ListInfo = data.FindAll(delegate(JTDJ_DAYWLXInfo info)
    //    {
    //        return info.PARENTID.ToString() == "0";
    //    });
    //    foreach (JTDJ_DAYWLXInfo info in ListInfo)
    //    {
    //        string nodeid = info.ID.ToString();
    //        string text = info.YWMC;
    //        text = "╋" + text;
    //        this.ddlYWLX.Items.Add(new ListItem(text, nodeid));
    //        string sonparentid = nodeid;
    //        string blank = "├";
    //        BindNode(sonparentid, data, blank);
    //    }
    //    this.DataBind();
    //}

    /// <summary>
    /// 创建树结点
    /// </summary>
    /// <param name="sonparentid">当前数据项</param>
    /// <param name="dt">数据表</param>
    /// <param name="blank">空白符</param>
    //private void BindNode(string sonparentid, List<JTDJ_DAYWLXInfo> data, string blank)
    //{
    //    List<JTDJ_DAYWLXInfo> ListInfo = data.FindAll(delegate(JTDJ_DAYWLXInfo info)
    //    {
    //        return info.PARENTID.ToString() == sonparentid;
    //    });

    //    foreach (JTDJ_DAYWLXInfo info in ListInfo)
    //    {
    //        string nodevalue = info.ID.ToString();
    //        string text = info.YWMC;
    //        text = blank + "『" + text + "』";
    //        this.ddlYWLX.Items.Add(new ListItem(text, nodevalue));
    //        string blankNode = blank + "─";
    //        BindNode(nodevalue, data, blankNode);
    //    }
    //}
    #endregion


    /// <summary>
    /// 创建树结点
    /// </summary>
    /// <param name="sonparentid">当前数据项</param>
    /// <param name="dt">数据表</param>
    /// <param name="blank">空白符</param>
    private void BindNode(string sonparentid, List<MoudleInfo> data, string blank)
    {
        List<MoudleInfo> ListInfo = data.FindAll(delegate(MoudleInfo info)
        {
            return info.ParentId.ToString() == sonparentid;
        });

        foreach (MoudleInfo info in ListInfo)
        {
            string nodevalue = info.MoudleId.ToString();
            string text = info.MoudleName;
            text = blank + "『" + text + "』";
            this.DDL_PARENTID.Items.Add(new ListItem(text, nodevalue));
            string blankNode = blank + "─";
            BindNode(nodevalue, data, blankNode);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private MoudleInfo SetInfo()
    {
        MoudleInfo info = new MoudleInfo();
        info.MoudleName = this.TXT_MOUDLENAME.Text.Trim();
        info.Url = this.TXT_URL.Text.Trim();
        if (this.DDL_PARENTID.SelectedValue != "")
            info.ParentId = this.DDL_PARENTID.SelectedValue;
        else
            info.ParentId = "0";
        info.Img = this.DDL_IMG.SelectedValue;
        info.IsEnable = this.DDL_ISENABLE.SelectedValue;
        info.IsRoot = this.DDL_ISROOT.SelectedValue;
        info.Sort = this.TXT_SORT.Text.Trim();
        info.MoudleId = this.ViewState["ID"].ToString();
        info.YWLX = "";// ddlYWLX.SelectedValue;
        return info;
    }
    private void GetInfo(string Id)
    {
        MoudleInfo info = this._Moudle.GetMoudleInfo(Id);
        this.TXT_MOUDLENAME.Text = info.MoudleName;
        this.TXT_SORT.Text = info.Sort;
        this.TXT_URL.Text = info.Url;
        this.DDL_PARENTID.SelectedValue = info.ParentId;
        this.DDL_ISROOT.SelectedValue = info.IsRoot;
        this.DDL_ISENABLE.SelectedValue = info.IsEnable;
        this.DDL_IMG.SelectedValue = info.Img;
       // this.ddlYWLX.SelectedValue = info.YWLX;
    }
    private void ClearPage()
    {
        PageBase.ClearAllContent(this.Page);
        this.DisplayMode = enuDisplayMode.Add;
    }

}