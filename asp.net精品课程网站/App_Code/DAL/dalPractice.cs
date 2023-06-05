using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*课程实践业务逻辑层实现*/
    public class dalPractice
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加课程实践实现*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            string sql = "insert into Practice(courseObj,title,content,place,praticeTime) values(@courseObj,@title,@content,@place,@praticeTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@place",SqlDbType.VarChar),
             new SqlParameter("@praticeTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = practice.courseObj; //实践的课程
            parm[1].Value = practice.title; //实践主题
            parm[2].Value = practice.content; //实践内容
            parm[3].Value = practice.place; //实践地点
            parm[4].Value = practice.praticeTime; //实践时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据practiceId获取某条课程实践记录*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            /*构建查询sql*/
            string sql = "select * from Practice where practiceId=" + practiceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Practice practice = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                practice = new ENTITY.Practice();
                practice.practiceId = Convert.ToInt32(DataRead["practiceId"]);
                practice.courseObj = DataRead["courseObj"].ToString();
                practice.title = DataRead["title"].ToString();
                practice.content = DataRead["content"].ToString();
                practice.place = DataRead["place"].ToString();
                practice.praticeTime = Convert.ToDateTime(DataRead["praticeTime"].ToString());
            }
            return practice;
        }

        /*更新课程实践实现*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            string sql = "update Practice set courseObj=@courseObj,title=@title,content=@content,place=@place,praticeTime=@praticeTime where practiceId=@practiceId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@place",SqlDbType.VarChar),
             new SqlParameter("@praticeTime",SqlDbType.DateTime),
             new SqlParameter("@practiceId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = practice.courseObj;
            parm[1].Value = practice.title;
            parm[2].Value = practice.content;
            parm[3].Value = practice.place;
            parm[4].Value = practice.praticeTime;
            parm[5].Value = practice.practiceId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除课程实践*/
        public static bool DelPractice(string p)
        {
            string sql = "delete from Practice where practiceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询课程实践*/
        public static DataSet GetPractice(string strWhere)
        {
            try
            {
                string strSql = "select * from Practice" + strWhere + " order by practiceId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询课程实践*/
        public static System.Data.DataTable GetPractice(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Practice";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "practiceId", strShow, strSql, strWhere, " practiceId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPractice()
        {
            try
            {
                string strSql = "select * from Practice";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
