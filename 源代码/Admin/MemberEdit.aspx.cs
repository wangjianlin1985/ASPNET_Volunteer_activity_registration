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
    public partial class MemberEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindGroupInfogroupObj();
                BindUserInfouserObj();
                if (Request["memberId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindGroupInfogroupObj()
        {
            groupObj.DataSource = BLL.bllGroupInfo.getAllGroupInfo();
            groupObj.DataTextField = "groupName";
            groupObj.DataValueField = "groupUserName";
            groupObj.DataBind();
        }

        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "memberId")))
            {
                ENTITY.Member member = BLL.bllMember.getSomeMember(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "memberId")));
                groupObj.SelectedValue = member.groupObj;
                userObj.SelectedValue = member.userObj;
                addTime.Text = member.addTime.ToShortDateString() + " " + member.addTime.ToLongTimeString();
                shenHeState.Value = member.shenHeState;
                memberMemo.Value = member.memberMemo;
            }
        }

        protected void BtnMemberSave_Click(object sender, EventArgs e)
        {
            ENTITY.Member member = new ENTITY.Member();
            member.groupObj = groupObj.SelectedValue;
            member.userObj = userObj.SelectedValue;
            member.addTime = Convert.ToDateTime(addTime.Text);
            member.shenHeState = shenHeState.Value;
            member.memberMemo = memberMemo.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "memberId")))
            {
                member.memberId = int.Parse(Request["memberId"]);
                if (BLL.bllMember.EditMember(member))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"MemberEdit.aspx?memberId=" + Request["memberId"] + "\"} else  {location.href=\"MemberList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllMember.AddMember(member))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"MemberEdit.aspx\"} else  {location.href=\"MemberList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberList.aspx");
        }
    }
}

