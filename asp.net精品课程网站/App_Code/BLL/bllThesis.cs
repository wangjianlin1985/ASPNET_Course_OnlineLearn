using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllThesis{
        /*�������*/
        public static bool AddThesis(ENTITY.Thesis thesis)
        {
            return DAL.dalThesis.AddThesis(thesis);
        }

        /*����thesisId��ȡĳ�����ļ�¼*/
        public static ENTITY.Thesis getSomeThesis(int thesisId)
        {
            return DAL.dalThesis.getSomeThesis(thesisId);
        }

        /*��������*/
        public static bool EditThesis(ENTITY.Thesis thesis)
        {
            return DAL.dalThesis.EditThesis(thesis);
        }

        /*ɾ������*/
        public static bool DelThesis(string p)
        {
            return DAL.dalThesis.DelThesis(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetThesis(string strWhere)
        {
            return DAL.dalThesis.GetThesis(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetThesis(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalThesis.GetThesis(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�����*/
        public static System.Data.DataSet getAllThesis()
        {
            return DAL.dalThesis.getAllThesis();
        }
    }
}
