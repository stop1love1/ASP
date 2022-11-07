using HalBookstore.Connect;
using HalBookstore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HalBookstore
{
    public partial class ChangePasswordForm : System.Web.UI.Page
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
            if (txtBaoMat.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập mã bảo mật!";
                return false;
            }
            return true;
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ValdidateForm())
            {
                string user = txtTaiKhoan.Text.Trim();
                string security = txtBaoMat.Text.Trim();
                List<Account> accounts = dao.GetAccounts($"SELECT * FROM ACCOUNT WHERE ACCOUNT.USERNAME = '{user}' AND ACCOUNT.SECURITY = '{security}'");
                if (accounts.Count > 0)
                {
                    lblAlert.Text = $"Mật khẩu của bạn là: {accounts[0].Password}";
                }
                else
                {
                    lblAlert.Text = "Tài khoản này chưa được đăng ký!";
                }
            }
        }
    }
}