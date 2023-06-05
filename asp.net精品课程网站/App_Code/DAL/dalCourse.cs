using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*课程业务逻辑层实现*/
    public class dalCourse
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加课程实现*/
        public static bool AddCourse(ENTITY.Course course)
        {
            string sql = "insert into Course(courseNo,courseName,coursePhoto,teacherObj,courseHours,jxff,kcjj) values(@courseNo,@courseName,@coursePhoto,@teacherObj,@courseHours,@jxff,@kcjj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@coursePhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@courseHours",SqlDbType.Int),
             new SqlParameter("@jxff",SqlDbType.VarChar),
             new SqlParameter("@kcjj",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = course.courseNo; //课程编号
            parm[1].Value = course.courseName; //课程名称
            parm[2].Value = course.coursePhoto; //课程图片
            parm[3].Value = course.teacherObj; //上课老师
            parm[4].Value = course.courseHours; //课程学时
            parm[5].Value = course.jxff; //教学大纲
            parm[6].Value = course.kcjj; //课程简介

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据courseNo获取某条课程记录*/
        public static ENTITY.Course getSomeCourse(string courseNo)
        {
            /*构建查询sql*/
            string sql = "select * from Course where courseNo='" + courseNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Course course = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新课程实现*/
        public static bool EditCourse(ENTITY.Course course)
        {
            string sql = "update Course set courseName=@courseName,coursePhoto=@coursePhoto,teacherObj=@teacherObj,courseHours=@courseHours,jxff=@jxff,kcjj=@kcjj where courseNo=@courseNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@coursePhoto",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@courseHours",SqlDbType.Int),
             new SqlParameter("@jxff",SqlDbType.VarChar),
             new SqlParameter("@kcjj",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = course.courseName;
            parm[1].Value = course.coursePhoto;
            parm[2].Value = course.teacherObj;
            parm[3].Value = course.courseHours;
            parm[4].Value = course.jxff;
            parm[5].Value = course.kcjj;
            parm[6].Value = course.courseNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除课程*/
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


        /*查询课程*/
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

        /*查询课程*/
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
