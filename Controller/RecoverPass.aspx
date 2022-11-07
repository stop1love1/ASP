<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPass.aspx.cs" Inherits="HalBookstore.Controller.RecoverPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 align="center">Đổi mật khẩu</h1>
   <center>
        <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label></center>
	<form name="loginForm" method="post" runat="server">
   		<table align="center" style="border: solid 1px; margin-top: 5%; height: 300px;">
        	<tr>
                <hr size="2" color="#CCCCCC" />
            </tr>
            <tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label4" runat="server"><b>Mật khẩu cũ</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox ID="txtMatKhauCu" runat="server"  type="text" placeholder="Nhập mật khẩu cũ"></asp:TextBox>
                </td>
            </tr>
        	<tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label5" runat="server"><b>Mật Khẩu mới:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox ID="txtMatKhauMoi" runat="server"  type="password" placeholder="Nhập mật khẩu mới"></asp:TextBox>
                </td>
            </tr>
            <tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label6" runat="server"><b>Xác nhận mật khẩu:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox id="txtMatKhauMoi2" runat="server" type="password" placeholder="Xác nhận mật khẩu"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnAccept" runat="server" Width="100px" Height="50px" Text="Xác nhận" type="submit" OnClick="btnAccept_Click"/><br />
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
