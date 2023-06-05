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
    public partial class PracticeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindcourseObj();
                string sqlstr = " where 1=1 ";
                if (Request["courseObj"] != null && Request["courseObj"].ToString() != "")
                {
                    sqlstr += "  and courseObj='" + Request["courseObj"].ToString() + "'";
                    courseObj.SelectedValue = Request["courseObj"].ToString();
                }
                if (Request["title"] != null && Request["title"].ToString() != "")
                {
                    sqlstr += "  and title like '%" + Request["title"].ToString() + "%'";
                    title.Text = Request["title"].ToString();
                }
                if (Request["praticeTime"] != null && Request["praticeTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,praticeTime,120) like '" + Request["praticeTime"].ToString() + "%'";
                    praticeTime.Text = Request["praticeTime"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindcourseObj()
        {
            ListItem li = new ListItem("������", "");
            courseObj.Items.Add(li);
            DataSet courseObjDs = BLL.bllCourse.getAllCourse();
            for (int i = 0; i < courseObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = courseObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["courseName"].ToString(), dr["courseName"].ToString());
                courseObj.Items.Add(li);
            }
            courseObj.SelectedValue = "";
        }

        protected void BtnPracticeAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("PracticeEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllPractice.DelPractice(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "PracticeList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
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
            DataTable dsLog = BLL.bllPractice.GetPractice(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpPractice.DataSource = dsLog;
            RpPractice.DataBind();
            PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
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
        protected void RpPractice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllPractice.DelPractice((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "PracticeList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "PracticeList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "PracticeList.aspx");
                }
            }
        }
        public string GetCoursecourseObj(string courseObj)
        {
            return BLL.bllCourse.getSomeCourse(courseObj).courseName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("PracticeList.aspx?courseObj=" + courseObj.SelectedValue.Trim()+ "&&title=" + title.Text.Trim()+ "&&praticeTime=" + praticeTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet practiceDataSet = BLL.bllPractice.GetPractice(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='5'>�γ�ʵ����¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>ʵ��id</th>");
            sb.Append("<th>ʵ���Ŀγ�</th>");
            sb.Append("<th>ʵ������</th>");
            sb.Append("<th>ʵ���ص�</th>");
            sb.Append("<th>ʵ��ʱ��</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < practiceDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = practiceDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["practiceId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllCourse.getSomeCourse(dr["courseObj"].ToString()).courseName + "</td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td>" + dr["place"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["praticeTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "�γ�ʵ����¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
