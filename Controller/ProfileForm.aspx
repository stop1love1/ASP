<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileForm.aspx.cs" Inherits="HalBookstore.Controller.ProfileForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thông tin cá nhân</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" />
    
    <link rel="stylesheet" href="~/Content/css/Profile.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container rounded bg-white mt-5 mb-5">
    <div class="row">
        <div class="col-md-3 border-right">
        </div>
        <div class="col-md-5 border-right">
            <div class="p-3 py-5">
                <center>
                    <h4>Thông tin cá nhân</h4>
                </center>
                
                <div class="row mt-2">
                    <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" class="labels" Text="Họ tên" Font-Size="16px"></asp:Label>
                        <asp:TextBox ID="txtHoTen" runat="server" type="text" class="form-control" placeholder="Nhập tên"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" class="labels" Text="Số điện thoại" Font-Size="16px"></asp:Label>
                        <asp:TextBox ID="txtDienThoai" runat="server" type="text" class="form-control" placeholder="Nhập số điện thoại"></asp:TextBox>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-md-12">
                        <asp:Label ID="Label3" runat="server" class="labels" Text="Giới tính" Font-Size="16px"></asp:Label><br />
                        <asp:CheckBox ID="cbxNam" runat="server" Text="Nam" style="margin-left: 20px;" OnDisposed="Checkbox_CheckedChanged"/>
                        <asp:CheckBox ID="cbxNu" runat="server"  Text="Nữ" style="margin-left: 30px;" OnCheckedChanged="Checkbox_CheckedChanged"/>
                    </div>
                    
                    <div class="col-md-12">
                        <asp:Label ID="Label7" runat="server" class="labels" Text="Quê quán" Font-Size="16px"></asp:Label>
                        <asp:TextBox ID="txtquequan" runat="server" type="text" class="form-control" placeholder="Nhập quê quán"></asp:TextBox>
                    </div>

                    <div class="col-md-12">
                        <asp:Label ID="Label4" runat="server" class="labels" Text="Email" Font-Size="16px"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" type="text" class="form-control" placeholder="Nhập Email"></asp:TextBox>
                    </div>

                    <div class="row mt-2">      
                        <div class="col-md-6">
                        <asp:Label ID="Label6" runat="server" class="labels" Text="Ngày sinh" Font-Size="16px"></asp:Label>
                        <asp:TextBox ID="txtNgaySinh" runat="server" class="form-control"></asp:TextBox>
                        </div> 
                    </div>
                </div>
                <div class="mt-5 text-center">
                    <asp:Button ID="btnluu" runat="server" Text="Lưu thông tin" class="btn btn-primary profile-button" type="button" OnClick="btnluu_Click"/>
                </div>
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
