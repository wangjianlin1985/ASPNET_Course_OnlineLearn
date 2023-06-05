<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThesisTeacherAdd.aspx.cs" Inherits="chengxusheji.Admin.ThesisEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var lwmc = document.getElementById("lwmc").value;
            if (lwmc == "") {
                alert("请输入论文名称...");
                document.getElementById("lwmc").focus();
                return false;
            }

            var qkmc = document.getElementById("qkmc").value;
            if (qkmc == "") {
                alert("请输入期刊名称...");
                document.getElementById("qkmc").focus();
                return false;
            }

            var fbrq = document.getElementById("fbrq").value;
            if (fbrq == "") {
                alert("请输入发布日期...");
                document.getElementById("fbrq").focus();
                return false;
            }
 

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">论文管理 》》提交论文</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   论文名称：</td>
                    <td width="650px;">
                         <input id="lwmc" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入论文名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   期刊名称：</td>
                    <td width="650px;">
                         <input id="qkmc" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入期刊名称！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  发布日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="fbrq"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd');"></asp:TextBox></td>                </tr>

                
 

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnThesisSave" runat="server" Text="提交信息 "
                            OnClientClick="return CheckIn()" onclick="BtnThesisSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

