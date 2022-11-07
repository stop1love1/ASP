<%@ Page Title="Quản lý khách hàng" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customform.aspx.cs" Inherits="HalBookstore.Nhanvienform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="637px">
        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="Quản lý khách hàng" ForeColor="Blue" Font-Size="20"></asp:Label><br />
        <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="#009933" Font-Size="14"></asp:Label>
        </center>
            <br />
        <div class="rowright">
            <asp:Label ID="Label10" runat="server" Text="Từ ngày: "></asp:Label>
            <asp:TextBox ID="txtTuNgay4" runat="server" TextMode="date"></asp:TextBox>
            <asp:Label ID="Label11" runat="server" Text="đến"></asp:Label>
            <asp:TextBox ID="txtDenNgay4" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <br />
        <asp:GridView ID="GridViewCustom" runat="server" Height="295px" Width="100%" AutoGenerateSelectButton="True" BorderColor="Black" BorderStyle="Inset" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewCustom_SelectedIndexChanged" >
            
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
            <asp:Panel ID="pnInformation" runat="server" Height="270px">
                <div class="left-column">
                    <asp:Label ID="Label2" runat="server" Text="Tên tài khoản" Font-Size="16px" class="lbltentaikhoan"></asp:Label>
                    <asp:TextBox ID="txtTenTaiKhoan2" runat="server" class="txttentaikhoan"></asp:TextBox><br /><br />
                    <asp:Label ID="Label7" runat="server" Text="Tên người dùng" Font-Size="16px" class="lblnguoidung"></asp:Label>
                    <asp:TextBox ID="txtnguoidung2" runat="server" class="txtnguoidung"></asp:TextBox><br /><br /><br /><br />
                    <asp:Label ID="Label3" runat="server" Text="Giới tính" style="margin-left: 50px; font-size: 16px;"></asp:Label>
                    <asp:CheckBox ID="ckbNam" runat="server" Text="Nam" style="margin-left: 60px;" OnCheckedChanged="CheckBox_CheckedChanged"/>
                    <asp:CheckBox ID="ckbNu" runat="server" Text="Nữ" style="margin-left: 30px;" OnCheckedChanged="CheckBox_CheckedChanged"/><br /><br />
                </div>
                <div class="right-column">
                    <asp:Label ID="Label8" runat="server" Text="Địa chỉ" class="lbldiachi"></asp:Label>
                    <asp:TextBox ID="txtdiachi" runat="server" class="txtdiachi"></asp:TextBox><br /><br />
                    <asp:Label ID="Label4" runat="server" Text="Điện thoại" class="lbldienthoai"></asp:Label>
                    <asp:TextBox ID="txtdienthoai" runat="server" class="txtdienthoai"></asp:TextBox><br /><br />
                    <asp:Label ID="Label12" runat="server" Text="Ghi chú" class="lblghichu"></asp:Label><br />
                    <asp:TextBox ID="txtGhiChu" runat="server" placeholder="Nội dung" class="txtghichu" TextMode="MultiLine"></asp:TextBox> <br /><br />
                </div>  
                <br />
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
