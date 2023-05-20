<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="GroupInfo_frontList" %>
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
<title>组织团体查询</title>
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
  			<li><a href="frontList.aspx">组织团体信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加组织团体</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpGroupInfo" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?groupUserName=<%#Eval("groupUserName")%>"><img class="img-responsive" src="../<%#Eval("groupPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		领队用户名: <%#Eval("groupUserName")%>
			     	</div>
			     	<div class="field">
	            		团体名称: <%#Eval("groupName")%>
			     	</div>
			     	<div class="field">
	            		领队姓名: <%#Eval("leageName")%>
			     	</div>
			     	<div class="field">
	            		联系电话: <%#Eval("telephone")%>
			     	</div>
			     	<div class="field">
	            		成立日期: <%#Eval("bornDate")%>
			     	</div>
			     	<div class="field">
	            		截止日期: <%#Eval("endDate")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?groupUserName=<%#Eval("groupUserName")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="groupInfoEdit('<%#Eval("groupUserName")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="groupInfoDelete('<%#Eval("groupUserName")%>');" style="display:none;">删除</a>
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
    		<h1>组织团体查询</h1>
		</div>
			<div class="form-group">
				<label for="groupUserName">领队用户名:</label>
				<asp:TextBox ID="groupUserName" runat="server"  CssClass="form-control" placeholder="请输入领队用户名"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="groupName">团体名称:</label>
				<asp:TextBox ID="groupName" runat="server"  CssClass="form-control" placeholder="请输入团体名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="leageName">领队姓名:</label>
				<asp:TextBox ID="leageName" runat="server"  CssClass="form-control" placeholder="请输入领队姓名"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="telephone">联系电话:</label>
				<asp:TextBox ID="telephone" runat="server"  CssClass="form-control" placeholder="请输入联系电话"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="bornDate">成立日期:</label>
				<asp:TextBox ID="bornDate"  runat="server" CssClass="form-control" placeholder="请选择成立日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="endDate">截止日期:</label>
				<asp:TextBox ID="endDate"  runat="server" CssClass="form-control" placeholder="请选择截止日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="groupInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;组织团体信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
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
			    <textarea id="groupInfo_groupDesc_edit" name="groupInfo.groupDesc" rows="8" class="form-control" placeholder="请输入团队介绍"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#groupInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxGroupInfoModify();">提交</button>
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
				$('#groupInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除组织团体信息*/
function groupInfoDelete(groupUserName) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "GroupInfo/GroupInfoController.aspx?action=delete",
			data : {
				groupUserName : groupUserName,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "GroupInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
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
})
</script>
</body>
</html>

