using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Practice_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        ListItem li = new ListItem("不限制", "");
        courseObj.Items.Add(li);
        DataSet courseObjDs = BLL.bllCourse.getAllCourse();
        for (int i = 0; i < courseObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = courseObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["courseName"].ToString(),dr["courseNo"].ToString());
            courseObj.Items.Add(li);
        }
        courseObj.SelectedValue = "";
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
        public string GetCoursecourseObj(string courseObj)
        {
            return BLL.bllCourse.getSomeCourse(courseObj).courseName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?courseObj=" + courseObj.SelectedValue.Trim()+ "&&title=" + title.Text.Trim()+ "&&praticeTime=" + praticeTime.Text.Trim());
        }

}
