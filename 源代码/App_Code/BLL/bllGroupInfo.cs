using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��֯����ҵ���߼���*/
    public class bllGroupInfo{

        public static bool ulogin(String userName,String password)
        {
            return DAL.dalGroupInfo.ulogin(userName,password);


        }
        /*�����֯����*/
        public static bool AddGroupInfo(ENTITY.GroupInfo groupInfo)
        {
            return DAL.dalGroupInfo.AddGroupInfo(groupInfo);
        }

        /*����groupUserName��ȡĳ����֯�����¼*/
        public static ENTITY.GroupInfo getSomeGroupInfo(string groupUserName)
        {
            return DAL.dalGroupInfo.getSomeGroupInfo(groupUserName);
        }

        /*������֯����*/
        public static bool EditGroupInfo(ENTITY.GroupInfo groupInfo)
        {
            return DAL.dalGroupInfo.EditGroupInfo(groupInfo);
        }

        /*ɾ����֯����*/
        public static bool DelGroupInfo(string p)
        {
            return DAL.dalGroupInfo.DelGroupInfo(p);
        }

        /*��ѯ��֯����*/
        public static System.Data.DataSet GetGroupInfo(string strWhere)
        {
            return DAL.dalGroupInfo.GetGroupInfo(strWhere);
        }

        /*����������ҳ��ѯ��֯����*/
        public static System.Data.DataTable GetGroupInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalGroupInfo.GetGroupInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���֯����*/
        public static System.Data.DataSet getAllGroupInfo()
        {
            return DAL.dalGroupInfo.getAllGroupInfo();
        }
    }
}
