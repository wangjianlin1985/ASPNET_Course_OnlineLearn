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
    ///Course ��ժҪ˵�����γ�ʵ��
    /// </summary>

    public class Course
    {
        /*�γ̱��*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*�γ�����*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*�γ�ͼƬ*/
        private string _coursePhoto;
        public string coursePhoto
        {
            get { return _coursePhoto; }
            set { _coursePhoto = value; }
        }

        /*�Ͽ���ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*�γ�ѧʱ*/
        private int _courseHours;
        public int courseHours
        {
            get { return _courseHours; }
            set { _courseHours = value; }
        }

        /*��ѧ���*/
        private string _jxff;
        public string jxff
        {
            get { return _jxff; }
            set { _jxff = value; }
        }

        /*�γ̼��*/
        private string _kcjj;
        public string kcjj
        {
            get { return _kcjj; }
            set { _kcjj = value; }
        }

    }
}
