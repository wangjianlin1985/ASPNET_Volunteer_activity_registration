using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class GroupInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sqlstr = " where 1=1 ";
            if (Request["groupUserName"] != null && Request["groupUserName"].ToString() != "")
            {
                sqlstr += "  and groupUserName like '%" + Request["groupUserName"].ToString() + "%'";
                groupUserName.Text = Request["groupUserName"].ToString();
            }
            if (Request["groupName"] != null && Request["groupName"].ToString() != "")
            {
                sqlstr += "  and groupName like '%" + Request["groupName"].ToString() + "%'";
                groupName.Text = Request["groupName"].ToString();
            }
            if (Request["leageName"] != null && Request["leageName"].ToString() != "")
            {
                sqlstr += "  and leageName like '%" + Request["leageName"].ToString() + "%'";
                leageName.Text = Request["leageName"].ToString();
            }
            if (Request["telephone"] != null && Request["telephone"].ToString() != "")
            {
                sqlstr += "  and telephone like '%" + Request["telephone"].ToString() + "%'";
                telephone.Text = Request["telephone"].ToString();
            }
            if (Request["bornDate"] != null && Request["bornDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,bornDate,120) like '" + Request["bornDate"].ToString() + "%'";
                bornDate.Text = Request["bornDate"].ToString();
            }
            if (Request["endDate"] != null && Request["endDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,endDate,120) like '" + Request["endDate"].ToString() + "%'";
                endDate.Text = Request["endDate"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
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
        DataTable dsLog = BLL.bllGroupInfo.GetGroupInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpGroupInfo.DataSource = dsLog;
        RpGroupInfo.DataBind();
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?groupUserName=" + groupUserName.Text.Trim() + "&&groupName=" + groupName.Text.Trim()+ "&&leageName=" + leageName.Text.Trim()+ "&&telephone=" + telephone.Text.Trim()+ "&&bornDate=" + bornDate.Text.Trim()+ "&&endDate=" + endDate.Text.Trim());
        }

}
