using HalBookstore.Connect;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalBookstore
{
    public partial class Staffform : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            LoadData("SELECT * FROM STAFF");
            if (!IsPostBack)
            {
                SelectedRow(0);
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button == btnSua)
            {
                Update();
            }
            if(button == btnXoa)
            {
                Delete();
            }
            if (button == btnTimKiem)
            {
                Search();
            }
            if (button == btnLuu)
            {
                Save();
            }
            if (button == btnHuy)
            {
                Cancel();
            }
            if (button == btnDLeft)
            {
                SelectedRow(0);
            }
            if (button == btnLeft)
            {
                try
                {
                    SelectedRow(GridViewStaff.SelectedIndex - 1);
                }
                catch
                {
                    SelectedRow(GridViewStaff.Rows.Count - 1);
                }
            }
            if (button == btnRight)
            {
                try
                {
                    SelectedRow(GridViewStaff.SelectedIndex + 1);
                }
                catch
                {
                    SelectedRow(0);
                }
            }
            if (button == btnDRight)
            {
                SelectedRow(GridViewStaff.Rows.Count-1);
            }
        }
        void Update()
        {
            lblAlert.Text = $"Đang sửa mã nhân viên {GridViewStaff.Rows[GridViewStaff.SelectedIndex].Cells[1].Text}";
            Lock(false);
        }
        void Delete()
        {
            string id = GridViewStaff.Rows[GridViewStaff.SelectedIndex].Cells[1].Text;
            dao.InsertOrUpdateOrDelete($"DELETE FROM STAFF WHERE [ID] = {id}");
            lblAlert.Text = "Xóa thành công";
            SelectedRow(0);
        }
        void Search()
        {
            if (lblAlert.Text!="Tìm kiếm")
            {
                lblAlert.Text = "Tìm kiếm";
                txtNguoiDung3.Text = "";
                txtEmail.Text = "";
                txtDiaChi3.Text = "";
                txtDienThoai3.Text = "";
                txtTaiKhoan3.Text = "";
                txtNgaySinh.Text = "";
                txtNgayVao.Text = "";
                txtNguoiDung3.ReadOnly = false;
                txtNgaySinh.ReadOnly = false;
                txtDiaChi3.ReadOnly = false;
                txtDienThoai3.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtGhiChu.ReadOnly = false;
                txtNgayVao.ReadOnly = false;
            }
            else
            {
                string sql = "SELECT * FROM STAFF WHERE ";
                string dk = " 1=1 ";
                if (txtNguoiDung3.Text.Trim() != "")
                {
                    dk += string.Format(" AND [NAME] LIKE '%{0}%'",txtNguoiDung3.Text.Trim());
                }
                if (txtTaiKhoan3.Text.Trim() != "")
                {
                    dk += string.Format(" AND [USERNAME] LIKE '%{0}%'", txtTaiKhoan3.Text.Trim());
                }
                if (txtDiaChi3.Text.Trim() != "")
                {
                    dk += string.Format(" AND [COUNTRY] LIKE '%{0}%'", txtDiaChi3.Text.Trim());
                }
                if (txtDienThoai3.Text.Trim() != "")
                {
                    dk += string.Format(" AND [NUMBERPHONE] LIKE '%{0}%'", txtDienThoai3.Text.Trim());
                }
                if (txtEmail.Text.Trim() != "")
                {
                    dk += string.Format(" AND [EMAIL] LIKE '%{0}%'", txtEmail.Text.Trim());
                }
                if (txtNgaySinh.Text.Trim() != "")
                {
                    dk += string.Format(" AND [BIRTHDAY] >= #{0}#", txtNgaySinh.Text.Trim());
                }
                if (txtNgayVao.Text.Trim() != "")
                {
                    dk += string.Format(" AND [START_DAY_WORK] >= #{0}#", txtNgayVao.Text.Trim());
                }
                try
                {
                    LoadData(sql + dk);
                    lblAlert.Text = $"Tìm thấy {GridViewStaff.Rows.Count} nhân viên";
                    SelectedRow(0);
                }
                catch { lblAlert.Text = "Định dạng ngày tháng sai!"; }
            }
        }
        void Save()
        {
            if (lblAlert.Text.Trim().Contains("Đang sửa"))
            {
                if (ValdidateForm())
                {
                    string id = GridViewStaff.Rows[GridViewStaff.SelectedIndex].Cells[1].Text;
                    string name = txtNguoiDung3.Text.Trim();
                    string country = txtDiaChi3.Text.Trim();
                    string numberphone = txtDienThoai3.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string user = txtTaiKhoan3.Text.Trim();
                    string gender = ckbNam.Checked == true ? "Nam" : "Nữ";
                    string note = txtGhiChu.Text.Trim();
                    string start_day = txtNgayVao.Text.Trim();
                    string birth = txtNgaySinh.Text.Trim();
                    string sql = $"UPDATE STAFF SET [NAME]='{name}', [GENDER]='{gender}', [BIRTHDAY]='{birth}', [COUNTRY]='{country}', " +
                        $"[NUMBERPHONE]='{numberphone}', [EMAIL]='{email}', [START_DAY_WORK]='{start_day}', [USERNAME]='{user}', " +
                        $"[NOTE]='{note}' WHERE [ID]={id}";
                    Lock(true);
                    dao.InsertOrUpdateOrDelete(sql);
                    lblAlert.Text = "Cập nhật thành công.";
                }
            }
        }
        void Cancel()
        {
            Lock(true);
            lblAlert.Text = "";
            SelectedRow(0);
        }
        void LoadData(string sql)
        {
            DataTable dataTable = dao.GetDataTable(sql);
            if (dataTable.Rows.Count > 0){
                dataTable.Columns[0].ColumnName = "Mã nhân viên";
                dataTable.Columns[1].ColumnName = "Họ tên";
                dataTable.Columns[2].ColumnName = "Giới tính";
                dataTable.Columns[3].ColumnName = "Ngày sinh";
                dataTable.Columns[4].ColumnName = "Quê quán";
                dataTable.Columns[5].ColumnName = "Số điện thoại";
                dataTable.Columns[6].ColumnName = "Email";
                dataTable.Columns[7].ColumnName = "Ngày vào làm";
                dataTable.Columns[8].ColumnName = "Tài khoản";
                dataTable.Columns[9].ColumnName = "Ghi chú";
                GridViewStaff.DataSource = dataTable;
                GridViewStaff.DataBind();
            }
            else
            {
                lblAlert.Text = "Không tìm thấy nhân viên nào!";
            }
        }
        bool ValdidateForm()
        {
            if (txtNguoiDung3.Text.Trim()=="")
            {
                lblAlert.Text = "Hãy nhập tên người dùng!";
                return false;
            }
            if (txtDienThoai3.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập số điện thoại!";
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập email!";
                return false;
            }
            if (txtNgayVao.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập ngày vào làm!";
                return false;
            }
            if (txtDiaChi3.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập quê quán!";
                return false;
            }
            if (txtGhiChu.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập ghi chú!";
                return false;
            }
            return true;
        }
        void Lock(bool TrueOrFalse)
        {
            if (TrueOrFalse)
            {
                txtNguoiDung3.ReadOnly = true;
                txtTaiKhoan3.ReadOnly = true;
                txtNgaySinh.ReadOnly = true;
                txtDiaChi3.ReadOnly = true;
                txtDienThoai3.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtGhiChu.ReadOnly = true;
                txtNgayVao.ReadOnly = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            else
            {
                txtNguoiDung3.ReadOnly = false;
                txtNgaySinh.ReadOnly = false;
                txtDiaChi3.ReadOnly = false;
                txtDienThoai3.ReadOnly = false;
                txtEmail.ReadOnly =false;
                txtGhiChu.ReadOnly = false;
                txtNgayVao.ReadOnly = false;
                btnSua.Enabled = false;
                btnXoa.Enabled =false;
                btnTimKiem.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }
        void SelectedRow(int index)
        {
            GridViewStaff.SelectedIndex = index;
            GridViewRow row = GridViewStaff.Rows[index];
            Lock(true);
            txtNguoiDung3.Text = row.Cells[2].Text;
            txtTaiKhoan3.Text = row.Cells[9].Text;
            txtDiaChi3.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
            txtDienThoai3.Text = row.Cells[6].Text;
            txtEmail.Text = row.Cells[7].Text;
            txtGhiChu.Text = row.Cells[10].Text;
            txtNgaySinh.Text = row.Cells[4].Text;
            txtNgayVao.Text = row.Cells[8].Text;
            lblCount.Text = $"{index+1}/{GridViewStaff.Rows.Count}";
            if (row.Cells[3].Text == "Nam")
            {
                ckbNam.Checked = true;
                ckbNu.Checked = false;
            }
            else if (row.Cells[3].Text == "Nữ")
            {
                ckbNu.Checked = true;
                ckbNam.Checked = false;
            }
            else
            {
                ckbNam.Checked = false;
                ckbNam.Checked = false;
            }
        }

        protected void GridViewStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRow(GridViewStaff.SelectedIndex);
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == ckbNam)
            {
                ckbNam.Checked = true;
                ckbNu.Checked = false;
            }
            else
            {
                ckbNam.Checked = false;
                ckbNu.Checked = true;
            }
        }
    }
}