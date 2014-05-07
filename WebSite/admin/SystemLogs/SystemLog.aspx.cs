using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AYJZ.BusinessLogic;
using System.Data;
using AYJZ.DevFx.SysManage;

public partial class business_other_SystemLog : System.Web.UI.Page
{
    Moudle _Moudle = new Moudle();
    syslogLogic logic = new syslogLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AspNetPager1.Visible = false;
            BuildTree(this._Moudle.GetMoudleAll());
            BindData();
        }
        UGridView oView = new UGridView(gvTable);
    }


    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Query();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Query();
    }

    #region 私有函数
    private void Query()
    {
        string where = "";
        if (!string.IsNullOrEmpty(txtSJS.Text))
        {
            where += string.Format(" and DATE_FORMAT(sj,'%Y-%m-%d')>='{0}'", txtSJS.Text);
        }
        if (!string.IsNullOrEmpty(txtSJE.Text))
        {
            where += string.Format(" and DATE_FORMAT(sj,'%Y-%m-%d')<='{0}'", txtSJE.Text);
        }
        if (!string.IsNullOrEmpty(ddlUser.SelectedValue))
        {
            where += string.Format(" and usercode='{0}'", ddlUser.SelectedValue);
        }
        if (!string.IsNullOrEmpty(ddlModule.SelectedValue))
        {
            where += string.Format(" and MOUDLEID='{0}'", ddlModule.SelectedValue);
        }
        DataTable list = logic.GetData(where);
        try
        {
            int iCount = list.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = iCount;
            pds.DataSource = list.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            if (iCount > AspNetPager1.PageSize)
            {
                AspNetPager1.Visible = true;
            }
            else
            {
                AspNetPager1.Visible = false;
            }

            gvTable.DataSource = pds;
            gvTable.DataBind();
        }
        catch (Exception)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('绑定数据时出错！');</script>");
            return;
        }
    }

    /// <summary>
    /// 创建树
    /// </summary>
    /// <param name="sqlstring">查询字符串</param>
    private void BuildTree(List<MoudleInfo> data)
    {
        this.ddlModule.Items.Clear();
        //加载树
        this.ddlModule.Items.Add(new ListItem("---全部---", ""));
        List<MoudleInfo> ListInfo = data.FindAll(delegate(MoudleInfo info)
        {
            return info.ParentId.ToString() == "0";
        });
        foreach (MoudleInfo info in ListInfo)
        {
            string nodeid = info.MoudleId.ToString();
            string text = info.MoudleName;
            text = "╋" + text;
            this.ddlModule.Items.Add(new ListItem(text, nodeid));
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
            this.ddlModule.Items.Add(new ListItem(text, nodevalue));
            string blankNode = blank + "─";
            BindNode(nodevalue, data, blankNode);
        }
    }

    private void BindData()
    {
        User o = new User();
        List<UserInfo> list = o.GetUserAll();
        ddlUser.DataSource = list;
        ddlUser.DataValueField = "Usercode";
        ddlUser.DataTextField = "username";
        ddlUser.DataBind();
        ddlUser.Items.Insert(0, new ListItem("全部", ""));
    }
    #endregion
}
