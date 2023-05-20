<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="GroupInfo_frontAdd" %>
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
<title>组织团体添加</title>
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
  			<li><a href="<%=basePath %>GroupInfo/frontList.aspx">组织团体管理</a></li>
  			<li class="active">添加组织团体</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="groupInfoAddForm" id="groupInfoAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
					 <label for="groupInfo_groupUserName" class="col-md-2 text-right">领队用户名:</label>
					 <div class="col-md-8"> 
					 	<input type="text" id="groupInfo_groupUserName" name="groupInfo.groupUserName" class="form-control" placeholder="请输入领队用户名">
					 </div>
				  </div> 
				  <div class="form-group">
				  	 <label for="groupInfo_password" class="col-md-2 text-right">登录密码:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="groupInfo_password" name="groupInfo.password" class="form-control" placeholder="请输入登录密码">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_groupName" class="col-md-2 text-right">团体名称:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="groupInfo_groupName" name="groupInfo.groupName" class="form-control" placeholder="请输入团体名称">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_leageName" class="col-md-2 text-right">领队姓名:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="groupInfo_leageName" name="groupInfo.leageName" class="form-control" placeholder="请输入领队姓名">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_groupPhoto" class="col-md-2 text-right">组织照片:</label>
				  	 <div class="col-md-8">
					    <img  class="img-responsive" id="groupInfo_groupPhotoImg" border="0px"/><br/>
					    <input type="hidden" id="groupInfo_groupPhoto" name="groupInfo.groupPhoto"/>
					    <input id="groupPhotoFile" name="groupPhotoFile" type="file" size="50" />
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_telephone" class="col-md-2 text-right">联系电话:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="groupInfo_telephone" name="groupInfo.telephone" class="form-control" placeholder="请输入联系电话">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_bornDateDiv" class="col-md-2 text-right">成立日期:</label>
				  	 <div class="col-md-8">
		                <div id="groupInfo_bornDateDiv" class="input-group date groupInfo_bornDate col-md-12" data-link-field="groupInfo_bornDate">
		                    <input class="form-control" id="groupInfo_bornDate" name="groupInfo.bornDate" size="16" type="text" value="" placeholder="请选择成立日期" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_endDateDiv" class="col-md-2 text-right">截止日期:</label>
				  	 <div class="col-md-8">
		                <div id="groupInfo_endDateDiv" class="input-group date groupInfo_endDate col-md-12" data-link-field="groupInfo_endDate">
		                    <input class="form-control" id="groupInfo_endDate" name="groupInfo.endDate" size="16" type="text" value="" placeholder="请选择截止日期" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="groupInfo_groupDesc" class="col-md-2 text-right">团队介绍:</label>
				  	 <div class="col-md-8">
					    <textarea id="groupInfo_groupDesc" name="groupInfo.groupDesc" rows="8" class="form-control" placeholder="请输入团队介绍"></textarea>
					 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxGroupInfoAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#groupInfoAddForm .form-group {margin:5px;}  </style>  
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
	//提交添加组织团体信息
	function ajaxGroupInfoAdd() { 
		//提交之前先验证表单
		$("#groupInfoAddForm").data('bootstrapValidator').validate();
		if(!$("#groupInfoAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "GroupInfo/GroupInfoController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#groupInfoAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#groupInfoAddForm").find("input").val("");
					$("#groupInfoAddForm").find("textarea").val("");
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
	//验证组织团体添加表单字段
	$('#groupInfoAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"groupInfo.groupUserName": {
				validators: {
					notEmpty: {
						message: "领队用户名不能为空",
					}
				}
			},
			"groupInfo.password": {
				validators: {
					notEmpty: {
						message: "登录密码不能为空",
					}
				}
			},
			"groupInfo.groupName": {
				validators: {
					notEmpty: {
						message: "团体名称不能为空",
					}
				}
			},
			"groupInfo.leageName": {
				validators: {
					notEmpty: {
						message: "领队姓名不能为空",
					}
				}
			},
			"groupInfo.telephone": {
				validators: {
					notEmpty: {
						message: "联系电话不能为空",
					}
				}
			},
			"groupInfo.bornDate": {
				validators: {
					notEmpty: {
						message: "成立日期不能为空",
					}
				}
			},
			"groupInfo.endDate": {
				validators: {
					notEmpty: {
						message: "截止日期不能为空",
					}
				}
			},
		}
	}); 
	//成立日期组件
	$('#groupInfo_bornDateDiv').datetimepicker({
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
		$('#groupInfoAddForm').data('bootstrapValidator').updateStatus('groupInfo.bornDate', 'NOT_VALIDATED',null).validateField('groupInfo.bornDate');
	});
	//截止日期组件
	$('#groupInfo_endDateDiv').datetimepicker({
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
		$('#groupInfoAddForm').data('bootstrapValidator').updateStatus('groupInfo.endDate', 'NOT_VALIDATED',null).validateField('groupInfo.endDate');
	});
})
</script>
</body>
</html>
