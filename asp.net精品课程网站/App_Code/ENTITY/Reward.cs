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
    ///Reward ��ժҪ˵������ʵ��
    /// </summary>

    public class Reward
    {
        /*��id*/
        private int _rewardId;
        public int rewardId
        {
            get { return _rewardId; }
            set { _rewardId = value; }
        }

        /*��ԭ��*/
        private string _reason;
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        /*������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�񽱵���ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*��ʱ��*/
        private DateTime _rewardTime;
        public DateTime rewardTime
        {
            get { return _rewardTime; }
            set { _rewardTime = value; }
        }

    }
}
