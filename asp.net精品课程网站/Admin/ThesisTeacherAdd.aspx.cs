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
            thesis.shzt = "�����";
             
                if (BLL.bllThesis.AddThesis(thesis))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ThesisTeacherAdd.aspx\"} else  {location.href=\"ThesisTeacherList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThesisTeacherList.aspx");
        }
    }
}

