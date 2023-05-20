using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Notice_NoticeController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addNotice();
        if (action == "delete") deleteNotice();
        if (action == "update") updateNotice();
        if (action == "getNotice") getNotice();
        if (action == "listAll") listAll();
    }
    //处理添加新闻公告控制层方法
    protected void addNotice()
    {
        int success = 0;
        string message = "";
        ENTITY.Notice notice = new ENTITY.Notice();
        notice.title = Request["notice.title"];
        notice.content = Request["notice.content"];
        notice.publishDate = Convert.ToDateTime(Request["notice.publishDate"]);
        if (!BLL.bllNotice.AddNotice(notice))
        {
            message = "添加新闻公告发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除新闻公告控制层方法
    protected void deleteNotice()
    {
        int success = 0;
        string message = "";
        string noticeId = Request["noticeId"];
        try {
            BLL.bllNotice.DelNotice(noticeId);
            success = 1;
        } catch {
            message = "新闻公告删除失败";
        }
        writeResult(success, message);
    }

    //处理更新新闻公告控制层方法
    protected void updateNotice()
    {
        int success = 0;
        string message = "";
        ENTITY.Notice notice = new ENTITY.Notice();
        notice.noticeId = int.Parse(Request["Notice.noticeId"]);
        notice.title = Request["notice.title"];
        notice.content = Request["notice.content"];
        notice.publishDate = Convert.ToDateTime(Request["notice.publishDate"]);
        if (!BLL.bllNotice.EditNotice(notice))
        {
            message = "更新新闻公告发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个新闻公告对象，返回json格式
    protected void getNotice()
    {
        int noticeId = int.Parse(Request.QueryString["noticeId"]);
        ENTITY.Notice notice = BLL.bllNotice.getSomeNotice(noticeId);
        JSONObject jsonNotice = new JSONObject();
        jsonNotice.Put("noticeId", notice.noticeId);
        jsonNotice.Put("title", notice.title);
        jsonNotice.Put("content", notice.content);
        jsonNotice.Put("publishDate", notice.publishDate.ToShortDateString() + " " + notice.publishDate.ToLongTimeString());
        Response.Write(jsonNotice.ToString());
    }

    protected void listAll()
    {
        DataSet noticeDs = BLL.bllNotice.getAllNotice();
        JSONArray noticeArray = new JSONArray();
        for (int i = 0; i < noticeDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = noticeDs.Tables[0].Rows[i];
            JSONObject jsonNotice = new JSONObject();
            jsonNotice.Put("noticeId", Convert.ToInt32(dr["noticeId"]));
            jsonNotice.Put("title", dr["title"].ToString());
            noticeArray.Put(jsonNotice);
        }
        Response.Write(noticeArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

}
