using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ҵ���߼���*/
    public class bllReward{
        /*��ӻ�*/
        public static bool AddReward(ENTITY.Reward reward)
        {
            return DAL.dalReward.AddReward(reward);
        }

        /*����rewardId��ȡĳ���񽱼�¼*/
        public static ENTITY.Reward getSomeReward(int rewardId)
        {
            return DAL.dalReward.getSomeReward(rewardId);
        }

        /*���»�*/
        public static bool EditReward(ENTITY.Reward reward)
        {
            return DAL.dalReward.EditReward(reward);
        }

        /*ɾ����*/
        public static bool DelReward(string p)
        {
            return DAL.dalReward.DelReward(p);
        }

        /*��ѯ��*/
        public static System.Data.DataSet GetReward(string strWhere)
        {
            return DAL.dalReward.GetReward(strWhere);
        }

        /*����������ҳ��ѯ��*/
        public static System.Data.DataTable GetReward(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalReward.GetReward(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĻ�*/
        public static System.Data.DataSet getAllReward()
        {
            return DAL.dalReward.getAllReward();
        }
    }
}
