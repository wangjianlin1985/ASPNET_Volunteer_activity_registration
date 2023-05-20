<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Huodong_frontList" %>
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
<title>活动查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">活动信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加活动</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpHuodong" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?huodongId=<%#Eval("huodongId")%>"><img class="img-responsive" src="../<%#Eval("huodongPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		活动id: <%#Eval("huodongId")%>
			     	</div>
			     	<div class="field">
	            		活动类型:<%#GetHuodongTypehuodongTypeObj(Eval("huodongTypeObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		活动名称: <%#Eval("title")%>
			     	</div>
			     	<div class="field">
	            		开始时间: <%#Eval("startTime")%>
			     	</div>
			     	<div class="field">
	            		结束时间: <%#Eval("endTime")%>
			     	</div>
			     	<div class="field">
	            		活动积分: <%#Eval("jifen")%>
			     	</div>
			     	<div class="field">
	            		发布组织:<%#GetGroupInfogroupObj(Eval("groupObj").ToString())%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?huodongId=<%#Eval("huodongId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="huodongEdit('<%#Eval("huodongId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="huodongDelete('<%#Eval("huodongId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>活动查询</h1>
		</div>
            <div class="form-group">
            	<label for="huodongTypeObj_typeId">活动类型：</label>
                <asp:DropDownList ID="huodongTypeObj" runat="server"  CssClass="form-control" placeholder="请选择活动类型"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="title">活动名称:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入活动名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="startTime">开始时间:</label>
				<asp:TextBox ID="startTime"  runat="server" CssClass="form-control" placeholder="请选择开始时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="endTime">结束时间:</label>
				<asp:TextBox ID="endTime"  runat="server" CssClass="form-control" placeholder="请选择结束时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="groupObj_groupUserName">发布组织：</label>
                <asp:DropDownList ID="groupObj" runat="server"  CssClass="form-control" placeholder="请选择发布组织"></asp:DropDownList>
            </div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="huodongEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;活动信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="huodongEditForm" id="huodongEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="huodong_huodongId_edit" class="col-md-3 text-right">活动id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="huodong_huodongId_edit" name="huodong.huodongId" class="form-control" placeholder="请输入活动id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="huodong_huodongTypeObj_typeId_edit" class="col-md-3 text-right">活动类型:</label>
		  	 <div class="col-md-9">
			    <select id="huodong_huodongTypeObj_typeId_edit" name="huodong.huodongTypeObj.typeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_title_edit" class="col-md-3 text-right">活动名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="huodong_title_edit" name="huodong.title" class="form-control" placeholder="请输入活动名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_huodongPhoto_edit" class="col-md-3 text-right">活动图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="huodong_huodongPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="huodong_huodongPhoto" name="huodong.huodongPhoto"/>
			    <input id="huodongPhotoFile" name="huodongPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_huodongDesc_edit" class="col-md-3 text-right">活动简介:</label>
		  	 <div class="col-md-9">
			    <textarea id="huodong_huodongDesc_edit" name="huodong.huodongDesc" rows="8" class="form-control" placeholder="请输入活动简介"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_startTime_edit" class="col-md-3 text-right">开始时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date huodong_startTime_edit col-md-12" data-link-field="huodong_startTime_edit">
                    <input class="form-control" id="huodong_startTime_edit" name="huodong.startTime" size="16" type="text" value="" placeholder="请选择开始时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_endTime_edit" class="col-md-3 text-right">结束时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date huodong_endTime_edit col-md-12" data-link-field="huodong_endTime_edit">
                    <input class="form-control" id="huodong_endTime_edit" name="huodong.endTime" size="16" type="text" value="" placeholder="请选择结束时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_jifen_edit" class="col-md-3 text-right">活动积分:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="huodong_jifen_edit" name="huodong.jifen" class="form-control" placeholder="请输入活动积分">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="huodong_groupObj_groupUserName_edit" class="col-md-3 text-right">发布组织:</label>
		  	 <div class="col-md-9">
			    <select id="huodong_groupObj_groupUserName_edit" name="huodong.groupObj.groupUserName" class="form-control">
			    </select>
		  	 </div>
		  </div>
		</form> 
	    <style>#huodongEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxHuodongModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改活动界面并初始化数据*/
function huodongEdit(huodongId) {
	$.ajax({
		url :  basePath + "Huodong/HuodongController.aspx?action=getHuodong&huodongId=" + huodongId,
		type : "get",
		dataType: "json",
		success : function (huodong, response, status) {
			if (huodong) {
				$("#huodong_huodongId_edit").val(huodong.huodongId);
				$.ajax({
					url: basePath + "HuodongType/HuodongTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(huodongTypes,response,status) { 
						$("#huodong_huodongTypeObj_typeId_edit").empty();
						var html="";
		        		$(huodongTypes).each(function(i,huodongType){
		        			html += "<option value='" + huodongType.typeId + "'>" + huodongType.typeName + "</option>";
		        		});
		        		$("#huodong_huodongTypeObj_typeId_edit").html(html);
		        		$("#huodong_huodongTypeObj_typeId_edit").val(huodong.huodongTypeObjPri);
					}
				});
				$("#huodong_title_edit").val(huodong.title);
				$("#huodong_huodongPhoto").val(huodong.huodongPhoto);
				$("#huodong_huodongPhotoImg").attr("src", basePath +　huodong.huodongPhoto);
				$("#huodong_huodongDesc_edit").val(huodong.huodongDesc);
				$("#huodong_startTime_edit").val(huodong.startTime);
				$("#huodong_endTime_edit").val(huodong.endTime);
				$("#huodong_jifen_edit").val(huodong.jifen);
				$.ajax({
					url: basePath + "GroupInfo/GroupInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(groupInfos,response,status) { 
						$("#huodong_groupObj_groupUserName_edit").empty();
						var html="";
		        		$(groupInfos).each(function(i,groupInfo){
		        			html += "<option value='" + groupInfo.groupUserName + "'>" + groupInfo.groupName + "</option>";
		        		});
		        		$("#huodong_groupObj_groupUserName_edit").html(html);
		        		$("#huodong_groupObj_groupUserName_edit").val(huodong.groupObjPri);
					}
				});
				$('#huodongEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除活动信息*/
function huodongDelete(huodongId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Huodong/HuodongController.aspx?action=delete",
			data : {
				huodongId : huodongId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Huodong/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交活动信息表单给服务器端修改*/
function ajaxHuodongModify() {
	$.ajax({
		url :  basePath + "Huodong/HuodongController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#huodongEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
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

    /*开始时间组件*/
    $('.huodong_startTime_edit').datetimepicker({
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
    /*结束时间组件*/
    $('.huodong_endTime_edit').datetimepicker({
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
})
</script>
</body>
</html>

