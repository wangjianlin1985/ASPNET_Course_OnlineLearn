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
    ///Course 的摘要说明：课程实体
    /// </summary>

    public class Course
    {
        /*课程编号*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*课程名称*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*课程图片*/
        private string _coursePhoto;
        public string coursePhoto
        {
            get { return _coursePhoto; }
            set { _coursePhoto = value; }
        }

        /*上课老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*课程学时*/
        private int _courseHours;
        public int courseHours
        {
            get { return _courseHours; }
            set { _courseHours = value; }
        }

        /*教学大纲*/
        private string _jxff;
        public string jxff
        {
            get { return _jxff; }
            set { _jxff = value; }
        }

        /*课程简介*/
        private string _kcjj;
        public string kcjj
        {
            get { return _kcjj; }
            set { _kcjj = value; }
        }

    }
}
