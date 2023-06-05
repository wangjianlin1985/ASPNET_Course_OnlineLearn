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
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Video 的摘要说明：视频录像实体
    /// </summary>

    public class Video
    {
        /*视频id*/
        private int _videoId;
        public int videoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        /*视频标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*所属课程*/
        private string _courseObj;
        public string courseObj
        {
            get { return _courseObj; }
            set { _courseObj = value; }
        }

        /*视频介绍*/
        private string _videoDesc;
        public string videoDesc
        {
            get { return _videoDesc; }
            set { _videoDesc = value; }
        }

        /*视频文件*/
        private string _videoFile;
        public string videoFile
        {
            get { return _videoFile; }
            set { _videoFile = value; }
        }

        /*上传的老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*录制时间*/
        private DateTime _videoTime;
        public DateTime videoTime
        {
            get { return _videoTime; }
            set { _videoTime = value; }
        }

    }
}
