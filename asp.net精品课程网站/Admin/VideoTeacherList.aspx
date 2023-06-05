<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoTeacherList.aspx.cs" Inherits="chengxusheji.Admin.VideoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>视频录像列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">视频录像管理 》》视频录像列表</div>
     <div class="Body_Search">
        视频标题&nbsp;&nbsp;<asp:TextBox ID="title" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        所属课程&nbsp;&nbsp;<asp:DropDownList ID="courseObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp; 
        录制时间&nbsp;&nbsp; <asp:TextBox ID="videoTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpVideo" runat="server" onitemcommand="RpVideo_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>视频id</th>
                        <th>视频标题</th>
                        <th>所属课程</th>
                        <th>视频文件</th>
                        <th>录制时间</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("videoId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("videoId")%> </td>
                <td align="center"><%#Eval("title")%> </td>
                  <td align="center"><%#GetCoursecourseObj(Eval("courseObj").ToString())%></td>
                <td><%#Eval("videoFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("videoFile").ToString() + "' target='_blank'>" + Eval("videoFile").ToString() +  "</a>" %></td>
               
                  <td align="center"><%# Convert.ToDateTime(Eval("videoTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("videoTime")).ToLongTimeString() %></td>
                <td align="center"> <asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("videoId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
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
