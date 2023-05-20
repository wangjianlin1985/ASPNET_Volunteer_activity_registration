<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="Huodong_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.Huodong huodong = BLL.bllHuodong.getSomeHuodong(int.Parse(Request.QueryString["huodongId"]));
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看活动详情</TITLE>
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
  		<li><a href="<%=basePath %>Huodong/frontList.aspx">活动信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">活动id:</div>
		<div class="col-md-10 col-xs-6"><%=huodong.huodongId%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">活动类型:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllHuodongType.getSomeHuodongType(huodong.huodongTypeObj).typeName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">活动名称:</div>
		<div class="col-md-10 col-xs-6"><%=huodong.title%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">活动图片:</div>
		<div class="col-md-10 col-xs-6"><img class="img-responsive" src="<%=basePath %><%=huodong.huodongPhoto %>"  border="0px"/></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">活动简介:</div>
		<div class="col-md-10 col-xs-6"><%=huodong.huodongDesc%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">开始时间:</div>
		<div class="col-md-10 col-xs-6"><%=huodong.startTime%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">结束时间:</div>
		<div class="col-md-10 col-xs-6"><%=huodong.endTime%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">活动积分:</div>
		<div class="col-md-10 col-xs-6"><%=huodong.jifen%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布组织:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllGroupInfo.getSomeGroupInfo(huodong.groupObj).groupName %></div>
	</div>
	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
            <button onclick="signUp();" class="btn btn-primary">我要报名</button>
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

function signUp() { 

	$.ajax({
		url : basePath + "SignUp/SignUpController.aspx?action=userAdd",
		type : "post",
		dataType: "json",
		data: {
			"signUp.huodongObj.huodongId": '<%=huodong.huodongId %>', 
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("活动报名提交成功~");
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

