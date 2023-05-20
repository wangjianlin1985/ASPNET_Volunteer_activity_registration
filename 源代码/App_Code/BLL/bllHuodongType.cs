using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*活动类型业务逻辑层*/
    public class bllHuodongType{
        /*添加活动类型*/
        public static bool AddHuodongType(ENTITY.HuodongType huodongType)
        {
            return DAL.dalHuodongType.AddHuodongType(huodongType);
        }

        /*根据typeId获取某条活动类型记录*/
        public static ENTITY.HuodongType getSomeHuodongType(int typeId)
        {
            return DAL.dalHuodongType.getSomeHuodongType(typeId);
        }

        /*更新活动类型*/
        public static bool EditHuodongType(ENTITY.HuodongType huodongType)
        {
            return DAL.dalHuodongType.EditHuodongType(huodongType);
        }

        /*删除活动类型*/
        public static bool DelHuodongType(string p)
        {
            return DAL.dalHuodongType.DelHuodongType(p);
        }

        /*查询活动类型*/
        public static System.Data.DataSet GetHuodongType(string strWhere)
        {
            return DAL.dalHuodongType.GetHuodongType(strWhere);
        }

        /*根据条件分页查询活动类型*/
        public static System.Data.DataTable GetHuodongType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHuodongType.GetHuodongType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的活动类型*/
        public static System.Data.DataSet getAllHuodongType()
        {
            return DAL.dalHuodongType.getAllHuodongType();
        }
    }
}
