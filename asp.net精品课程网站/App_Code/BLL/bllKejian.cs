using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�μ�ҵ���߼���*/
    public class bllKejian{
        /*��ӿμ�*/
        public static bool AddKejian(ENTITY.Kejian kejian)
        {
            return DAL.dalKejian.AddKejian(kejian);
        }

        /*����kejianId��ȡĳ���μ���¼*/
        public static ENTITY.Kejian getSomeKejian(int kejianId)
        {
            return DAL.dalKejian.getSomeKejian(kejianId);
        }

        /*���¿μ�*/
        public static bool EditKejian(ENTITY.Kejian kejian)
        {
            return DAL.dalKejian.EditKejian(kejian);
        }

        /*ɾ���μ�*/
        public static bool DelKejian(string p)
        {
            return DAL.dalKejian.DelKejian(p);
        }

        /*��ѯ�μ�*/
        public static System.Data.DataSet GetKejian(string strWhere)
        {
            return DAL.dalKejian.GetKejian(strWhere);
        }

        /*����������ҳ��ѯ�μ�*/
        public static System.Data.DataTable GetKejian(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalKejian.GetKejian(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĿμ�*/
        public static System.Data.DataSet getAllKejian()
        {
            return DAL.dalKejian.getAllKejian();
        }
    }
}
