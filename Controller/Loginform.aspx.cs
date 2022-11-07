using HalBookstore.Connect;
using HalBookstore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalBookstore
{
    public partial class Formlogin : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
        }
        bool ValdidateForm()
        {
            if (txtUsername.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập tài khoản!";
                return false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập mật khẩu!";
                return false;
            }
            return true;
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ValdidateForm())
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                int permisson = DropDownListPermisson.SelectedValue == "Admin" ? 1 : 0;
                string sql = $"SELECT * FROM ACCOUNT WHERE ACCOUNT.USERNAME = '{username}' AND ACCOUNT.PASSWORD = '{password}' ";
                sql += permisson == 1 ? " AND ACCOUNT.ISADMIN = 1" : " AND ACCOUNT.ISSTAFF = 1" ;
                List<Account> accounts = dao.GetAccounts(sql);
                if (accounts.Count > 0)
                {
                    lblAlert.Text = "Đăng nhập thành công.";
                    Account account = accounts[0];
                    dao.StoreInCookie("userHal", "", account.Username, DateTime.Now.AddHours(1));
                    dao.StoreInCookie("passHal", "", account.Password, DateTime.Now.AddHours(1));
                    dao.StoreInCookie("permissHal", "", permisson.ToString(), DateTime.Now.AddHours(1));
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblAlert.Text = "Hãy kiểm tra lại tài khoản và mật khẩu!";
                }
            }
        }
    }
}