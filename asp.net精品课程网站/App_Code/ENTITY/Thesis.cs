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
    ///Thesis ��ժҪ˵��������ʵ��
    /// </summary>

    public class Thesis
    {
        /*����id*/
        private int _thesisId;
        public int thesisId
        {
            get { return _thesisId; }
            set { _thesisId = value; }
        }

        /*��������*/
        private string _lwmc;
        public string lwmc
        {
            get { return _lwmc; }
            set { _lwmc = value; }
        }

        /*�ڿ�����*/
        private string _qkmc;
        public string qkmc
        {
            get { return _qkmc; }
            set { _qkmc = value; }
        }

        /*��������*/
        private DateTime _fbrq;
        public DateTime fbrq
        {
            get { return _fbrq; }
            set { _fbrq = value; }
        }

        /*��������*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*���״̬*/
        private string _shzt;
        public string shzt
        {
            get { return _shzt; }
            set { _shzt = value; }
        }

    }
}
