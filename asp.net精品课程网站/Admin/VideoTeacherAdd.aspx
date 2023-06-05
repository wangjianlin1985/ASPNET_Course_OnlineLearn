<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoTeacherAdd.aspx.cs" Inherits="chengxusheji.Admin.VideoEdit" %>
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
            var title = document.getElementById("title").value;
            if (title == "") {
                alert("��������Ƶ����...");
                document.getElementById("title").focus();
                return false;
            }

            var videoDesc = document.getElementById("videoDesc").value;
            if (videoDesc == "") {
                alert("��������Ƶ����...");
                document.getElementById("videoDesc").focus();
                return false;
            }

            var videoTime = document.getElementById("videoTime").value;
            if (videoTime == "") {
                alert("������¼��ʱ��...");
                document.getElementById("videoTime").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">��Ƶ¼����� �����༭��Ƶ¼��</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ƶ���⣺</td>
                    <td width="650px;">
                         <input id="title" type="text"   style="width:600px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������Ƶ���⣡</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �����γ̣�</td>
                    <td width="650px;">
                         <asp:DropDownList ID="courseObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ƶ���ܣ�</td>
                    <td width="650px;">
                        <textarea id="videoDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>��������Ƶ���ܣ�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ƶ�ļ���</td>
                    <td width="650px;">
                     <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         �ļ����أ�<asp:HyperLink  ID="videoFile" runat="server"></asp:HyperLink > &nbsp; &nbsp; &nbsp;
                         <br /><br />
                         �ϴ��ļ���<asp:FileUpload ID="VideoFileUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_VideoFileUpload" runat="server" Text="�ϴ�" OnClick="Btn_VideoFileUpload_Click" /></td><td>
                         </td></tr>
                       </table>
                    </td>
                </tr>
               

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ¼��ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="videoTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnVideoSave" runat="server" Text="�ύ��Ƶ��Ϣ"
                            OnClientClick="return CheckIn()" onclick="BtnVideoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

