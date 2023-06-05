using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���Դ���ҵ���߼���*/
    public class bllLeaveword{
        /*������Դ���*/
        public static bool AddLeaveword(ENTITY.Leaveword leaveword)
        {
            return DAL.dalLeaveword.AddLeaveword(leaveword);
        }

        /*����leaveWordId��ȡĳ�����Դ��ɼ�¼*/
        public static ENTITY.Leaveword getSomeLeaveword(int leaveWordId)
        {
            return DAL.dalLeaveword.getSomeLeaveword(leaveWordId);
        }

        /*�������Դ���*/
        public static bool EditLeaveword(ENTITY.Leaveword leaveword)
        {
            return DAL.dalLeaveword.EditLeaveword(leaveword);
        }

        /*ɾ�����Դ���*/
        public static bool DelLeaveword(string p)
        {
            return DAL.dalLeaveword.DelLeaveword(p);
        }

        /*��ѯ���Դ���*/
        public static System.Data.DataSet GetLeaveword(string strWhere)
        {
            return DAL.dalLeaveword.GetLeaveword(strWhere);
        }

        /*����������ҳ��ѯ���Դ���*/
        public static System.Data.DataTable GetLeaveword(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalLeaveword.GetLeaveword(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����Դ���*/
        public static System.Data.DataSet getAllLeaveword()
        {
            return DAL.dalLeaveword.getAllLeaveword();
        }
    }
}
