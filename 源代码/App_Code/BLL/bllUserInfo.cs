using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*志愿者业务逻辑层*/
    public class bllUserInfo{
        /*添加志愿者*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.AddUserInfo(userInfo);
        }

        /*根据user_name获取某条志愿者记录*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            return DAL.dalUserInfo.getSomeUserInfo(user_name);
        }

        /*更新志愿者*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.EditUserInfo(userInfo);
        }

        /*删除志愿者*/
        public static bool DelUserInfo(string p)
        {
            return DAL.dalUserInfo.DelUserInfo(p);
        }

        /*查询志愿者*/
        public static System.Data.DataSet GetUserInfo(string strWhere)
        {
            return DAL.dalUserInfo.GetUserInfo(strWhere);
        }

        /*根据条件分页查询志愿者*/
        public static System.Data.DataTable GetUserInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的志愿者*/
        public static System.Data.DataSet getAllUserInfo()
        {
            return DAL.dalUserInfo.getAllUserInfo();
        }
    }
}
