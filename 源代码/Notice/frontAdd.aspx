<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="Notice_frontAdd" %>
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
<title>新闻公告添加</title>
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
  			<li><a href="<%=basePath %>Notice/frontList.aspx">新闻公告管理</a></li>
  			<li class="active">添加新闻公告</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="noticeAddForm" id="noticeAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="notice_title" class="col-md-2 text-right">标题:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="notice_title" name="notice.title" class="form-control" placeholder="请输入标题">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="notice_content" class="col-md-2 text-right">公告内容:</label>
				  	 <div class="col-md-8">
					    <textarea id="notice_content" name="notice.content" rows="8" class="form-control" placeholder="请输入公告内容"></textarea>
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="notice_publishDateDiv" class="col-md-2 text-right">发布时间:</label>
				  	 <div class="col-md-8">
		                <div id="notice_publishDateDiv" class="input-group date notice_publishDate col-md-12" data-link-field="notice_publishDate">
		                    <input class="form-control" id="notice_publishDate" name="notice.publishDate" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxNoticeAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#noticeAddForm .form-group {margin:5px;}  </style>  
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
	//提交添加新闻公告信息
	function ajaxNoticeAdd() { 
		//提交之前先验证表单
		$("#noticeAddForm").data('bootstrapValidator').validate();
		if(!$("#noticeAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "Notice/NoticeController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#noticeAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#noticeAddForm").find("input").val("");
					$("#noticeAddForm").find("textarea").val("");
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
	//验证新闻公告添加表单字段
	$('#noticeAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"notice.title": {
				validators: {
					notEmpty: {
						message: "标题不能为空",
					}
				}
			},
			"notice.publishDate": {
				validators: {
					notEmpty: {
						message: "发布时间不能为空",
					}
				}
			},
		}
	}); 
	//发布时间组件
	$('#notice_publishDateDiv').datetimepicker({
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
		$('#noticeAddForm').data('bootstrapValidator').updateStatus('notice.publishDate', 'NOT_VALIDATED',null).validateField('notice.publishDate');
	});
})
</script>
</body>
</html>
