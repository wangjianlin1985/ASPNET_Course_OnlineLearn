using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*论文业务逻辑层实现*/
    public class dalThesis
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加论文实现*/
        public static bool AddThesis(ENTITY.Thesis thesis)
        {
            string sql = "insert into Thesis(lwmc,qkmc,fbrq,teacherObj,shzt) values(@lwmc,@qkmc,@fbrq,@teacherObj,@shzt)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@lwmc",SqlDbType.VarChar),
             new SqlParameter("@qkmc",SqlDbType.VarChar),
             new SqlParameter("@fbrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = thesis.lwmc; //论文名称
            parm[1].Value = thesis.qkmc; //期刊名称
            parm[2].Value = thesis.fbrq; //发布日期
            parm[3].Value = thesis.teacherObj; //论文作者
            parm[4].Value = thesis.shzt; //审核状态

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据thesisId获取某条论文记录*/
        public static ENTITY.Thesis getSomeThesis(int thesisId)
        {
            /*构建查询sql*/
            string sql = "select * from Thesis where thesisId=" + thesisId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Thesis thesis = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                thesis = new ENTITY.Thesis();
                thesis.thesisId = Convert.ToInt32(DataRead["thesisId"]);
                thesis.lwmc = DataRead["lwmc"].ToString();
                thesis.qkmc = DataRead["qkmc"].ToString();
                thesis.fbrq = Convert.ToDateTime(DataRead["fbrq"].ToString());
                thesis.teacherObj = DataRead["teacherObj"].ToString();
                thesis.shzt = DataRead["shzt"].ToString();
            }
            return thesis;
        }

        /*更新论文实现*/
        public static bool EditThesis(ENTITY.Thesis thesis)
        {
            string sql = "update Thesis set lwmc=@lwmc,qkmc=@qkmc,fbrq=@fbrq,teacherObj=@teacherObj,shzt=@shzt where thesisId=@thesisId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@lwmc",SqlDbType.VarChar),
             new SqlParameter("@qkmc",SqlDbType.VarChar),
             new SqlParameter("@fbrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@thesisId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = thesis.lwmc;
            parm[1].Value = thesis.qkmc;
            parm[2].Value = thesis.fbrq;
            parm[3].Value = thesis.teacherObj;
            parm[4].Value = thesis.shzt;
            parm[5].Value = thesis.thesisId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除论文*/
        public static bool DelThesis(string p)
        {
            string sql = "delete from Thesis where thesisId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询论文*/
        public static DataSet GetThesis(string strWhere)
        {
            try
            {
                string strSql = "select * from Thesis" + strWhere + " order by thesisId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询论文*/
        public static System.Data.DataTable GetThesis(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Thesis";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "thesisId", strShow, strSql, strWhere, " thesisId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllThesis()
        {
            try
            {
                string strSql = "select * from Thesis";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
