using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�����ҵ���߼���*/
    public class bllHuodongType{
        /*��ӻ����*/
        public static bool AddHuodongType(ENTITY.HuodongType huodongType)
        {
            return DAL.dalHuodongType.AddHuodongType(huodongType);
        }

        /*����typeId��ȡĳ������ͼ�¼*/
        public static ENTITY.HuodongType getSomeHuodongType(int typeId)
        {
            return DAL.dalHuodongType.getSomeHuodongType(typeId);
        }

        /*���»����*/
        public static bool EditHuodongType(ENTITY.HuodongType huodongType)
        {
            return DAL.dalHuodongType.EditHuodongType(huodongType);
        }

        /*ɾ�������*/
        public static bool DelHuodongType(string p)
        {
            return DAL.dalHuodongType.DelHuodongType(p);
        }

        /*��ѯ�����*/
        public static System.Data.DataSet GetHuodongType(string strWhere)
        {
            return DAL.dalHuodongType.GetHuodongType(strWhere);
        }

        /*����������ҳ��ѯ�����*/
        public static System.Data.DataTable GetHuodongType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHuodongType.GetHuodongType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĻ����*/
        public static System.Data.DataSet getAllHuodongType()
        {
            return DAL.dalHuodongType.getAllHuodongType();
        }
    }
}
