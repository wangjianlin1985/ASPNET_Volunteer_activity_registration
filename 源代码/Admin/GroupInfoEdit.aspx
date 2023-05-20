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
                alert("����������û���...");
                document.getElementById("groupUserName").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("�������¼����...");
                document.getElementById("password").focus();
                return false;
            }

            var groupName = document.getElementById("groupName").value;
            if (groupName == "") {
                alert("��������������...");
                document.getElementById("groupName").focus();
                return false;
            }

            var leageName = document.getElementById("leageName").value;
            if (leageName == "") {
                alert("�������������...");
                document.getElementById("leageName").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("��������ϵ�绰...");
                document.getElementById("telephone").focus();
                return false;
            }

            var bornDate = document.getElementById("bornDate").value;
            if (bornDate == "") {
                alert("�������������...");
                document.getElementById("bornDate").focus();
                return false;
            }

            var endDate = document.getElementById("endDate").value;
            if (endDate == "") {
                alert("�������ֹ����...");
                document.getElementById("endDate").focus();
                return false;
            }

            var groupDesc = document.getElementById("groupDesc").value;
            if (groupDesc == "") {
                alert("�������Ŷӽ���...");
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
    <div class="Body_Title">��֯������� �����༭��֯����</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ����û�����</td>
                    <td width="650px;">
                         <input id="groupUserName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>����������û�����</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��¼���룺</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������¼���룡</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �������ƣ�</td>
                    <td width="650px;">
                         <input id="groupName" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������������ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���������</td>
                    <td width="650px;">
                         <input id="leageName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>���������������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��֯��Ƭ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="groupPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="GroupPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_GroupPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_GroupPhotoUpload_Click" /></td><td>
                         <asp:Image ID="GroupPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������ϵ�绰��</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="bornDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ��ֹ���ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="endDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �Ŷӽ��ܣ�</td>
                    <td width="650px;">
                        <textarea id="groupDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>�������Ŷӽ��ܣ�</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnGroupInfoSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnGroupInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

