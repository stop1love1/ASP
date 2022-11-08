<%@ Page Title="Thống kê" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThongKeForm.aspx.cs" Inherits="HalBookstore.Controller.ThongKeForm" EnableEventValidation="false"  %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style type="text/css">
        .menuTabs
        {
            position:relative;
            top:1px;
            left:10px;
        }
        .tab
        {
            border:Solid 1px black;
            border-bottom:none;
            padding:0px 10px;
            background-color:#eeeeee;
        }
        .selectedTab
        {
            border:Solid 1px black;
            border-bottom:Solid 1px white;
            padding:0px 10px;
            background-color:white;
        }
        .tabBody
        {
            border:Solid 1px black;
            height: 600px;
            background-color:white;
        }
    </style>

    <div>
    
    <asp:Menu
        id="menuTabs"
        CssClass="menuTabs"
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="selectedTab"
        Orientation="Horizontal"
        OnMenuItemClick="menuTabs_MenuItemClick"
        Runat="server">
        <Items>
        <asp:MenuItem
            Text="Doanh thu nhân viên - "
            Value="0" 
            Selected="true" />
        <asp:MenuItem
            Text="Nhập hàng vào kho - " 
            Value="1"/>
        <asp:MenuItem
            Text="Hoá đơn đã bán"
            Value="2" />
        </Items>
    </asp:Menu>    
    
    <div class="tabBody">
    <asp:MultiView id="multiTabs" ActiveViewIndex="0" Runat="server">
        <asp:View ID="view1" runat="server">
            <div class="col-md-8">
            <asp:Panel ID="Panel1" runat="server" style="margin-top: 10px; margin-left: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Từ" style="font-size: 16px;"></asp:Label>
                <asp:TextBox ID="txtTuNgay" runat="server" TextMode="Date" style="font-size: 16px;" AutoPostBack="True" OnTextChanged="txtTuNgay_TextChanged"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="đến" style="font-size: 16px;"></asp:Label>
                <asp:TextBox ID="txtDenNgay" runat="server" TextMode="Date" style="font-size: 16px;" AutoPostBack="True" OnTextChanged="txtTuNgay_TextChanged"></asp:TextBox>

                <asp:TextBox ID="txtSearch" runat="server" style="margin-left: 30px; font-size: 16px;"></asp:TextBox>
                <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" style="margin-right: 30px; font-size: 16px;" OnClick="btnTimKiem_Click"/>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" style="margin-top: 10px; margin-left: 30px;">
                <asp:GridView ID="GridViewDTNV" runat="server" Font-Size="16px" style="width:700px;" CellPadding="4" ForeColor="#333333" GridLines="None">
                    
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    
                </asp:GridView>
            </asp:Panel>
            </div>
           <div class="col-md-4" style="margin-top: 3%; float: right;">
                    <div style="width: 350px; height: 350px; margin-top: 10px;">
                        <center>
                            <asp:Label ID="Label3" runat="server" Text="Bảng xếp hạng" style="margin-top: 100px; font-size: 30px;"></asp:Label><br /><br /><br />
                        </center>
                        <asp:Label ID="lblTop1" runat="server" Text="Top 1:" style="font-size: 16px; color: red;"></asp:Label><br /><br /><br />
                        <asp:Label ID="lblTop2" runat="server" Text="Top 2:" style="font-size: 16px; color: green;"></asp:Label><br /><br /><br />
                        <asp:Label ID="lblTop3" runat="server" Text="Top 3:" style="font-size: 16px; color: #bf5f00"></asp:Label><br /><br /><br />
                </div>
            </div>
        </asp:View>
        <asp:View ID="view2" runat="server">
            <br />
            <asp:Chart ID="chartProduct" runat="server" Width="1100px" Height="500px">
                <Series>
                    <asp:Series Name="Series1" YValuesPerPoint="13"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </asp:View>
        <asp:View ID="view3" runat="server">
            <br />
            <asp:GridView ID="gridViewBill" runat="server" style="margin-left: 10px; width: 1140px; height: 520px;" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewBill_SelectedIndexChanged">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <div style="float: left; margin-left: 30px;"><br />
                <asp:Label ID="lblCount" runat="server" Text="Tổng 9 hoá đơn đã bán" Font-Size="16px"></asp:Label>
            </div>
            <div style="float: right; margin-right: 30px;"><br />
                <asp:LinkButton ID="btnDetail" runat="server" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" Font-Size="16px" OnClick="btnDetail_Click">Xem chi tiết</asp:LinkButton>

            </div>
        </asp:View>
    </asp:MultiView>    
    </div>
        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document" style="margin-left: 15%;">
            <div class="modal-content" style="width: 900px;">
                <div class="modal-header">
                    <center>
                        <asp:Label ID="Label4" runat="server" class="modal-title" Text="Thông tin chi tiết" Font-Bold="true" Font-Size="20px"></asp:Label><br />
                        <asp:Label ID="lblCountDetail" runat="server" Text="3 sản phẩm"></asp:Label>
                    </center>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="gridViewDetail" runat="server"></asp:GridView>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnThoat" runat="server" type="button" class="btn btn-secondary" data-dismiss="modal" Text="Thoát" />
                    <asp:Button ID="btnXuatFile" runat="server" type="button" class="btn btn-primary" Text="Xuất file" OnClick="btnXuatFile_Click" />
                </div>
            </div>
        </div>
    </div>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </div>
</asp:Content>
