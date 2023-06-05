<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

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
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;班级学生管理</div>
        <div class="MenuNote" style="display:none;" id="StudentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ClassInfoEdit.aspx" target="main">添加班级</a></li>
                <li><a href="ClassInfoList.aspx" target="main">班级查询</a></li> 
                <li><a href="StudentEdit.aspx" target="main">添加学生</a></li>
                <li><a href="StudentList.aspx" target="main">学生查询</a></li> 
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教师管理</div>
        <div class="MenuNote" style="display:none;" id="TeacherDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="TeacherEdit.aspx" target="main">添加教师</a></li>
                <li><a href="TeacherList.aspx" target="main">教师查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;课程实践管理</div>
        <div class="MenuNote" style="display:none;" id="CourseDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="CourseEdit.aspx" target="main">添加课程</a></li>
                <li><a href="CourseList.aspx" target="main">课程查询</a></li>
                <li><a href="PracticeEdit.aspx" target="main">添加课程实践</a></li>
                <li><a href="PracticeList.aspx" target="main">课程实践查询</a></li>  
            </ul>
        </div>

        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教材管理</div>
        <div class="MenuNote" style="display:none;" id="TextBookDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="TextBookEdit.aspx" target="main">添加教材</a></li>
                <li><a href="TextBookList.aspx" target="main">教材查询</a></li> 
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

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;视频录像管理</div>
        <div class="MenuNote" style="display:none;" id="VideoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="VideoEdit.aspx" target="main">添加视频录像</a></li>
                <li><a href="VideoList.aspx" target="main">视频录像查询</a></li> 
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

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;论文管理</div>
        <div class="MenuNote" style="display:none;" id="ThesisDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ThesisEdit.aspx" target="main">添加论文</a></li>
                <li><a href="ThesisList.aspx" target="main">论文查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;获奖管理</div>
        <div class="MenuNote" style="display:none;" id="RewardDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="RewardEdit.aspx" target="main">添加获奖</a></li>
                <li><a href="RewardList.aspx" target="main">获奖查询</a></li> 
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;友情链接管理</div>
        <div class="MenuNote" style="display:none;" id="WebLinkDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="WebLinkEdit.aspx" target="main">添加友情链接</a></li>
                <li><a href="WebLinkList.aspx" target="main">友情链接查询</a></li> 
            </ul>
        </div>

  
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
