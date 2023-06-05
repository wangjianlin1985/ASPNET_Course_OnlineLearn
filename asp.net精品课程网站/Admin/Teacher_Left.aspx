<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

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
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生管理</div>
        <div class="MenuNote" style="display:none;" id="StudentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="StudentEdit.aspx" target="main">添加学生</a></li>
                <li><a href="StudentList.aspx" target="main">学生查询</a></li> 
            </ul>
        </div>
         
         

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;留言答疑管理</div>
        <div class="MenuNote" style="display:none;" id="LeavewordDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LeavewordEdit.aspx" target="main">添加留言答疑</a></li>
                <li><a href="LeavewordList.aspx" target="main">留言答疑查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;课件管理</div>
        <div class="MenuNote" style="display:none;" id="KejianDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="KejianEdit.aspx" target="main">添加课件</a></li>
                <li><a href="KejianList.aspx" target="main">课件查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;视频录像管理</div>
        <div class="MenuNote" style="display:none;" id="VideoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="VideoTeacherAdd.aspx" target="main">发布视频录像</a></li>
                <li><a href="VideoTeacherList.aspx" target="main">我发布的视频</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;论文管理</div>
        <div class="MenuNote" style="display:none;" id="ThesisDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ThesisTeacherAdd.aspx" target="main">提交论文</a></li>
                <li><a href="ThesisTeacherList.aspx" target="main">我的论文查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;获奖管理</div>
        <div class="MenuNote" style="display:none;" id="RewardDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="RewardTeacherList.aspx" target="main">我的获奖查询</a></li> 
            </ul>
        </div>

        
 
   
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
