<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="Notice_frontModify" %>
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
  <TITLE>修改新闻公告信息</TITLE>
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
  		<li class="active">新闻公告信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="noticeEditForm" id="noticeEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="notice_noticeId_edit" class="col-md-3 text-right">公告id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="notice_noticeId_edit" name="notice.noticeId" class="form-control" placeholder="请输入公告id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="notice_title_edit" class="col-md-3 text-right">标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="notice_title_edit" name="notice.title" class="form-control" placeholder="请输入标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="notice_content_edit" class="col-md-3 text-right">公告内容:</label>
		  	 <div class="col-md-9">
			    <script name="notice.content" id="notice_content_edit" type="text/plain"   style="width:100%;height:500px;"></script>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="notice_publishDate_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date notice_publishDate_edit col-md-12" data-link-field="notice_publishDate_edit">
                    <input class="form-control" id="notice_publishDate_edit" name="notice.publishDate" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxNoticeModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#noticeEditForm .form-group {margin-bottom:5px;}  </style>
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
/*弹出修改新闻公告界面并初始化数据*/
function noticeEdit(noticeId) {
	$.ajax({
		url :  basePath + "Notice/NoticeController.aspx?action=getNotice&noticeId=" + noticeId,
		type : "get",
		dataType: "json",
		success : function (notice, response, status) {
			if (notice) {
				$("#notice_noticeId_edit").val(notice.noticeId);
				$("#notice_title_edit").val(notice.title);
				$("#notice_content_edit").val(notice.content);
				$("#notice_publishDate_edit").val(notice.publishDate);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交新闻公告信息表单给服务器端修改*/
function ajaxNoticeModify() {
	$.ajax({
		url :  basePath + "Notice/NoticeController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#noticeEditForm")[0]),
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
    /*发布时间组件*/
    $('.notice_publishDate_edit').datetimepicker({
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
    noticeEdit('<%=Request["noticeId"] %>');
 })
 </script> 
</body>
</html>

