<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupInfoList.aspx.cs" Inherits="chengxusheji.Admin.GroupInfoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>组织团体列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">组织团体管理 》》组织团体列表</div>
     <div class="Body_Search">
        领队用户名&nbsp;&nbsp;<asp:TextBox ID="groupUserName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        团体名称&nbsp;&nbsp;<asp:TextBox ID="groupName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        领队姓名&nbsp;&nbsp;<asp:TextBox ID="leageName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        联系电话&nbsp;&nbsp;<asp:TextBox ID="telephone" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        成立日期&nbsp;&nbsp; <asp:TextBox ID="bornDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        截止日期&nbsp;&nbsp; <asp:TextBox ID="endDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpGroupInfo" runat="server" onitemcommand="RpGroupInfo_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>领队用户名</th>
                        <th>团体名称</th>
                        <th>领队姓名</th>
                        <th>组织照片</th>
                        <th>联系电话</th>
                        <th>成立日期</th>
                        <th>截止日期</th>
                        <th>操作</th> 
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
                <td align="center"><a href="GroupInfoEdit.aspx?groupUserName=<%#Eval("groupUserName") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("groupUserName")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
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
