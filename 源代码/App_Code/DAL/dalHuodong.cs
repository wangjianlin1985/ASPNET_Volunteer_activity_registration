using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*活动业务逻辑层实现*/
    public class dalHuodong
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加活动实现*/
        public static bool AddHuodong(ENTITY.Huodong huodong)
        {
            string sql = "insert into Huodong(huodongTypeObj,title,huodongPhoto,huodongDesc,startTime,endTime,jifen,groupObj) values(@huodongTypeObj,@title,@huodongPhoto,@huodongDesc,@startTime,@endTime,@jifen,@groupObj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huodongTypeObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@huodongPhoto",SqlDbType.VarChar),
             new SqlParameter("@huodongDesc",SqlDbType.VarChar),
             new SqlParameter("@startTime",SqlDbType.DateTime),
             new SqlParameter("@endTime",SqlDbType.DateTime),
             new SqlParameter("@jifen",SqlDbType.Float),
             new SqlParameter("@groupObj",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = huodong.huodongTypeObj; //活动类型
            parm[1].Value = huodong.title; //活动名称
            parm[2].Value = huodong.huodongPhoto; //活动图片
            parm[3].Value = huodong.huodongDesc; //活动简介
            parm[4].Value = huodong.startTime; //开始时间
            parm[5].Value = huodong.endTime; //结束时间
            parm[6].Value = huodong.jifen; //活动积分
            parm[7].Value = huodong.groupObj; //发布组织

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据huodongId获取某条活动记录*/
        public static ENTITY.Huodong getSomeHuodong(int huodongId)
        {
            /*构建查询sql*/
            string sql = "select * from Huodong where huodongId=" + huodongId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Huodong huodong = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                huodong = new ENTITY.Huodong();
                huodong.huodongId = Convert.ToInt32(DataRead["huodongId"]);
                huodong.huodongTypeObj = Convert.ToInt32(DataRead["huodongTypeObj"]);
                huodong.title = DataRead["title"].ToString();
                huodong.huodongPhoto = DataRead["huodongPhoto"].ToString();
                huodong.huodongDesc = DataRead["huodongDesc"].ToString();
                huodong.startTime = Convert.ToDateTime(DataRead["startTime"].ToString());
                huodong.endTime = Convert.ToDateTime(DataRead["endTime"].ToString());
                huodong.jifen = float.Parse(DataRead["jifen"].ToString());
                huodong.groupObj = DataRead["groupObj"].ToString();
            }
            return huodong;
        }

        /*更新活动实现*/
        public static bool EditHuodong(ENTITY.Huodong huodong)
        {
            string sql = "update Huodong set huodongTypeObj=@huodongTypeObj,title=@title,huodongPhoto=@huodongPhoto,huodongDesc=@huodongDesc,startTime=@startTime,endTime=@endTime,jifen=@jifen,groupObj=@groupObj where huodongId=@huodongId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huodongTypeObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@huodongPhoto",SqlDbType.VarChar),
             new SqlParameter("@huodongDesc",SqlDbType.VarChar),
             new SqlParameter("@startTime",SqlDbType.DateTime),
             new SqlParameter("@endTime",SqlDbType.DateTime),
             new SqlParameter("@jifen",SqlDbType.Float),
             new SqlParameter("@groupObj",SqlDbType.VarChar),
             new SqlParameter("@huodongId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = huodong.huodongTypeObj;
            parm[1].Value = huodong.title;
            parm[2].Value = huodong.huodongPhoto;
            parm[3].Value = huodong.huodongDesc;
            parm[4].Value = huodong.startTime;
            parm[5].Value = huodong.endTime;
            parm[6].Value = huodong.jifen;
            parm[7].Value = huodong.groupObj;
            parm[8].Value = huodong.huodongId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除活动*/
        public static bool DelHuodong(string p)
        {
            string sql = "delete from Huodong where huodongId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询活动*/
        public static DataSet GetHuodong(string strWhere)
        {
            try
            {
                string strSql = "select * from Huodong" + strWhere + " order by huodongId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询活动*/
        public static System.Data.DataTable GetHuodong(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Huodong";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "huodongId", strShow, strSql, strWhere, " huodongId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllHuodong()
        {
            try
            {
                string strSql = "select * from Huodong";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
