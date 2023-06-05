using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*课件业务逻辑层*/
    public class bllKejian{
        /*添加课件*/
        public static bool AddKejian(ENTITY.Kejian kejian)
        {
            return DAL.dalKejian.AddKejian(kejian);
        }

        /*根据kejianId获取某条课件记录*/
        public static ENTITY.Kejian getSomeKejian(int kejianId)
        {
            return DAL.dalKejian.getSomeKejian(kejianId);
        }

        /*更新课件*/
        public static bool EditKejian(ENTITY.Kejian kejian)
        {
            return DAL.dalKejian.EditKejian(kejian);
        }

        /*删除课件*/
        public static bool DelKejian(string p)
        {
            return DAL.dalKejian.DelKejian(p);
        }

        /*查询课件*/
        public static System.Data.DataSet GetKejian(string strWhere)
        {
            return DAL.dalKejian.GetKejian(strWhere);
        }

        /*根据条件分页查询课件*/
        public static System.Data.DataTable GetKejian(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalKejian.GetKejian(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的课件*/
        public static System.Data.DataSet getAllKejian()
        {
            return DAL.dalKejian.getAllKejian();
        }
    }
}
