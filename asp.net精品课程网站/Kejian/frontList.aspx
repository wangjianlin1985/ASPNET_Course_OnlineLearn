<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Kejian_frontList" %>
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
<title>课件查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#kejianListPanel" aria-controls="kejianListPanel" role="tab" data-toggle="tab">课件列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加课件</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="kejianListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>课件id</td><td>课件标题</td><td>所属课程</td><td>课件文件</td><td>发布时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpKejian" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("kejianId")%></td>
 											<td><%#Eval("title")%></td>
 											<td><%#GetCoursecourseObj(Eval("courseObj").ToString())%></td>
 											<td><%#Eval("kejianFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("kejianFile").ToString() + "' target='_blank'>" + Eval("kejianFile").ToString() +  "</a>" %></td>
 											<td><%#Eval("addTime")%></td>
 											<td>
 												<a href="frontshow.aspx?kejianId=<%#Eval("kejianId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="kejianEdit('<%#Eval("kejianId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="kejianDelete('<%#Eval("kejianId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>课件查询</h1>
		</div>
			<div class="form-group">
				<label for="title">课件标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入课件标题"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="courseObj_kejianId">所属课程：</label>
                <asp:DropDownList ID="courseObj" runat="server"  CssClass="form-control" placeholder="请选择所属课程"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="kejianEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;课件信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="kejianEditForm" id="kejianEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="kejian_kejianId_edit" class="col-md-3 text-right">课件id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="kejian_kejianId_edit" name="kejian.kejianId" class="form-control" placeholder="请输入课件id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="kejian_title_edit" class="col-md-3 text-right">课件标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="kejian_title_edit" name="kejian.title" class="form-control" placeholder="请输入课件标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="kejian_courseObj_courseNo_edit" class="col-md-3 text-right">所属课程:</label>
		  	 <div class="col-md-9">
			    <select id="kejian_courseObj_courseNo_edit" name="kejian.courseObj.courseNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="kejian_kejianDesc_edit" class="col-md-3 text-right">课件描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="kejian_kejianDesc_edit" name="kejian.kejianDesc" rows="8" class="form-control" placeholder="请输入课件描述"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="kejian_kejianFile_edit" class="col-md-3 text-right">课件文件:</label>
		  	 <div class="col-md-9">
			    <a id="kejian_kejianFileA" target="_blank"></a><br/>
			    <input type="hidden" id="kejian_kejianFile" name="kejian.kejianFile"/>
			    <input id="kejianFileFile" name="kejianFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="kejian_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date kejian_addTime_edit col-md-12" data-link-field="kejian_addTime_edit">
                    <input class="form-control" id="kejian_addTime_edit" name="kejian.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#kejianEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxKejianModify();">提交</button>
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
/*弹出修改课件界面并初始化数据*/
function kejianEdit(kejianId) {
	$.ajax({
		url :  basePath + "Kejian/KejianController.aspx?action=getKejian&kejianId=" + kejianId,
		type : "get",
		dataType: "json",
		success : function (kejian, response, status) {
			if (kejian) {
				$("#kejian_kejianId_edit").val(kejian.kejianId);
				$("#kejian_title_edit").val(kejian.title);
				$.ajax({
					url: basePath + "Course/CourseController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(courses,response,status) { 
						$("#kejian_courseObj_courseNo_edit").empty();
						var html="";
		        		$(courses).each(function(i,course){
		        			html += "<option value='" + course.courseNo + "'>" + course.courseName + "</option>";
		        		});
		        		$("#kejian_courseObj_courseNo_edit").html(html);
		        		$("#kejian_courseObj_courseNo_edit").val(kejian.courseObjPri);
					}
				});
				$("#kejian_kejianDesc_edit").val(kejian.kejianDesc);
				$("#kejian_kejianFile").val(kejian.kejianFile);
				$("#kejian_kejianFileA").text(kejian.kejianFile);
				$("#kejian_kejianFileA").attr("href", basePath +　kejian.kejianFile);
				$("#kejian_addTime_edit").val(kejian.addTime);
				$('#kejianEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除课件信息*/
function kejianDelete(kejianId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Kejian/KejianController.aspx?action=delete",
			data : {
				kejianId : kejianId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Kejian/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交课件信息表单给服务器端修改*/
function ajaxKejianModify() {
	$.ajax({
		url :  basePath + "Kejian/KejianController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#kejianEditForm")[0]),
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

    /*发布时间组件*/
    $('.kejian_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

