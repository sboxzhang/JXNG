using System;
using AYJZ.Entities;
using AYJZ.BusinessLogic;
using AYJZ.DevFx.SysManage;
using System.Collections.Generic;
using AYJZ.DataAccess;
using System.Text;
using System.Web.UI;
using System.IO;

public partial class aygl_AyglAdd : PageBase
{
    #region 属性

    private ayjz_ayzhxxLogic ayjzLogic = new ayjz_ayzhxxLogic();
    private ayjz_d_lxdhLogic lxdhLogic = new ayjz_d_lxdhLogic();

    /// <summary>
    /// 主键ID
    /// </summary>
    private string PKID
    {
        set { this.ViewState["PKID"] = value; }
        get
        {
            if (!string.IsNullOrEmpty(this.Request["PKID"]))
            {
                return this.Request["PKID"];
            }
            else if (this.ViewState["PKID"] != null)
            {
                return this.ViewState["PKID"].ToString();
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// 姓名
    /// </summary>
    private string XM
    {
        set { this.TXT_USERNAME.Text = value; }
        get { return this.TXT_USERNAME.Text; }
    }

    /// <summary>
    /// 性别
    /// </summary>
    private string XB
    {
        set { this.DDL_GENDER.SelectedValue = value; }
        get { return this.DDL_GENDER.SelectedValue; }
    }

    /// <summary>
    /// 身份证
    /// </summary>
    private string SFZH
    {
        set { this.TXT_USERID.Text = value; }
        get { return this.TXT_USERID.Text; }
    }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    private string HYZK
    {
        set { this.DDL_MARY.SelectedValue = value; }
        get { return this.DDL_MARY.SelectedValue; }
    }

    /// <summary>
    /// 民族
    /// </summary>
    private string MZ
    {
        set { this.TXT_FOLK.Text = value; }
        get { return this.TXT_FOLK.Text; }
    }

    /// <summary>
    /// 文化程度
    /// </summary>
    private string YHCD
    {
        set { this.DDL_WHCD.SelectedValue = value; }
        get { return this.DDL_WHCD.SelectedValue; }
    }

    /// <summary>
    /// 联系电话
    /// </summary>
    private string[] LXDH
    {
        set
        {
            StringBuilder lxdhHtml = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                lxdhHtml.AppendFormat("<div><input type='text' name='lxdh' value='{0}' class='textbox' /><input type='button' value='删除' class='btnlxdhDel button' /></div>", value[i]);
            }

            StringBuilder sb = new StringBuilder(lxdhHtml.ToString());
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter(sb));
            this.DIV_LXDH.RenderControl(htmlTextWriter);            
            
            //HtmlTextWriter textWriter = new HtmlTextWriter(this.Response.Output);            
            //this.DIV_LXDH.RenderControl(textWriter);
        }
        get
        {
            if (this.Request.Form["lxdh"] != null && this.Request.Form["lxdh"].Length > 0)
            {
                return this.Request.Form["lxdh"].Split(',');
            }

            return null;
        }
    }

    /// <summary>
    /// 联系手机
    /// </summary>
    private string[] LXSJ
    {
        set { this.DIV_LXSJ.InnerHtml = string.Empty; }
        get { return null; }
    }

    /// <summary>
    /// 身高
    /// </summary>
    private string SG
    {
        set { this.TXT_SG.Text = value; }
        get { return this.TXT_SG.Text; }
    }

    /// <summary>
    /// 体重
    /// </summary>
    private string TZ
    {
        set { this.TXT_TZ.Text = value; }
        get { return this.TXT_TZ.Text; }
    }

    /// <summary>
    /// 家庭成员
    /// </summary>
    private string ZTCY
    {
        set { this.TXT_JTCY.Text = value; }
        get { return this.TXT_JTCY.Text; }
    }

    /// <summary>
    /// 是否加入黑名单
    /// </summary>
    private string SFZHMD
    {
        set { this.CB_HMD.Checked = value == "1" ? true : false; }
        get { return this.CB_HMD.Checked == true ? "1" : "0"; }
    }

    /// <summary>
    /// 健康证到期日
    /// </summary>
    private string SJZDQR
    {
        set { this.TXT_JKZDQR.Text = value; }
        get { return this.TXT_JKZDQR.Text; }
    }

    /// <summary>
    /// 健康证编号
    /// </summary>
    private string JKZBH
    {
        set { this.TXT_JKZBH.Text = value; }
        get { return this.TXT_JKZBH.Text; }
    }

    /// <summary>
    /// 办理医院
    /// </summary>
    private string BLYY
    {
        set { this.TXT_BLYY.Text = value; }
        get { return this.TXT_BLYY.Text; }
    }

    /// <summary>
    /// 保险有效期
    /// </summary>
    private string BSYSQ
    {
        set { this.TXT_BXYXQ.Text = value; }
        get { return this.TXT_BXYXQ.Text; }
    }

    /// <summary>
    /// 保险购买处
    /// </summary>
    private string BSGMQ
    {
        set { this.TXT_BXGMC.Text = value; }
        get { return this.TXT_BXGMC.Text; }
    }

    /// <summary>
    /// 属相
    /// </summary>
    private string SS
    {
        set { this.DDL_SX.SelectedValue = value; }
        get { return this.DDL_SX.SelectedValue; }
    }

    /// <summary>
    /// 现住址
    /// </summary>
    private string XZZ
    {
        set { this.TXT_XZZ.Text = value; }
        get { return this.TXT_XZZ.Text; }
    }

    /// <summary>
    /// 户籍地址
    /// </summary>
    private string HJDZ
    {
        set { this.TXT_HJDZ.Text = value; }
        get { return this.TXT_HJDZ.Text; }
    }

    /// <summary>
    /// 银行帐号
    /// </summary>
    private string[][] YHZH
    {
        set { this.DIV_YHZH.InnerHtml = string.Empty; }
        get { return null; }
    }

    /// <summary>
    /// 服务工种
    /// </summary>
    private string FWGZ
    {
        set { this.DDL_FWGZ.SelectedValue = value; }
        get { return this.DDL_FWGZ.SelectedValue; }
    }

    /// <summary>
    /// 服务内容
    /// </summary>
    private string FWNR
    {
        set { this.DDL_FWNR.SelectedValue = value; }
        get { return this.DDL_FWNR.SelectedValue; }
    }

    /// <summary>
    /// 服务时间段
    /// </summary>
    private string[] FWSJD
    {
        set { this.DIV_FWSJD.InnerHtml = string.Empty; }
        get { return null; }
    }

    /// <summary>
    /// 部门
    /// </summary>
    private string BM
    {
        set { this.TXT_DEPT.Text = value; }
        get { return this.TXT_DEPT.Text; }
    }

    /// <summary>
    /// 共享
    /// </summary>
    private string GX
    {
        set { this.CB_GX.Checked = value == "1" ? true : false; }
        get { return this.CB_GX.Checked == true ? "1" : "0"; }
    }

    /// <summary>
    /// 分配
    /// </summary>
    private string FP
    {
        set { this.DDL_FP.SelectedValue = value; }
        get { return this.DDL_FP.SelectedValue; }
    }

    #endregion

    #region 方法

    #region 初始化

    private void DoInit()
    {
        this.InitDDL();
    }

    private void InitDDL()
    {
        this.BindDDL(this.DDL_GENDER, "SEX");       //性别
        this.BindDDL(this.DDL_MARY, "HYZK");        //婚姻状况
        this.BindDDL(this.DDL_WHCD, "WHCD");        //文化程度
        this.BindDDL(this.DDL_SX, "SX");            //属相
        this.BindDDL(this.DDL_FWGZ, "FWGZ");        //服务工种
        this.BindDDL(this.DDL_FWNR, "FWNR");        //服务内容

        Dept dept = new Dept();
        List<DeptInfo> listDept = dept.GetDeptAll();
        this.BindDDL<DeptInfo>("DeptName", "DeptId", this.DDL_FP, listDept);    //分配部门
    }

    private void BindView()
    {
        if (!string.IsNullOrEmpty(this.PKID))
        {
            ayjz_ayzhxxInfo entity = ayjzLogic.Getayjz_ayzhxx(MyConvert.ToLong(this.PKID));
            this.XM = entity.XM;
            this.XB = entity.XB;
            this.SFZH = entity.SFZH;
            this.HYZK = entity.HYZK;
            this.MZ = entity.MZ;
            this.YHCD = entity.YHCD;

            List<ayjz_d_lxdhInfo> lxdhList = lxdhLogic.Getayjz_d_lxdhList(string.Format(" AND EIID = {0} AND LX = '1' ", this.PKID));
            if (lxdhList != null && lxdhList.Count > 0)
            {
                string[] lxdhArray = new string[lxdhList.Count];
                for (int i = 0; i < lxdhList.Count; i++)
                {
                    lxdhArray[i] = lxdhList[i].LXDH;
                }

                this.LXDH = lxdhArray;
            }

            this.DIV_LXDH.InnerHtml = string.Empty;
            //this.DIV_LXSJ.InnerHtml = string.Empty;
            this.SG = entity.SG;
            this.TZ = entity.TZ;
            this.ZTCY = entity.ZTCY;
            this.SFZH = entity.SFZH;
            this.SJZDQR = entity.SJZDQR;
            this.JKZBH = entity.JKZBH;
            this.BLYY = entity.BLYY;
            this.BSYSQ = entity.BSYSQ;
            this.BSGMQ = entity.BSGMQ;
            this.SS = entity.SS;
            this.XZZ = entity.XZZ;
            this.HJDZ = entity.HJDZ;
            //this.DIV_YHZH.InnerHtml = string.Empty;
            this.FWGZ = entity.FWGZ;
            this.FWNR = entity.FWNR;
            //this.DIV_FWSJD.InnerHtml = string.Empty;
            this.BM = entity.BM;
            this.GX = entity.GX;
            this.FP = entity.FP;
        }
    }

    #endregion

    #region 保存

    private void DoSave()
    {
        ayjz_ayzhxxInfo entity = this.GetAYJZEntity();
        List<bool> listResults = new List<bool>();

        if (string.IsNullOrEmpty(this.PKID))
        {
            this.PKID = ayjzLogic.InsertIdentity(entity).ToString();
        }
        else
        {
            listResults.Add(ayjzLogic.Update(entity));
        }

        if (this.PKID != "0" || string.IsNullOrEmpty(this.PKID))
        {
            if (this.LXDH != null)
            {
                for (int i = 0; i < this.LXDH.Length; i++)
                {
                    ayjz_d_lxdhInfo lxdhEntity = new ayjz_d_lxdhInfo();
                    lxdhEntity.EIID = MyConvert.ToLong(this.PKID);
                    lxdhEntity.LX = "1";
                    lxdhEntity.LXDH = this.LXDH[i];
                    listResults.Add(lxdhLogic.Insert(lxdhEntity));
                }
            }
        }

        PageHelper.RegisterJavascriptAfterBody(this, listResults.Contains(false) == true ? "alert('保存失败')" : "alert('保存成功')");
        this.BindView();
    }

    private ayjz_ayzhxxInfo GetAYJZEntity()
    {
        ayjz_ayzhxxInfo entity = new ayjz_ayzhxxInfo();
        if (!string.IsNullOrEmpty(this.PKID))
        {
            entity.ID = MyConvert.ToLong(this.PKID);
        }
        entity.XM = this.XM;
        entity.XB = this.XB;
        entity.SFZH = this.SFZH;
        entity.HYZK = this.HYZK;
        entity.MZ = this.MZ;
        entity.YHCD = this.YHCD;
        entity.SG = this.SG;
        entity.TZ = this.TZ;
        entity.ZTCY = this.ZTCY;
        entity.SFHMD = this.SFZHMD;
        entity.SJZDQR = this.SJZDQR;
        entity.JKZBH = this.JKZBH;
        entity.BLYY = this.BLYY;
        entity.BSYSQ = this.BSYSQ;
        entity.BSGMQ = this.BSGMQ;
        entity.SS = this.SS;
        entity.XZZ = this.XZZ;
        entity.HJDZ = this.HJDZ;
        entity.FWGZ = this.FWGZ;
        entity.FWNR = this.FWNR;
        entity.BM = this.BM;
        entity.GX = this.GX;
        entity.FP = this.FP;

        //this.DIV_LXDH.InnerHtml = string.Empty;             //联系电话
        //this.DIV_LXSJ.InnerHtml = string.Empty;             //联系手机
        //this.DIV_YHZH.InnerHtml = string.Empty;             //银行帐号
        //this.DIV_FWSJD.InnerHtml = string.Empty;            //服务时间段

        return entity;
    }

    #endregion

    #endregion

    #region 事件

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DoInit();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.DoSave();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }

    #endregion
}
