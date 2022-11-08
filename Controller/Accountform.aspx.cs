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
    public partial class Accountform : System.Web.UI.Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            LoadData("SELECT * FROM ACCOUNT");
            if (!IsPostBack)
            {
                Lock(true);
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
            else if(button == btnXoa)
            {
                Delete();
            }
            else if (button == btnTimKiem)
            {
                Search();
            }
            else if (button == btnLuu)
            {
                Save();
            }
            else if (button == btnHuy)
            {
                Cancel();
            }
            else if (button == btnDLeft)
            {
                SelectedRow(0);
            }
            else if (button == btnLeft)
            {
                try
                {
                    SelectedRow(GridViewAccount.SelectedIndex-1);
                }
                catch { SelectedRow(GridViewAccount.Rows.Count - 1); }
            }
            else if (button == btnRight)
            {
                try
                {
                    SelectedRow(GridViewAccount.SelectedIndex + 1);
                }
                catch { SelectedRow(0); }
            }
            else if (button == btnDRight)
            {
                SelectedRow(GridViewAccount.Rows.Count - 1);
            }
        }

        void Update()
        {
            lblAlert.Text = $"Bạn đang sửa quyền truy cập tài khoản {GridViewAccount.Rows[GridViewAccount.SelectedIndex].Cells[2].Text}";
            SelectedRow(GridViewAccount.SelectedIndex);
        }

        void Delete()
        {
            lblAlert.Text = $"Bấm lưu để xác nhận xóa tài khoản {GridViewAccount.Rows[GridViewAccount.SelectedIndex].Cells[2].Text}";
            SelectedRow(GridViewAccount.SelectedIndex);
        }
        void Search()
        {
            if (lblAlert.Text !="Tìm kiếm")
            {
                lblAlert.Text = "Tìm kiếm";
                Lock(false);
            }
            else
            {
                int isstaff = 0, isadmin = 1;
                if (ckbadmin.Checked) isadmin = 1;
                else isadmin = 0;
                if (ckbnhanvien.Checked) isstaff = 1;
                else isstaff = 0;
                string sql = $"SELECT * FROM ACCOUNT ";
                string dk = $"WHERE 1=1 ";
                if (txtTaiKhoan.Text.Trim() != "")
                {
                    dk = dk + string.Format(" AND [USERNAME] LIKE '%{0}%'", txtTaiKhoan.Text.Trim());
                }
                if (txtNguoiDung.Text.Trim() != "")
                {
                    dk = dk + string.Format(" AND [NAME] LIKE '%{0}%'", txtNguoiDung.Text.Trim());
                }
                dk += $"AND ([ISSTAFF] = {isstaff} AND [ISADMIN] = {isadmin}) ";
                LoadData(sql + dk);
                lblAlert.Text = $"Tìm thấy {GridViewAccount.Rows.Count} tài khoản tương tự.";
                Lock(true);
            }
        }

        void Save()
        {
            if (lblAlert.Text.Contains("đang sửa"))
            {
                GridViewRow row = GridViewAccount.Rows[GridViewAccount.SelectedIndex];
                string username = row.Cells[2].Text;
                string permiss = row.Cells[6].Text;
                permiss = permiss == "1" ? "0" : "1";
                string sql = $"UPDATE ACCOUNT SET [ISSTAFF] = {permiss} WHERE [USERNAME] ='{username}'";
                dao.InsertOrUpdateOrDelete(sql);
                if (permiss == "1")
                {
                    lblAlert.Text = $"Cho phép {username} quyền truy cập nhân viên";
                }
                else
                {
                    lblAlert.Text = $"Không cho phép {username} quyền truy cập nhân viên";
                }
                
            }
            if(lblAlert.Text.Contains("xác nhận xóa"))
            {
                GridViewRow row = GridViewAccount.Rows[GridViewAccount.SelectedIndex];
                dao.InsertOrUpdateOrDelete($"DELETE FROM ACCOUNT WHERE ACCOUNT.USERNAME = '{row.Cells[2].Text}' AND ACCOUNT.ID = {row.Cells[1].Text}");
                lblAlert.Text = $"Xóa thành công.";
                SelectedRow(0);
            }
        }

        void Cancel()
        {
            lblAlert.Text = "";
            Lock(true);
            SelectedRow(0);
        }

        void Lock(bool TrueOrFalse)
        {
            if (TrueOrFalse)
            {
                txtTaiKhoan.ReadOnly = true;
                txtNguoiDung.ReadOnly = true;
                ckbadmin.Enabled = false;
                ckbnhanvien.Enabled = false;
                
            }
            else
            {
                txtTaiKhoan.ReadOnly = false;
                txtNguoiDung.ReadOnly = false;
                ckbadmin.Enabled = true;
                ckbnhanvien.Enabled = true;
              
            }
        }
        void LoadData(string sql)
        {
            DataTable dataTable = dao.GetDataTable(sql);
            dataTable.Columns[0].ColumnName = "ID";
            dataTable.Columns[1].ColumnName = "Tài khoản";
            dataTable.Columns[2].ColumnName = "Mật khẩu";
            dataTable.Columns[3].ColumnName = "Họ tên";
            dataTable.Columns[4].ColumnName = "Mã bảo mật";
            dataTable.Columns[5].ColumnName = "Nhân viên";
            dataTable.Columns[6].ColumnName = "Admin";
            dataTable.Columns[7].ColumnName = "Ngày tạo";
            dataTable.Columns[8].ColumnName = "Ngày cập nhật";
            if (dataTable.Rows.Count > 0)
            {
                GridViewAccount.DataSource = dataTable;
                GridViewAccount.DataBind();
                for(int i=0; i< GridViewAccount.Rows.Count; i++)
                {
                    GridViewAccount.Rows[i].Cells[8].Text = DateTime.Parse(GridViewAccount.Rows[i].Cells[8].Text).ToString("dd/MM/yyyy HH:mm:ss");
                    GridViewAccount.Rows[i].Cells[9].Text = DateTime.Parse(GridViewAccount.Rows[i].Cells[9].Text).ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            else
            {
                lblAlert.Text = "Không có sản phẩm nào!";
            }
        }
        void SelectedRow(int index)
        {
            GridViewAccount.SelectedIndex = index;
            lblCount.Text = $"{index+1}/{GridViewAccount.Rows.Count}";
        }
        protected void GridViewAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRow(GridViewAccount.SelectedIndex);
        }
    }
}