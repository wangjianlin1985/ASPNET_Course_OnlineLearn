using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*教材业务逻辑层实现*/
    public class dalTextBook
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加教材实现*/
        public static bool AddTextBook(ENTITY.TextBook textBook)
        {
            string sql = "insert into TextBook(textBookName,textBookClass,price,publish,publishDate,author,bookCount,bookMemo) values(@textBookName,@textBookClass,@price,@publish,@publishDate,@author,@bookCount,@bookMemo)";
            /*构建sql参数*/
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
            /*给参数赋值*/
            parm[0].Value = textBook.textBookName; //教材名称
            parm[1].Value = textBook.textBookClass; //教材类别
            parm[2].Value = textBook.price; //教材定价
            parm[3].Value = textBook.publish; //出版社
            parm[4].Value = textBook.publishDate; //出版日期
            parm[5].Value = textBook.author; //作者
            parm[6].Value = textBook.bookCount; //库存数量
            parm[7].Value = textBook.bookMemo; //教材备注

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据textBookId获取某条教材记录*/
        public static ENTITY.TextBook getSomeTextBook(int textBookId)
        {
            /*构建查询sql*/
            string sql = "select * from TextBook where textBookId=" + textBookId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TextBook textBook = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新教材实现*/
        public static bool EditTextBook(ENTITY.TextBook textBook)
        {
            string sql = "update TextBook set textBookName=@textBookName,textBookClass=@textBookClass,price=@price,publish=@publish,publishDate=@publishDate,author=@author,bookCount=@bookCount,bookMemo=@bookMemo where textBookId=@textBookId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
            parm[0].Value = textBook.textBookName;
            parm[1].Value = textBook.textBookClass;
            parm[2].Value = textBook.price;
            parm[3].Value = textBook.publish;
            parm[4].Value = textBook.publishDate;
            parm[5].Value = textBook.author;
            parm[6].Value = textBook.bookCount;
            parm[7].Value = textBook.bookMemo;
            parm[8].Value = textBook.textBookId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除教材*/
        public static bool DelTextBook(string p)
        {
            string sql = "delete from TextBook where textBookId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询教材*/
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

        /*查询教材*/
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
