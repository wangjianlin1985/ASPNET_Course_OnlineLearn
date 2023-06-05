using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*教师业务逻辑层实现*/
    public class dalTeacher
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*教师登录*/
        public static bool ulogin(string teacherNo,string passsword)
        {
            string sql = @"select teacherNo from Teacher where teacherNo =@teacherNo and password =@password";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@teacherNo",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar)
           };
            para[0].Value = teacherNo;
            para[1].Value = passsword;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }


        /*添加教师实现*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            string sql = "insert into Teacher(teacherNo,password,teacherName,teacherSex,teacherPhoto,comeDate,teacherDesc) values(@teacherNo,@password,@teacherName,@teacherSex,@teacherPhoto,@comeDate,@teacherDesc)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherNo",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@comeDate",SqlDbType.DateTime),
             new SqlParameter("@teacherDesc",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = teacher.teacherNo; //教师工号
            parm[1].Value = teacher.password; //登录密码
            parm[2].Value = teacher.teacherName; //教师姓名
            parm[3].Value = teacher.teacherSex; //教师性别
            parm[4].Value = teacher.teacherPhoto; //教师照片
            parm[5].Value = teacher.comeDate; //入职日期
            parm[6].Value = teacher.teacherDesc; //教师介绍

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据teacherNo获取某条教师记录*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNo)
        {
            /*构建查询sql*/
            string sql = "select * from Teacher where teacherNo='" + teacherNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teacher teacher = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                teacher = new ENTITY.Teacher();
                teacher.teacherNo = DataRead["teacherNo"].ToString();
                teacher.password = DataRead["password"].ToString();
                teacher.teacherName = DataRead["teacherName"].ToString();
                teacher.teacherSex = DataRead["teacherSex"].ToString();
                teacher.teacherPhoto = DataRead["teacherPhoto"].ToString();
                teacher.comeDate = Convert.ToDateTime(DataRead["comeDate"].ToString());
                teacher.teacherDesc = DataRead["teacherDesc"].ToString();
            }
            return teacher;
        }

        /*更新教师实现*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            string sql = "update Teacher set password=@password,teacherName=@teacherName,teacherSex=@teacherSex,teacherPhoto=@teacherPhoto,comeDate=@comeDate,teacherDesc=@teacherDesc where teacherNo=@teacherNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@comeDate",SqlDbType.DateTime),
             new SqlParameter("@teacherDesc",SqlDbType.VarChar),
             new SqlParameter("@teacherNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = teacher.password;
            parm[1].Value = teacher.teacherName;
            parm[2].Value = teacher.teacherSex;
            parm[3].Value = teacher.teacherPhoto;
            parm[4].Value = teacher.comeDate;
            parm[5].Value = teacher.teacherDesc;
            parm[6].Value = teacher.teacherNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除教师*/
        public static bool DelTeacher(string p)
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
            sql = "delete from Teacher where teacherNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询教师*/
        public static DataSet GetTeacher(string strWhere)
        {
            try
            {
                string strSql = "select * from Teacher" + strWhere + " order by teacherNo asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询教师*/
        public static System.Data.DataTable GetTeacher(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Teacher";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "teacherNo", strShow, strSql, strWhere, " teacherNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeacher()
        {
            try
            {
                string strSql = "select * from Teacher";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
