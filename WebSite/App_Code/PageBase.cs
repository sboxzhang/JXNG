using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Security;
using VSM.DevFx.SysManage;
using System.Web.UI;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : System.Web.UI.Page
{
    private static readonly string url = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
    public PageBase()
    {

    }
    #region 清空指定页面上所有的控件内容，public static void ClearAllContent()
    /// <summary>
    /// 清空指定页面上所有的控件内容，包括TextBox，CheckBox,CheckBoxList,RadioButton,RadioButtonList。但是不清
    /// 除如ListBox，DropDownList，因为这样的控件值对当前页面来说还可以用，一般这些控件里都是保存的字典数据。
    /// Author：zhangshh
    /// 日期：2004-12-02
    /// </summary>
    /// <param name="page"> 指定的页面</param> 
    public static void ClearAllContent(System.Web.UI.Control page)
    {
        //int nPageControls = page.Controls.Count;
        //for (int i = 0; i < nPageControls; i++)
        //{[i].Controls
        foreach (System.Web.UI.Control control in page.Controls)
        {
            if (control.HasControls())
            {
                ClearAllContent(control);
            }
            else
            {
                if (control is TextBox)
                    (control as TextBox).Text = "";

                if (control is DropDownList)
                {
                    if ((control as DropDownList).Items.Count > 0)
                        (control as DropDownList).SelectedIndex = 0;
                }

                if (control is CheckBox)
                    (control as CheckBox).Checked = false;

                if (control is RadioButtonList)
                    (control as RadioButtonList).SelectedIndex = -1;

                if (control is RadioButton)
                    (control as RadioButton).Checked = false;

                if (control is CheckBoxList)
                {
                    foreach (ListItem item in (control as CheckBoxList).Items)
                    {
                        item.Selected = false;
                    }
                }
              
            }//if..else
        }//foreach
        //}//for
    }



    #endregion

    #region 常用方法

    protected void BindDDL(DropDownList ddl, string typeCode)
    {
        DictInfo dictInfo = new DictInfo() { TypeCode = typeCode };
        Dict dict = new Dict();        
        List<DictInfo> list = dict.GetDictInfoByCondition(dictInfo);
        if (list.Count > 0)
        {
            ddl.DataSource = list;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Code";
            ddl.DataBind();
        }

        ddl.Items.Insert(0, new ListItem("---请选择---", string.Empty));
    }

    protected void BindDDL<T>(string textFiled, string valudFiled, DropDownList ddl, List<T> list)
    {
        if (list.Count > 0)
        {
            ddl.DataSource = list;
            ddl.DataTextField = textFiled;
            ddl.DataValueField = valudFiled;
            ddl.DataBind();
        }

        ddl.Items.Insert(0, new ListItem("---请选择---", string.Empty));
    }

    #endregion

    private UserInfo _UserInfo = null;
    public UserInfo Users
    {
        get
        {
            Validator();
            return _UserInfo;

        }
    }
    private void Validator()
    {
        if (Session["UserInfo"] == null && JITE.CIS.DevFx.Security.Authentication.GetUserCode().Equals(""))
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            Response.Write("<script defer>window.alert('您没有权限进入本页或当前登录用户已过期！\\n请重新登录或与管理员联系！');parent.location='" + url + "';</script>");
            Response.End();
        }
        else
        {
            User _user = new User();
            if (_UserInfo == null)
                _UserInfo = _user.GetUserInfoByUserCode(JITE.CIS.DevFx.Security.Authentication.GetUserCode());
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (!Page.IsPostBack)
        {
            Validator();
        }
    }

    public static Control GetContentForID(System.Web.UI.Control page, string strControlID)
    {
        Control oControl = null;
        foreach (System.Web.UI.Control control in page.Controls)
        {
            if (control.HasControls())
            {
                if (control.ID != null && control.ID.Equals(strControlID)) oControl = control;
                Control oControl1 = GetContentForID(control, strControlID);
                if (oControl1 != null) oControl = oControl1;
            }
            else
            {
                if (control.ID != null && control.ID.Equals(strControlID)) oControl = control;
            }//if..else
        }//foreach
        return oControl;
    }
}
