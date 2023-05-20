using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��֯����ҵ���߼���ʵ��*/
    public class dalGroupInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        public static bool ulogin(String userName,String password)
        {
            string sql = @"select groupUserName from GroupInfo where groupUserName =@userName and password =@password";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@userName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar)
           };
            para[0].Value = userName;
            para[1].Value = password;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }


        /*�����֯����ʵ��*/
        public static bool AddGroupInfo(ENTITY.GroupInfo groupInfo)
        {
            string sql = "insert into GroupInfo(groupUserName,password,groupName,leageName,groupPhoto,telephone,bornDate,endDate,groupDesc) values(@groupUserName,@password,@groupName,@leageName,@groupPhoto,@telephone,@bornDate,@endDate,@groupDesc)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@groupUserName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@groupName",SqlDbType.VarChar),
             new SqlParameter("@leageName",SqlDbType.VarChar),
             new SqlParameter("@groupPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@endDate",SqlDbType.DateTime),
             new SqlParameter("@groupDesc",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = groupInfo.groupUserName; //����û���
            parm[1].Value = groupInfo.password; //��¼����
            parm[2].Value = groupInfo.groupName; //��������
            parm[3].Value = groupInfo.leageName; //�������
            parm[4].Value = groupInfo.groupPhoto; //��֯��Ƭ
            parm[5].Value = groupInfo.telephone; //��ϵ�绰
            parm[6].Value = groupInfo.bornDate; //��������
            parm[7].Value = groupInfo.endDate; //��ֹ����
            parm[8].Value = groupInfo.groupDesc; //�Ŷӽ���

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����groupUserName��ȡĳ����֯�����¼*/
        public static ENTITY.GroupInfo getSomeGroupInfo(string groupUserName)
        {
            /*������ѯsql*/
            string sql = "select * from GroupInfo where groupUserName='" + groupUserName + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.GroupInfo groupInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                groupInfo = new ENTITY.GroupInfo();
                groupInfo.groupUserName = DataRead["groupUserName"].ToString();
                groupInfo.password = DataRead["password"].ToString();
                groupInfo.groupName = DataRead["groupName"].ToString();
                groupInfo.leageName = DataRead["leageName"].ToString();
                groupInfo.groupPhoto = DataRead["groupPhoto"].ToString();
                groupInfo.telephone = DataRead["telephone"].ToString();
                groupInfo.bornDate = Convert.ToDateTime(DataRead["bornDate"].ToString());
                groupInfo.endDate = Convert.ToDateTime(DataRead["endDate"].ToString());
                groupInfo.groupDesc = DataRead["groupDesc"].ToString();
            }
            return groupInfo;
        }

        /*������֯����ʵ��*/
        public static bool EditGroupInfo(ENTITY.GroupInfo groupInfo)
        {
            string sql = "update GroupInfo set password=@password,groupName=@groupName,leageName=@leageName,groupPhoto=@groupPhoto,telephone=@telephone,bornDate=@bornDate,endDate=@endDate,groupDesc=@groupDesc where groupUserName=@groupUserName";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@groupName",SqlDbType.VarChar),
             new SqlParameter("@leageName",SqlDbType.VarChar),
             new SqlParameter("@groupPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@endDate",SqlDbType.DateTime),
             new SqlParameter("@groupDesc",SqlDbType.VarChar),
             new SqlParameter("@groupUserName",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = groupInfo.password;
            parm[1].Value = groupInfo.groupName;
            parm[2].Value = groupInfo.leageName;
            parm[3].Value = groupInfo.groupPhoto;
            parm[4].Value = groupInfo.telephone;
            parm[5].Value = groupInfo.bornDate;
            parm[6].Value = groupInfo.endDate;
            parm[7].Value = groupInfo.groupDesc;
            parm[8].Value = groupInfo.groupUserName;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����֯����*/
        public static bool DelGroupInfo(string p)
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
            sql = "delete from GroupInfo where groupUserName in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��֯����*/
        public static DataSet GetGroupInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from GroupInfo" + strWhere + " order by groupUserName asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��֯����*/
        public static System.Data.DataTable GetGroupInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from GroupInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "groupUserName", strShow, strSql, strWhere, " groupUserName asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllGroupInfo()
        {
            try
            {
                string strSql = "select * from GroupInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
