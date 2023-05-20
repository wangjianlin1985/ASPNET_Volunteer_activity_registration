using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*活动报名业务逻辑层*/
    public class bllSignUp{
        /*添加活动报名*/
        public static bool AddSignUp(ENTITY.SignUp signUp)
        {
            return DAL.dalSignUp.AddSignUp(signUp);
        }

        /*根据signUpId获取某条活动报名记录*/
        public static ENTITY.SignUp getSomeSignUp(int signUpId)
        {
            return DAL.dalSignUp.getSomeSignUp(signUpId);
        }

        /*更新活动报名*/
        public static bool EditSignUp(ENTITY.SignUp signUp)
        {
            return DAL.dalSignUp.EditSignUp(signUp);
        }

        /*删除活动报名*/
        public static bool DelSignUp(string p)
        {
            return DAL.dalSignUp.DelSignUp(p);
        }

        /*查询活动报名*/
        public static System.Data.DataSet GetSignUp(string strWhere)
        {
            return DAL.dalSignUp.GetSignUp(strWhere);
        }

        /*根据条件分页查询活动报名*/
        public static System.Data.DataTable GetSignUp(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSignUp.GetSignUp(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*根据条件分页查询活动报名*/
        public static System.Data.DataTable GetSignUpView(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSignUp.GetSignUpView(NowPage, PageSize, out AllPage, out DataCount, p);

        }
        /*查询所有的活动报名*/
        public static System.Data.DataSet getAllSignUp()
        {
            return DAL.dalSignUp.getAllSignUp();
        }
    }
}
