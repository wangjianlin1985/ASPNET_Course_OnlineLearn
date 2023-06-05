<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Thesis_frontList" %>
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
<title>论文查询</title>
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
			    	<li role="presentation" class="active"><a href="#thesisListPanel" aria-controls="thesisListPanel" role="tab" data-toggle="tab">论文列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加论文</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="thesisListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>论文id</td><td>论文名称</td><td>期刊名称</td><td>发布日期</td><td>论文作者</td><td>审核状态</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpThesis" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("thesisId")%></td>
 											<td><%#Eval("lwmc")%></td>
 											<td><%#Eval("qkmc")%></td>
 											<td><%#Eval("fbrq")%></td>
 											<td><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
 											<td><%#Eval("shzt")%></td>
 											<td>
 												<a href="frontshow.aspx?thesisId=<%#Eval("thesisId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="thesisEdit('<%#Eval("thesisId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="thesisDelete('<%#Eval("thesisId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>论文查询</h1>
		</div>
			<div class="form-group">
				<label for="lwmc">论文名称:</label>
				<asp:TextBox ID="lwmc" runat="server"  CssClass="form-control" placeholder="请输入论文名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="qkmc">期刊名称:</label>
				<asp:TextBox ID="qkmc" runat="server"  CssClass="form-control" placeholder="请输入期刊名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="fbrq">发布日期:</label>
				<asp:TextBox ID="fbrq"  runat="server" CssClass="form-control" placeholder="请选择发布日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="teacherObj_thesisId">论文作者：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择论文作者"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="shzt">审核状态:</label>
				<asp:TextBox ID="shzt" runat="server"  CssClass="form-control" placeholder="请输入审核状态"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="thesisEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;论文信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="thesisEditForm" id="thesisEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="thesis_thesisId_edit" class="col-md-3 text-right">论文id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="thesis_thesisId_edit" name="thesis.thesisId" class="form-control" placeholder="请输入论文id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="thesis_lwmc_edit" class="col-md-3 text-right">论文名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="thesis_lwmc_edit" name="thesis.lwmc" class="form-control" placeholder="请输入论文名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="thesis_qkmc_edit" class="col-md-3 text-right">期刊名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="thesis_qkmc_edit" name="thesis.qkmc" class="form-control" placeholder="请输入期刊名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="thesis_fbrq_edit" class="col-md-3 text-right">发布日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date thesis_fbrq_edit col-md-12" data-link-field="thesis_fbrq_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="thesis_fbrq_edit" name="thesis.fbrq" size="16" type="text" value="" placeholder="请选择发布日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="thesis_teacherObj_teacherNo_edit" class="col-md-3 text-right">论文作者:</label>
		  	 <div class="col-md-9">
			    <select id="thesis_teacherObj_teacherNo_edit" name="thesis.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="thesis_shzt_edit" class="col-md-3 text-right">审核状态:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="thesis_shzt_edit" name="thesis.shzt" class="form-control" placeholder="请输入审核状态">
			 </div>
		  </div>
		</form> 
	    <style>#thesisEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxThesisModify();">提交</button>
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
/*弹出修改论文界面并初始化数据*/
function thesisEdit(thesisId) {
	$.ajax({
		url :  basePath + "Thesis/ThesisController.aspx?action=getThesis&thesisId=" + thesisId,
		type : "get",
		dataType: "json",
		success : function (thesis, response, status) {
			if (thesis) {
				$("#thesis_thesisId_edit").val(thesis.thesisId);
				$("#thesis_lwmc_edit").val(thesis.lwmc);
				$("#thesis_qkmc_edit").val(thesis.qkmc);
				$("#thesis_fbrq_edit").val(thesis.fbrq);
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#thesis_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.teacherName + "</option>";
		        		});
		        		$("#thesis_teacherObj_teacherNo_edit").html(html);
		        		$("#thesis_teacherObj_teacherNo_edit").val(thesis.teacherObjPri);
					}
				});
				$("#thesis_shzt_edit").val(thesis.shzt);
				$('#thesisEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除论文信息*/
function thesisDelete(thesisId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Thesis/ThesisController.aspx?action=delete",
			data : {
				thesisId : thesisId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Thesis/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交论文信息表单给服务器端修改*/
function ajaxThesisModify() {
	$.ajax({
		url :  basePath + "Thesis/ThesisController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#thesisEditForm")[0]),
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

    /*发布日期组件*/
    $('.thesis_fbrq_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
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

