<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="Member_frontAdd" %>
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
<title>团员添加</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-12 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="<%=basePath %>index.aspx">首页</a></li>
  			<li><a href="<%=basePath %>Member/frontList.aspx">团员管理</a></li>
  			<li class="active">添加团员</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="memberAddForm" id="memberAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="member_groupObj_groupUserName" class="col-md-2 text-right">申请团体:</label>
				  	 <div class="col-md-8">
					    <select id="member_groupObj_groupUserName" name="member.groupObj.groupUserName" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="member_userObj_user_name" class="col-md-2 text-right">申请用户:</label>
				  	 <div class="col-md-8">
					    <select id="member_userObj_user_name" name="member.userObj.user_name" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="member_addTimeDiv" class="col-md-2 text-right">申请时间:</label>
				  	 <div class="col-md-8">
		                <div id="member_addTimeDiv" class="input-group date member_addTime col-md-12" data-link-field="member_addTime">
		                    <input class="form-control" id="member_addTime" name="member.addTime" size="16" type="text" value="" placeholder="请选择申请时间" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="member_shenHeState" class="col-md-2 text-right">审核状态:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="member_shenHeState" name="member.shenHeState" class="form-control" placeholder="请输入审核状态">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="member_memberMemo" class="col-md-2 text-right">备注信息:</label>
				  	 <div class="col-md-8">
					    <textarea id="member_memberMemo" name="member.memberMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
					 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxMemberAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#memberAddForm .form-group {margin:5px;}  </style>  
				</form> 
			</div>
			<div class="col-md-2"></div> 
	    </div>
	</div>
</div>
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrapvalidator/js/bootstrapValidator.min.js"></script>
<script type="text/javascript" src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
<script>
var basePath = "<%=basePath%>";
	//提交添加团员信息
	function ajaxMemberAdd() { 
		//提交之前先验证表单
		$("#memberAddForm").data('bootstrapValidator').validate();
		if(!$("#memberAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "Member/MemberController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#memberAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#memberAddForm").find("input").val("");
					$("#memberAddForm").find("textarea").val("");
				} else {
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
	//验证团员添加表单字段
	$('#memberAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"member.addTime": {
				validators: {
					notEmpty: {
						message: "申请时间不能为空",
					}
				}
			},
			"member.shenHeState": {
				validators: {
					notEmpty: {
						message: "审核状态不能为空",
					}
				}
			},
		}
	}); 
	//初始化申请团体下拉框值 
	$.ajax({
		url: basePath + "GroupInfo/GroupInfoController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(groupInfos,response,status) { 
			$("#member_groupObj_groupUserName").empty();
			var html="";
    		$(groupInfos).each(function(i,groupInfo){
    			html += "<option value='" + groupInfo.groupUserName + "'>" + groupInfo.groupName + "</option>";
    		});
    		$("#member_groupObj_groupUserName").html(html);
    	}
	});
	//初始化申请用户下拉框值 
	$.ajax({
		url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(userInfos,response,status) { 
			$("#member_userObj_user_name").empty();
			var html="";
    		$(userInfos).each(function(i,userInfo){
    			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
    		});
    		$("#member_userObj_user_name").html(html);
    	}
	});
	//申请时间组件
	$('#member_addTimeDiv').datetimepicker({
		language:  'zh-CN',  //显示语言
		format: 'yyyy-mm-dd hh:ii:ss',
		weekStart: 1,
		todayBtn:  1,
		autoclose: 1,
		minuteStep: 1,
		todayHighlight: 1,
		startView: 2,
		forceParse: 0
	}).on('hide',function(e) {
		//下面这行代码解决日期组件改变日期后不验证的问题
		$('#memberAddForm').data('bootstrapValidator').updateStatus('member.addTime', 'NOT_VALIDATED',null).validateField('member.addTime');
	});
})
</script>
</body>
</html>
