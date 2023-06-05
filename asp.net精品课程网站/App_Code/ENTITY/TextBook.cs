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
    ///TextBook ��ժҪ˵�����̲�ʵ��
    /// </summary>

    public class TextBook
    {
        /*�̲�id*/
        private int _textBookId;
        public int textBookId
        {
            get { return _textBookId; }
            set { _textBookId = value; }
        }

        /*�̲�����*/
        private string _textBookName;
        public string textBookName
        {
            get { return _textBookName; }
            set { _textBookName = value; }
        }

        /*�̲����*/
        private string _textBookClass;
        public string textBookClass
        {
            get { return _textBookClass; }
            set { _textBookClass = value; }
        }

        /*�̲Ķ���*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*������*/
        private string _publish;
        public string publish
        {
            get { return _publish; }
            set { _publish = value; }
        }

        /*��������*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

        /*����*/
        private string _author;
        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        /*�������*/
        private int _bookCount;
        public int bookCount
        {
            get { return _bookCount; }
            set { _bookCount = value; }
        }

        /*�̲ı�ע*/
        private string _bookMemo;
        public string bookMemo
        {
            get { return _bookMemo; }
            set { _bookMemo = value; }
        }

    }
}
