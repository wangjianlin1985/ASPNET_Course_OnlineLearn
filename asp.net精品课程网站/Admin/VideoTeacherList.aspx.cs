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
    public partial class VideoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindcourseObj(); 
                string sqlstr = " where 1=1 ";
                if (Request["title"] != null && Request["title"].ToString() != "")
                {
                    sqlstr += "  and title like '%" + Request["title"].ToString() + "%'";
                    title.Text = Request["title"].ToString();
                }
                if (Request["courseObj"] != null && Request["courseObj"].ToString() != "")
                {
                    sqlstr += "  and courseObj='" + Request["courseObj"].ToString() + "'";
                    courseObj.SelectedValue = Request["courseObj"].ToString();
                }
                
                sqlstr += "  and teacherObj='" + Session["Customername"].ToString() + "'";
                if (Request["videoTime"] != null && Request["videoTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,videoTime,120) like '" + Request["videoTime"].ToString() + "%'";
                    videoTime.Text = Request["videoTime"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindcourseObj()
        {
            ListItem li = new ListItem("不限制", "");
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

        
        protected void BtnVideoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("VideoTeacherAdd.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllVideo.DelVideo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "VideoTeacherList.aspx");
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
            DataTable dsLog = BLL.bllVideo.GetVideo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpVideo.DataSource = dsLog;
            RpVideo.DataBind();
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
        protected void RpVideo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllVideo.DelVideo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "VideoTeacherList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "VideoTeacherList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "VideoTeacherList.aspx");
                }
            }
        }
        public string GetCoursecourseObj(string courseObj)
        {
            return BLL.bllCourse.getSomeCourse(courseObj).courseName;
        }

        public string GetTeacherteacherObj(string teacherObj)
        {
            return BLL.bllTeacher.getSomeTeacher(teacherObj).teacherName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("VideoTeacherList.aspx?title=" + title.Text.Trim() + "&&courseObj=" + courseObj.SelectedValue.Trim() + "&&teacherObj=" + Session["Customername"].ToString() + "&&videoTime=" + videoTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet videoDataSet = BLL.bllVideo.GetVideo(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>视频录像记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>视频id</th>");
            sb.Append("<th>视频标题</th>");
            sb.Append("<th>所属课程</th>");
            sb.Append("<th>视频文件</th>");
            sb.Append("<th>上传的老师</th>");
            sb.Append("<th>录制时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < videoDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = videoDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["videoId"].ToString() + "</td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllCourse.getSomeCourse(dr["courseObj"].ToString()).courseName + "</td>");
                sb.Append("<td>" + dr["videoFile"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllTeacher.getSomeTeacher(dr["teacherObj"].ToString()).teacherName + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["videoTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "视频录像记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
