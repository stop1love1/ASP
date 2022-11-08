<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HalBookstore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container">
        <div class="row">
        <div class="col-md-4" style="background: #048D02; height: 90px; color: white;">
            <div class="col-md-8">
                <center><br />
                <asp:Label ID="Label1" runat="server" Text="Sản phẩm đã bán" Font-Size="16px"></asp:Label><br />
                <asp:Label ID="lblSanPhamDaBan" runat="server" Text="28" Font-Size="16px"></asp:Label>
                </center>
            </div>
            <div class="col-md-4">
                <asp:Image ID="Image1" runat="server" />
            </div>
        </div>
        <div class="col-md-4" style="background: #D18F1C; height: 90px;">
            <div class="col-md-8">
                <center><br />
                <asp:Label ID="Label3" runat="server" Text="Tổng doanh thu" Font-Size="16px"></asp:Label><br />
                <asp:Label ID="lblTongDoanhThu" runat="server" Text="1000000 đ" Font-Size="16px"></asp:Label>
                </center>
            </div>
            <div class="col-md-4">
                <asp:Image ID="Image2" runat="server" />
            </div>
        </div>
        <div class="col-md-4" style="background: #38D1DC; height: 90px;">
            <div class="col-md-8">
                <center><br />
                <asp:Label ID="Label5" runat="server" Text="Tổng khách hàng" Font-Size="16px"></asp:Label><br />
                <asp:Label ID="lblTongKhachHang" runat="server" Text="7" Font-Size="16px"></asp:Label>
                </center>
            </div>
            <div class="col-md-4">
                <asp:Image ID="Image3" runat="server" />
            </div>
        </div>
        </div>
    </div>

    <div class="container">
        <div class="row" style="margin-top: 5px;">
            <div class="col-md-6" style="background: #1C83D1; height: 60px; color: white;">
                <div class="col-md-5">
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Biểu đồ doanh thu" Font-Size="16px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <br />
                    <asp:DropDownList ID="cbLeftRevenue" runat="server" Width="120px" Font-Size="16px" style="float: right;" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="cbLeftRevenue_SelectedIndexChanged">
                        <asp:ListItem>Hôm nay</asp:ListItem>
                        <asp:ListItem>1 tuần</asp:ListItem>
                        <asp:ListItem>1 tháng</asp:ListItem>
                        <asp:ListItem>Từ trước đến nay</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6" style="background: #1C65D1; height: 60px; color: white;">
                <div class="col-md-5">
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Top 5 sản phẩm bán chạy" Font-Size="16px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <br />
                    <asp:DropDownList ID="cbRightChart" runat="server" Width="120px" Font-Size="16px" style="float: right;" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="cbRightChart_SelectedIndexChanged">
                        <asp:ListItem>Hôm nay</asp:ListItem>
                        <asp:ListItem>1 tuần</asp:ListItem>
                        <asp:ListItem>1 tháng</asp:ListItem>
                        <asp:ListItem>Từ trước đến nay</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-6" style="height: 400px;">
                <div class="col-lg-2" style="margin-top: 25%;">
                    <center>
                        <asp:Label ID="lblLeftDate" runat="server" Text="02/11/2022" Font-Size="16px"></asp:Label>
                    </center>
                </div>
                <div class="col-lg-7" style="margin-top: 5%;">
                    <div style="width: 280px;">
                        <div class="col-lg-3">
                            <asp:Panel ID="Panel1" runat="server" Width="70px" Height="300px" style="border: solid 1px;">
                                <asp:Panel ID="panelLeftRevenue" runat="server"  Width="80px" Height="80px" BackColor="#49ECEC" style="margin-top: 150%;" BorderStyle="Solid" BorderWidth="1px"></asp:Panel>
                            </asp:Panel>
                        </div>
                        <div class="col-lg-3">
                            <asp:Panel ID="Panel2" runat="server" Width="70px" Height="300px" style="border: solid 1px;"></asp:Panel>
                        </div>
                        <div class="col-lg-3">
                            <asp:Panel ID="Panel3" runat="server" Width="140px" Height="300px" style="border: solid 1px;"></asp:Panel>
                        </div>
                    </div>
                    <div style="margin-top: 105%;">
                        <asp:Label ID="Label12" runat="server" Text="0" style="margin-left: 10px;"></asp:Label>
                        <asp:Label ID="Label13" runat="server" Text="5000000" style="margin-left: 45px;"></asp:Label>
                        <asp:Label ID="Label14" runat="server" Text="10000000" style="margin-left: 5px;"></asp:Label>
                        <asp:Label ID="Label15" runat="server" Text="20000000" style="margin-left: 35px;"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-3">
                    <br />
                    <div style="background: #49ECEC; width: 40px; height: 15px;"></div>
                    <asp:Label ID="Label10" runat="server" Text="Doanh thu" Font-Size="16px"></asp:Label>
                    <div style="margin-top: 70%;">
                        <asp:Label ID="lblLeftRevenue" runat="server" Text="0 đ" Font-Size="16px"></asp:Label>
                    </div>
                </div>
            </div>
            
            <div class="col-md-6">
        <div class="col-md-7">
                    <center>
                        <br />
                        <asp:Label ID="Label16" runat="server" Text="Biểu đồ" Font-Size="22px"></asp:Label>
            <asp:Chart ID="chartTopProducts" runat="server" Height="320px">
                <Series>
                    <asp:Series Name="Series1" YValuesPerPoint="5"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
                    </center>
                </div>
                <div class="col-md-5">
                    <center>
                        <br /><br />
                        <asp:Label ID="lbl1" runat="server" Text="1. Chưa có sản phẩm được bán"></asp:Label><br /><br />
                        <asp:Label ID="lbl2" runat="server" Text="2. Chưa có sản phẩm được bán"></asp:Label><br /><br />
                        <asp:Label ID="lbl3" runat="server" Text="3. Chưa có sản phẩm được bán"></asp:Label><br /><br />
                        <asp:Label ID="lbl4" runat="server" Text="4. Chưa có sản phẩm được bán"></asp:Label><br /><br />
                        <asp:Label ID="lbl5" runat="server" Text="5. Chưa có sản phẩm được bán"></asp:Label>
                    </center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
