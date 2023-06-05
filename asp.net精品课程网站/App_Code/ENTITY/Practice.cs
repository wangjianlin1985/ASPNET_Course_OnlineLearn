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
    ///Practice 的摘要说明：课程实践实体
    /// </summary>

    public class Practice
    {
        /*实践id*/
        private int _practiceId;
        public int practiceId
        {
            get { return _practiceId; }
            set { _practiceId = value; }
        }

        /*实践的课程*/
        private string _courseObj;
        public string courseObj
        {
            get { return _courseObj; }
            set { _courseObj = value; }
        }

        /*实践主题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*实践内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*实践地点*/
        private string _place;
        public string place
        {
            get { return _place; }
            set { _place = value; }
        }

        /*实践时间*/
        private DateTime _praticeTime;
        public DateTime praticeTime
        {
            get { return _praticeTime; }
            set { _praticeTime = value; }
        }

    }
}
