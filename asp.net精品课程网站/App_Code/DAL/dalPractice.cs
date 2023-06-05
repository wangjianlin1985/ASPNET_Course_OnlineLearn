using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�γ�ʵ��ҵ���߼���ʵ��*/
    public class dalPractice
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӿγ�ʵ��ʵ��*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            string sql = "insert into Practice(courseObj,title,content,place,praticeTime) values(@courseObj,@title,@content,@place,@praticeTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@place",SqlDbType.VarChar),
             new SqlParameter("@praticeTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = practice.courseObj; //ʵ���Ŀγ�
            parm[1].Value = practice.title; //ʵ������
            parm[2].Value = practice.content; //ʵ������
            parm[3].Value = practice.place; //ʵ���ص�
            parm[4].Value = practice.praticeTime; //ʵ��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����practiceId��ȡĳ���γ�ʵ����¼*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            /*������ѯsql*/
            string sql = "select * from Practice where practiceId=" + practiceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Practice practice = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���¿γ�ʵ��ʵ��*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            string sql = "update Practice set courseObj=@courseObj,title=@title,content=@content,place=@place,praticeTime=@praticeTime where practiceId=@practiceId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@place",SqlDbType.VarChar),
             new SqlParameter("@praticeTime",SqlDbType.DateTime),
             new SqlParameter("@practiceId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = practice.courseObj;
            parm[1].Value = practice.title;
            parm[2].Value = practice.content;
            parm[3].Value = practice.place;
            parm[4].Value = practice.praticeTime;
            parm[5].Value = practice.practiceId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���γ�ʵ��*/
        public static bool DelPractice(string p)
        {
            string sql = "delete from Practice where practiceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�γ�ʵ��*/
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

        /*��ѯ�γ�ʵ��*/
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
