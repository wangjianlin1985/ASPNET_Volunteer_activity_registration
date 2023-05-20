<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="GroupInfo_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.GroupInfo groupInfo = BLL.bllGroupInfo.getSomeGroupInfo(Request.QueryString["groupUserName"]);
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看组织团体详情</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<uc:header ID="header" runat="server" />
<div class="container">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li><a href="<%=basePath %>GroupInfo/frontList.aspx">组织团体信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">领队用户名:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.groupUserName%></div>
	</div>
	 
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">团体名称:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.groupName%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">领队姓名:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.leageName%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">组织照片:</div>
		<div class="col-md-10 col-xs-6"><img class="img-responsive" src="<%=basePath %><%=groupInfo.groupPhoto %>"  border="0px"/></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">联系电话:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.telephone%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">成立日期:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.bornDate%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">截止日期:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.endDate%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">团队介绍:</div>
		<div class="col-md-10 col-xs-6"><%=groupInfo.groupDesc%></div>
	</div>
	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
            <button onclick="addGroup();" class="btn btn-primary">加入团体</button>
			<button onclick="history.back();" class="btn btn-primary">返回</button>
		</div>
	</div>
</div> 
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script>
    var basePath = "<%=basePath%>";


function addGroup() { 

	$.ajax({
		url : basePath + "Member/MemberController.aspx?action=userAdd",
		type : "post",
		dataType: "json",
		data: {
			"member.groupObj.groupUserName": '<%=groupInfo.groupUserName %>', 
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("申请入团提交成功~");
				location.reload();
			}else{
				alert(data.message);
			}
		}
	});
}


$(function(){
        /*小屏幕导航点击关闭菜单*/
        $('.navbar-collapse a').click(function(){
            $('.navbar-collapse').collapse('hide');
        });
        new WOW().init();
 })
 </script> 
</body>
</html>

