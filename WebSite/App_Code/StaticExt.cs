using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using System.Web.UI;

/// <summary>
///StaticExt 的摘要说明
/// </summary>
public static class StaticExt
{
    public static void GridOutExcel(GridView gvTable, object data, Page page, string Outname)
    {
        try
        {
            page.Response.ClearContent();
            //page.Response.Charset = "GB2312";
            page.Response.AddHeader("content-disposition", "attachment; filename=" + page.Server.UrlEncode(Outname) + ".xls");
            page.Response.ContentType = "application/excel";
            //page.Response.ContentEncoding = System.Text.Encoding.UTF7;
            GridView oView = new GridView();
            foreach (DataControlField field in gvTable.Columns)
            {
                oView.Columns.Add(field);
            }
            if (page.GetType().GetMethod(gvTable.ID + "_RowCreated", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) != null)
                oView.RowCreated += delegate(object sender, GridViewRowEventArgs e)
                {
                    page.GetType().GetMethod(gvTable.ID + "_RowCreated", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(page, new object[] { sender, e });
                };
            if (page.GetType().GetMethod(gvTable.ID + "_RowDataBound", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) != null)
                oView.RowDataBound += delegate(object sender, GridViewRowEventArgs e)
                {
                    page.GetType().GetMethod(gvTable.ID + "_RowDataBound", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(page, new object[] { sender, e });
                };

            oView.AutoGenerateColumns = false;
            oView.DataSource = data;
            oView.DataBind();
            for (int i = oView.Columns.Count - 1; i >= 0; i--)
            {
                if (oView.Columns[i].HeaderText == "")
                    oView.Columns[i].Visible = false;
            }
            StringWriter o_sw = new StringWriter();
            HtmlTextWriter o_htw = new HtmlTextWriter(o_sw);
            oView.RenderControl(o_htw);
            page.Response.Write(o_sw.ToString());
            page.Response.End();

        }
        catch (Exception ex)
        { }
    }

    public static void GridOutExcel(GridView gvTable, Page page, string Outname)
    {
        try
        {
            page.Response.ClearContent();
            //page.Response.Charset = "GB2312";
            page.Response.Charset = "UTF-8";
            page.Response.ContentEncoding = System.Text.Encoding.UTF8;
            page.Response.HeaderEncoding = System.Text.Encoding.UTF8; 
            page.Response.AddHeader("content-disposition", "attachment; filename=" + page.Server.UrlEncode(Outname) + ".xls");
            page.Response.ContentType = "application/excel";
            StringWriter o_sw = new StringWriter();
            HtmlTextWriter o_htw = new HtmlTextWriter(o_sw);
            gvTable.RenderControl(o_htw);
            page.Response.Write(o_sw.ToString());
            page.Response.End();

        }
        catch (Exception ex)
        { }
    }

    public static void GridOutExcel(Control gvTable, Page page, string Outname)
    {
        try
        {
            page.Response.ClearContent();
            //page.Response.Charset = "GB2312";
            page.Response.ContentEncoding = System.Text.Encoding.Default;
            page.Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(Outname, System.Text.Encoding.UTF8) + ".xls");
            page.Response.ContentType = "application/excel";
            StringWriter o_sw = new StringWriter();
            HtmlTextWriter o_htw = new HtmlTextWriter(o_sw);
            gvTable.RenderControl(o_htw);
            page.Response.Write(o_sw.ToString());
            page.Response.End();

        }
        catch (Exception ex)
        { }
    }

    public static void GridOutExcelGB2312(Control gvTable, Page page, string Outname)
    {
        try
        {
            page.Response.ClearContent();
            page.Response.Charset = "GB2312";
            //page.Response.ContentEncoding = System.Text.Encoding.Default;
            page.Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(Outname, System.Text.Encoding.UTF8) + ".xls");
            page.Response.ContentType = "application/excel";
            StringWriter o_sw = new StringWriter();
            HtmlTextWriter o_htw = new HtmlTextWriter(o_sw);
            gvTable.RenderControl(o_htw);
            page.Response.Write(o_sw.ToString());
            page.Response.End();

        }
        catch (Exception ex)
        { }
    }
}
