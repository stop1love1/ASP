using HalBookstore.Connect;
using HalBookstore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalBookstore
{
    public partial class Registerform : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
        }

        bool ValdidateForm()
        {
            if (txtTaiKhoan.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập tài khoản!";
                return false;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập mật khẩu!";
                return false;
            }
            if (txtMatKhau2.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập lại mật khẩu!";
                return false;
            }
            if (txtMatKhau.Text != txtMatKhau2.Text)
            {
                lblAlert.Text = "Xác nhận mật khẩu không trùng khớp!";
                return false;
            }
            if (txtTaiKhoan.Text.Trim().Length < 6)
            {
                lblAlert.Text = "Độ dài tài khoản phải >= 6 kí tự!";
                return false;
            }
            if(txtTaiKhoan.Text.Trim().Contains(" ")){
                lblAlert.Text = "Tài khoản không bao gồm dấu cách!";
                return false;
            }
            if (txtMatKhau.Text.Trim().Contains(" ")){
                lblAlert.Text = "Mật khẩu không bao gồm dấu cách!";
                return false;
            }
            return true;
        }
        protected void btnregister_Click(object sender, EventArgs e)
        {
            if (ValdidateForm())
            {
                string username = txtTaiKhoan.Text.Trim();
                string password = txtMatKhau.Text.Trim();
                List<Account> accounts = dao.GetAccounts($"SELECT * FROM ACCOUNT WHERE ACCOUNT.USERNAME = '{username}'");
                if (accounts.Count > 0)
                {
                    lblAlert.Text = "Tài khoản này đã tồn tại!";
                }
                else
                {
                    string sql = $"INSERT INTO ACCOUNT([USERNAME], [PASSWORD], [NAME], [SECURITY], [ISSTAFF], [ISADMIN], [CREATE_AT], [UPDATE_AT]) VALUES ('{username}','{password}','null','null','0','0','{DateTime.Now}','{DateTime.Now}')";
                    dao.InsertOrUpdateOrDelete(sql);
                    lblAlert.Text = "Đăng ký thành công.";
                    Thread.Sleep(3000);
                    Response.Redirect("~/Controller/Loginform.aspx");
                }
            }
        }
    }
}