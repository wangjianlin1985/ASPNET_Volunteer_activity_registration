using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*活动类型业务逻辑层实现*/
    public class dalHuodongType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加活动类型实现*/
        public static bool AddHuodongType(ENTITY.HuodongType huodongType)
        {
            string sql = "insert into HuodongType(typeName) values(@typeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = huodongType.typeName; //类型名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据typeId获取某条活动类型记录*/
        public static ENTITY.HuodongType getSomeHuodongType(int typeId)
        {
            /*构建查询sql*/
            string sql = "select * from HuodongType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.HuodongType huodongType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                huodongType = new ENTITY.HuodongType();
                huodongType.typeId = Convert.ToInt32(DataRead["typeId"]);
                huodongType.typeName = DataRead["typeName"].ToString();
            }
            return huodongType;
        }

        /*更新活动类型实现*/
        public static bool EditHuodongType(ENTITY.HuodongType huodongType)
        {
            string sql = "update HuodongType set typeName=@typeName where typeId=@typeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = huodongType.typeName;
            parm[1].Value = huodongType.typeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除活动类型*/
        public static bool DelHuodongType(string p)
        {
            string sql = "delete from HuodongType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询活动类型*/
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

        /*查询活动类型*/
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
