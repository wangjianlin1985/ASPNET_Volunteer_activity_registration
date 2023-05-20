using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class GroupInfo_GroupInfoController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addGroupInfo();
        if (action == "delete") deleteGroupInfo();
        if (action == "update") updateGroupInfo();
        if (action == "getGroupInfo") getGroupInfo();
        if (action == "listAll") listAll();
    }
    //处理添加组织团体控制层方法
    protected void addGroupInfo()
    {
        int success = 0;
        string message = "";
        ENTITY.GroupInfo groupInfo = new ENTITY.GroupInfo();
        groupInfo.groupUserName = Request["groupInfo.groupUserName"];
        if (BLL.bllGroupInfo.getSomeGroupInfo(groupInfo.groupUserName) != null)
        {
            message = "该领队用户名已经存在！";
            writeResult(success, message);
            return;
        }
        groupInfo.password = Request["groupInfo.password"];
        groupInfo.groupName = Request["groupInfo.groupName"];
        groupInfo.leageName = Request["groupInfo.leageName"];
        try {
            groupInfo.groupPhoto = handleImageUpload("groupPhotoFile");
        } catch {
            message = "图片格式不正确！";
            writeResult(success, message);
            return;
        }
        groupInfo.telephone = Request["groupInfo.telephone"];
        groupInfo.bornDate = Convert.ToDateTime(Request["groupInfo.bornDate"]);
        groupInfo.endDate = Convert.ToDateTime(Request["groupInfo.endDate"]);
        groupInfo.groupDesc = Request["groupInfo.groupDesc"];
        if (!BLL.bllGroupInfo.AddGroupInfo(groupInfo))
        {
            message = "添加组织团体发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除组织团体控制层方法
    protected void deleteGroupInfo()
    {
        int success = 0;
        string message = "";
        string groupUserName = Request["groupUserName"];
        try {
            BLL.bllGroupInfo.DelGroupInfo(groupUserName);
            success = 1;
        } catch {
            message = "组织团体删除失败";
        }
        writeResult(success, message);
    }

    //处理更新组织团体控制层方法
    protected void updateGroupInfo()
    {
        int success = 0;
        string message = "";
        ENTITY.GroupInfo groupInfo = new ENTITY.GroupInfo();
        groupInfo.groupUserName = Request["GroupInfo.groupUserName"];
        groupInfo.password = Request["groupInfo.password"];
        groupInfo.groupName = Request["groupInfo.groupName"];
        groupInfo.leageName = Request["groupInfo.leageName"];
        groupInfo.groupPhoto = Request["groupInfo.groupPhoto"];
        string groupPhotoPath = handleImageUpload("groupPhotoFile");
        if (groupPhotoPath != "FileUpload/NoImage.jpg") groupInfo.groupPhoto = groupPhotoPath;
        groupInfo.telephone = Request["groupInfo.telephone"];
        groupInfo.bornDate = Convert.ToDateTime(Request["groupInfo.bornDate"]);
        groupInfo.endDate = Convert.ToDateTime(Request["groupInfo.endDate"]);
        groupInfo.groupDesc = Request["groupInfo.groupDesc"];
        if (!BLL.bllGroupInfo.EditGroupInfo(groupInfo))
        {
            message = "更新组织团体发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个组织团体对象，返回json格式
    protected void getGroupInfo()
    {
        String groupUserName = Request.QueryString["groupUserName"];
        ENTITY.GroupInfo groupInfo = BLL.bllGroupInfo.getSomeGroupInfo(groupUserName);
        JSONObject jsonGroupInfo = new JSONObject();
        jsonGroupInfo.Put("groupUserName", groupInfo.groupUserName);
        jsonGroupInfo.Put("password", groupInfo.password);
        jsonGroupInfo.Put("groupName", groupInfo.groupName);
        jsonGroupInfo.Put("leageName", groupInfo.leageName);
        jsonGroupInfo.Put("groupPhoto", groupInfo.groupPhoto);
        jsonGroupInfo.Put("telephone", groupInfo.telephone);
        jsonGroupInfo.Put("bornDate", groupInfo.bornDate.ToShortDateString() + " " + groupInfo.bornDate.ToLongTimeString());
        jsonGroupInfo.Put("endDate", groupInfo.endDate.ToShortDateString() + " " + groupInfo.endDate.ToLongTimeString());
        jsonGroupInfo.Put("groupDesc", groupInfo.groupDesc);
        Response.Write(jsonGroupInfo.ToString());
    }

    protected void listAll()
    {
        DataSet groupInfoDs = BLL.bllGroupInfo.getAllGroupInfo();
        JSONArray groupInfoArray = new JSONArray();
        for (int i = 0; i < groupInfoDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = groupInfoDs.Tables[0].Rows[i];
            JSONObject jsonGroupInfo = new JSONObject();
            jsonGroupInfo.Put("groupUserName", dr["groupUserName"].ToString());
            jsonGroupInfo.Put("groupName", dr["groupName"].ToString());
            groupInfoArray.Put(jsonGroupInfo);
        }
        Response.Write(groupInfoArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

    //处理图片文件上传
    protected string handleImageUpload(string fileKeyName)
    {
        string imagePath = "FileUpload/NoImage.jpg";
        HttpPostedFile photoFile = Request.Files[fileKeyName];
        if (photoFile.ContentLength > 0)
        { 
            //获取文件的扩展名
            string fileExt = Path.GetExtension(photoFile.FileName);
            List<string> ExtList = new List<string>(new string[] { ".jpg", ".gif" });
            if (!ExtList.Contains(fileExt))
            {
                throw new Exception("图片格式不正确！");
            }
            string saveFileName = DAL.Function.MakeFileName(fileExt);
            imagePath = "FileUpload/" + saveFileName;/*图片路径*/
            photoFile.SaveAs(Server.MapPath("../" + imagePath));
        }
        return imagePath;
    }

}
