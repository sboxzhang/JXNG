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

/// <summary>
/// Summary description for UGridView
/// </summary>
public class UGridView
{
    public UGridView(GridView grd)
    {
        if (grd.EmptyDataText == "")
        {
            grd.EmptyDataText = "没有符合条件的数据";
        }
        grd.PreRender += new EventHandler(grd_PreRender);
    }

    void grd_PreRender(object sender, EventArgs e)
    {
        DrawHeader(sender);
    }
    private void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
        {
            DrawHeader(sender);
        }
    }
    private void DrawHeader(object sender)
    {
        GridView grd = (GridView)sender;
        if (grd.Rows.Count > 0) return; //有数据，不要处理
        GridViewRow row = new GridViewRow(-1, -1, DataControlRowType.EmptyDataRow, DataControlRowState.Normal);
        foreach (DataControlField field in grd.Columns)
        {
            TableCell cell = new TableCell();
            cell.Text = field.HeaderText;
            cell.Width = field.HeaderStyle.Width;
            cell.Height = field.HeaderStyle.Height;
            cell.ForeColor = field.HeaderStyle.ForeColor;
            cell.Font.Size = field.HeaderStyle.Font.Size;
            cell.Font.Bold = field.HeaderStyle.Font.Bold;
            cell.Font.Name = field.HeaderStyle.Font.Name;
            cell.Font.Strikeout = field.HeaderStyle.Font.Strikeout;
            cell.Font.Underline = field.HeaderStyle.Font.Underline;
            cell.BackColor = field.HeaderStyle.BackColor;
            cell.VerticalAlign = field.HeaderStyle.VerticalAlign;
            cell.HorizontalAlign = field.HeaderStyle.HorizontalAlign;
            //cell.CssClass = field.HeaderStyle.CssClass;
            cell.BorderColor = field.HeaderStyle.BorderColor;
            cell.BorderStyle = field.HeaderStyle.BorderStyle;
            cell.BorderWidth = field.HeaderStyle.BorderWidth;
            cell.Visible = field.Visible;
            row.Cells.Add(cell);
        }

        TableItemStyle headStyle = grd.HeaderStyle;
        TableItemStyle emptyStyle = grd.EmptyDataRowStyle;
        emptyStyle.Width = headStyle.Width;
        emptyStyle.Height = headStyle.Height;
        emptyStyle.ForeColor = headStyle.ForeColor;
        emptyStyle.Font.Size = headStyle.Font.Size;
        emptyStyle.Font.Bold = headStyle.Font.Bold;
        emptyStyle.Font.Name = headStyle.Font.Name;
        emptyStyle.Font.Strikeout = headStyle.Font.Strikeout;
        emptyStyle.Font.Underline = headStyle.Font.Underline;
        emptyStyle.BackColor = headStyle.BackColor;
        emptyStyle.VerticalAlign = headStyle.VerticalAlign;
        emptyStyle.HorizontalAlign = headStyle.HorizontalAlign;
        emptyStyle.CssClass = emptyStyle.CssClass;
        emptyStyle.BorderColor = headStyle.BorderColor;
        emptyStyle.BorderStyle = headStyle.BorderStyle;
        emptyStyle.BorderWidth = headStyle.BorderWidth;
        if (grd.Controls.Count == 0)
        {
            //grd.Page.Response.Write("<script language='javascript'>alert('必须在初始化表格类之前执行DataBind方法并设置EmptyDataText属性不为空!');</script>");
        }
        else
        {
            grd.Controls[0].Controls.Clear(); //删除没数据时的提示
            grd.Controls[0].Controls.AddAt(0, row);
        }

    }
}