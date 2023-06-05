using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*教材业务逻辑层*/
    public class bllTextBook{
        /*添加教材*/
        public static bool AddTextBook(ENTITY.TextBook textBook)
        {
            return DAL.dalTextBook.AddTextBook(textBook);
        }

        /*根据textBookId获取某条教材记录*/
        public static ENTITY.TextBook getSomeTextBook(int textBookId)
        {
            return DAL.dalTextBook.getSomeTextBook(textBookId);
        }

        /*更新教材*/
        public static bool EditTextBook(ENTITY.TextBook textBook)
        {
            return DAL.dalTextBook.EditTextBook(textBook);
        }

        /*删除教材*/
        public static bool DelTextBook(string p)
        {
            return DAL.dalTextBook.DelTextBook(p);
        }

        /*查询教材*/
        public static System.Data.DataSet GetTextBook(string strWhere)
        {
            return DAL.dalTextBook.GetTextBook(strWhere);
        }

        /*根据条件分页查询教材*/
        public static System.Data.DataTable GetTextBook(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTextBook.GetTextBook(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的教材*/
        public static System.Data.DataSet getAllTextBook()
        {
            return DAL.dalTextBook.getAllTextBook();
        }
    }
}
