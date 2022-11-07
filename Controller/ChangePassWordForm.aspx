<%@ Page Title="Quên mật khẩu?" Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordForm.aspx.cs" Inherits="HalBookstore.ChangePasswordForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 189px;
        }
        .auto-style3 {
            width: 119px;
        }
        .auto-style8 {
            width: 119px;
            height: 33px;
        }
        .auto-style9 {
            height: 33px;
        }
    </style>
</head>
<body>
    <h1 align="center">Lấy lại mật khẩu</h1>
   <center>
       <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label></center>
	<form name="loginForm" method="post" runat="server">
   		<table align="center" style="border: solid 1px; margin-top: 5%; height: 200px;">
        	<tr>
                <hr size="2" color="#CCCCCC" />
            </tr>
            <tr>
                <td align="center" class="auto-style8">
                    <asp:Label ID="Label7" runat="server"><b>Tài khoản:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtTaiKhoan" runat="server"  type="text" size="30" placeholder="Tên tài khoản"></asp:TextBox>
                </td>
            </tr>
        	<tr>
                <td align="right" class="auto-style3">
                    <asp:Label ID="Label2" runat="server"><b>Mã bảo mật:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <asp:TextBox id="txtBaoMat" runat="server" type="text" size="30" placeholder="Mã bảo mật"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnsubmit" runat="server" Width="100px" Height="50px" Text="Gửi" type="submit" OnClick="btnsubmit_Click" /><br />
                </td>
                <td style="float: right;">
                    <br /><br /><asp:Label ID="Label6" runat="server" Text="Bạn chưa có tài khoản?"></asp:Label>
                    <a>
                        <asp:LinkButton ID="lbtnregister" runat="server" type="register" href="Registerform.aspx">
                            <br />Đăng ký
                        </asp:LinkButton>
                    </a>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
