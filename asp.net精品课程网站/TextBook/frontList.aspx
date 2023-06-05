<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="TextBook_frontList" %>
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
<title>教材查询</title>
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
			    	<li role="presentation" class="active"><a href="#textBookListPanel" aria-controls="textBookListPanel" role="tab" data-toggle="tab">教材列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加教材</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="textBookListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>教材id</td><td>教材名称</td><td>教材类别</td><td>教材定价</td><td>出版社</td><td>出版日期</td><td>作者</td><td>库存数量</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpTextBook" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("textBookId")%></td>
 											<td><%#Eval("textBookName")%></td>
 											<td><%#Eval("textBookClass")%></td>
 											<td><%#Eval("price")%></td>
 											<td><%#Eval("publish")%></td>
 											<td><%#Eval("publishDate")%></td>
 											<td><%#Eval("author")%></td>
 											<td><%#Eval("bookCount")%></td>
 											<td>
 												<a href="frontshow.aspx?textBookId=<%#Eval("textBookId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="textBookEdit('<%#Eval("textBookId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="textBookDelete('<%#Eval("textBookId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>教材查询</h1>
		</div>
			<div class="form-group">
				<label for="textBookName">教材名称:</label>
				<asp:TextBox ID="textBookName" runat="server"  CssClass="form-control" placeholder="请输入教材名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="textBookClass">教材类别:</label>
				<asp:TextBox ID="textBookClass" runat="server"  CssClass="form-control" placeholder="请输入教材类别"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="publishDate">出版日期:</label>
				<asp:TextBox ID="publishDate"  runat="server" CssClass="form-control" placeholder="请选择出版日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="author">作者:</label>
				<asp:TextBox ID="author" runat="server"  CssClass="form-control" placeholder="请输入作者"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="textBookEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;教材信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="textBookEditForm" id="textBookEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="textBook_textBookId_edit" class="col-md-3 text-right">教材id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="textBook_textBookId_edit" name="textBook.textBookId" class="form-control" placeholder="请输入教材id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="textBook_textBookName_edit" class="col-md-3 text-right">教材名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="textBook_textBookName_edit" name="textBook.textBookName" class="form-control" placeholder="请输入教材名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_textBookClass_edit" class="col-md-3 text-right">教材类别:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="textBook_textBookClass_edit" name="textBook.textBookClass" class="form-control" placeholder="请输入教材类别">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_price_edit" class="col-md-3 text-right">教材定价:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="textBook_price_edit" name="textBook.price" class="form-control" placeholder="请输入教材定价">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_publish_edit" class="col-md-3 text-right">出版社:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="textBook_publish_edit" name="textBook.publish" class="form-control" placeholder="请输入出版社">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_publishDate_edit" class="col-md-3 text-right">出版日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date textBook_publishDate_edit col-md-12" data-link-field="textBook_publishDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="textBook_publishDate_edit" name="textBook.publishDate" size="16" type="text" value="" placeholder="请选择出版日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_author_edit" class="col-md-3 text-right">作者:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="textBook_author_edit" name="textBook.author" class="form-control" placeholder="请输入作者">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_bookCount_edit" class="col-md-3 text-right">库存数量:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="textBook_bookCount_edit" name="textBook.bookCount" class="form-control" placeholder="请输入库存数量">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="textBook_bookMemo_edit" class="col-md-3 text-right">教材备注:</label>
		  	 <div class="col-md-9">
			    <textarea id="textBook_bookMemo_edit" name="textBook.bookMemo" rows="8" class="form-control" placeholder="请输入教材备注"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#textBookEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxTextBookModify();">提交</button>
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
/*弹出修改教材界面并初始化数据*/
function textBookEdit(textBookId) {
	$.ajax({
		url :  basePath + "TextBook/TextBookController.aspx?action=getTextBook&textBookId=" + textBookId,
		type : "get",
		dataType: "json",
		success : function (textBook, response, status) {
			if (textBook) {
				$("#textBook_textBookId_edit").val(textBook.textBookId);
				$("#textBook_textBookName_edit").val(textBook.textBookName);
				$("#textBook_textBookClass_edit").val(textBook.textBookClass);
				$("#textBook_price_edit").val(textBook.price);
				$("#textBook_publish_edit").val(textBook.publish);
				$("#textBook_publishDate_edit").val(textBook.publishDate);
				$("#textBook_author_edit").val(textBook.author);
				$("#textBook_bookCount_edit").val(textBook.bookCount);
				$("#textBook_bookMemo_edit").val(textBook.bookMemo);
				$('#textBookEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除教材信息*/
function textBookDelete(textBookId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "TextBook/TextBookController.aspx?action=delete",
			data : {
				textBookId : textBookId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "TextBook/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交教材信息表单给服务器端修改*/
function ajaxTextBookModify() {
	$.ajax({
		url :  basePath + "TextBook/TextBookController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#textBookEditForm")[0]),
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

    /*出版日期组件*/
    $('.textBook_publishDate_edit').datetimepicker({
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

