using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�μ�ҵ���߼���ʵ��*/
    public class dalKejian
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӿμ�ʵ��*/
        public static bool AddKejian(ENTITY.Kejian kejian)
        {
            string sql = "insert into Kejian(title,courseObj,kejianDesc,kejianFile,addTime) values(@title,@courseObj,@kejianDesc,@kejianFile,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@kejianDesc",SqlDbType.VarChar),
             new SqlParameter("@kejianFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = kejian.title; //�μ�����
            parm[1].Value = kejian.courseObj; //�����γ�
            parm[2].Value = kejian.kejianDesc; //�μ�����
            parm[3].Value = kejian.kejianFile; //�μ��ļ�
            parm[4].Value = kejian.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����kejianId��ȡĳ���μ���¼*/
        public static ENTITY.Kejian getSomeKejian(int kejianId)
        {
            /*������ѯsql*/
            string sql = "select * from Kejian where kejianId=" + kejianId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Kejian kejian = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���¿μ�ʵ��*/
        public static bool EditKejian(ENTITY.Kejian kejian)
        {
            string sql = "update Kejian set title=@title,courseObj=@courseObj,kejianDesc=@kejianDesc,kejianFile=@kejianFile,addTime=@addTime where kejianId=@kejianId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@courseObj",SqlDbType.VarChar),
             new SqlParameter("@kejianDesc",SqlDbType.VarChar),
             new SqlParameter("@kejianFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@kejianId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = kejian.title;
            parm[1].Value = kejian.courseObj;
            parm[2].Value = kejian.kejianDesc;
            parm[3].Value = kejian.kejianFile;
            parm[4].Value = kejian.addTime;
            parm[5].Value = kejian.kejianId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���μ�*/
        public static bool DelKejian(string p)
        {
            string sql = "delete from Kejian where kejianId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�μ�*/
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

        /*��ѯ�μ�*/
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
