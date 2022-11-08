<%@ Page Title="Quản lý nhân viên" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staffform.aspx.cs" Inherits="HalBookstore.Staffform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="637px">
        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="Quản lý nhân viên" ForeColor="Blue" Font-Size="20"></asp:Label><br />
        <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="#009933" Font-Size="14"></asp:Label>
        </center>
            <br />
        <div class="rowright">
        </div>
        <br />
        <asp:GridView ID="GridViewStaff" runat="server" Height="295px" Width="100%" AutoGenerateSelectButton="True" BorderColor="Tan" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewStaff_SelectedIndexChanged" BackColor="LightGoldenrodYellow" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" >
            
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            
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
            <div style="border: solid 1px; width: 60%;  margin-left: 20%; height: auto;"><br />
            <asp:Panel ID="pnInformation" runat="server" Height="350px">
                <div class="left-column">
                    <asp:Label ID="Label7" runat="server" Text="Họ tên" class="lblnguoidung3"></asp:Label>
                    <asp:TextBox ID="txtNguoiDung3" runat="server" class="txtnguoidung3"></asp:TextBox><br /><br />
                    <asp:Label ID="Label9" runat="server" Text="Tài khoản" class="lbltaikhoan3"></asp:Label>
                    <asp:TextBox ID="txtTaiKhoan3" runat="server" class="txttaikhoan3"></asp:TextBox><br /><br /><br />
                    <asp:Label ID="Label3" runat="server" Text="Giới tính" class="lblgioitinh"></asp:Label>
                    <asp:CheckBox ID="ckbNam" runat="server" Text="Nam" class="ckbgioitinh" OnCheckedChanged="CheckBox_CheckedChanged"/>
                    <asp:CheckBox ID="ckbNu" runat="server" Text="Nữ" style="margin-left: 30px;"/><br /><br />
                    <asp:Label ID="Label2" runat="server" Text="Ngày sinh" Font-Size="16px" class="lblngaysinh"></asp:Label>
                    <asp:TextBox ID="txtNgaySinh" runat="server" class="txtngaysinh"></asp:TextBox><br /><br />
                    <asp:Label ID="Label6" runat="server" Text="Ngày vào làm" class="lblngaythamgia"></asp:Label>
                    <asp:TextBox ID="txtNgayVao" runat="server" class="txtngaythamgia"></asp:TextBox><br /><br />
                </div>
                <div class="right-column">
                    <asp:Label ID="Label8" runat="server" Text="Quê quán" class="lbldiachi"></asp:Label>
                    <asp:TextBox ID="txtDiaChi3" runat="server" class="txtdiachi"></asp:TextBox><br /><br />
                    <asp:Label ID="Label4" runat="server" Text="Điện thoại" class="lbldienthoai"></asp:Label>
                    <asp:TextBox ID="txtDienThoai3" runat="server" class="txtdienthoai" TextMode="Phone"></asp:TextBox><br /><br />
                    <asp:Label ID="Label5" runat="server" Text="Email" class="lblemail"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" class="txtemail" TextMode="Email"></asp:TextBox><br /><br />
                    <asp:Label ID="Label12" runat="server" Text="Ghi chú" class="lblghichu"></asp:Label><br />
                    <asp:TextBox ID="txtGhiChu" runat="server" placeholder="Nội dung" class="txtghichu" Height="75px" TextMode="MultiLine" Width="249px"></asp:TextBox> <br /><br />
                </div>  
            </asp:Panel>
                </div>
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
