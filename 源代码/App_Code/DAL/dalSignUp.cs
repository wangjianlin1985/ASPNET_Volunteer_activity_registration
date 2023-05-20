using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*活动报名业务逻辑层实现*/
    public class dalSignUp
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加活动报名实现*/
        public static bool AddSignUp(ENTITY.SignUp signUp)
        {
            string sql = "insert into SignUp(huodongObj,userObj,signUpTime,executeState,signUpMemo) values(@huodongObj,@userObj,@signUpTime,@executeState,@signUpMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huodongObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@signUpTime",SqlDbType.DateTime),
             new SqlParameter("@executeState",SqlDbType.VarChar),
             new SqlParameter("@signUpMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = signUp.huodongObj; //报名活动
            parm[1].Value = signUp.userObj; //报名用户
            parm[2].Value = signUp.signUpTime; //报名时间
            parm[3].Value = signUp.executeState; //执行状态
            parm[4].Value = signUp.signUpMemo; //备注信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据signUpId获取某条活动报名记录*/
        public static ENTITY.SignUp getSomeSignUp(int signUpId)
        {
            /*构建查询sql*/
            string sql = "select * from SignUp where signUpId=" + signUpId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SignUp signUp = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新活动报名实现*/
        public static bool EditSignUp(ENTITY.SignUp signUp)
        {
            string sql = "update SignUp set huodongObj=@huodongObj,userObj=@userObj,signUpTime=@signUpTime,executeState=@executeState,signUpMemo=@signUpMemo where signUpId=@signUpId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huodongObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@signUpTime",SqlDbType.DateTime),
             new SqlParameter("@executeState",SqlDbType.VarChar),
             new SqlParameter("@signUpMemo",SqlDbType.VarChar),
             new SqlParameter("@signUpId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = signUp.huodongObj;
            parm[1].Value = signUp.userObj;
            parm[2].Value = signUp.signUpTime;
            parm[3].Value = signUp.executeState;
            parm[4].Value = signUp.signUpMemo;
            parm[5].Value = signUp.signUpId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除活动报名*/
        public static bool DelSignUp(string p)
        {
            string sql = "delete from SignUp where signUpId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询活动报名*/
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

        /*查询活动报名*/
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

        /*查询活动报名*/
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
