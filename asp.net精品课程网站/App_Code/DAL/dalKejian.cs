using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*课件业务逻辑层实现*/
    public class dalKejian
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加课件实现*/
        public static bool AddKejian(ENTITY.Kejian kejian)
        {
            string sql = "insert into Kejian(title,courseObj,kejianDesc,kejianFile,addTime) values(@title,@courseObj,@kejianDesc,@kejianFile,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@kejianDesc",SqlDbType.VarChar),
             new SqlParameter("@kejianFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = kejian.title; //课件标题
            parm[1].Value = kejian.courseObj; //所属课程
            parm[2].Value = kejian.kejianDesc; //课件描述
            parm[3].Value = kejian.kejianFile; //课件文件
            parm[4].Value = kejian.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据kejianId获取某条课件记录*/
        public static ENTITY.Kejian getSomeKejian(int kejianId)
        {
            /*构建查询sql*/
            string sql = "select * from Kejian where kejianId=" + kejianId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Kejian kejian = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                kejian = new ENTITY.Kejian();
                kejian.kejianId = Convert.ToInt32(DataRead["kejianId"]);
                kejian.title = DataRead["title"].ToString();
                kejian.courseObj = DataRead["courseObj"].ToString();
                kejian.kejianDesc = DataRead["kejianDesc"].ToString();
                kejian.kejianFile = DataRead["kejianFile"].ToString();
                kejian.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return kejian;
        }

        /*更新课件实现*/
        public static bool EditKejian(ENTITY.Kejian kejian)
        {
            string sql = "update Kejian set title=@title,courseObj=@courseObj,kejianDesc=@kejianDesc,kejianFile=@kejianFile,addTime=@addTime where kejianId=@kejianId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@kejianDesc",SqlDbType.VarChar),
             new SqlParameter("@kejianFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@kejianId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = kejian.title;
            parm[1].Value = kejian.courseObj;
            parm[2].Value = kejian.kejianDesc;
            parm[3].Value = kejian.kejianFile;
            parm[4].Value = kejian.addTime;
            parm[5].Value = kejian.kejianId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除课件*/
        public static bool DelKejian(string p)
        {
            string sql = "delete from Kejian where kejianId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询课件*/
        public static DataSet GetKejian(string strWhere)
        {
            try
            {
                string strSql = "select * from Kejian" + strWhere + " order by kejianId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询课件*/
        public static System.Data.DataTable GetKejian(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Kejian";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "kejianId", strShow, strSql, strWhere, " kejianId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllKejian()
        {
            try
            {
                string strSql = "select * from Kejian";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
