using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�γ�ҵ���߼���*/
    public class bllCourse{
        /*��ӿγ�*/
        public static bool AddCourse(ENTITY.Course course)
        {
            return DAL.dalCourse.AddCourse(course);
        }

        /*����courseNo��ȡĳ���γ̼�¼*/
        public static ENTITY.Course getSomeCourse(string courseNo)
        {
            return DAL.dalCourse.getSomeCourse(courseNo);
        }

        /*���¿γ�*/
        public static bool EditCourse(ENTITY.Course course)
        {
            return DAL.dalCourse.EditCourse(course);
        }

        /*ɾ���γ�*/
        public static bool DelCourse(string p)
        {
            return DAL.dalCourse.DelCourse(p);
        }

        /*��ѯ�γ�*/
        public static System.Data.DataSet GetCourse(string strWhere)
        {
            return DAL.dalCourse.GetCourse(strWhere);
        }

        /*����������ҳ��ѯ�γ�*/
        public static System.Data.DataTable GetCourse(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourse.GetCourse(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĿγ�*/
        public static System.Data.DataSet getAllCourse()
        {
            return DAL.dalCourse.getAllCourse();
        }
    }
}
