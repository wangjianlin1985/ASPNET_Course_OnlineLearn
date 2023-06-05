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
    ///Kejian 的摘要说明：课件实体
    /// </summary>

    public class Kejian
    {
        /*课件id*/
        private int _kejianId;
        public int kejianId
        {
            get { return _kejianId; }
            set { _kejianId = value; }
        }

        /*课件标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*所属课程*/
        private string _courseObj;
        public string courseObj
        {
            get { return _courseObj; }
            set { _courseObj = value; }
        }

        /*课件描述*/
        private string _kejianDesc;
        public string kejianDesc
        {
            get { return _kejianDesc; }
            set { _kejianDesc = value; }
        }

        /*课件文件*/
        private string _kejianFile;
        public string kejianFile
        {
            get { return _kejianFile; }
            set { _kejianFile = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
