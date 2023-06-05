using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalThesis
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�������ʵ��*/
        public static bool AddThesis(ENTITY.Thesis thesis)
        {
            string sql = "insert into Thesis(lwmc,qkmc,fbrq,teacherObj,shzt) values(@lwmc,@qkmc,@fbrq,@teacherObj,@shzt)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@lwmc",SqlDbType.VarChar),
             new SqlParameter("@qkmc",SqlDbType.VarChar),
             new SqlParameter("@fbrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = thesis.lwmc; //��������
            parm[1].Value = thesis.qkmc; //�ڿ�����
            parm[2].Value = thesis.fbrq; //��������
            parm[3].Value = thesis.teacherObj; //��������
            parm[4].Value = thesis.shzt; //���״̬

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����thesisId��ȡĳ�����ļ�¼*/
        public static ENTITY.Thesis getSomeThesis(int thesisId)
        {
            /*������ѯsql*/
            string sql = "select * from Thesis where thesisId=" + thesisId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Thesis thesis = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*��������ʵ��*/
        public static bool EditThesis(ENTITY.Thesis thesis)
        {
            string sql = "update Thesis set lwmc=@lwmc,qkmc=@qkmc,fbrq=@fbrq,teacherObj=@teacherObj,shzt=@shzt where thesisId=@thesisId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@lwmc",SqlDbType.VarChar),
             new SqlParameter("@qkmc",SqlDbType.VarChar),
             new SqlParameter("@fbrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@thesisId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = thesis.lwmc;
            parm[1].Value = thesis.qkmc;
            parm[2].Value = thesis.fbrq;
            parm[3].Value = thesis.teacherObj;
            parm[4].Value = thesis.shzt;
            parm[5].Value = thesis.thesisId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelThesis(string p)
        {
            string sql = "delete from Thesis where thesisId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
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

        /*��ѯ����*/
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
