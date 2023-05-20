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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"MemberEdit.aspx?memberId=" + Request["memberId"] + "\"} else  {location.href=\"MemberList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllMember.AddMember(member))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"MemberEdit.aspx\"} else  {location.href=\"MemberList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberList.aspx");
        }
    }
}

