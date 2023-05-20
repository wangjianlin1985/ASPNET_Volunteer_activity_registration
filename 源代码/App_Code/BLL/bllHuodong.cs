using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�ҵ���߼���*/
    public class bllHuodong{
        /*��ӻ*/
        public static bool AddHuodong(ENTITY.Huodong huodong)
        {
            return DAL.dalHuodong.AddHuodong(huodong);
        }

        /*����huodongId��ȡĳ�����¼*/
        public static ENTITY.Huodong getSomeHuodong(int huodongId)
        {
            return DAL.dalHuodong.getSomeHuodong(huodongId);
        }

        /*���»*/
        public static bool EditHuodong(ENTITY.Huodong huodong)
        {
            return DAL.dalHuodong.EditHuodong(huodong);
        }

        /*ɾ���*/
        public static bool DelHuodong(string p)
        {
            return DAL.dalHuodong.DelHuodong(p);
        }

        /*��ѯ�*/
        public static System.Data.DataSet GetHuodong(string strWhere)
        {
            return DAL.dalHuodong.GetHuodong(strWhere);
        }

        /*����������ҳ��ѯ�*/
        public static System.Data.DataTable GetHuodong(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHuodong.GetHuodong(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĻ*/
        public static System.Data.DataSet getAllHuodong()
        {
            return DAL.dalHuodong.getAllHuodong();
        }
    }
}
