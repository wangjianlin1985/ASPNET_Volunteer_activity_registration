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
    public partial class HuodongEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindHuodongTypehuodongTypeObj();
                BindGroupInfogroupObj();
                /*进入本信息添加页显示无图的图片*/
                this.HuodongPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["huodongId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindHuodongTypehuodongTypeObj()
        {
            huodongTypeObj.DataSource = BLL.bllHuodongType.getAllHuodongType();
            huodongTypeObj.DataTextField = "typeName";
            huodongTypeObj.DataValueField = "typeId";
            huodongTypeObj.DataBind();
        }

        private void BindGroupInfogroupObj()
        {
            groupObj.DataSource = BLL.bllGroupInfo.getAllGroupInfo();
            groupObj.DataTextField = "groupName";
            groupObj.DataValueField = "groupUserName";
            groupObj.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "huodongId")))
            {
                ENTITY.Huodong huodong = BLL.bllHuodong.getSomeHuodong(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "huodongId")));
                huodongTypeObj.SelectedValue = huodong.huodongTypeObj.ToString();
                title.Value = huodong.title;
                huodongPhoto.Text = huodong.huodongPhoto;
                if (huodong.huodongPhoto != "") this.HuodongPhotoImage.ImageUrl = "../" + huodong.huodongPhoto;
                huodongDesc.Value = huodong.huodongDesc;
                startTime.Text = huodong.startTime.ToShortDateString() + " " + huodong.startTime.ToLongTimeString();
                endTime.Text = huodong.endTime.ToShortDateString() + " " + huodong.endTime.ToLongTimeString();
                jifen.Value = huodong.jifen.ToString("0.00");
                groupObj.SelectedValue = huodong.groupObj;
            }
        }

        protected void BtnHuodongSave_Click(object sender, EventArgs e)
        {
            ENTITY.Huodong huodong = new ENTITY.Huodong();
            huodong.huodongTypeObj = int.Parse(huodongTypeObj.SelectedValue);
            huodong.title = title.Value;
            if (huodongPhoto.Text == "") huodongPhoto.Text = "FileUpload/NoImage.jpg";
            huodong.huodongPhoto = huodongPhoto.Text;
            huodong.huodongDesc = huodongDesc.Value;
            huodong.startTime = Convert.ToDateTime(startTime.Text);
            huodong.endTime = Convert.ToDateTime(endTime.Text);
            huodong.jifen = float.Parse(float.Parse(jifen.Value).ToString("0.00"));
            huodong.groupObj = groupObj.SelectedValue;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "huodongId")))
            {
                huodong.huodongId = int.Parse(Request["huodongId"]);
                if (BLL.bllHuodong.EditHuodong(huodong))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"HuodongGroupEdit.aspx?huodongId=" + Request["huodongId"] + "\"} else  {location.href=\"HuodongGroupList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                huodong.groupObj = Session["Customername"].ToString();
                if (BLL.bllHuodong.AddHuodong(huodong))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"HuodongGroupEdit.aspx\"} else  {location.href=\"HuodongGroupList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HuodongGroupList.aspx");
        }
        protected void Btn_HuodongPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.HuodongPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.HuodongPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.huodongPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.HuodongPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.HuodongPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.HuodongPhotoImage.ImageUrl = "../" + imagePath;
                    this.huodongPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

