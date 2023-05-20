using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�����ҵ���߼���ʵ��*/
    public class dalSignUp
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӻ����ʵ��*/
        public static bool AddSignUp(ENTITY.SignUp signUp)
        {
            string sql = "insert into SignUp(huodongObj,userObj,signUpTime,executeState,signUpMemo) values(@huodongObj,@userObj,@signUpTime,@executeState,@signUpMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huodongObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@signUpTime",SqlDbType.DateTime),
             new SqlParameter("@executeState",SqlDbType.VarChar),
             new SqlParameter("@signUpMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = signUp.huodongObj; //�����
            parm[1].Value = signUp.userObj; //�����û�
            parm[2].Value = signUp.signUpTime; //����ʱ��
            parm[3].Value = signUp.executeState; //ִ��״̬
            parm[4].Value = signUp.signUpMemo; //��ע��Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����signUpId��ȡĳ���������¼*/
        public static ENTITY.SignUp getSomeSignUp(int signUpId)
        {
            /*������ѯsql*/
            string sql = "select * from SignUp where signUpId=" + signUpId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SignUp signUp = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                signUp = new ENTITY.SignUp();
                signUp.signUpId = Convert.ToInt32(DataRead["signUpId"]);
                signUp.huodongObj = Convert.ToInt32(DataRead["huodongObj"]);
                signUp.userObj = DataRead["userObj"].ToString();
                signUp.signUpTime = Convert.ToDateTime(DataRead["signUpTime"].ToString());
                signUp.executeState = DataRead["executeState"].ToString();
                signUp.signUpMemo = DataRead["signUpMemo"].ToString();
            }
            return signUp;
        }

        /*���»����ʵ��*/
        public static bool EditSignUp(ENTITY.SignUp signUp)
        {
            string sql = "update SignUp set huodongObj=@huodongObj,userObj=@userObj,signUpTime=@signUpTime,executeState=@executeState,signUpMemo=@signUpMemo where signUpId=@signUpId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huodongObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@signUpTime",SqlDbType.DateTime),
             new SqlParameter("@executeState",SqlDbType.VarChar),
             new SqlParameter("@signUpMemo",SqlDbType.VarChar),
             new SqlParameter("@signUpId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = signUp.huodongObj;
            parm[1].Value = signUp.userObj;
            parm[2].Value = signUp.signUpTime;
            parm[3].Value = signUp.executeState;
            parm[4].Value = signUp.signUpMemo;
            parm[5].Value = signUp.signUpId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�������*/
        public static bool DelSignUp(string p)
        {
            string sql = "delete from SignUp where signUpId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�����*/
        public static DataSet GetSignUp(string strWhere)
        {
            try
            {
                string strSql = "select * from SignUp" + strWhere + " order by signUpId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�����*/
        public static System.Data.DataTable GetSignUp(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from SignUp";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "signUpId", strShow, strSql, strWhere, " signUpId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�����*/
        public static System.Data.DataTable GetSignUpView(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from SignUpView";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "signUpId", strShow, strSql, strWhere, " signUpId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSignUp()
        {
            try
            {
                string strSql = "select * from SignUp";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
