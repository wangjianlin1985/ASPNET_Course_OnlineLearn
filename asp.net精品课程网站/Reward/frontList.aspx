<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Reward_frontList" %>
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
<title>获奖查询</title>
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
			    	<li role="presentation" class="active"><a href="#rewardListPanel" aria-controls="rewardListPanel" role="tab" data-toggle="tab">获奖列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加获奖</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="rewardListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>获奖id</td><td>获奖原因</td><td>获奖的老师</td><td>获奖时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpReward" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("rewardId")%></td>
 											<td><%#Eval("reason")%></td>
 											<td><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
 											<td><%#Eval("rewardTime")%></td>
 											<td>
 												<a href="frontshow.aspx?rewardId=<%#Eval("rewardId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="rewardEdit('<%#Eval("rewardId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="rewardDelete('<%#Eval("rewardId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>获奖查询</h1>
		</div>
			<div class="form-group">
				<label for="reason">获奖原因:</label>
				<asp:TextBox ID="reason" runat="server"  CssClass="form-control" placeholder="请输入获奖原因"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="teacherObj_rewardId">获奖的老师：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择获奖的老师"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="rewardTime">获奖时间:</label>
				<asp:TextBox ID="rewardTime"  runat="server" CssClass="form-control" placeholder="请选择获奖时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="rewardEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;获奖信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="rewardEditForm" id="rewardEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="reward_rewardId_edit" class="col-md-3 text-right">获奖id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="reward_rewardId_edit" name="reward.rewardId" class="form-control" placeholder="请输入获奖id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="reward_reason_edit" class="col-md-3 text-right">获奖原因:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="reward_reason_edit" name="reward.reason" class="form-control" placeholder="请输入获奖原因">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="reward_content_edit" class="col-md-3 text-right">获奖内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="reward_content_edit" name="reward.content" rows="8" class="form-control" placeholder="请输入获奖内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="reward_teacherObj_teacherNo_edit" class="col-md-3 text-right">获奖的老师:</label>
		  	 <div class="col-md-9">
			    <select id="reward_teacherObj_teacherNo_edit" name="reward.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="reward_rewardTime_edit" class="col-md-3 text-right">获奖时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date reward_rewardTime_edit col-md-12" data-link-field="reward_rewardTime_edit">
                    <input class="form-control" id="reward_rewardTime_edit" name="reward.rewardTime" size="16" type="text" value="" placeholder="请选择获奖时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#rewardEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxRewardModify();">提交</button>
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
/*弹出修改获奖界面并初始化数据*/
function rewardEdit(rewardId) {
	$.ajax({
		url :  basePath + "Reward/RewardController.aspx?action=getReward&rewardId=" + rewardId,
		type : "get",
		dataType: "json",
		success : function (reward, response, status) {
			if (reward) {
				$("#reward_rewardId_edit").val(reward.rewardId);
				$("#reward_reason_edit").val(reward.reason);
				$("#reward_content_edit").val(reward.content);
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#reward_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.teacherName + "</option>";
		        		});
		        		$("#reward_teacherObj_teacherNo_edit").html(html);
		        		$("#reward_teacherObj_teacherNo_edit").val(reward.teacherObjPri);
					}
				});
				$("#reward_rewardTime_edit").val(reward.rewardTime);
				$('#rewardEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除获奖信息*/
function rewardDelete(rewardId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Reward/RewardController.aspx?action=delete",
			data : {
				rewardId : rewardId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Reward/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交获奖信息表单给服务器端修改*/
function ajaxRewardModify() {
	$.ajax({
		url :  basePath + "Reward/RewardController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#rewardEditForm")[0]),
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

    /*获奖时间组件*/
    $('.reward_rewardTime_edit').datetimepicker({
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

