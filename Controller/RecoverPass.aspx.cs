using HalBookstore.Connect;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalBookstore.Controller
{
    public partial class RecoverPass : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
        }

        bool ValdidateForm()
        {
            if (txtMatKhauCu.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập mật khẩu cũ!";
                return false;
            }
            if (txtMatKhauMoi.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập mật khẩu mới!";
                return false;
            }
            if (txtMatKhauMoi2.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy xác nhận mật khẩu mới!";
                return false;
            }
            if (txtMatKhauMoi2.Text.Trim() != txtMatKhauMoi.Text.Trim())
            {
                lblAlert.Text = "Xác nhận mật khẩu mới không trùng khớp!";
                return false;
            }
            if(txtMatKhauMoi.Text.Contains(" "))
            {
                lblAlert.Text = "Mật khẩu không bao gồm khoảng trắng!";
                return false;
            }
            return true;
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValdidateForm())
            {
                string pass = txtMatKhauMoi.Text;
                string user = dao.GetFromCookie("userHal", "");
                string sql = $"UPDATE ACCOUNT SET [PASSWORD]='{pass}' WHERE [USERNAME]='{user}'";
                dao.InsertOrUpdateOrDelete(sql);
                lblAlert.Text = "Đổi mật khẩu thành công";
                Thread.Sleep(3000);
                Response.Redirect("./Controller/Loginform.aspx");
            }
        }
    }
}