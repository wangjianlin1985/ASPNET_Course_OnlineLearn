<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Course_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>课程查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">课程信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加课程</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpCourse" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?courseNo=<%#Eval("courseNo")%>"><img class="img-responsive" src="../<%#Eval("coursePhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		课程编号: <%#Eval("courseNo")%>
			     	</div>
			     	<div class="field">
	            		课程名称: <%#Eval("courseName")%>
			     	</div>
			     	<div class="field">
	            		上课老师:<%#GetTeacherteacherObj(Eval("teacherObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		课程学时: <%#Eval("courseHours")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?courseNo=<%#Eval("courseNo")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="courseEdit('<%#Eval("courseNo")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="courseDelete('<%#Eval("courseNo")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>课程查询</h1>
		</div>
			<div class="form-group">
				<label for="courseNo">课程编号:</label>
				<asp:TextBox ID="courseNo" runat="server"  CssClass="form-control" placeholder="请输入课程编号"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="courseName">课程名称:</label>
				<asp:TextBox ID="courseName" runat="server"  CssClass="form-control" placeholder="请输入课程名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="teacherObj_teacherNo">上课老师：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择上课老师"></asp:DropDownList>
            </div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="courseEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;课程信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="courseEditForm" id="courseEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="course_courseNo_edit" class="col-md-3 text-right">课程编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="course_courseNo_edit" name="course.courseNo" class="form-control" placeholder="请输入课程编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="course_courseName_edit" class="col-md-3 text-right">课程名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="course_courseName_edit" name="course.courseName" class="form-control" placeholder="请输入课程名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="course_coursePhoto_edit" class="col-md-3 text-right">课程图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="course_coursePhotoImg" border="0px"/><br/>
			    <input type="hidden" id="course_coursePhoto" name="course.coursePhoto"/>
			    <input id="coursePhotoFile" name="coursePhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="course_teacherObj_teacherNo_edit" class="col-md-3 text-right">上课老师:</label>
		  	 <div class="col-md-9">
			    <select id="course_teacherObj_teacherNo_edit" name="course.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="course_courseHours_edit" class="col-md-3 text-right">课程学时:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="course_courseHours_edit" name="course.courseHours" class="form-control" placeholder="请输入课程学时">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="course_jxff_edit" class="col-md-3 text-right">教学大纲:</label>
		  	 <div class="col-md-9">
			    <textarea id="course_jxff_edit" name="course.jxff" rows="8" class="form-control" placeholder="请输入教学大纲"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="course_kcjj_edit" class="col-md-3 text-right">课程简介:</label>
		  	 <div class="col-md-9">
			    <textarea id="course_kcjj_edit" name="course.kcjj" rows="8" class="form-control" placeholder="请输入课程简介"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#courseEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxCourseModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改课程界面并初始化数据*/
function courseEdit(courseNo) {
	$.ajax({
		url :  basePath + "Course/CourseController.aspx?action=getCourse&courseNo=" + courseNo,
		type : "get",
		dataType: "json",
		success : function (course, response, status) {
			if (course) {
				$("#course_courseNo_edit").val(course.courseNo);
				$("#course_courseName_edit").val(course.courseName);
				$("#course_coursePhoto").val(course.coursePhoto);
				$("#course_coursePhotoImg").attr("src", basePath +　course.coursePhoto);
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#course_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.teacherName + "</option>";
		        		});
		        		$("#course_teacherObj_teacherNo_edit").html(html);
		        		$("#course_teacherObj_teacherNo_edit").val(course.teacherObjPri);
					}
				});
				$("#course_courseHours_edit").val(course.courseHours);
				$("#course_jxff_edit").val(course.jxff);
				$("#course_kcjj_edit").val(course.kcjj);
				$('#courseEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除课程信息*/
function courseDelete(courseNo) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Course/CourseController.aspx?action=delete",
			data : {
				courseNo : courseNo,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Course/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交课程信息表单给服务器端修改*/
function ajaxCourseModify() {
	$.ajax({
		url :  basePath + "Course/CourseController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#courseEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

})
</script>
</body>
</html>

