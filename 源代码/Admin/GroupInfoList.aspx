<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupInfoList.aspx.cs" Inherits="chengxusheji.Admin.GroupInfoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��֯�����б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">��֯������� ������֯�����б�</div>
     <div class="Body_Search">
        ����û���&nbsp;&nbsp;<asp:TextBox ID="groupUserName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��������&nbsp;&nbsp;<asp:TextBox ID="groupName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        �������&nbsp;&nbsp;<asp:TextBox ID="leageName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��ϵ�绰&nbsp;&nbsp;<asp:TextBox ID="telephone" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��������&nbsp;&nbsp; <asp:TextBox ID="bornDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        ��ֹ����&nbsp;&nbsp; <asp:TextBox ID="endDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="����excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpGroupInfo" runat="server" onitemcommand="RpGroupInfo_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>����û���</th>
                        <th>��������</th>
                        <th>�������</th>
                        <th>��֯��Ƭ</th>
                        <th>��ϵ�绰</th>
                        <th>��������</th>
                        <th>��ֹ����</th>
                        <th>����</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("groupUserName") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("groupUserName")%> </td>
                <td align="center"><%#Eval("groupName")%> </td>
                <td align="center"><%#Eval("leageName")%> </td>
                <td align="center"><img src="../<%#Eval("groupPhoto")%>" width=50 height=50 />
                <td align="center"><%#Eval("telephone")%> </td>
                  <td align="center"><%# Convert.ToDateTime(Eval("bornDate")).ToShortDateString() + " " + Convert.ToDateTime(Eval("bornDate")).ToLongTimeString() %></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("endDate")).ToShortDateString() + " " + Convert.ToDateTime(Eval("endDate")).ToLongTimeString() %></td>
                <td align="center"><a href="GroupInfoEdit.aspx?groupUserName=<%#Eval("groupUserName") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("groupUserName")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="ȫѡ" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" ɾ��ѡ�� " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[��ҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[βҳ]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
