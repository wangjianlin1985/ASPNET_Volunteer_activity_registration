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
    public partial class GroupInfoEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*进入本信息添加页显示无图的图片*/
                this.GroupPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["groupUserName"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "groupUserName")))
            {
                ENTITY.GroupInfo groupInfo = BLL.bllGroupInfo.getSomeGroupInfo(Common.GetMes.GetRequestQuery(Request, "groupUserName"));
                groupUserName.Value = groupInfo.groupUserName;
                password.Value = groupInfo.password;
                groupName.Value = groupInfo.groupName;
                leageName.Value = groupInfo.leageName;
                groupPhoto.Text = groupInfo.groupPhoto;
                if (groupInfo.groupPhoto != "") this.GroupPhotoImage.ImageUrl = "../" + groupInfo.groupPhoto;
                telephone.Value = groupInfo.telephone;
                bornDate.Text = groupInfo.bornDate.ToShortDateString() + " " + groupInfo.bornDate.ToLongTimeString();
                endDate.Text = groupInfo.endDate.ToShortDateString() + " " + groupInfo.endDate.ToLongTimeString();
                groupDesc.Value = groupInfo.groupDesc;
            }
        }

        protected void BtnGroupInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.GroupInfo groupInfo = new ENTITY.GroupInfo();
            groupInfo.groupUserName = this.groupUserName.Value;
            groupInfo.password = password.Value;
            groupInfo.groupName = groupName.Value;
            groupInfo.leageName = leageName.Value;
            if (groupPhoto.Text == "") groupPhoto.Text = "FileUpload/NoImage.jpg";
            groupInfo.groupPhoto = groupPhoto.Text;
            groupInfo.telephone = telephone.Value;
            groupInfo.bornDate = Convert.ToDateTime(bornDate.Text);
            groupInfo.endDate = Convert.ToDateTime(endDate.Text);
            groupInfo.groupDesc = groupDesc.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "groupUserName")))
            {
                groupInfo.groupUserName = Request["groupUserName"];
                if (BLL.bllGroupInfo.EditGroupInfo(groupInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"GroupInfoEdit.aspx?groupUserName=" + Request["groupUserName"] + "\"} else  {location.href=\"GroupInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllGroupInfo.AddGroupInfo(groupInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"GroupInfoEdit.aspx\"} else  {location.href=\"GroupInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroupInfoList.aspx");
        }
        protected void Btn_GroupPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.GroupPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.GroupPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.groupPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.GroupPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.GroupPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.GroupPhotoImage.ImageUrl = "../" + imagePath;
                    this.groupPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

