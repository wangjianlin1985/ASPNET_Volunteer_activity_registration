using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*团员业务逻辑层*/
    public class bllMember{
        /*添加团员*/
        public static bool AddMember(ENTITY.Member member)
        {
            return DAL.dalMember.AddMember(member);
        }

        /*根据memberId获取某条团员记录*/
        public static ENTITY.Member getSomeMember(int memberId)
        {
            return DAL.dalMember.getSomeMember(memberId);
        }

        /*更新团员*/
        public static bool EditMember(ENTITY.Member member)
        {
            return DAL.dalMember.EditMember(member);
        }

        /*删除团员*/
        public static bool DelMember(string p)
        {
            return DAL.dalMember.DelMember(p);
        }

        /*查询团员*/
        public static System.Data.DataSet GetMember(string strWhere)
        {
            return DAL.dalMember.GetMember(strWhere);
        }

        /*根据条件分页查询团员*/
        public static System.Data.DataTable GetMember(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalMember.GetMember(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的团员*/
        public static System.Data.DataSet getAllMember()
        {
            return DAL.dalMember.getAllMember();
        }
    }
}
