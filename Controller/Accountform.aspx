<%@ Page Title="Quản lý tài khoản" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accountform.aspx.cs" Inherits="HalBookstore.Accountform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="637px">
        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="Quản lý tài khoản" ForeColor="Blue" Font-Size="20"></asp:Label><br />
        <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="#009933" Font-Size="14"></asp:Label>
        </center>
            <br />
        <div class="rowright">
        </div>
        <br />
        <asp:GridView ID="GridViewAccount" runat="server" Height="295px" Width="100%" AutoGenerateSelectButton="True" BorderColor="Black" BorderStyle="Inset" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewAccount_SelectedIndexChanged" >
        </asp:GridView>
        <asp:Panel ID="Panel2" runat="server" Height="31px"><br />
            <asp:Panel ID="pnControl" runat="server" Height="47px" class="content">
            <strong>
            <asp:Button ID="btnDLeft" runat="server" style="font-weight: bold" Text="&lt;&lt;" Width="60px" OnClick="Button_Click" />
            </strong>
            <asp:Button ID="btnLeft" runat="server" style="font-weight: bold" Text="&lt;" Width="60px" OnClick="Button_Click" />
            <strong>
            <asp:Label ID="lblCount" runat="server" Font-Size="10pt" Text="00/00"></asp:Label>
            </strong>
            <asp:Button ID="btnRight" runat="server" style="font-weight: bold" Text="&gt;" Width="60px" OnClick="Button_Click" />
            <strong>
            <asp:Button ID="btnDRight" runat="server" style="font-weight: bold" Text="&gt;&gt;" Width="60px" OnClick="Button_Click" />
            </strong>
                 </asp:Panel>
            <br />
            <asp:Panel ID="PanelSearch" runat="server">
            <div style="border: solid 1px; width: 60%; margin-left: 20%;"><br /><br />
            <asp:Panel ID="pnInformation" runat="server" Height="250px">
                <div class="left-column">
                    <asp:Label ID="Label2" runat="server" Text="Tên tài khoản" Font-Size="16px" class="lbltentaikhoan"></asp:Label>
                    <asp:TextBox ID="txtTaiKhoan" runat="server" class="txttentaikhoan"></asp:TextBox><br /><br />
                    <asp:Label ID="Label7" runat="server" Text="Tên người dùng" Font-Size="16px" class="lblnguoidung"></asp:Label>
                    <asp:TextBox ID="txtNguoiDung" runat="server" class="txtnguoidung"></asp:TextBox><br /><br />
                    <br /><br />
                </div>
                <div class="right-column">
                    <asp:CheckBox ID="ckbadmin" runat="server" class="ckbadmin" AutoPostBack="True"/><span style="margin-left: 10px;">Admin</span><br /><br /><br />
                    <asp:CheckBox ID="ckbnhanvien" runat="server" class="ckbnhanvien" AutoPostBack="True"/><span style="margin-left: 10px;">Nhân viên</span>
                </div>  
                <br />
            </asp:Panel>
                </div>
                </asp:Panel>
            <asp:Panel ID="Panel4" runat="server" Height="40px" class="content"><br />
                    <asp:Button ID="btnSua" runat="server" Height="30px" Text="Sửa" Width="120px" OnClick="Button_Click"/>
                    <asp:Button ID="btnXoa" runat="server" Height="30px" Text="Xóa" Width="120px" OnClick="Button_Click"/>
                    <asp:Button ID="btnTimKiem" runat="server" Height="30px" Text="Tìm kiếm" Width="120px" OnClick="Button_Click"/>
                    <asp:Button ID="btnLuu" runat="server" Height="30px" Text="Lưu" Width="120px" OnClick="Button_Click"/>
                    <asp:Button ID="btnHuy" runat="server" Height="30px" Text="Hủy" Width="120px" OnClick="Button_Click"/>
            </asp:Panel>
            <br /><br />
        </asp:Panel>

    </asp:Panel>
</asp:Content>
