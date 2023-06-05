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
    ///Thesis 的摘要说明：论文实体
    /// </summary>

    public class Thesis
    {
        /*论文id*/
        private int _thesisId;
        public int thesisId
        {
            get { return _thesisId; }
            set { _thesisId = value; }
        }

        /*论文名称*/
        private string _lwmc;
        public string lwmc
        {
            get { return _lwmc; }
            set { _lwmc = value; }
        }

        /*期刊名称*/
        private string _qkmc;
        public string qkmc
        {
            get { return _qkmc; }
            set { _qkmc = value; }
        }

        /*发布日期*/
        private DateTime _fbrq;
        public DateTime fbrq
        {
            get { return _fbrq; }
            set { _fbrq = value; }
        }

        /*论文作者*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*审核状态*/
        private string _shzt;
        public string shzt
        {
            get { return _shzt; }
            set { _shzt = value; }
        }

    }
}
