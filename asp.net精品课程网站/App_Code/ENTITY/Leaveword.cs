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
    ///Leaveword ��ժҪ˵�������Դ���ʵ��
    /// </summary>

    public class Leaveword
    {
        /*����id*/
        private int _leaveWordId;
        public int leaveWordId
        {
            get { return _leaveWordId; }
            set { _leaveWordId = value; }
        }

        /*��������*/
        private string _leaveTitle;
        public string leaveTitle
        {
            get { return _leaveTitle; }
            set { _leaveTitle = value; }
        }

        /*��������*/
        private string _leaveContent;
        public string leaveContent
        {
            get { return _leaveContent; }
            set { _leaveContent = value; }
        }

        /*������*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _leaveTime;
        public DateTime leaveTime
        {
            get { return _leaveTime; }
            set { _leaveTime = value; }
        }

        /*���ɻظ�*/
        private string _replyContent;
        public string replyContent
        {
            get { return _replyContent; }
            set { _replyContent = value; }
        }

        /*����ʱ��*/
        private string _replyTime;
        public string replyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

    }
}
