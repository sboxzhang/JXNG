using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AYJZ.Entities;
using AYJZ.BusinessLogic;
using AYJZ.DevFx.SysManage;
using System.Collections.Generic;
using AYJZ.DataAccess;


public partial class khgl_khxx_Add : PageBase
{
    #region 属性

    /// <summary>
    /// 主键ID
    /// </summary>
    private string PKID
    {
        set { this.ViewState["PKID"] = value; }
        get
        {
            if (string.IsNullOrEmpty(this.Request["PKID"]))
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

    ayjz_khxxlogic khxxlogic = new ayjz_khxxlogic();
    
    #endregion

    #region 方法

    #region 初始化
    private void DoInit()
    {
        this.InitDDL();
    }

    private void InitDDL()
    {   
        this.BindDDL(this.DDL_FWGZ, "FWGZ");        //服务工种
        this.BindDDL(this.DDL_HYLX, "HYLX");        //会员类型
        this.BindDDL(this.DDL_GLF, "GLF");          //管理费
        this.BindDDL(this.DDL_FWNR,"FWNR");         //服务内容
    }

    private void BindView()
    {
        if (!string.IsNullOrEmpty(this.PKID))
        {
            ayjz_employeeinfoInfo khxx_info = this.khxxlogic.Getayjz_khxx(MyConvert.ToLong(this.PKID));

            this.TXT_USERNAME.Text = khxx_info.XM;                              //姓名
            this.DDL_FWGZ.SelectedValue = khxx_info.FWGZ;                       //服务工种
            this.TXT_SFZH.Text = khxx_info.SFZH;                                //身份证号
            this.CB_KHZT.Checked = khxx_info.KHZT == "1" ? true : false;        //客户状态
            this.DIV_LXDH.InnerHtml = string.Empty;                             //联系电话
            this.TXT_KHYXRQ.Text = khxx_info.KHYXQ;                             //客户有效日期
            this.DIV_LXSJ.InnerHtml = string.Empty;                             //联系手机
            this.CB_HMD.Checked = khxx_info.SFHMD == "1" ? true : false;        //是否黑名单
            this.TXT_KHFWDZ.Text = khxx_info.KHFZDZ;                            //客户服务地址
            this.TXT_KHHJDZ.Text = khxx_info.KHFZDZ;                            //客户户籍地址
            this.DIV_YHXX.InnerHtml = string.Empty;                             //银行信息
            this.DDL_FWNR.SelectedValue = khxx_info.FWNR;                       //服务内容
            HtmlInputText text = new HtmlInputText();

            switch (khxx_info.FWNR)
            {
                case "BJ":
                    this.DDL_BJCH.SelectedValue = khxx_info.FWXX1;              //保洁场合
                    this.TXT_MJ.Text = khxx_info.FWXX2;                         //保洁面积
                    break;
                case "ZGET":
                    this.TXT_ETZS.Text = khxx_info.FWXX1;                       //儿童周岁
                    break;
                case "ZGYYR":
                    this.TXT_YENL.Text = khxx_info.FWXX1;                       //婴儿周
                    break;
                case "YS":
                    this.TXT_YCQ.Text = khxx_info.FWXX1;                        //预产期
                    this.TXT_DGRQ.Text = khxx_info.FWXX2;                       //到岗日期
                    this.TXT_DGDD.Text = khxx_info.FWXX3;                       //到岗地点
                    break;
                case "ZGLR":
                    this.DDL_SEX.SelectedValue = khxx_info.FWXX1;               //性别
                    this.TXT_NL.Text = khxx_info.FWXX2;                         //老人年龄
                    this.DDL_ZLZT.SelectedValue = khxx_info.FWXX3;              //老人自理情况
                    break;
                case "FWNRQT":
                    this.TXT_QT.Text = khxx_info.FWXX1;                         //服务内容其他
                    break;

            }
            this.TXT_DEPT.Text = khxx_info.BM;                                  //部门
            this.DDL_GLF.SelectedValue = khxx_info.GLF;                         //管理费
            this.DDL_HYLX.SelectedValue = khxx_info.HYLX;                       //会员类型
        }
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
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }

    #endregion
}
