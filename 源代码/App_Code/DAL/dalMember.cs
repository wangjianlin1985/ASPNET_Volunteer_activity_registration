using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*团员业务逻辑层实现*/
    public class dalMember
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加团员实现*/
        public static bool AddMember(ENTITY.Member member)
        {
            string sql = "insert into Member(groupObj,userObj,addTime,shenHeState,memberMemo) values(@groupObj,@userObj,@addTime,@shenHeState,@memberMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@groupObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar),
             new SqlParameter("@memberMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = member.groupObj; //申请团体
            parm[1].Value = member.userObj; //申请用户
            parm[2].Value = member.addTime; //申请时间
            parm[3].Value = member.shenHeState; //审核状态
            parm[4].Value = member.memberMemo; //备注信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据memberId获取某条团员记录*/
        public static ENTITY.Member getSomeMember(int memberId)
        {
            /*构建查询sql*/
            string sql = "select * from Member where memberId=" + memberId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Member member = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                member = new ENTITY.Member();
                member.memberId = Convert.ToInt32(DataRead["memberId"]);
                member.groupObj = DataRead["groupObj"].ToString();
                member.userObj = DataRead["userObj"].ToString();
                member.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
                member.shenHeState = DataRead["shenHeState"].ToString();
                member.memberMemo = DataRead["memberMemo"].ToString();
            }
            return member;
        }

        /*更新团员实现*/
        public static bool EditMember(ENTITY.Member member)
        {
            string sql = "update Member set groupObj=@groupObj,userObj=@userObj,addTime=@addTime,shenHeState=@shenHeState,memberMemo=@memberMemo where memberId=@memberId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@groupObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar),
             new SqlParameter("@memberMemo",SqlDbType.VarChar),
             new SqlParameter("@memberId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = member.groupObj;
            parm[1].Value = member.userObj;
            parm[2].Value = member.addTime;
            parm[3].Value = member.shenHeState;
            parm[4].Value = member.memberMemo;
            parm[5].Value = member.memberId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除团员*/
        public static bool DelMember(string p)
        {
            string sql = "delete from Member where memberId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询团员*/
        public static DataSet GetMember(string strWhere)
        {
            try
            {
                string strSql = "select * from Member" + strWhere + " order by memberId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询团员*/
        public static System.Data.DataTable GetMember(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Member";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "memberId", strShow, strSql, strWhere, " memberId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllMember()
        {
            try
            {
                string strSql = "select * from Member";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
