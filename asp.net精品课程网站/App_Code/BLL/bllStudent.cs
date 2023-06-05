using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学生业务逻辑层*/
    public class bllStudent{
        /*添加学生*/
        public static bool AddStudent(ENTITY.Student student)
        {
            return DAL.dalStudent.AddStudent(student);
        }

        /*根据user_name获取某条学生记录*/
        public static ENTITY.Student getSomeStudent(string user_name)
        {
            return DAL.dalStudent.getSomeStudent(user_name);
        }

        /*更新学生*/
        public static bool EditStudent(ENTITY.Student student)
        {
            return DAL.dalStudent.EditStudent(student);
        }

        /*删除学生*/
        public static bool DelStudent(string p)
        {
            return DAL.dalStudent.DelStudent(p);
        }

        /*查询学生*/
        public static System.Data.DataSet GetStudent(string strWhere)
        {
            return DAL.dalStudent.GetStudent(strWhere);
        }

        /*根据条件分页查询学生*/
        public static System.Data.DataTable GetStudent(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudent.GetStudent(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学生*/
        public static System.Data.DataSet getAllStudent()
        {
            return DAL.dalStudent.getAllStudent();
        }
    }
}
