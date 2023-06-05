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
    ///Reward 的摘要说明：获奖实体
    /// </summary>

    public class Reward
    {
        /*获奖id*/
        private int _rewardId;
        public int rewardId
        {
            get { return _rewardId; }
            set { _rewardId = value; }
        }

        /*获奖原因*/
        private string _reason;
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        /*获奖内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*获奖的老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*获奖时间*/
        private DateTime _rewardTime;
        public DateTime rewardTime
        {
            get { return _rewardTime; }
            set { _rewardTime = value; }
        }

    }
}
