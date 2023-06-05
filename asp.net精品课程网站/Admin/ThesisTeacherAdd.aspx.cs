using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class ThesisEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {  
            }
        }
        
 

        protected void BtnThesisSave_Click(object sender, EventArgs e)
        {
            ENTITY.Thesis thesis = new ENTITY.Thesis();
            thesis.lwmc = lwmc.Value;
            thesis.qkmc = qkmc.Value;
            thesis.fbrq = Convert.ToDateTime(fbrq.Text);
            thesis.teacherObj = Session["Customername"].ToString();
            thesis.shzt = "待审核";
             
                if (BLL.bllThesis.AddThesis(thesis))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"ThesisTeacherAdd.aspx\"} else  {location.href=\"ThesisTeacherList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThesisTeacherList.aspx");
        }
    }
}

