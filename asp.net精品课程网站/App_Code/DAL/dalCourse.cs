using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�γ�ҵ���߼���ʵ��*/
    public class dalCourse
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӿγ�ʵ��*/
        public static bool AddCourse(ENTITY.Course course)
        {
            string sql = "insert into Course(courseNo,courseName,coursePhoto,teacherObj,courseHours,jxff,kcjj) values(@courseNo,@courseName,@coursePhoto,@teacherObj,@courseHours,@jxff,@kcjj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@coursePhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@courseHours",SqlDbType.Int),
             new SqlParameter("@jxff",SqlDbType.VarChar),
             new SqlParameter("@kcjj",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = course.courseNo; //�γ̱��
            parm[1].Value = course.courseName; //�γ�����
            parm[2].Value = course.coursePhoto; //�γ�ͼƬ
            parm[3].Value = course.teacherObj; //�Ͽ���ʦ
            parm[4].Value = course.courseHours; //�γ�ѧʱ
            parm[5].Value = course.jxff; //��ѧ���
            parm[6].Value = course.kcjj; //�γ̼��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����courseNo��ȡĳ���γ̼�¼*/
        public static ENTITY.Course getSomeCourse(string courseNo)
        {
            /*������ѯsql*/
            string sql = "select * from Course where courseNo='" + courseNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Course course = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                course = new ENTITY.Course();
                course.courseNo = DataRead["courseNo"].ToString();
                course.courseName = DataRead["courseName"].ToString();
                course.coursePhoto = DataRead["coursePhoto"].ToString();
                course.teacherObj = DataRead["teacherObj"].ToString();
                course.courseHours = Convert.ToInt32(DataRead["courseHours"]);
                course.jxff = DataRead["jxff"].ToString();
                course.kcjj = DataRead["kcjj"].ToString();
            }
            return course;
        }

        /*���¿γ�ʵ��*/
        public static bool EditCourse(ENTITY.Course course)
        {
            string sql = "update Course set courseName=@courseName,coursePhoto=@coursePhoto,teacherObj=@teacherObj,courseHours=@courseHours,jxff=@jxff,kcjj=@kcjj where courseNo=@courseNo";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@coursePhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@courseHours",SqlDbType.Int),
             new SqlParameter("@jxff",SqlDbType.VarChar),
             new SqlParameter("@kcjj",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = course.courseName;
            parm[1].Value = course.coursePhoto;
            parm[2].Value = course.teacherObj;
            parm[3].Value = course.courseHours;
            parm[4].Value = course.jxff;
            parm[5].Value = course.kcjj;
            parm[6].Value = course.courseNo;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���γ�*/
        public static bool DelCourse(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Course where courseNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�γ�*/
        public static DataSet GetCourse(string strWhere)
        {
            try
            {
                string strSql = "select * from Course" + strWhere + " order by courseNo asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�γ�*/
        public static System.Data.DataTable GetCourse(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Course";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "courseNo", strShow, strSql, strWhere, " courseNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCourse()
        {
            try
            {
                string strSql = "select * from Course";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
