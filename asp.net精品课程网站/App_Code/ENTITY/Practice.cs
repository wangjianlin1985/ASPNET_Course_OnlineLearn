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
    ///Practice ��ժҪ˵�����γ�ʵ��ʵ��
    /// </summary>

    public class Practice
    {
        /*ʵ��id*/
        private int _practiceId;
        public int practiceId
        {
            get { return _practiceId; }
            set { _practiceId = value; }
        }

        /*ʵ���Ŀγ�*/
        private string _courseObj;
        public string courseObj
        {
            get { return _courseObj; }
            set { _courseObj = value; }
        }

        /*ʵ������*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*ʵ������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*ʵ���ص�*/
        private string _place;
        public string place
        {
            get { return _place; }
            set { _place = value; }
        }

        /*ʵ��ʱ��*/
        private DateTime _praticeTime;
        public DateTime praticeTime
        {
            get { return _praticeTime; }
            set { _praticeTime = value; }
        }

    }
}
