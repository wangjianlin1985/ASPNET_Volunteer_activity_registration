using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Member_MemberController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addMember();
        if (action == "userAdd") userAddMember();
        if (action == "delete") deleteMember();
        if (action == "update") updateMember();
        if (action == "getMember") getMember();
        if (action == "listAll") listAll();
    }
    //处理添加团员控制层方法
    protected void addMember()
    {
        int success = 0;
        string message = "";
        ENTITY.Member member = new ENTITY.Member();
        member.groupObj = Request["member.groupObj.groupUserName"];
        member.userObj = Request["member.userObj.user_name"];
        member.addTime = Convert.ToDateTime(Request["member.addTime"]);
        member.shenHeState = Request["member.shenHeState"];
        member.memberMemo = Request["member.memberMemo"];
        if (!BLL.bllMember.AddMember(member))
        {
            message = "添加团员发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理添加团员控制层方法
    protected void userAddMember()
    {
        int success = 0;
        string message = "";
        ENTITY.Member member = new ENTITY.Member();

        if (Session["user_name"] == null)
        {
            message = "请先登录网站!";
            writeResult(success, message);
            return;
        }


        member.groupObj = Request["member.groupObj.groupUserName"];
        member.userObj = Session["user_name"].ToString() ;
        member.addTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
        member.shenHeState = "待审核";
        member.memberMemo = "--";

        System.Data.DataSet ds = BLL.bllMember.GetMember(" where groupObj='" + member.groupObj + "' and userObj='" + member.userObj + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            message = "已经提交过申请记录!";
            writeResult(success, message);
            return;
        }


        if (!BLL.bllMember.AddMember(member))
        {
            message = "添加团员发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }


    //处理删除团员控制层方法
    protected void deleteMember()
    {
        int success = 0;
        string message = "";
        string memberId = Request["memberId"];
        try {
            BLL.bllMember.DelMember(memberId);
            success = 1;
        } catch {
            message = "团员删除失败";
        }
        writeResult(success, message);
    }

    //处理更新团员控制层方法
    protected void updateMember()
    {
        int success = 0;
        string message = "";
        ENTITY.Member member = new ENTITY.Member();
        member.memberId = int.Parse(Request["Member.memberId"]);
        member.groupObj = Request["member.groupObj.groupUserName"];
        member.userObj = Request["member.userObj.user_name"];
        member.addTime = Convert.ToDateTime(Request["member.addTime"]);
        member.shenHeState = Request["member.shenHeState"];
        member.memberMemo = Request["member.memberMemo"];
        if (!BLL.bllMember.EditMember(member))
        {
            message = "更新团员发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个团员对象，返回json格式
    protected void getMember()
    {
        int memberId = int.Parse(Request.QueryString["memberId"]);
        ENTITY.Member member = BLL.bllMember.getSomeMember(memberId);
        JSONObject jsonMember = new JSONObject();
        jsonMember.Put("memberId", member.memberId);
        jsonMember.Put("groupObj", BLL.bllGroupInfo.getSomeGroupInfo(member.groupObj).groupName);
        jsonMember.Put("groupObjPri", member.groupObj);
        jsonMember.Put("userObj", BLL.bllUserInfo.getSomeUserInfo(member.userObj).name);
        jsonMember.Put("userObjPri", member.userObj);
        jsonMember.Put("addTime", member.addTime.ToShortDateString() + " " + member.addTime.ToLongTimeString());
        jsonMember.Put("shenHeState", member.shenHeState);
        jsonMember.Put("memberMemo", member.memberMemo);
        Response.Write(jsonMember.ToString());
    }

    protected void listAll()
    {
        DataSet memberDs = BLL.bllMember.getAllMember();
        JSONArray memberArray = new JSONArray();
        for (int i = 0; i < memberDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = memberDs.Tables[0].Rows[i];
            JSONObject jsonMember = new JSONObject();
            jsonMember.Put("memberId", Convert.ToInt32(dr["memberId"]));
            jsonMember.Put("memberId", Convert.ToInt32(dr["memberId"]));
            memberArray.Put(jsonMember);
        }
        Response.Write(memberArray.ToString());
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
