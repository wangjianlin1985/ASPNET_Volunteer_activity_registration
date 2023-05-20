using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�ҵ���߼���ʵ��*/
    public class dalHuodong
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӻʵ��*/
        public static bool AddHuodong(ENTITY.Huodong huodong)
        {
            string sql = "insert into Huodong(huodongTypeObj,title,huodongPhoto,huodongDesc,startTime,endTime,jifen,groupObj) values(@huodongTypeObj,@title,@huodongPhoto,@huodongDesc,@startTime,@endTime,@jifen,@groupObj)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = huodong.huodongTypeObj; //�����
            parm[1].Value = huodong.title; //�����
            parm[2].Value = huodong.huodongPhoto; //�ͼƬ
            parm[3].Value = huodong.huodongDesc; //����
            parm[4].Value = huodong.startTime; //��ʼʱ��
            parm[5].Value = huodong.endTime; //����ʱ��
            parm[6].Value = huodong.jifen; //�����
            parm[7].Value = huodong.groupObj; //������֯

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����huodongId��ȡĳ�����¼*/
        public static ENTITY.Huodong getSomeHuodong(int huodongId)
        {
            /*������ѯsql*/
            string sql = "select * from Huodong where huodongId=" + huodongId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Huodong huodong = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���»ʵ��*/
        public static bool EditHuodong(ENTITY.Huodong huodong)
        {
            string sql = "update Huodong set huodongTypeObj=@huodongTypeObj,title=@title,huodongPhoto=@huodongPhoto,huodongDesc=@huodongDesc,startTime=@startTime,endTime=@endTime,jifen=@jifen,groupObj=@groupObj where huodongId=@huodongId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = huodong.huodongTypeObj;
            parm[1].Value = huodong.title;
            parm[2].Value = huodong.huodongPhoto;
            parm[3].Value = huodong.huodongDesc;
            parm[4].Value = huodong.startTime;
            parm[5].Value = huodong.endTime;
            parm[6].Value = huodong.jifen;
            parm[7].Value = huodong.groupObj;
            parm[8].Value = huodong.huodongId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���*/
        public static bool DelHuodong(string p)
        {
            string sql = "delete from Huodong where huodongId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�*/
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

        /*��ѯ�*/
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
