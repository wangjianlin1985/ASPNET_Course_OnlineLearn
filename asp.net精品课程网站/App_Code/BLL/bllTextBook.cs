using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�̲�ҵ���߼���*/
    public class bllTextBook{
        /*��ӽ̲�*/
        public static bool AddTextBook(ENTITY.TextBook textBook)
        {
            return DAL.dalTextBook.AddTextBook(textBook);
        }

        /*����textBookId��ȡĳ���̲ļ�¼*/
        public static ENTITY.TextBook getSomeTextBook(int textBookId)
        {
            return DAL.dalTextBook.getSomeTextBook(textBookId);
        }

        /*���½̲�*/
        public static bool EditTextBook(ENTITY.TextBook textBook)
        {
            return DAL.dalTextBook.EditTextBook(textBook);
        }

        /*ɾ���̲�*/
        public static bool DelTextBook(string p)
        {
            return DAL.dalTextBook.DelTextBook(p);
        }

        /*��ѯ�̲�*/
        public static System.Data.DataSet GetTextBook(string strWhere)
        {
            return DAL.dalTextBook.GetTextBook(strWhere);
        }

        /*����������ҳ��ѯ�̲�*/
        public static System.Data.DataTable GetTextBook(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTextBook.GetTextBook(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĽ̲�*/
        public static System.Data.DataSet getAllTextBook()
        {
            return DAL.dalTextBook.getAllTextBook();
        }
    }
}
