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
    ///Kejian ��ժҪ˵�����μ�ʵ��
    /// </summary>

    public class Kejian
    {
        /*�μ�id*/
        private int _kejianId;
        public int kejianId
        {
            get { return _kejianId; }
            set { _kejianId = value; }
        }

        /*�μ�����*/
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

        /*�μ�����*/
        private string _kejianDesc;
        public string kejianDesc
        {
            get { return _kejianDesc; }
            set { _kejianDesc = value; }
        }

        /*�μ��ļ�*/
        private string _kejianFile;
        public string kejianFile
        {
            get { return _kejianFile; }
            set { _kejianFile = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
