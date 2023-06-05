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
    public partial class ThesisList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindteacherObj();
                string sqlstr = " where 1=1 ";
                if (Request["lwmc"] != null && Request["lwmc"].ToString() != "")
                {
                    sqlstr += "  and lwmc like '%" + Request["lwmc"].ToString() + "%'";
                    lwmc.Text = Request["lwmc"].ToString();
                }
                if (Request["qkmc"] != null && Request["qkmc"].ToString() != "")
                {
                    sqlstr += "  and qkmc like '%" + Request["qkmc"].ToString() + "%'";
                    qkmc.Text = Request["qkmc"].ToString();
                }
                if (Request["fbrq"] != null && Request["fbrq"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,fbrq,120) like '" + Request["fbrq"].ToString() + "%'";
                    fbrq.Text = Request["fbrq"].ToString();
                }
                if (Request["teacherObj"] != null && Request["teacherObj"].ToString() != "")
                {
                    sqlstr += "  and teacherObj='" + Request["teacherObj"].ToString() + "'";
                    teacherObj.SelectedValue = Request["teacherObj"].ToString();
                }
                if (Request["shzt"] != null && Request["shzt"].ToString() != "")
                {
                    sqlstr += "  and shzt like '%" + Request["shzt"].ToString() + "%'";
                    shzt.Text = Request["shzt"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindteacherObj()
        {
            ListItem li = new ListItem("������", "");
            teacherObj.Items.Add(li);
            DataSet teacherObjDs = BLL.bllTeacher.getAllTeacher();
            for (int i = 0; i < teacherObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = teacherObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["teacherName"].ToString(), dr["teacherName"].ToString());
                teacherObj.Items.Add(li);
            }
            teacherObj.SelectedValue = "";
        }

        protected void BtnThesisAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThesisEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllThesis.DelThesis(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "ThesisList.aspx");
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
            DataTable dsLog = BLL.bllThesis.GetThesis(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpThesis.DataSource = dsLog;
            RpThesis.DataBind();
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
        protected void RpThesis_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllThesis.DelThesis((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "ThesisList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "ThesisList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "ThesisList.aspx");
                }
            }
        }
        public string GetTeacherteacherObj(string teacherObj)
        {
            return BLL.bllTeacher.getSomeTeacher(teacherObj).teacherName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThesisList.aspx?lwmc=" + lwmc.Text.Trim() + "&&qkmc=" + qkmc.Text.Trim()+ "&&fbrq=" + fbrq.Text.Trim() + "&&teacherObj=" + teacherObj.SelectedValue.Trim()+ "&&shzt=" + shzt.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet thesisDataSet = BLL.bllThesis.GetThesis(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>���ļ�¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>����id</th>");
            sb.Append("<th>��������</th>");
            sb.Append("<th>�ڿ�����</th>");
            sb.Append("<th>��������</th>");
            sb.Append("<th>��������</th>");
            sb.Append("<th>���״̬</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < thesisDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = thesisDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["thesisId"].ToString() + "</td>");
                sb.Append("<td>" + dr["lwmc"].ToString() + "</td>");
                sb.Append("<td>" + dr["qkmc"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["fbrq"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + BLL.bllTeacher.getSomeTeacher(dr["teacherObj"].ToString()).teacherName + "</td>");
                sb.Append("<td>" + dr["shzt"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "���ļ�¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
