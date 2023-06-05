using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�̲�ҵ���߼���ʵ��*/
    public class dalTextBook
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӽ̲�ʵ��*/
        public static bool AddTextBook(ENTITY.TextBook textBook)
        {
            string sql = "insert into TextBook(textBookName,textBookClass,price,publish,publishDate,author,bookCount,bookMemo) values(@textBookName,@textBookClass,@price,@publish,@publishDate,@author,@bookCount,@bookMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@textBookName",SqlDbType.VarChar),
             new SqlParameter("@textBookClass",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@publish",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@author",SqlDbType.VarChar),
             new SqlParameter("@bookCount",SqlDbType.Int),
             new SqlParameter("@bookMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = textBook.textBookName; //�̲�����
            parm[1].Value = textBook.textBookClass; //�̲����
            parm[2].Value = textBook.price; //�̲Ķ���
            parm[3].Value = textBook.publish; //������
            parm[4].Value = textBook.publishDate; //��������
            parm[5].Value = textBook.author; //����
            parm[6].Value = textBook.bookCount; //�������
            parm[7].Value = textBook.bookMemo; //�̲ı�ע

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����textBookId��ȡĳ���̲ļ�¼*/
        public static ENTITY.TextBook getSomeTextBook(int textBookId)
        {
            /*������ѯsql*/
            string sql = "select * from TextBook where textBookId=" + textBookId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TextBook textBook = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                textBook = new ENTITY.TextBook();
                textBook.textBookId = Convert.ToInt32(DataRead["textBookId"]);
                textBook.textBookName = DataRead["textBookName"].ToString();
                textBook.textBookClass = DataRead["textBookClass"].ToString();
                textBook.price = float.Parse(DataRead["price"].ToString());
                textBook.publish = DataRead["publish"].ToString();
                textBook.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
                textBook.author = DataRead["author"].ToString();
                textBook.bookCount = Convert.ToInt32(DataRead["bookCount"]);
                textBook.bookMemo = DataRead["bookMemo"].ToString();
            }
            return textBook;
        }

        /*���½̲�ʵ��*/
        public static bool EditTextBook(ENTITY.TextBook textBook)
        {
            string sql = "update TextBook set textBookName=@textBookName,textBookClass=@textBookClass,price=@price,publish=@publish,publishDate=@publishDate,author=@author,bookCount=@bookCount,bookMemo=@bookMemo where textBookId=@textBookId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@textBookName",SqlDbType.VarChar),
             new SqlParameter("@textBookClass",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@publish",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@author",SqlDbType.VarChar),
             new SqlParameter("@bookCount",SqlDbType.Int),
             new SqlParameter("@bookMemo",SqlDbType.VarChar),
             new SqlParameter("@textBookId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = textBook.textBookName;
            parm[1].Value = textBook.textBookClass;
            parm[2].Value = textBook.price;
            parm[3].Value = textBook.publish;
            parm[4].Value = textBook.publishDate;
            parm[5].Value = textBook.author;
            parm[6].Value = textBook.bookCount;
            parm[7].Value = textBook.bookMemo;
            parm[8].Value = textBook.textBookId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���̲�*/
        public static bool DelTextBook(string p)
        {
            string sql = "delete from TextBook where textBookId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�̲�*/
        public static DataSet GetTextBook(string strWhere)
        {
            try
            {
                string strSql = "select * from TextBook" + strWhere + " order by textBookId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�̲�*/
        public static System.Data.DataTable GetTextBook(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from TextBook";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "textBookId", strShow, strSql, strWhere, " textBookId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTextBook()
        {
            try
            {
                string strSql = "select * from TextBook";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
