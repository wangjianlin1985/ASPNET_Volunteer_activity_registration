using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*־Ը��ҵ���߼���*/
    public class bllUserInfo{
        /*���־Ը��*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.AddUserInfo(userInfo);
        }

        /*����user_name��ȡĳ��־Ը�߼�¼*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            return DAL.dalUserInfo.getSomeUserInfo(user_name);
        }

        /*����־Ը��*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.EditUserInfo(userInfo);
        }

        /*ɾ��־Ը��*/
        public static bool DelUserInfo(string p)
        {
            return DAL.dalUserInfo.DelUserInfo(p);
        }

        /*��ѯ־Ը��*/
        public static System.Data.DataSet GetUserInfo(string strWhere)
        {
            return DAL.dalUserInfo.GetUserInfo(strWhere);
        }

        /*����������ҳ��ѯ־Ը��*/
        public static System.Data.DataTable GetUserInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�־Ը��*/
        public static System.Data.DataSet getAllUserInfo()
        {
            return DAL.dalUserInfo.getAllUserInfo();
        }
    }
}
