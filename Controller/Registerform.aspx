<%@ Page Title="Đăng ký tài khoản" Language="C#" AutoEventWireup="true" CodeBehind="Registerform.aspx.cs" Inherits="HalBookstore.Registerform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 align="center">Đăng ký tài khoản</h1>
   <center>
       <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label></center>
	<form name="loginForm" method="post" runat="server">
   		<table align="center" style="border: solid 1px; margin-top: 5%; height: 300px;">
        	<tr>
                <hr size="2" color="#CCCCCC" />
            </tr>
            <tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label4" runat="server"><b>Tài khoản:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox ID="txtTaiKhoan" runat="server"  type="text" placeholder="Tên đăng nhập"></asp:TextBox>
                </td>
            </tr>
        	<tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label5" runat="server"><b>Mật Khẩu:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox ID="txtMatKhau" runat="server"  type="password" placeholder="Mật khẩu"></asp:TextBox>
                </td>
            </tr>
            <tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label6" runat="server"><b>Xác nhận mật khẩu:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox id="txtMatKhau2" runat="server" type="password" placeholder="Xác nhận mật khẩu"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnregister" runat="server" Width="100px" Height="50px" Text="Đăng ký" type="submit" OnClick="btnregister_Click"/><br />
                </td>
                <td style="float: right;">
                    <br /><asp:Label ID="Label7" runat="server" Text="Bạn đã có tài khoản?"></asp:Label>
                    <a >
                        <asp:LinkButton ID="lbtnregister" runat="server" type="register" href="Loginform.aspx">
                            <br />Đăng nhập
                        </asp:LinkButton>
                    </a>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
