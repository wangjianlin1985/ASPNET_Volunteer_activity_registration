using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Huodong_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindhuodongTypeObj();
            BindgroupObj();
            string sqlstr = " where 1=1 ";
            if (Request["huodongTypeObj"] != null && Request["huodongTypeObj"].ToString() != "0")
            {
                    sqlstr += "  and huodongTypeObj=" + Request["huodongTypeObj"].ToString();
                    huodongTypeObj.SelectedValue = Request["huodongTypeObj"].ToString();
            }
            if (Request["title"] != null && Request["title"].ToString() != "")
            {
                sqlstr += "  and title like '%" + Request["title"].ToString() + "%'";
                title.Text = Request["title"].ToString();
            }
            if (Request["startTime"] != null && Request["startTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,startTime,120) like '" + Request["startTime"].ToString() + "%'";
                startTime.Text = Request["startTime"].ToString();
            }
            if (Request["endTime"] != null && Request["endTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,endTime,120) like '" + Request["endTime"].ToString() + "%'";
                endTime.Text = Request["endTime"].ToString();
            }
            if (Request["groupObj"] != null && Request["groupObj"].ToString() != "")
            {
                sqlstr += "  and groupObj='" + Request["groupObj"].ToString() + "'";
                groupObj.SelectedValue = Request["groupObj"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindhuodongTypeObj()
    {
        ListItem li = new ListItem("不限制", "0");
        huodongTypeObj.Items.Add(li);
        DataSet huodongTypeObjDs = BLL.bllHuodongType.getAllHuodongType();
        for (int i = 0; i < huodongTypeObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = huodongTypeObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["typeName"].ToString(),dr["typeId"].ToString());
            huodongTypeObj.Items.Add(li);
        }
        huodongTypeObj.SelectedValue = "0";
    }

    private void BindgroupObj()
    {
        ListItem li = new ListItem("不限制", "");
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
        DataTable dsLog = BLL.bllHuodong.GetHuodong(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpHuodong.DataSource = dsLog;
        RpHuodong.DataBind();
        PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
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
        public string GetHuodongTypehuodongTypeObj(string huodongTypeObj)
        {
            return BLL.bllHuodongType.getSomeHuodongType(int.Parse(huodongTypeObj)).typeName;
        }

        public string GetGroupInfogroupObj(string groupObj)
        {
            return BLL.bllGroupInfo.getSomeGroupInfo(groupObj).groupName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?huodongTypeObj=" + huodongTypeObj.SelectedValue.Trim()+ "&&title=" + title.Text.Trim()+ "&&startTime=" + startTime.Text.Trim()+ "&&endTime=" + endTime.Text.Trim() + "&&groupObj=" + groupObj.SelectedValue.Trim());
        }

}
