using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*活动业务逻辑层*/
    public class bllHuodong{
        /*添加活动*/
        public static bool AddHuodong(ENTITY.Huodong huodong)
        {
            return DAL.dalHuodong.AddHuodong(huodong);
        }

        /*根据huodongId获取某条活动记录*/
        public static ENTITY.Huodong getSomeHuodong(int huodongId)
        {
            return DAL.dalHuodong.getSomeHuodong(huodongId);
        }

        /*更新活动*/
        public static bool EditHuodong(ENTITY.Huodong huodong)
        {
            return DAL.dalHuodong.EditHuodong(huodong);
        }

        /*删除活动*/
        public static bool DelHuodong(string p)
        {
            return DAL.dalHuodong.DelHuodong(p);
        }

        /*查询活动*/
        public static System.Data.DataSet GetHuodong(string strWhere)
        {
            return DAL.dalHuodong.GetHuodong(strWhere);
        }

        /*根据条件分页查询活动*/
        public static System.Data.DataTable GetHuodong(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHuodong.GetHuodong(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的活动*/
        public static System.Data.DataSet getAllHuodong()
        {
            return DAL.dalHuodong.getAllHuodong();
        }
    }
}
