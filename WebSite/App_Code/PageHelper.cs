using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
/// <summary>
///PageHelper 的摘要说明
/// </summary>
public class PageHelper
{
    public PageHelper()
    {

    }

    /// <summary>
    /// 截取字串长度
    /// </summary>
    /// <param name="strFull">原始字符串</param>
    /// <param name="iLength">截取的长度</param>
    /// <returns></returns>
    public static string SetCutString(Object strFull, int iLength)
    {
        if (strFull == null)
        {
            return "";
        }
        if (strFull.ToString().Length <= iLength)
        {
            return strFull.ToString();
        }
        return strFull.ToString().Substring(0, iLength) + "...";
    }


    //设置提交按钮点击后变灰
    public static void SetButtonGray(Button button, System.Web.UI.Page page)
    {

        //sb保存的是JavaScript脚本代码,点击提交按钮时执行该脚本
        StringBuilder sb = new StringBuilder();
        //保证验证函数的执行 
        sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }};");
        //点击提交按钮后设置Button的disable属性防止用户再次点击,注意这里的this是JavaScript代码
        sb.Append("this.value='提交中…';this.disabled  = true;");
        //用__doPostBack来提交，保证按钮的服务器端click事件执行 
        sb.Append(page.ClientScript.GetPostBackEventReference(button, ""));
        sb.Append(";");
        //SetUIStyle()是JavaScript函数,点击提交按钮后执行,如可以显示动画效果提示后台处理进度
        //给提交按钮增加OnClick属性
        button.Attributes.Add("onclick", sb.ToString());
    }

    /// <summary>
    /// 设置提交按钮点击后变灰
    /// </summary>
    /// <param name="button"></param>
    /// <param name="page"></param>
    /// <param name="btnText">变灰时显示文本</param>
    public static void SetButtonGray(Button button, System.Web.UI.Page page, string btnText)
    {

        //sb保存的是JavaScript脚本代码,点击提交按钮时执行该脚本
        StringBuilder sb = new StringBuilder();
        //保证验证函数的执行 
        sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }};");
        //点击提交按钮后设置Button的disable属性防止用户再次点击,注意这里的this是JavaScript代码
        //sb.Append("alert('12344');");
        sb.Append("this.value='" + btnText + "';this.disabled  = true;");
        //用__doPostBack来提交，保证按钮的服务器端click事件执行 
        sb.Append(page.ClientScript.GetPostBackEventReference(button, ""));
        sb.Append(";");
        //SetUIStyle()是JavaScript函数,点击提交按钮后执行,如可以显示动画效果提示后台处理进度
        //给提交按钮增加OnClick属性
        button.Attributes.Add("onclick", sb.ToString());
    }

    /// <summary>
    /// create random string 
    /// </summary>
    /// <returns>random string</returns>
    public static string CreateRandom()
    {
        int number;
        char code;
        string checkCode = String.Empty;

        System.Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            number = random.Next();

            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));

            checkCode += code.ToString();
        }
        return checkCode;
    }


    public static void SetTexxBoxMuiltleghth(TextBox textBox, int maxLegth)
    {
        string lengthFunction = "function isMaxLength(txtBox) {";
        lengthFunction += " if(txtBox) { ";
        lengthFunction += " return ( txtBox.value.length <=" + maxLegth + ");";
        lengthFunction += " }";
        lengthFunction += "}";

        textBox.Attributes.Add("onkeypress", "return isMaxLength(this);");
        ScriptManager.RegisterStartupScript(textBox,
        typeof(string),
        CreateRandom(),
        lengthFunction, true);
    }
    /**/
    /// <summary>
    /// 将Web控件或页面信息导出(不带文件名参数)
    /// </summary>
    /// <param name="source">控件实例</param>        
    /// <param name="DocumentType">导出类型:Excel或Word</param>
    public static void ExportControl(System.Web.UI.Control source, string DocumentType)
    {
        //设置Http的头信息,编码格式
        if (DocumentType == "Excel")
        {
            //Excel            
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("下载文件.xls", System.Text.Encoding.UTF8));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
        }
        else if (DocumentType == "Word")
        {
            //Word
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("下载文件.doc", System.Text.Encoding.UTF8));
            HttpContext.Current.Response.ContentType = "application/ms-word";
        }

        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

        //关闭控件的视图状态
        source.Page.EnableViewState = false;

        //初始化HtmlWriter
        System.IO.StringWriter writer = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);
        source.RenderControl(htmlWriter);

        //输出
        HttpContext.Current.Response.Write(writer.ToString());
        HttpContext.Current.Response.End();
    }

    /**/
    /// <summary>
    /// 将Web控件或页面信息导出(带文件名参数)
    /// </summary>
    /// <param name="source">控件实例</param>        
    /// <param name="DocumentType">导出类型:Excel或Word</param>
    /// <param name="filename">保存文件名</param>
    public static void ExportControl(System.Web.UI.Control source, string DocumentType, string filename)
    {
        //设置Http的头信息,编码格式
        if (DocumentType == "Excel")
        {
            //Excel            
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename + ".xls", System.Text.Encoding.UTF8));
            HttpContext.Current.Response.ContentType = "application/ms-excel";
        }

        else if (DocumentType == "Word")
        {
            //Word
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename + ".doc", System.Text.Encoding.UTF8));
            HttpContext.Current.Response.ContentType = "application/ms-word";
        }

        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

        //关闭控件的视图状态
        source.Page.EnableViewState = false;

        //初始化HtmlWriter
        System.IO.StringWriter writer = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);
        source.RenderControl(htmlWriter);

        //输出
        HttpContext.Current.Response.Write(writer.ToString());
        HttpContext.Current.Response.End();
    }

    public static void GridOutExcel(Control gvTable, Page page, string Outname)
    {
        try
        {
            page.Response.ClearContent();
            page.Response.Charset = "GB2312";
            page.Response.AddHeader("content-disposition", "attachment; filename=" + page.Server.UrlEncode(Outname) + ".xls");
            page.Response.ContentType = "application/excel";
            page.Response.ContentEncoding = System.Text.Encoding.Default;
            StringWriter o_sw = new StringWriter();
            HtmlTextWriter o_htw = new HtmlTextWriter(o_sw);
            gvTable.RenderControl(o_htw);
            page.Response.Write(o_sw.ToString());
            page.Response.End();

        }
        catch (Exception ex)
        { }
    }

    public static string GB2312_ISO8859(string write)
    {
        //声明字符集   
        System.Text.Encoding iso8859, gb2312;
        //iso8859   
        iso8859 = System.Text.Encoding.GetEncoding("iso8859-1");
        //国标2312   
        gb2312 = System.Text.Encoding.GetEncoding("gb2312");
        byte[] gb;
        gb = gb2312.GetBytes(write);
        //返回转换后的字符   
        return iso8859.GetString(gb);
    }

    public static void RegisterJavascriptBeforeBody(Page page, string script)
    {
        string scriptFrame = "<script type='text/javascript'>$(document).ready(function(){" + script + "});</script>";
        page.ClientScript.RegisterClientScriptBlock(page.GetType(), new Guid().ToString(), scriptFrame);
    }

    public static void RegisterJavascriptAfterBody(Page page, string script)
    {
        string scriptFrame = "<script type='text/javascript'>$(document).ready(function(){" + script + "});</script>";
        page.ClientScript.RegisterStartupScript(page.GetType(), new Guid().ToString(), scriptFrame);
    }

    public static void ScriptManageRegisterJavaScript(Page page, string script)
    {
        string scriptFrame = "$(document).ready(function(){" + script + "});";
        ScriptManager.RegisterStartupScript(page, page.GetType(), new Guid().ToString(), scriptFrame, true);
    }
}
