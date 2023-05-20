<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="GroupInfo_frontModify" %>
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
  <TITLE>修改组织团体信息</TITLE>
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
  		<li class="active">组织团体信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="groupInfoEditForm" id="groupInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="groupInfo_groupUserName_edit" class="col-md-3 text-right">领队用户名:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="groupInfo_groupUserName_edit" name="groupInfo.groupUserName" class="form-control" placeholder="请输入领队用户名" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="groupInfo_password_edit" class="col-md-3 text-right">登录密码:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="groupInfo_password_edit" name="groupInfo.password" class="form-control" placeholder="请输入登录密码">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_groupName_edit" class="col-md-3 text-right">团体名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="groupInfo_groupName_edit" name="groupInfo.groupName" class="form-control" placeholder="请输入团体名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_leageName_edit" class="col-md-3 text-right">领队姓名:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="groupInfo_leageName_edit" name="groupInfo.leageName" class="form-control" placeholder="请输入领队姓名">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_groupPhoto_edit" class="col-md-3 text-right">组织照片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="groupInfo_groupPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="groupInfo_groupPhoto" name="groupInfo.groupPhoto"/>
			    <input id="groupPhotoFile" name="groupPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_telephone_edit" class="col-md-3 text-right">联系电话:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="groupInfo_telephone_edit" name="groupInfo.telephone" class="form-control" placeholder="请输入联系电话">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_bornDate_edit" class="col-md-3 text-right">成立日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date groupInfo_bornDate_edit col-md-12" data-link-field="groupInfo_bornDate_edit">
                    <input class="form-control" id="groupInfo_bornDate_edit" name="groupInfo.bornDate" size="16" type="text" value="" placeholder="请选择成立日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_endDate_edit" class="col-md-3 text-right">截止日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date groupInfo_endDate_edit col-md-12" data-link-field="groupInfo_endDate_edit">
                    <input class="form-control" id="groupInfo_endDate_edit" name="groupInfo.endDate" size="16" type="text" value="" placeholder="请选择截止日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="groupInfo_groupDesc_edit" class="col-md-3 text-right">团队介绍:</label>
		  	 <div class="col-md-9">
			    <script name="groupInfo.groupDesc" id="groupInfo_groupDesc_edit" type="text/plain"   style="width:100%;height:500px;"></script>
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxGroupInfoModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#groupInfoEditForm .form-group {margin-bottom:5px;}  </style>
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
/*弹出修改组织团体界面并初始化数据*/
function groupInfoEdit(groupUserName) {
	$.ajax({
		url :  basePath + "GroupInfo/GroupInfoController.aspx?action=getGroupInfo&groupUserName=" + groupUserName,
		type : "get",
		dataType: "json",
		success : function (groupInfo, response, status) {
			if (groupInfo) {
				$("#groupInfo_groupUserName_edit").val(groupInfo.groupUserName);
				$("#groupInfo_password_edit").val(groupInfo.password);
				$("#groupInfo_groupName_edit").val(groupInfo.groupName);
				$("#groupInfo_leageName_edit").val(groupInfo.leageName);
				$("#groupInfo_groupPhoto").val(groupInfo.groupPhoto);
				$("#groupInfo_groupPhotoImg").attr("src", basePath +　groupInfo.groupPhoto);
				$("#groupInfo_telephone_edit").val(groupInfo.telephone);
				$("#groupInfo_bornDate_edit").val(groupInfo.bornDate);
				$("#groupInfo_endDate_edit").val(groupInfo.endDate);
				$("#groupInfo_groupDesc_edit").val(groupInfo.groupDesc);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交组织团体信息表单给服务器端修改*/
function ajaxGroupInfoModify() {
	$.ajax({
		url :  basePath + "GroupInfo/GroupInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#groupInfoEditForm")[0]),
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
    /*成立日期组件*/
    $('.groupInfo_bornDate_edit').datetimepicker({
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
    /*截止日期组件*/
    $('.groupInfo_endDate_edit').datetimepicker({
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
    groupInfoEdit('<%=Request["groupUserName"] %>');
 })
 </script> 
</body>
</html>

