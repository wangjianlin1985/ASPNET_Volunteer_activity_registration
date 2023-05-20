using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*组织团体业务逻辑层*/
    public class bllGroupInfo{

        public static bool ulogin(String userName,String password)
        {
            return DAL.dalGroupInfo.ulogin(userName,password);


        }
        /*添加组织团体*/
        public static bool AddGroupInfo(ENTITY.GroupInfo groupInfo)
        {
            return DAL.dalGroupInfo.AddGroupInfo(groupInfo);
        }

        /*根据groupUserName获取某条组织团体记录*/
        public static ENTITY.GroupInfo getSomeGroupInfo(string groupUserName)
        {
            return DAL.dalGroupInfo.getSomeGroupInfo(groupUserName);
        }

        /*更新组织团体*/
        public static bool EditGroupInfo(ENTITY.GroupInfo groupInfo)
        {
            return DAL.dalGroupInfo.EditGroupInfo(groupInfo);
        }

        /*删除组织团体*/
        public static bool DelGroupInfo(string p)
        {
            return DAL.dalGroupInfo.DelGroupInfo(p);
        }

        /*查询组织团体*/
        public static System.Data.DataSet GetGroupInfo(string strWhere)
        {
            return DAL.dalGroupInfo.GetGroupInfo(strWhere);
        }

        /*根据条件分页查询组织团体*/
        public static System.Data.DataTable GetGroupInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalGroupInfo.GetGroupInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的组织团体*/
        public static System.Data.DataSet getAllGroupInfo()
        {
            return DAL.dalGroupInfo.getAllGroupInfo();
        }
    }
}
