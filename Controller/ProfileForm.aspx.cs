using HalBookstore.Connect;
using HalBookstore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalBookstore.Controller
{
    public partial class ProfileForm : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            string user = dao.GetFromCookie("userHal", "");
            Staff staff = dao.GetStaffs($"SELECT * FROM STAFF WHERE STAFF.USERNAME = '{user}'")[0];
            txtHoTen.Text = staff.Name;
            txtDienThoai.Text = staff.NumberPhone;
            txtEmail.Text = staff.Email;
            txtquequan.Text = staff.Country;
            txtNgaySinh.Text = staff.Birthday;
            if (staff.Gender == "Nam")
            {
                cbxNam.Checked = true;
                cbxNu.Checked = false;
            }
            else
            {
                cbxNam.Checked = false;
                cbxNu.Checked = true;
            }
        }
        bool ValdidateForm()
        {
            if (txtHoTen.Text.Trim()=="")
            {
                return false;
            }

            if (txtDienThoai.Text.Trim() == "")
            {
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                return false;
            }
            if (txtquequan.Text.Trim() == "")
            {
                return false;
            }
            if (txtNgaySinh.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }
        protected void btnluu_Click(object sender, EventArgs e)
        {
            if (ValdidateForm())
            {
                string user = dao.GetFromCookie("userHal", "");
                string name = txtHoTen.Text.Trim();
                string phone = txtDienThoai.Text.Trim();
                string country = txtquequan.Text.Trim();
                string email = txtEmail.Text.Trim();
                string birth = txtNgaySinh.Text.Trim();
                string gender = cbxNam.Checked == true ? "Nam" : "Nữ";
                string sql = $"UPDATE STAFF SET [NAME]='{name}', [GENDER]='{gender}', [BIRTHDAY]='{birth}', [COUNTRY]='{country}', " +
                        $" [NUMBERPHONE]='{phone}', [EMAIL]='{email}' WHERE [USERNAME]='{user}'";
                dao.InsertOrUpdateOrDelete(sql);
                Response.Write("<script>alert(\"Cập nhật thành công\")</script>");
            }
        }

        protected void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkBox == cbxNam)
            {
                cbxNam.Checked = true;
                cbxNu.Checked = false;
            }
            else
            {
                cbxNam.Checked = false;
                cbxNu.Checked = true;
            }
        }
    }
}