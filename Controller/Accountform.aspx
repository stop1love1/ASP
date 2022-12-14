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
        <asp:GridView ID="GridViewAccount" runat="server" Height="295px" Width="100%" AutoGenerateSelectButton="True" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewAccount_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
          <asp:Panel ID="pnInformation" runat="server" Height="170px">
                <div class="left-column">
                    <asp:Label ID="Label2" runat="server" Text="Tên tài khoản" Font-Size="16px" class="lbltentaikhoan"></asp:Label>
                    <asp:TextBox ID="txtTaiKhoan" runat="server" class="txttentaikhoan"></asp:TextBox><br /><br />
                    <asp:Label ID="Label7" runat="server" Text="Tên người dùng" Font-Size="16px" class="lblnguoidung"></asp:Label>
                    <asp:TextBox ID="txtNguoiDung" runat="server" class="txtnguoidung"></asp:TextBox><br /><br />
                    <br /><br />
                </div>
                <div class="right-column">
                    <asp:CheckBox ID="ckbadmin" runat="server" class="ckbadmin" AutoPostBack="True" Text=" Admin" style="margin-left: 25%;"/><br /><br /><br /><br />
                    <asp:CheckBox ID="ckbnhanvien" runat="server" class="ckbnhanvien" AutoPostBack="True" Text="Nhân viên" style="margin-left: 25%;"/>
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
