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
    ///TextBook 的摘要说明：教材实体
    /// </summary>

    public class TextBook
    {
        /*教材id*/
        private int _textBookId;
        public int textBookId
        {
            get { return _textBookId; }
            set { _textBookId = value; }
        }

        /*教材名称*/
        private string _textBookName;
        public string textBookName
        {
            get { return _textBookName; }
            set { _textBookName = value; }
        }

        /*教材类别*/
        private string _textBookClass;
        public string textBookClass
        {
            get { return _textBookClass; }
            set { _textBookClass = value; }
        }

        /*教材定价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*出版社*/
        private string _publish;
        public string publish
        {
            get { return _publish; }
            set { _publish = value; }
        }

        /*出版日期*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

        /*作者*/
        private string _author;
        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        /*库存数量*/
        private int _bookCount;
        public int bookCount
        {
            get { return _bookCount; }
            set { _bookCount = value; }
        }

        /*教材备注*/
        private string _bookMemo;
        public string bookMemo
        {
            get { return _bookMemo; }
            set { _bookMemo = value; }
        }

    }
}
