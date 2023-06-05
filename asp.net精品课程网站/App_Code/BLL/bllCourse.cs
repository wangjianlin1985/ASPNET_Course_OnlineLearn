using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*课程业务逻辑层*/
    public class bllCourse{
        /*添加课程*/
        public static bool AddCourse(ENTITY.Course course)
        {
            return DAL.dalCourse.AddCourse(course);
        }

        /*根据courseNo获取某条课程记录*/
        public static ENTITY.Course getSomeCourse(string courseNo)
        {
            return DAL.dalCourse.getSomeCourse(courseNo);
        }

        /*更新课程*/
        public static bool EditCourse(ENTITY.Course course)
        {
            return DAL.dalCourse.EditCourse(course);
        }

        /*删除课程*/
        public static bool DelCourse(string p)
        {
            return DAL.dalCourse.DelCourse(p);
        }

        /*查询课程*/
        public static System.Data.DataSet GetCourse(string strWhere)
        {
            return DAL.dalCourse.GetCourse(strWhere);
        }

        /*根据条件分页查询课程*/
        public static System.Data.DataTable GetCourse(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourse.GetCourse(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的课程*/
        public static System.Data.DataSet getAllCourse()
        {
            return DAL.dalCourse.getAllCourse();
        }
    }
}
