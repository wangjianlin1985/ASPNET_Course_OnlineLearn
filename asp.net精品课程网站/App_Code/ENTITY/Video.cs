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
    ///Video ��ժҪ˵������Ƶ¼��ʵ��
    /// </summary>

    public class Video
    {
        /*��Ƶid*/
        private int _videoId;
        public int videoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        /*��Ƶ����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*�����γ�*/
        private string _courseObj;
        public string courseObj
        {
            get { return _courseObj; }
            set { _courseObj = value; }
        }

        /*��Ƶ����*/
        private string _videoDesc;
        public string videoDesc
        {
            get { return _videoDesc; }
            set { _videoDesc = value; }
        }

        /*��Ƶ�ļ�*/
        private string _videoFile;
        public string videoFile
        {
            get { return _videoFile; }
            set { _videoFile = value; }
        }

        /*�ϴ�����ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*¼��ʱ��*/
        private DateTime _videoTime;
        public DateTime videoTime
        {
            get { return _videoTime; }
            set { _videoTime = value; }
        }

    }
}
