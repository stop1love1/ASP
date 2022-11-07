<%@ Page Title="Đăng nhập hệ thống" Language="C#" AutoEventWireup="true" CodeBehind="Loginform.aspx.cs" Inherits="HalBookstore.Formlogin" %>

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
        </style>
</head>
<body>
    <h1 align="center">Đăng nhập hệ thống</h1>
   <center> <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label></center>
	<form name="loginForm" method="post" runat="server">
   		<table align="center" style="border: solid 1px; margin-top: 5%; height: 300px;">
        	<tr>
                <hr size="2" color="#CCCCCC" />
            </tr>
            <tr>
            	<td align="center" class="auto-style3">
                    <asp:Label ID="Label3" runat="server"><b>Quyền:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListPermisson" runat="server" Width="168px" type="text" Height="22px" AutoPostBack="True">
                        <asp:ListItem>Nhân viên</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        	<tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label1" runat="server"><b>Tài khoản:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox ID="txtUsername" runat="server"  type="text" placeholder="Tên đăng nhập"></asp:TextBox>
                </td>
            </tr>
            <tr>
            	<td align="right" class="auto-style3">
                    <br /><asp:Label ID="Label2" runat="server"><b>Mật khẩu:</b></asp:Label>
                    &nbsp;&nbsp;&nbsp;
            	</td>
                <td class="auto-style1">
                    <br /><asp:TextBox id="txtPassword" runat="server" type="password" placeholder="Mật khẩu"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td style="float: right;">
                    <br /><asp:LinkButton ID="Lbtnchagnepass" runat="server" href="ChangePassWordForm.aspx">Quên mật khẩu?</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnlogin" runat="server" Width="100px" Height="50px" Text="Đăng nhập" type="submit" OnClick="btnlogin_Click"/><br />
                </td>
                <td style="float: right;">
                    <br /><asp:Label ID="Label4" runat="server" Text="Bạn chưa có tài khoản?"></asp:Label>
                    <a >
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
