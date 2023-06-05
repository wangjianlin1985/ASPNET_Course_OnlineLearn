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
                Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"VideoTeacherAdd.aspx\"} else  {location.href=\"VideoTeacherList.aspx\"} ");
            }
            else
            {
                Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("VideoTeacherList.aspx");
        }
        protected void Btn_VideoFileUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.VideoFileUpload.PostedFile.ContentLength > 0)
            {
                this.videoFile.Text = "�ϴ��ļ���....";
                string extFileString = System.IO.Path.GetExtension(this.VideoFileUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                string filePath = "FileUpload/" + saveFileName;/*�ļ�·��*/
                this.VideoFileUpload.PostedFile.SaveAs(Server.MapPath("../" + filePath));
                this.videoFile.Text = filePath;
            }
        }
    }
}

