<%@ Page Title="Quản lý sản phẩm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="HalBookstore.ProductForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server" Height="637px">
        <br />
        <center>
            <asp:Label ID="Label1" runat="server" Text="Quản lý sản phẩm" ForeColor="Blue" Font-Size="20"></asp:Label><br />
            <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="#009933" Font-Size="14"></asp:Label>
        </center>
        <div class="rowright">
            <asp:Label ID="Label7" runat="server" Text="Từ ngày: "></asp:Label>
            <asp:TextBox ID="txtTuNgay" runat="server" TextMode="date" OnTextChanged="txtTuNgay_TextChanged" AutoPostBack="True">01-01-2022</asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="đến"></asp:Label>
            <asp:TextBox ID="txtDenNgay" runat="server" TextMode="Date" OnTextChanged="txtTuNgay_TextChanged" AutoPostBack="True">31-12-2022</asp:TextBox>
        </div>
        <br />
        <asp:GridView ID="GridViewProducts" runat="server" Height="295px" Width="100%" AutoGenerateSelectButton="True" BorderColor="#DEDFDE" BorderStyle="None" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewProducts_SelectedIndexChanged" BackColor="White" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
            
        </asp:GridView>
        <asp:Panel ID="Panel2" runat="server" Height="31px"><br />
            <asp:Panel ID="pnControl" runat="server" Height="47px" class="content">
            <strong>
            <asp:Button ID="btnDLeft" runat="server" style="font-weight: bold" Text="&lt;&lt;" Width="60px" OnClick="ButtonCRUD_Click"/>
            </strong>
            <asp:Button ID="btnLeft" runat="server" style="font-weight: bold" Text="&lt;" Width="60px" OnClick="ButtonCRUD_Click" />
            <strong>
            <asp:Label ID="lblCount" runat="server" Font-Size="10pt" Text="00/00"></asp:Label>
            </strong>
            <asp:Button ID="btnRight" runat="server" style="font-weight: bold" Text="&gt;" Width="60px" OnClick="ButtonCRUD_Click" />
            <strong>
            <asp:Button ID="btnDRight" runat="server" style="font-weight: bold" Text="&gt;&gt;" Width="60px"  OnClick="ButtonCRUD_Click"/>
            </strong>
                 </asp:Panel>
            <br />
            <div style="border: solid 1px; width: 870px; height:auto; text-align: center; margin-left: 150px;"><br />
            <asp:Panel ID="pnInformation" runat="server" Height="230px">
                <div class="left-column">
                    <asp:Label ID="Label2" runat="server" Text="Tên sách" Font-Size="16px" class="lbltensach"></asp:Label>
                    <asp:TextBox ID="txtTenSach" runat="server" class="txttensach" TextMode="MultiLine"></asp:TextBox><br /><br />
                    <asp:Label ID="Label3" runat="server" Text="Ảnh" Font-Size="16px" class="lblimage"></asp:Label> 
                    <asp:TextBox ID="txtImage" runat="server" class="txtimage"></asp:TextBox><br />
                    <br />
                    <asp:Image ID="ImageSach" runat="server" class="image" Height="100px" Width="100px" />
                </div>
                <div class="right-column">
                    <asp:Label ID="Label6" runat="server" Text="Danh mục" class="lbllistcate"></asp:Label>
                    <asp:DropDownList ID="DropDownListCategory" runat="server" class="listcate" AutoPostBack="True">
                        <asp:ListItem>--- Tất cả sản phẩm ---</asp:ListItem>
                        <asp:ListItem>Bách khoa toàn thư</asp:ListItem>
                        <asp:ListItem>Truyện ngắn</asp:ListItem>
                        <asp:ListItem>Tiểu thuyết</asp:ListItem>
                        <asp:ListItem>Kĩ năng sống</asp:ListItem>
                        <asp:ListItem>Tiếng Anh</asp:ListItem>
                    </asp:DropDownList> <br /><br />
                    <asp:Label ID="Label4" runat="server" Text="Đơn giá" class="lbldongia"></asp:Label>
                    <asp:TextBox ID="txtDonGia" runat="server" TextMode="Number" class="txtdongia"></asp:TextBox><br /><br />
                    <asp:Label ID="Label5" runat="server" Text="Số lượng" class="lblsoluong"></asp:Label>
                    <asp:TextBox ID="txtSoLuong" runat="server" TextMode="Number" class="txtsoluong"></asp:TextBox>
                </div>  
                <br />
            </asp:Panel>
                </div>
            <asp:Panel ID="Panel4" runat="server" Height="40px" class="content"><br />
                    <asp:Button ID="btnThem" runat="server" Height="30px" Text="Thêm mới" Width="120px" OnClick="ButtonCRUD_Click" />
                    <asp:Button ID="btnSua" runat="server" Height="30px" Text="Sửa" Width="120px" OnClick="ButtonCRUD_Click"/>
                    <asp:Button ID="btnXoa" runat="server" Height="30px" Text="Xóa" Width="120px" OnClick="ButtonCRUD_Click"/>
                    <asp:Button ID="btnTimKiem" runat="server" Height="30px" Text="Tìm kiếm" Width="120px" OnClick="ButtonCRUD_Click" />
                    <asp:Button ID="btnXuatFile" runat="server" Height="30px" Text="Xuất File" Width="120px" OnClick="ButtonCRUD_Click" />
                    <asp:Button ID="btnLuu" runat="server" Height="30px" Text="Lưu" Width="120px" OnClick="ButtonCRUD_Click"/>
                    <asp:Button ID="btnHuy" runat="server" Height="30px" Text="Hủy" Width="120px" OnClick="ButtonCRUD_Click" />
            </asp:Panel>
            <br />
            
        </asp:Panel>

    </asp:Panel>

</asp:Content>