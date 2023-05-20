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
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
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

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"HuodongGroupEdit.aspx?huodongId=" + Request["huodongId"] + "\"} else  {location.href=\"HuodongGroupList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                huodong.groupObj = Session["Customername"].ToString();
                if (BLL.bllHuodong.AddHuodong(huodong))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"HuodongGroupEdit.aspx\"} else  {location.href=\"HuodongGroupList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HuodongGroupList.aspx");
        }
        protected void Btn_HuodongPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.HuodongPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.HuodongPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.huodongPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.HuodongPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.HuodongPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.HuodongPhotoImage.ImageUrl = "../" + imagePath;
                    this.huodongPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

