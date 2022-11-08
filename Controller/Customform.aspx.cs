using HalBookstore.Connect;
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
    public partial class Nhanvienform : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            LoadData("SELECT * FROM CUSTOM");
            if (!IsPostBack)
            {
                SelectedRow(0);
            }
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == btnSua)
            {
                Update();
            }
            if (button == btnXoa)
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
                    SelectedRow(GridViewCustom.SelectedIndex - 1);
                }
                catch
                {
                    SelectedRow(GridViewCustom.Rows.Count - 1);
                }
            }
            if (button == btnRight)
            {
                try
                {
                    SelectedRow(GridViewCustom.SelectedIndex + 1);
                }
                catch
                {
                    SelectedRow(0);
                }
            }
            if (button == btnDRight)
            {
                SelectedRow(GridViewCustom.Rows.Count - 1);
            }
        }
        void Update()
        {
            lblAlert.Text = $"Đang sửa mã khách hàng {GridViewCustom.Rows[GridViewCustom.SelectedIndex].Cells[1].Text}";
            Lock(false);
        }
        void Delete()
        {
            string id = GridViewCustom.Rows[GridViewCustom.SelectedIndex].Cells[1].Text;
            dao.InsertOrUpdateOrDelete($"DELETE FROM CUSTOM WHERE [ID] = {id}");
            lblAlert.Text = "Xóa thành công";
            SelectedRow(0);
        }
        void Search()
        {
            if (lblAlert.Text != "Tìm kiếm")
            {
                lblAlert.Text = "Tìm kiếm";
                txtTenTaiKhoan2.Text = "";
                txtnguoidung2.Text = "";
                txtdiachi.Text = "";
                txtdienthoai.Text = "";
                txtTenTaiKhoan2.ReadOnly = false;
                txtnguoidung2.ReadOnly = false;
                txtdiachi.ReadOnly = false;
                txtdienthoai.ReadOnly = false;
            }
            else
            {
                string sql = "SELECT * FROM CUSTOM WHERE ";
                string dk = " 1=1 ";
                if (txtnguoidung2.Text.Trim() != "")
                {
                    dk += string.Format(" AND [NAME] LIKE '%{0}%'", txtnguoidung2.Text.Trim());
                }
                if (txtTenTaiKhoan2.Text.Trim() != "")
                {
                    dk += string.Format(" AND [USERNAME] LIKE '%{0}%'", txtTenTaiKhoan2.Text.Trim());
                }
                if (txtdiachi.Text.Trim() != "")
                {
                    dk += string.Format(" AND [ADDRESS] LIKE '%{0}%'", txtdiachi.Text.Trim());
                }
                if (txtdienthoai.Text.Trim() != "")
                {
                    dk += string.Format(" AND [PHONE] LIKE '%{0}%'", txtdienthoai.Text.Trim());
                }
                try
                {
                    LoadData(sql + dk);
                    lblAlert.Text = $"Tìm thấy {GridViewCustom.Rows.Count} khách hàng";
                    SelectedRow(0);
                }
                catch { lblAlert.Text = "Có lỗi xảy ra!"; }
            }
        }
        void Save()
        {
            if (lblAlert.Text.Trim().Contains("Đang sửa"))
            {
                if (ValdidateForm())
                {
                    string id = GridViewCustom.Rows[GridViewCustom.SelectedIndex].Cells[1].Text;
                    string name = txtnguoidung2.Text.Trim();
                    string country = txtdiachi.Text.Trim();
                    string numberphone = txtdienthoai.Text.Trim();
                    string user = txtTenTaiKhoan2.Text.Trim();
                    string gender = ckbNam.Checked == true ? "Nam" : "Nữ";
                    string note = txtGhiChu.Text.Trim();
                    string sql = $"UPDATE CUSTOM SET [USERNAME]='{user}', [NAME]='{name}', [GENDER]='{gender}', [ADDRESS]='{country}', " +
                        $"[PHONE]='{numberphone}', [NOTE]='{note}' WHERE [ID]={id}";
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
            if (dataTable.Rows.Count > 0)
            {
                dataTable.Columns[0].ColumnName = "Mã khách hàng";
                dataTable.Columns[1].ColumnName = "Tài khoản";
                dataTable.Columns[2].ColumnName = "Họ tên";
                dataTable.Columns[3].ColumnName = "Giới tính";
                dataTable.Columns[4].ColumnName = "Địa chỉ";
                dataTable.Columns[5].ColumnName = "Số điện thoại";
                dataTable.Columns[6].ColumnName = "Hóa đơn đã thanh toán";
                dataTable.Columns[7].ColumnName = "Ghi chú";
                GridViewCustom.DataSource = dataTable;
                GridViewCustom.DataBind();
                lblAlert.Text = $"Tổng {GridViewCustom.Rows.Count} khách hàng.";
            }
            else
            {
                lblAlert.Text = "Không tìm thấy khách hàng nào!";
            }
        }
        bool ValdidateForm()
        {
            if (txtnguoidung2.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập họ tên!";
                return false;
            }
            if (txtTenTaiKhoan2.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập tên tài khoản!";
                return false;
            }
            if (txtdiachi.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập địa chỉ!";
                return false;
            }
            if (txtdienthoai.Text.Trim() == "")
            {
                lblAlert.Text = "Hãy nhập số điện thoại!";
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
                txtnguoidung2.ReadOnly = true;
                txtTenTaiKhoan2.ReadOnly = true;
                txtdiachi.ReadOnly = true;
                txtdienthoai.ReadOnly = true;
                txtGhiChu.ReadOnly = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            else
            {
                txtnguoidung2.ReadOnly = false;
                txtTenTaiKhoan2.ReadOnly = true;
                txtdiachi.ReadOnly = false;
                txtdienthoai.ReadOnly =false;
                txtGhiChu.ReadOnly = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }
        void SelectedRow(int index)
        {
            GridViewCustom.SelectedIndex = index;
            GridViewRow row = GridViewCustom.Rows[index];
            Lock(true);
            txtnguoidung2.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            txtTenTaiKhoan2.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
            txtdiachi.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
            txtdienthoai.Text = row.Cells[6].Text;
            txtGhiChu.Text = row.Cells[8].Text;
            lblCount.Text = $"{index + 1}/{GridViewCustom.Rows.Count}";
            if (row.Cells[4].Text.Trim() == "Nam")
            {
                ckbNam.Checked = true;
                ckbNu.Checked = false;
            }
            else if (row.Cells[4].Text.Trim() == "Nữ")
            {
                ckbNu.Checked = true;
                ckbNam.Checked = false;
            }
            else
            {
                ckbNam.Checked = false;
                ckbNu.Checked = false;
            }
        }

        protected void GridViewCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRow(GridViewCustom.SelectedIndex);
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