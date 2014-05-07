using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
//using JITE.CIS.DevFx.Security;

/// <summary>
///BaseCommunicationAttribute 的摘要说明
/// </summary>
[Serializable] 
public class BaseCommunicationAttribute : UserControl, IUserCommunications
{
    //ID项目代号
    private string _ObjID;
    //是否disable页面的判断条件值
    private bool _Disable = true;

    private string _Instance;

    private string _FlowType;

    /// <summary>
    /// 活动名称
    /// </summary>
    private string _ActivityName;

    /// <summary>
    /// 跟踪ID
    /// </summary>
    private string _TrackID;

    private string _GUID;

    public string GUID
    {
        get { return _GUID; }
        set { _GUID = value; }
    }

    public string TrackID
    {
        get { return _TrackID; }
        set { _TrackID = value; }
    }

    public string ActivityName
    {
        get { return _ActivityName; }
        set { _ActivityName = value; }
    }

    /// <summary>
    /// 工作流类型
    /// </summary>
    public string FlowType
    {
        get { return _FlowType; }
        set { _FlowType = value; }
    }

    /// <summary>
    /// 工作流ID
    /// </summary>
    public string Instance
    {
        get { return _Instance; }
        set { _Instance = value; }
    }

    /// <summary>
    /// 工程ID
    /// </summary>
    public string ObjID
    {
        set { _ObjID = value; }
        get { return _ObjID; }
    }

    public string EventHanlder
    {
        get;
        set;
    }

    public bool Disable
    {
        get { return _Disable; }
        set { _Disable = value; }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        if (!_Disable)
            ReadOnlyContent(this);
    }


    #region 清空指定页面上所有的控件内容，public static void ClearAllContent()
    /// <summary>
    /// 清空指定页面上所有的控件内容，包括TextBox，CheckBox,CheckBoxList,RadioButton,RadioButtonList。但是不清
    /// 除如ListBox，DropDownList，因为这样的控件值对当前页面来说还可以用，一般这些控件里都是保存的字典数据。
    /// Author：杨佑诚
    /// 日期：2008-06-06
    /// </summary>
    /// <param name="page"> 指定的页面</param> 
    public static void ReadOnlyContent(System.Web.UI.Control page)
    {
        foreach (System.Web.UI.Control control in page.Controls)
        {
            if (control.HasControls())
            {
                ReadOnlyContent(control);
            }
            else
            {
                if (control is TextBox)
                    (control as TextBox).ReadOnly = true;

                if (control is DropDownList)
                {
                    if ((control as DropDownList).Items.Count > 0)
                        (control as DropDownList).Enabled = false;
                }

                if (control is CheckBox)
                    (control as CheckBox).Enabled = false;

                if (control is RadioButtonList)
                    (control as RadioButtonList).Enabled = false;

                if (control is RadioButton)
                    (control as RadioButton).Enabled = false;

                if (control is CheckBoxList)
                {
                    foreach (ListItem item in (control as CheckBoxList).Items)
                    {
                        item.Enabled = false;
                    }
                }
                if (control is Button)
                {
                    (control as Button).Visible = false;
                }
            }//if..else
        }//foreach
    }
    #endregion

    #region IUserCommunications 成员

    public void GetID(string strID)
    {
        return;
    }

    public virtual bool Save()
    {
        return true;
    }

    public virtual System.Collections.Generic.Dictionary<string, object> GetFlowData()
    {
        return null;
    }

    #endregion
}
