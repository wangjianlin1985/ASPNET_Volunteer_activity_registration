<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Member_frontList" %>
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
<title>团员查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#memberListPanel" aria-controls="memberListPanel" role="tab" data-toggle="tab">团员列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加团员</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="memberListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>记录id</td><td>申请团体</td><td>申请用户</td><td>申请时间</td><td>审核状态</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpMember" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("memberId")%></td>
 											<td><%#GetGroupInfogroupObj(Eval("groupObj").ToString())%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("addTime")%></td>
 											<td><%#Eval("shenHeState")%></td>
 											<td>
 												<a href="frontshow.aspx?memberId=<%#Eval("memberId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="memberEdit('<%#Eval("memberId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="memberDelete('<%#Eval("memberId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>团员查询</h1>
		</div>
            <div class="form-group">
            	<label for="groupObj_memberId">申请团体：</label>
                <asp:DropDownList ID="groupObj" runat="server"  CssClass="form-control" placeholder="请选择申请团体"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="userObj_memberId">申请用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择申请用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">申请时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择申请时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="shenHeState">审核状态:</label>
				<asp:TextBox ID="shenHeState" runat="server"  CssClass="form-control" placeholder="请输入审核状态"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="memberEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;团员信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
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
		</form> 
	    <style>#memberEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxMemberModify();">提交</button>
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
				$('#memberEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除团员信息*/
function memberDelete(memberId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Member/MemberController.aspx?action=delete",
			data : {
				memberId : memberId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Member/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
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
})
</script>
</body>
</html>

