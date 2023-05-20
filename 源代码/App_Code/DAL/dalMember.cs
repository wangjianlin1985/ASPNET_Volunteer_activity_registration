using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Աҵ���߼���ʵ��*/
    public class dalMember
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Աʵ��*/
        public static bool AddMember(ENTITY.Member member)
        {
            string sql = "insert into Member(groupObj,userObj,addTime,shenHeState,memberMemo) values(@groupObj,@userObj,@addTime,@shenHeState,@memberMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@groupObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar),
             new SqlParameter("@memberMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = member.groupObj; //��������
            parm[1].Value = member.userObj; //�����û�
            parm[2].Value = member.addTime; //����ʱ��
            parm[3].Value = member.shenHeState; //���״̬
            parm[4].Value = member.memberMemo; //��ע��Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����memberId��ȡĳ����Ա��¼*/
        public static ENTITY.Member getSomeMember(int memberId)
        {
            /*������ѯsql*/
            string sql = "select * from Member where memberId=" + memberId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Member member = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Աʵ��*/
        public static bool EditMember(ENTITY.Member member)
        {
            string sql = "update Member set groupObj=@groupObj,userObj=@userObj,addTime=@addTime,shenHeState=@shenHeState,memberMemo=@memberMemo where memberId=@memberId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@groupObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar),
             new SqlParameter("@memberMemo",SqlDbType.VarChar),
             new SqlParameter("@memberId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = member.groupObj;
            parm[1].Value = member.userObj;
            parm[2].Value = member.addTime;
            parm[3].Value = member.shenHeState;
            parm[4].Value = member.memberMemo;
            parm[5].Value = member.memberId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ա*/
        public static bool DelMember(string p)
        {
            string sql = "delete from Member where memberId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ա*/
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

        /*��ѯ��Ա*/
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
