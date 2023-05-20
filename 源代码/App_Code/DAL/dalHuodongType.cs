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
    public class dalHuodongType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӻ����ʵ��*/
        public static bool AddHuodongType(ENTITY.HuodongType huodongType)
        {
            string sql = "insert into HuodongType(typeName) values(@typeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = huodongType.typeName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����typeId��ȡĳ������ͼ�¼*/
        public static ENTITY.HuodongType getSomeHuodongType(int typeId)
        {
            /*������ѯsql*/
            string sql = "select * from HuodongType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.HuodongType huodongType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                huodongType = new ENTITY.HuodongType();
                huodongType.typeId = Convert.ToInt32(DataRead["typeId"]);
                huodongType.typeName = DataRead["typeName"].ToString();
            }
            return huodongType;
        }

        /*���»����ʵ��*/
        public static bool EditHuodongType(ENTITY.HuodongType huodongType)
        {
            string sql = "update HuodongType set typeName=@typeName where typeId=@typeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = huodongType.typeName;
            parm[1].Value = huodongType.typeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�������*/
        public static bool DelHuodongType(string p)
        {
            string sql = "delete from HuodongType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�����*/
        public static DataSet GetHuodongType(string strWhere)
        {
            try
            {
                string strSql = "select * from HuodongType" + strWhere + " order by typeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�����*/
        public static System.Data.DataTable GetHuodongType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from HuodongType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "typeId", strShow, strSql, strWhere, " typeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllHuodongType()
        {
            try
            {
                string strSql = "select * from HuodongType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
