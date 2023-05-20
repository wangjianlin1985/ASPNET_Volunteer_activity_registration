<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Group_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        
        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;团体成员管理</div>
        <div class="MenuNote" style="display:none;" id="MemberDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL"> 
                <li><a href="MemberGroupList.aspx" target="main">团体成员查询</a></li> 
            </ul>
        </div>


        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;活动类型管理</div>
        <div class="MenuNote" style="display:none;" id="HuodongTypeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="HuodongTypeEdit.aspx" target="main">添加活动类型</a></li>
                <li><a href="HuodongTypeList.aspx" target="main">活动类型查询</a></li> 
            </ul>
        </div>


        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;活动管理</div>
        <div class="MenuNote" style="display:none;" id="HuodongDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="HuodongGroupEdit.aspx" target="main">发布活动</a></li>
                <li><a href="HuodongGroupList.aspx" target="main">活动管理</a></li> 
            </ul>
        </div>

        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;活动报名管理</div>
        <div class="MenuNote" style="display:none;" id="SignUpDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="SignUpGroupList.aspx" target="main">活动报名查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;组织团体管理</div>
        <div class="MenuNote" style="display:none;" id="GroupInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="GroupInfoSelfEdit.aspx" target="main">修改团体信息</a></li> 
            </ul>
        </div>

        

 
   
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
