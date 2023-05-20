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
    public partial class HuodongList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
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
            ListItem li = new ListItem("������", "0");
            huodongTypeObj.Items.Add(li);
            DataSet huodongTypeObjDs = BLL.bllHuodongType.getAllHuodongType();
            for (int i = 0; i < huodongTypeObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = huodongTypeObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["typeName"].ToString(), dr["typeName"].ToString());
                huodongTypeObj.Items.Add(li);
            }
            huodongTypeObj.SelectedValue = "0";
        }

        private void BindgroupObj()
        {
            ListItem li = new ListItem("������", "");
            groupObj.Items.Add(li);
            DataSet groupObjDs = BLL.bllGroupInfo.getAllGroupInfo();
            for (int i = 0; i < groupObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = groupObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["groupName"].ToString(), dr["groupName"].ToString());
                groupObj.Items.Add(li);
            }
            groupObj.SelectedValue = "";
        }

        protected void BtnHuodongAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("HuodongEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllHuodong.DelHuodong(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "HuodongList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
                }
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
        protected void RpHuodong_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllHuodong.DelHuodong((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "HuodongList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "HuodongList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "HuodongList.aspx");
                }
            }
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
            Response.Redirect("HuodongList.aspx?huodongTypeObj=" + huodongTypeObj.SelectedValue.Trim()+ "&&title=" + title.Text.Trim()+ "&&startTime=" + startTime.Text.Trim()+ "&&endTime=" + endTime.Text.Trim() + "&&groupObj=" + groupObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet huodongDataSet = BLL.bllHuodong.GetHuodong(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='8'>���¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>�id</th>");
            sb.Append("<th>�����</th>");
            sb.Append("<th>�����</th>");
            sb.Append("<th>�ͼƬ</th>");
            sb.Append("<th>��ʼʱ��</th>");
            sb.Append("<th>����ʱ��</th>");
            sb.Append("<th>�����</th>");
            sb.Append("<th>������֯</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < huodongDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = huodongDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["huodongId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllHuodongType.getSomeHuodongType(Convert.ToInt32(dr["huodongTypeObj"])).typeName + "</td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["huodongPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["startTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["endTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["jifen"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllGroupInfo.getSomeGroupInfo(dr["groupObj"].ToString()).groupName + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "���¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
