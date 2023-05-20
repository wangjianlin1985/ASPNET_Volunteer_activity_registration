using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class HuodongTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["typeId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "typeId")))
            {
                ENTITY.HuodongType huodongType = BLL.bllHuodongType.getSomeHuodongType(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "typeId")));
                typeName.Value = huodongType.typeName;
            }
        }

        protected void BtnHuodongTypeSave_Click(object sender, EventArgs e)
        {
            ENTITY.HuodongType huodongType = new ENTITY.HuodongType();
            huodongType.typeName = typeName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "typeId")))
            {
                huodongType.typeId = int.Parse(Request["typeId"]);
                if (BLL.bllHuodongType.EditHuodongType(huodongType))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"HuodongTypeEdit.aspx?typeId=" + Request["typeId"] + "\"} else  {location.href=\"HuodongTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllHuodongType.AddHuodongType(huodongType))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"HuodongTypeEdit.aspx\"} else  {location.href=\"HuodongTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HuodongTypeList.aspx");
        }
    }
}

