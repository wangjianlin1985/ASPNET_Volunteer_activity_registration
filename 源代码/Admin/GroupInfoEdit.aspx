<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupInfoEdit.aspx.cs" Inherits="chengxusheji.Admin.GroupInfoEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var groupUserName = document.getElementById("groupUserName").value;
            if (groupUserName == "") {
                alert("请输入领队用户名...");
                document.getElementById("groupUserName").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("请输入登录密码...");
                document.getElementById("password").focus();
                return false;
            }

            var groupName = document.getElementById("groupName").value;
            if (groupName == "") {
                alert("请输入团体名称...");
                document.getElementById("groupName").focus();
                return false;
            }

            var leageName = document.getElementById("leageName").value;
            if (leageName == "") {
                alert("请输入领队姓名...");
                document.getElementById("leageName").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("请输入联系电话...");
                document.getElementById("telephone").focus();
                return false;
            }

            var bornDate = document.getElementById("bornDate").value;
            if (bornDate == "") {
                alert("请输入成立日期...");
                document.getElementById("bornDate").focus();
                return false;
            }

            var endDate = document.getElementById("endDate").value;
            if (endDate == "") {
                alert("请输入截止日期...");
                document.getElementById("endDate").focus();
                return false;
            }

            var groupDesc = document.getElementById("groupDesc").value;
            if (groupDesc == "") {
                alert("请输入团队介绍...");
                document.getElementById("groupDesc").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">组织团体管理 》》编辑组织团体</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   领队用户名：</td>
                    <td width="650px;">
                         <input id="groupUserName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入领队用户名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   登录密码：</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入登录密码！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   团体名称：</td>
                    <td width="650px;">
                         <input id="groupName" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入团体名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   领队姓名：</td>
                    <td width="650px;">
                         <input id="leageName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入领队姓名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   组织照片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="groupPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="GroupPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_GroupPhotoUpload" runat="server" Text="上传" OnClick="Btn_GroupPhotoUpload_Click" /></td><td>
                         <asp:Image ID="GroupPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入联系电话！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  成立日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="bornDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  截止日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="endDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   团队介绍：</td>
                    <td width="650px;">
                        <textarea id="groupDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入团队介绍！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnGroupInfoSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnGroupInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

