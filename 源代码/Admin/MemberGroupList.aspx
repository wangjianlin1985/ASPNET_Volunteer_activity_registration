<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberGroupList.aspx.cs" Inherits="chengxusheji.Admin.MemberList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>团员列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">团员管理 》》团员列表</div>
     <div class="Body_Search">
       <asp:DropDownList ID="groupObj" runat="server" Visible="false"></asp:DropDownList>  &nbsp;&nbsp;
        申请用户&nbsp;&nbsp;<asp:DropDownList ID="userObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        申请时间&nbsp;&nbsp; <asp:TextBox ID="addTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        审核状态&nbsp;&nbsp;<asp:TextBox ID="shenHeState" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpMember" runat="server" onitemcommand="RpMember_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>记录id</th>
                        <th>申请用户</th>
                        <th>申请时间</th>
                        <th>审核状态</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("memberId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("memberId")%> </td>
                  <td align="center"><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("addTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("addTime")).ToLongTimeString() %></td>
                <td align="center"><%#Eval("shenHeState")%> </td>
                <td align="center"><a href="MemberGroupEdit.aspx?memberId=<%#Eval("memberId") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("memberId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
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
