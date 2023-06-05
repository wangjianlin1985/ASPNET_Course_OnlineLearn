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
    public partial class VideoEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindCoursecourseObj(); 
                
            }
        }
        private void BindCoursecourseObj()
        {
            courseObj.DataSource = BLL.bllCourse.getAllCourse();
            courseObj.DataTextField = "courseName";
            courseObj.DataValueField = "courseNo";
            courseObj.DataBind();
        } 

        protected void BtnVideoSave_Click(object sender, EventArgs e)
        {
            ENTITY.Video video = new ENTITY.Video();
            video.title = title.Value;
            video.courseObj = courseObj.SelectedValue;
            video.videoDesc = videoDesc.Value;
            video.videoFile = videoFile.Text;
            video.teacherObj = Session["Customername"].ToString();
            video.videoTime = Convert.ToDateTime(videoTime.Text);
            
            if (BLL.bllVideo.AddVideo(video))
            {
                Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"VideoTeacherAdd.aspx\"} else  {location.href=\"VideoTeacherList.aspx\"} ");
            }
            else
            {
                Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("VideoTeacherList.aspx");
        }
        protected void Btn_VideoFileUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.VideoFileUpload.PostedFile.ContentLength > 0)
            {
                this.videoFile.Text = "上传文件中....";
                string extFileString = System.IO.Path.GetExtension(this.VideoFileUpload.PostedFile.FileName); /*获取文件扩展名*/
                string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                string filePath = "FileUpload/" + saveFileName;/*文件路径*/
                this.VideoFileUpload.PostedFile.SaveAs(Server.MapPath("../" + filePath));
                this.videoFile.Text = filePath;
            }
        }
    }
}

