using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�γ�ʵ��ҵ���߼���*/
    public class bllPractice{
        /*��ӿγ�ʵ��*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            return DAL.dalPractice.AddPractice(practice);
        }

        /*����practiceId��ȡĳ���γ�ʵ����¼*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            return DAL.dalPractice.getSomePractice(practiceId);
        }

        /*���¿γ�ʵ��*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            return DAL.dalPractice.EditPractice(practice);
        }

        /*ɾ���γ�ʵ��*/
        public static bool DelPractice(string p)
        {
            return DAL.dalPractice.DelPractice(p);
        }

        /*��ѯ�γ�ʵ��*/
        public static System.Data.DataSet GetPractice(string strWhere)
        {
            return DAL.dalPractice.GetPractice(strWhere);
        }

        /*����������ҳ��ѯ�γ�ʵ��*/
        public static System.Data.DataTable GetPractice(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPractice.GetPractice(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĿγ�ʵ��*/
        public static System.Data.DataSet getAllPractice()
        {
            return DAL.dalPractice.getAllPractice();
        }
    }
}
