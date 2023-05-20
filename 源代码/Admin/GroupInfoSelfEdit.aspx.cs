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
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.GroupPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                 
                 LoadData();
                
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
             
                ENTITY.GroupInfo groupInfo = BLL.bllGroupInfo.getSomeGroupInfo(Session["Customername"].ToString());
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

            groupInfo.groupUserName = Session["Customername"].ToString();
            if (BLL.bllGroupInfo.EditGroupInfo(groupInfo))
            {
                Common.ShowMessage.myScriptMes(Page, "Suess", "alert('�޸ĳɹ�');");
            }
            else
            {
                Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("GroupInfoList.aspx");
        }
        protected void Btn_GroupPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.GroupPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.GroupPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.groupPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.GroupPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.GroupPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.GroupPhotoImage.ImageUrl = "../" + imagePath;
                    this.groupPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

