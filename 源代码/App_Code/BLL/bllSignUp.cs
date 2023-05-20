using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�����ҵ���߼���*/
    public class bllSignUp{
        /*��ӻ����*/
        public static bool AddSignUp(ENTITY.SignUp signUp)
        {
            return DAL.dalSignUp.AddSignUp(signUp);
        }

        /*����signUpId��ȡĳ���������¼*/
        public static ENTITY.SignUp getSomeSignUp(int signUpId)
        {
            return DAL.dalSignUp.getSomeSignUp(signUpId);
        }

        /*���»����*/
        public static bool EditSignUp(ENTITY.SignUp signUp)
        {
            return DAL.dalSignUp.EditSignUp(signUp);
        }

        /*ɾ�������*/
        public static bool DelSignUp(string p)
        {
            return DAL.dalSignUp.DelSignUp(p);
        }

        /*��ѯ�����*/
        public static System.Data.DataSet GetSignUp(string strWhere)
        {
            return DAL.dalSignUp.GetSignUp(strWhere);
        }

        /*����������ҳ��ѯ�����*/
        public static System.Data.DataTable GetSignUp(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSignUp.GetSignUp(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*����������ҳ��ѯ�����*/
        public static System.Data.DataTable GetSignUpView(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSignUp.GetSignUpView(NowPage, PageSize, out AllPage, out DataCount, p);

        }
        /*��ѯ���еĻ����*/
        public static System.Data.DataSet getAllSignUp()
        {
            return DAL.dalSignUp.getAllSignUp();
        }
    }
}
