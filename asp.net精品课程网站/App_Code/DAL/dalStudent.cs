using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ��ҵ���߼���ʵ��*/
    public class dalStudent
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ��ʵ��*/
        public static bool AddStudent(ENTITY.Student student)
        {
            string sql = "insert into Student(user_name,password,classObj,name,gender,birthDate,userPhoto,telephone,email,address,regTime) values(@user_name,@password,@classObj,@name,@gender,@birthDate,@userPhoto,@telephone,@email,@address,@regTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@user_name",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@classObj",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = student.user_name; //ѧ��
            parm[1].Value = student.password; //��¼����
            parm[2].Value = student.classObj; //���ڰ༶
            parm[3].Value = student.name; //����
            parm[4].Value = student.gender; //�Ա�
            parm[5].Value = student.birthDate; //��������
            parm[6].Value = student.userPhoto; //�û���Ƭ
            parm[7].Value = student.telephone; //��ϵ�绰
            parm[8].Value = student.email; //����
            parm[9].Value = student.address; //��ͥ��ַ
            parm[10].Value = student.regTime; //ע��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����user_name��ȡĳ��ѧ����¼*/
        public static ENTITY.Student getSomeStudent(string user_name)
        {
            /*������ѯsql*/
            string sql = "select * from Student where user_name='" + user_name + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Student student = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                student = new ENTITY.Student();
                student.user_name = DataRead["user_name"].ToString();
                student.password = DataRead["password"].ToString();
                student.classObj = DataRead["classObj"].ToString();
                student.name = DataRead["name"].ToString();
                student.gender = DataRead["gender"].ToString();
                student.birthDate = Convert.ToDateTime(DataRead["birthDate"].ToString());
                student.userPhoto = DataRead["userPhoto"].ToString();
                student.telephone = DataRead["telephone"].ToString();
                student.email = DataRead["email"].ToString();
                student.address = DataRead["address"].ToString();
                student.regTime = Convert.ToDateTime(DataRead["regTime"].ToString());
            }
            return student;
        }

        /*����ѧ��ʵ��*/
        public static bool EditStudent(ENTITY.Student student)
        {
            string sql = "update Student set password=@password,classObj=@classObj,name=@name,gender=@gender,birthDate=@birthDate,userPhoto=@userPhoto,telephone=@telephone,email=@email,address=@address,regTime=@regTime where user_name=@user_name";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@classObj",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime),
             new SqlParameter("@user_name",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = student.password;
            parm[1].Value = student.classObj;
            parm[2].Value = student.name;
            parm[3].Value = student.gender;
            parm[4].Value = student.birthDate;
            parm[5].Value = student.userPhoto;
            parm[6].Value = student.telephone;
            parm[7].Value = student.email;
            parm[8].Value = student.address;
            parm[9].Value = student.regTime;
            parm[10].Value = student.user_name;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ��*/
        public static bool DelStudent(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Student where user_name in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ��*/
        public static DataSet GetStudent(string strWhere)
        {
            try
            {
                string strSql = "select * from Student" + strWhere + " order by user_name asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧ��*/
        public static System.Data.DataTable GetStudent(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Student";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "user_name", strShow, strSql, strWhere, " user_name asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStudent()
        {
            try
            {
                string strSql = "select * from Student";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
