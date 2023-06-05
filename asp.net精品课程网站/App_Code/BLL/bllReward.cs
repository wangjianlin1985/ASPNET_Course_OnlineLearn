using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*获奖业务逻辑层*/
    public class bllReward{
        /*添加获奖*/
        public static bool AddReward(ENTITY.Reward reward)
        {
            return DAL.dalReward.AddReward(reward);
        }

        /*根据rewardId获取某条获奖记录*/
        public static ENTITY.Reward getSomeReward(int rewardId)
        {
            return DAL.dalReward.getSomeReward(rewardId);
        }

        /*更新获奖*/
        public static bool EditReward(ENTITY.Reward reward)
        {
            return DAL.dalReward.EditReward(reward);
        }

        /*删除获奖*/
        public static bool DelReward(string p)
        {
            return DAL.dalReward.DelReward(p);
        }

        /*查询获奖*/
        public static System.Data.DataSet GetReward(string strWhere)
        {
            return DAL.dalReward.GetReward(strWhere);
        }

        /*根据条件分页查询获奖*/
        public static System.Data.DataTable GetReward(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalReward.GetReward(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的获奖*/
        public static System.Data.DataSet getAllReward()
        {
            return DAL.dalReward.getAllReward();
        }
    }
}
