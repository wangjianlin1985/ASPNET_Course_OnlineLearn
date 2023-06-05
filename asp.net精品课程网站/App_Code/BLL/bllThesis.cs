using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*论文业务逻辑层*/
    public class bllThesis{
        /*添加论文*/
        public static bool AddThesis(ENTITY.Thesis thesis)
        {
            return DAL.dalThesis.AddThesis(thesis);
        }

        /*根据thesisId获取某条论文记录*/
        public static ENTITY.Thesis getSomeThesis(int thesisId)
        {
            return DAL.dalThesis.getSomeThesis(thesisId);
        }

        /*更新论文*/
        public static bool EditThesis(ENTITY.Thesis thesis)
        {
            return DAL.dalThesis.EditThesis(thesis);
        }

        /*删除论文*/
        public static bool DelThesis(string p)
        {
            return DAL.dalThesis.DelThesis(p);
        }

        /*查询论文*/
        public static System.Data.DataSet GetThesis(string strWhere)
        {
            return DAL.dalThesis.GetThesis(strWhere);
        }

        /*根据条件分页查询论文*/
        public static System.Data.DataTable GetThesis(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalThesis.GetThesis(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的论文*/
        public static System.Data.DataSet getAllThesis()
        {
            return DAL.dalThesis.getAllThesis();
        }
    }
}
