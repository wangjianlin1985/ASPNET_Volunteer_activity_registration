using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Member_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindgroupObj();
            BinduserObj();
            string sqlstr = " where 1=1 ";
            if (Request["groupObj"] != null && Request["groupObj"].ToString() != "")
            {
                sqlstr += "  and groupObj='" + Request["groupObj"].ToString() + "'";
                groupObj.SelectedValue = Request["groupObj"].ToString();
            }
            /*
            if (Request["userObj"] != null && Request["userObj"].ToString() != "")
            {
                sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                userObj.SelectedValue = Request["userObj"].ToString();
            }*/

            sqlstr += "  and userObj='" + Session["user_name"].ToString() + "'";

            if (Request["addTime"] != null && Request["addTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                addTime.Text = Request["addTime"].ToString();
            }
            if (Request["shenHeState"] != null && Request["shenHeState"].ToString() != "")
            {
                sqlstr += "  and shenHeState like '%" + Request["shenHeState"].ToString() + "%'";
                shenHeState.Text = Request["shenHeState"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindgroupObj()
    {
        ListItem li = new ListItem("������", "");
        groupObj.Items.Add(li);
        DataSet groupObjDs = BLL.bllGroupInfo.getAllGroupInfo();
        for (int i = 0; i < groupObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = groupObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["groupName"].ToString(),dr["groupUserName"].ToString());
            groupObj.Items.Add(li);
        }
        groupObj.SelectedValue = "";
    }

    private void BinduserObj()
    {
        ListItem li = new ListItem("������", "");
        userObj.Items.Add(li);
        DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
        for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = userObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["name"].ToString(),dr["user_name"].ToString());
            userObj.Items.Add(li);
        }
        userObj.SelectedValue = "";
    }

    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllMember.GetMember(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpMember.DataSource = dsLog;
        RpMember.DataBind();
        PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
        public string GetGroupInfogroupObj(string groupObj)
        {
            return BLL.bllGroupInfo.getSomeGroupInfo(groupObj).groupName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("userFrontList.aspx?groupObj=" + groupObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim()+ "&&shenHeState=" + shenHeState.Text.Trim());
        }

}
