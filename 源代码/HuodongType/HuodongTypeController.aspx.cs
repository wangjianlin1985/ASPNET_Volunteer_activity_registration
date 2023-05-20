using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class HuodongType_HuodongTypeController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addHuodongType();
        if (action == "delete") deleteHuodongType();
        if (action == "update") updateHuodongType();
        if (action == "getHuodongType") getHuodongType();
        if (action == "listAll") listAll();
    }
    //处理添加活动类型控制层方法
    protected void addHuodongType()
    {
        int success = 0;
        string message = "";
        ENTITY.HuodongType huodongType = new ENTITY.HuodongType();
        huodongType.typeName = Request["huodongType.typeName"];
        if (!BLL.bllHuodongType.AddHuodongType(huodongType))
        {
            message = "添加活动类型发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除活动类型控制层方法
    protected void deleteHuodongType()
    {
        int success = 0;
        string message = "";
        string typeId = Request["typeId"];
        try {
            BLL.bllHuodongType.DelHuodongType(typeId);
            success = 1;
        } catch {
            message = "活动类型删除失败";
        }
        writeResult(success, message);
    }

    //处理更新活动类型控制层方法
    protected void updateHuodongType()
    {
        int success = 0;
        string message = "";
        ENTITY.HuodongType huodongType = new ENTITY.HuodongType();
        huodongType.typeId = int.Parse(Request["HuodongType.typeId"]);
        huodongType.typeName = Request["huodongType.typeName"];
        if (!BLL.bllHuodongType.EditHuodongType(huodongType))
        {
            message = "更新活动类型发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个活动类型对象，返回json格式
    protected void getHuodongType()
    {
        int typeId = int.Parse(Request.QueryString["typeId"]);
        ENTITY.HuodongType huodongType = BLL.bllHuodongType.getSomeHuodongType(typeId);
        JSONObject jsonHuodongType = new JSONObject();
        jsonHuodongType.Put("typeId", huodongType.typeId);
        jsonHuodongType.Put("typeName", huodongType.typeName);
        Response.Write(jsonHuodongType.ToString());
    }

    protected void listAll()
    {
        DataSet huodongTypeDs = BLL.bllHuodongType.getAllHuodongType();
        JSONArray huodongTypeArray = new JSONArray();
        for (int i = 0; i < huodongTypeDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = huodongTypeDs.Tables[0].Rows[i];
            JSONObject jsonHuodongType = new JSONObject();
            jsonHuodongType.Put("typeId", Convert.ToInt32(dr["typeId"]));
            jsonHuodongType.Put("typeName", dr["typeName"].ToString());
            huodongTypeArray.Put(jsonHuodongType);
        }
        Response.Write(huodongTypeArray.ToString());
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
