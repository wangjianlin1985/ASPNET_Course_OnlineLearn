using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ҵ���߼���ʵ��*/
    public class dalReward
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӻ�ʵ��*/
        public static bool AddReward(ENTITY.Reward reward)
        {
            string sql = "insert into Reward(reason,content,teacherObj,rewardTime) values(@reason,@content,@teacherObj,@rewardTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@rewardTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = reward.reason; //��ԭ��
            parm[1].Value = reward.content; //������
            parm[2].Value = reward.teacherObj; //�񽱵���ʦ
            parm[3].Value = reward.rewardTime; //��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����rewardId��ȡĳ���񽱼�¼*/
        public static ENTITY.Reward getSomeReward(int rewardId)
        {
            /*������ѯsql*/
            string sql = "select * from Reward where rewardId=" + rewardId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Reward reward = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                reward = new ENTITY.Reward();
                reward.rewardId = Convert.ToInt32(DataRead["rewardId"]);
                reward.reason = DataRead["reason"].ToString();
                reward.content = DataRead["content"].ToString();
                reward.teacherObj = DataRead["teacherObj"].ToString();
                reward.rewardTime = Convert.ToDateTime(DataRead["rewardTime"].ToString());
            }
            return reward;
        }

        /*���»�ʵ��*/
        public static bool EditReward(ENTITY.Reward reward)
        {
            string sql = "update Reward set reason=@reason,content=@content,teacherObj=@teacherObj,rewardTime=@rewardTime where rewardId=@rewardId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@rewardTime",SqlDbType.DateTime),
             new SqlParameter("@rewardId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = reward.reason;
            parm[1].Value = reward.content;
            parm[2].Value = reward.teacherObj;
            parm[3].Value = reward.rewardTime;
            parm[4].Value = reward.rewardId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����*/
        public static bool DelReward(string p)
        {
            string sql = "delete from Reward where rewardId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��*/
        public static DataSet GetReward(string strWhere)
        {
            try
            {
                string strSql = "select * from Reward" + strWhere + " order by rewardId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��*/
        public static System.Data.DataTable GetReward(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Reward";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "rewardId", strShow, strSql, strWhere, " rewardId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllReward()
        {
            try
            {
                string strSql = "select * from Reward";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
