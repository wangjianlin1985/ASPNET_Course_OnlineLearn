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

namespace chengxusheji.Admin
{
    public partial class TextBookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                string sqlstr = " where 1=1 ";
                if (Request["textBookName"] != null && Request["textBookName"].ToString() != "")
                {
                    sqlstr += "  and textBookName like '%" + Request["textBookName"].ToString() + "%'";
                    textBookName.Text = Request["textBookName"].ToString();
                }
                if (Request["textBookClass"] != null && Request["textBookClass"].ToString() != "")
                {
                    sqlstr += "  and textBookClass like '%" + Request["textBookClass"].ToString() + "%'";
                    textBookClass.Text = Request["textBookClass"].ToString();
                }
                if (Request["publishDate"] != null && Request["publishDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,publishDate,120) like '" + Request["publishDate"].ToString() + "%'";
                    publishDate.Text = Request["publishDate"].ToString();
                }
                if (Request["author"] != null && Request["author"].ToString() != "")
                {
                    sqlstr += "  and author like '%" + Request["author"].ToString() + "%'";
                    author.Text = Request["author"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        protected void BtnTextBookAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("TextBookEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllTextBook.DelTextBook(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "TextBookList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllTextBook.GetTextBook(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpTextBook.DataSource = dsLog;
            RpTextBook.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpTextBook_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllTextBook.DelTextBook((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "TextBookList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "TextBookList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "TextBookList.aspx");
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("TextBookList.aspx?textBookName=" + textBookName.Text.Trim() + "&&textBookClass=" + textBookClass.Text.Trim()+ "&&publishDate=" + publishDate.Text.Trim()+ "&&author=" + author.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet textBookDataSet = BLL.bllTextBook.GetTextBook(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='8'>教材记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>教材id</th>");
            sb.Append("<th>教材名称</th>");
            sb.Append("<th>教材类别</th>");
            sb.Append("<th>教材定价</th>");
            sb.Append("<th>出版社</th>");
            sb.Append("<th>出版日期</th>");
            sb.Append("<th>作者</th>");
            sb.Append("<th>库存数量</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < textBookDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = textBookDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["textBookId"].ToString() + "</td>");
                sb.Append("<td>" + dr["textBookName"].ToString() + "</td>");
                sb.Append("<td>" + dr["textBookClass"].ToString() + "</td>");
                sb.Append("<td>" + dr["price"].ToString() + "</td>");
                sb.Append("<td>" + dr["publish"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["publishDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["author"].ToString() + "</td>");
                sb.Append("<td>" + dr["bookCount"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "教材记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
