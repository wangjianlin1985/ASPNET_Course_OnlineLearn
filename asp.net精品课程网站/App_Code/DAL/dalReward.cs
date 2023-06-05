using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*获奖业务逻辑层实现*/
    public class dalReward
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加获奖实现*/
        public static bool AddReward(ENTITY.Reward reward)
        {
            string sql = "insert into Reward(reason,content,teacherObj,rewardTime) values(@reason,@content,@teacherObj,@rewardTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@rewardTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = reward.reason; //获奖原因
            parm[1].Value = reward.content; //获奖内容
            parm[2].Value = reward.teacherObj; //获奖的老师
            parm[3].Value = reward.rewardTime; //获奖时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据rewardId获取某条获奖记录*/
        public static ENTITY.Reward getSomeReward(int rewardId)
        {
            /*构建查询sql*/
            string sql = "select * from Reward where rewardId=" + rewardId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Reward reward = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新获奖实现*/
        public static bool EditReward(ENTITY.Reward reward)
        {
            string sql = "update Reward set reason=@reason,content=@content,teacherObj=@teacherObj,rewardTime=@rewardTime where rewardId=@rewardId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@reason",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@rewardTime",SqlDbType.DateTime),
             new SqlParameter("@rewardId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = reward.reason;
            parm[1].Value = reward.content;
            parm[2].Value = reward.teacherObj;
            parm[3].Value = reward.rewardTime;
            parm[4].Value = reward.rewardId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除获奖*/
        public static bool DelReward(string p)
        {
            string sql = "delete from Reward where rewardId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询获奖*/
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

        /*查询获奖*/
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
