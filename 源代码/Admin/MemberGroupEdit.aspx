<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberGroupEdit.aspx.cs" Inherits="chengxusheji.Admin.MemberEdit" %>
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
            var addTime = document.getElementById("addTime").value;
            if (addTime == "") {
                alert("请输入申请时间...");
                document.getElementById("addTime").focus();
                return false;
            }

            var shenHeState = document.getElementById("shenHeState").value;
            if (shenHeState == "") {
                alert("请输入审核状态...");
                document.getElementById("shenHeState").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">团员管理 》》编辑团员</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    申请团体：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="groupObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    申请用户：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  申请时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="addTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   审核状态：</td>
                    <td width="650px;">
                         <select id="shenHeState"  runat="server">
                            <option value="待审核">待审核</option>
                            <option value="审核通过">审核通过</option>
                            <option value="审核拒绝">审核拒绝</option>

                         </select>    
                    </td>
                        
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   备注信息：</td>
                    <td width="650px;">
                        <textarea id="memberMemo" rows=6 cols=80 runat="server"></textarea></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnMemberSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnMemberSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

