<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="Member_frontModify" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>修改团员信息</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-9 wow fadeInLeft">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li class="active">团员信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="memberEditForm" id="memberEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="member_memberId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="member_memberId_edit" name="member.memberId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="member_groupObj_groupUserName_edit" class="col-md-3 text-right">申请团体:</label>
		  	 <div class="col-md-9">
			    <select id="member_groupObj_groupUserName_edit" name="member.groupObj.groupUserName" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="member_userObj_user_name_edit" class="col-md-3 text-right">申请用户:</label>
		  	 <div class="col-md-9">
			    <select id="member_userObj_user_name_edit" name="member.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="member_addTime_edit" class="col-md-3 text-right">申请时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date member_addTime_edit col-md-12" data-link-field="member_addTime_edit">
                    <input class="form-control" id="member_addTime_edit" name="member.addTime" size="16" type="text" value="" placeholder="请选择申请时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="member_shenHeState_edit" class="col-md-3 text-right">审核状态:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="member_shenHeState_edit" name="member.shenHeState" class="form-control" placeholder="请输入审核状态">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="member_memberMemo_edit" class="col-md-3 text-right">备注信息:</label>
		  	 <div class="col-md-9">
			    <textarea id="member_memberMemo_edit" name="member.memberMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxMemberModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#memberEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
   </div>
</div>


<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改团员界面并初始化数据*/
function memberEdit(memberId) {
	$.ajax({
		url :  basePath + "Member/MemberController.aspx?action=getMember&memberId=" + memberId,
		type : "get",
		dataType: "json",
		success : function (member, response, status) {
			if (member) {
				$("#member_memberId_edit").val(member.memberId);
				$.ajax({
					url: basePath + "GroupInfo/GroupInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(groupInfos,response,status) { 
						$("#member_groupObj_groupUserName_edit").empty();
						var html="";
		        		$(groupInfos).each(function(i,groupInfo){
		        			html += "<option value='" + groupInfo.groupUserName + "'>" + groupInfo.groupName + "</option>";
		        		});
		        		$("#member_groupObj_groupUserName_edit").html(html);
		        		$("#member_groupObj_groupUserName_edit").val(member.groupObjPri);
					}
				});
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#member_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#member_userObj_user_name_edit").html(html);
		        		$("#member_userObj_user_name_edit").val(member.userObjPri);
					}
				});
				$("#member_addTime_edit").val(member.addTime);
				$("#member_shenHeState_edit").val(member.shenHeState);
				$("#member_memberMemo_edit").val(member.memberMemo);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交团员信息表单给服务器端修改*/
function ajaxMemberModify() {
	$.ajax({
		url :  basePath + "Member/MemberController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#memberEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                location.reload(true);
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
        /*小屏幕导航点击关闭菜单*/
        $('.navbar-collapse a').click(function(){
            $('.navbar-collapse').collapse('hide');
        });
        new WOW().init();
    /*申请时间组件*/
    $('.member_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
    memberEdit('<%=Request["memberId"] %>');
 })
 </script> 
</body>
</html>

