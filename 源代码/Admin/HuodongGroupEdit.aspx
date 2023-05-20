<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HuodongGroupEdit.aspx.cs" Inherits="chengxusheji.Admin.HuodongEdit" %>
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
            var title = document.getElementById("title").value;
            if (title == "") {
                alert("请输入活动名称...");
                document.getElementById("title").focus();
                return false;
            }

            var huodongDesc = document.getElementById("huodongDesc").value;
            if (huodongDesc == "") {
                alert("请输入活动简介...");
                document.getElementById("huodongDesc").focus();
                return false;
            }

            var startTime = document.getElementById("startTime").value;
            if (startTime == "") {
                alert("请输入开始时间...");
                document.getElementById("startTime").focus();
                return false;
            }

            var endTime = document.getElementById("endTime").value;
            if (endTime == "") {
                alert("请输入结束时间...");
                document.getElementById("endTime").focus();
                return false;
            }

            var jifen = document.getElementById("jifen").value;
            if(jifen == ""){
                alert("请输入活动积分...");
                document.getElementById("jifen").focus();
                return false;
            }
            else if (!re.test(jifen))
            {
                alert("活动积分请输入数字");
                document.getElementById("jifen").focus();
                //input.rate.focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">活动管理 》》编辑活动</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    活动类型：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="huodongTypeObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   活动名称：</td>
                    <td width="650px;">
                         <input id="title" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入活动名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   活动图片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="huodongPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="HuodongPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_HuodongPhotoUpload" runat="server" Text="上传" OnClick="Btn_HuodongPhotoUpload_Click" /></td><td>
                         <asp:Image ID="HuodongPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   活动简介：</td>
                    <td width="650px;">
                        <textarea id="huodongDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入活动简介！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  开始时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="startTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  结束时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="endTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   活动积分：</td>
                    <td width="650px;">
                         <input id="jifen" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入活动积分！</td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    发布组织：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="groupObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnHuodongSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnHuodongSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

