using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Աҵ���߼���*/
    public class bllMember{
        /*�����Ա*/
        public static bool AddMember(ENTITY.Member member)
        {
            return DAL.dalMember.AddMember(member);
        }

        /*����memberId��ȡĳ����Ա��¼*/
        public static ENTITY.Member getSomeMember(int memberId)
        {
            return DAL.dalMember.getSomeMember(memberId);
        }

        /*������Ա*/
        public static bool EditMember(ENTITY.Member member)
        {
            return DAL.dalMember.EditMember(member);
        }

        /*ɾ����Ա*/
        public static bool DelMember(string p)
        {
            return DAL.dalMember.DelMember(p);
        }

        /*��ѯ��Ա*/
        public static System.Data.DataSet GetMember(string strWhere)
        {
            return DAL.dalMember.GetMember(strWhere);
        }

        /*����������ҳ��ѯ��Ա*/
        public static System.Data.DataTable GetMember(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalMember.GetMember(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ա*/
        public static System.Data.DataSet getAllMember()
        {
            return DAL.dalMember.getAllMember();
        }
    }
}
