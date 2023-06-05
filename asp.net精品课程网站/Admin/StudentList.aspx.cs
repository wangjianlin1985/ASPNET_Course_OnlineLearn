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
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindclassObj();
                string sqlstr = " where 1=1 ";
                if (Request["user_name"] != null && Request["user_name"].ToString() != "")
                {
                    sqlstr += "  and user_name like '%" + Request["user_name"].ToString() + "%'";
                    user_name.Text = Request["user_name"].ToString();
                }
                if (Request["classObj"] != null && Request["classObj"].ToString() != "")
                {
                    sqlstr += "  and classObj='" + Request["classObj"].ToString() + "'";
                    classObj.SelectedValue = Request["classObj"].ToString();
                }
                if (Request["name"] != null && Request["name"].ToString() != "")
                {
                    sqlstr += "  and name like '%" + Request["name"].ToString() + "%'";
                    name.Text = Request["name"].ToString();
                }
                if (Request["birthDate"] != null && Request["birthDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,birthDate,120) like '" + Request["birthDate"].ToString() + "%'";
                    birthDate.Text = Request["birthDate"].ToString();
                }
                if (Request["telephone"] != null && Request["telephone"].ToString() != "")
                {
                    sqlstr += "  and telephone like '%" + Request["telephone"].ToString() + "%'";
                    telephone.Text = Request["telephone"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindclassObj()
        {
            ListItem li = new ListItem("不限制", "");
            classObj.Items.Add(li);
            DataSet classObjDs = BLL.bllClassInfo.getAllClassInfo();
            for (int i = 0; i < classObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = classObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["className"].ToString(), dr["className"].ToString());
                classObj.Items.Add(li);
            }
            classObj.SelectedValue = "";
        }

        protected void BtnStudentAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllStudent.DelStudent(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "StudentList.aspx");
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
            DataTable dsLog = BLL.bllStudent.GetStudent(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpStudent.DataSource = dsLog;
            RpStudent.DataBind();
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
        protected void RpStudent_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllStudent.DelStudent((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "StudentList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "StudentList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "StudentList.aspx");
                }
            }
        }
        public string GetClassInfoclassObj(string classObj)
        {
            return BLL.bllClassInfo.getSomeClassInfo(classObj).className;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx?user_name=" + user_name.Text.Trim()  + "&&classObj=" + classObj.SelectedValue.Trim()+ "&&name=" + name.Text.Trim()+ "&&birthDate=" + birthDate.Text.Trim()+ "&&telephone=" + telephone.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet studentDataSet = BLL.bllStudent.GetStudent(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='9'>学生记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>学号</th>");
            sb.Append("<th>所在班级</th>");
            sb.Append("<th>姓名</th>");
            sb.Append("<th>性别</th>");
            sb.Append("<th>出生日期</th>");
            sb.Append("<th>用户照片</th>");
            sb.Append("<th>联系电话</th>");
            sb.Append("<th>邮箱</th>");
            sb.Append("<th>注册时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < studentDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = studentDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["user_name"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllClassInfo.getSomeClassInfo(dr["classObj"].ToString()).className + "</td>");
                sb.Append("<td>" + dr["name"].ToString() + "</td>");
                sb.Append("<td>" + dr["gender"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["birthDate"]).ToShortDateString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["userPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["telephone"].ToString() + "</td>");
                sb.Append("<td>" + dr["email"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["regTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "学生记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
