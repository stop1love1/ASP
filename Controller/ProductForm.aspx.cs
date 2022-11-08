using HalBookstore.Connect;
using HalBookstore.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalBookstore
{
    public partial class ProductForm : System.Web.UI.Page
    {
        private DAO dao;
        private int memory;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            LoadData("SELECT * FROM PRODUCT");
           
            if (!IsPostBack)
            {
                txtTuNgay.Text = "01/01/2022";
                txtDenNgay.Text = DateTime.Today.ToString("dd/MM/yyyy");
                LockControl(true);
                memory = 0;
                GetValueInformation(memory);
               
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }
        void Insert()
        {
            Clear();
            LockControl(false);
            Alert("Bạn đang thêm mới sản phẩm", 0);
            DropDownListCategory.Items[0].Enabled = false;
        }
        void Update()
        {
            LockControl(false);
            Alert("Bạn đang sửa 1 sản phẩm", 0);
            GetValueInformation(GridViewProducts.SelectedIndex);
            DropDownListCategory.Items[0].Enabled = false;
        }

        void Delete()
        {
            memory = GridViewProducts.SelectedIndex;
            int id = int.Parse(GridViewProducts.Rows[memory].Cells[1].Text);
            dao.InsertOrUpdateOrDelete($"DELETE FROM PRODUCT WHERE PRODUCT.ID = {id}");
            Alert("Xóa thành công.",0);
        }

        void Search()
        {
           
            btnHuy.Enabled = true;
            if(lblAlert.Text!="Tìm kiếm")
            {
                Clear();
                txtTenSach.ReadOnly = false;
                txtDonGia.ReadOnly = false;
                txtImage.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                DropDownListCategory.Enabled = true;
                Alert("Tìm kiếm", 0);
            }
            else
            {
                string sql = "SELECT * FROM PRODUCT WHERE ";
                string dk;
                if (DropDownListCategory.SelectedIndex == 0)
                {
                    dk = " 1=1 ";
                }
                else
                {
                    int category = dao.GetCategories($"SELECT * FROM CATEGORIES WHERE CATEGORIES.NAME = '{DropDownListCategory.Text}'")[0].Id;
                    dk = $" 1=1 AND PRODUCT.CATEGORY = {category} ";
                }
                dk = dk + $" AND PRODUCT.CREATE_AT >= #{txtTuNgay.Text}# AND PRODUCT.CREATE_AT <= #{txtDenNgay.Text}# ";
                if (txtTenSach.Text.Trim() != "")
                {
                    dk = dk + string.Format(" AND PRODUCT.NAME LIKE '%{0}%' ",txtTenSach.Text.Trim());
                }
                if (txtDonGia.Text.Trim() != "")
                {
                    dk = dk + string.Format(" AND PRODUCT.PRICE >= {0} ", txtDonGia.Text.Trim());
                }
                if (txtSoLuong.Text.Trim() != "")
                {
                    dk = dk + string.Format(" AND PRODUCT.AMOUNT >= {0} ", txtSoLuong.Text.Trim());
                }
                if (txtImage.Text.Trim() != "")
                {
                    dk = dk + string.Format(" AND PRODUCT.IMAGE LIKE '%{0}%' ", txtImage.Text.Trim());
                }
                LoadData(sql + dk);
                Alert($"Tìm thấy {GridViewProducts.Rows.Count} sản phẩm tương tự.",0);
                LockControl(true);
                GetValueInformation(0);
            }

        }

        void Export()
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "HalBookstore.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridViewProducts.AllowPaging = false;
            GridViewProducts.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int i = 0; i < GridViewProducts.HeaderRow.Cells.Count; i++)
            {
                GridViewProducts.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            }
            GridViewProducts.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        void Save()
        {
            if (ValdidateForm()) {
                string name = txtTenSach.Text.Trim();
                string image = txtImage.Text.Trim();
                int price = int.Parse(txtDonGia.Text.Trim());
                int amount = int.Parse(txtSoLuong.Text.Trim());
                int category = 1;
                try
                {
                        category = dao.GetCategories($"SELECT * FROM CATEGORIES WHERE CATEGORIES.NAME = '{DropDownListCategory.SelectedValue}'")[0].Id;
                }
                catch { category = 1; }
                string sql = "";
                List<Product> products = dao.GetProducts($"SELECT * FROM PRODUCT WHERE PRODUCT.NAME = '{name}' AND PRODUCT.IMAGE = '{image}'");
                if (lblAlert.Text.Contains("thêm"))
                {
                    if (products.Count > 0)
                    {
                        Alert("Sản phẩm này đã tồn tại!", 1);
                    }
                    else
                    {
                        sql = $"INSERT INTO PRODUCT ([NAME], [IMAGE], [PRICE], [AMOUNT], [CATEGORY], [CREATE_AT], [UPDATE_AT]) VALUES " +
                            $"('{name}', '{image}', '{price}', '{amount}', '{category}', '{DateTime.Now}', '{DateTime.Now}')";
                        dao.InsertOrUpdateOrDelete(sql);
                        Alert("Thêm mới thành công", 4);
                        DropDownListCategory.Items[0].Enabled = true;
                    }
                }
                else if (lblAlert.Text.Contains("sửa"))
                {
                    int id = int.Parse(GridViewProducts.Rows[GridViewProducts.SelectedIndex].Cells[1].Text);
                    sql = $"UPDATE PRODUCT SET PRODUCT.NAME = '{name}', PRODUCT.IMAGE = '{image}', PRODUCT.PRICE = '{price}', PRODUCT.AMOUNT = '{amount}', PRODUCT.CATEGORY = '{category}', PRODUCT.UPDATE_AT = '{DateTime.Now}' " +
                        $" WHERE PRODUCT.ID = {id}";
                    dao.InsertOrUpdateOrDelete(sql);
                    Alert("Cập nhật thành công", 4);
                    DropDownListCategory.Items[0].Enabled = true;
                }
            }
        }

        bool ValdidateForm()
        {
            if (txtTenSach.Text.Trim() == "")
            {
                Alert("Hãy nhập tên sách!",2);
                return false;
            }
            else if (txtImage.Text.Trim() == "")
            {
                Alert("Hãy nhập link ảnh!", 2);
                return false;
            }
            else if (txtDonGia.Text.Trim()=="")
            {
                Alert("Hãy nhập đơn giá!", 2);
                return false;
            }
            else if (!dao.IsNumber(txtDonGia.Text.Trim()))
            {
                Alert("Đơn giá phải là 1 số nguyên dương!", 2);
                return false;
            }
            else if (txtSoLuong.Text.Trim() == "")
            {
                Alert("Hãy nhập số lượng!", 2);
                return false;
            }
            else if (!dao.IsNumber(txtSoLuong.Text.Trim()))
            {
                Alert("Số lượng phải là 1 số nguyên dương!", 2);
                return false;
            }
            return true;
        }

        void Cancel()
        {
            LockControl(true);
            memory = 0;
            lblAlert.Text = "";
            DropDownListCategory.Items[0].Enabled = true;
        }

        void LoadData(string sql)
        {
            DataTable dataTable = dao.GetDataTable(sql);
            if (dataTable.Rows.Count != 0)
            {
                dataTable.Columns[0].ColumnName = "Mã sản phẩm";
                dataTable.Columns[1].ColumnName = "Tên sách";
                dataTable.Columns[2].ColumnName = "Link ảnh";
                dataTable.Columns[3].ColumnName = "Đơn giá";
                dataTable.Columns[4].ColumnName = "Số lượng";
                dataTable.Columns[5].ColumnName = "Danh mục";
                dataTable.Columns[6].ColumnName = "Ngày thêm";
                dataTable.Columns[7].ColumnName = "Ngày cập nhật";
                GridViewProducts.DataSource = dataTable;
                GridViewProducts.DataBind();
                for(int i=0; i< GridViewProducts.Rows.Count; i++)
                {
                    GridViewProducts.Rows[i].Cells[7].Text = DateTime.Parse(GridViewProducts.Rows[i].Cells[7].Text).ToString("dd/MM/yy HH:mm:ss");
                    GridViewProducts.Rows[i].Cells[8].Text = DateTime.Parse(GridViewProducts.Rows[i].Cells[8].Text).ToString("dd/MM/yy HH:mm:ss");
                }
                Alert($"Tổng {GridViewProducts.Rows.Count} sản phẩm",0);
            }
            else
            {
                Alert("Không tìm thấy sản phẩm nào!", 1);
            }
        }

        void Clear()
        {
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            ImageSach.ImageUrl = "";
            txtImage.Text = "";
            ImageSach.ImageUrl = "";
        }
        void GetValueInformation(int index)
        {
            GridViewProducts.SelectedIndex = index;
            GridViewRow row = GridViewProducts.Rows[index];
            int id = int.Parse(row.Cells[1].Text);
            Product product = dao.GetProducts($"SELECT * FROM PRODUCT WHERE PRODUCT.ID = {id}")[0];
            txtTenSach.Text = product.Name;
            txtDonGia.Text = product.Price.ToString();
            txtSoLuong.Text = product.Amount.ToString();
            txtImage.Text = product.Image;
            DropDownListCategory.SelectedValue = dao.GetCategories($"SELECT * FROM CATEGORIES WHERE CATEGORIES.ID={product.Category}")[0].Name;
            ImageSach.ImageUrl = product.Image;
            if (IsPostBack)
            {
                lblCount.Text = $"{GridViewProducts.SelectedIndex + 1}/{GridViewProducts.Rows.Count}";
            }
            else
            {
                lblCount.Text = $"1/{GridViewProducts.Rows.Count}";
            }

        }
        void LockControl(bool TrueOrFalse)
        {
            if (TrueOrFalse)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = true;
                btnXuatFile.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnDLeft.Enabled = true;
                btnDRight.Enabled = true;
                btnLeft.Enabled = true;
                btnRight.Enabled = true;
                txtTenSach.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                txtSoLuong.ReadOnly = true;
                txtImage.ReadOnly = true;
                DropDownListCategory.Enabled = false;
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = false;
                btnXuatFile.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnDLeft.Enabled = false;
                btnDRight.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                pnInformation.Enabled = true;
                txtTenSach.ReadOnly = false;
                txtDonGia.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtImage.ReadOnly = false;
                DropDownListCategory.Enabled = true;
            }
        }

        void Alert(string message, int status)
        {
            lblAlert.Text = message;
            if (status == 0)
            {
                lblAlert.ForeColor = Color.Green;
            } else if(status == 1)
            {
                lblAlert.ForeColor = Color.Red;
            } else if(status == 2)
            {
                lblAlert.ForeColor = Color.GreenYellow;
            } else if(status == 3)
            {
                lblAlert.ForeColor = Color.Blue;
            }
        }

        protected void ButtonCRUD_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button == btnThem)
            {
                Insert();
            }
            else if(button == btnSua)
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
            else if (button == btnXuatFile)
            {
                Export();
            }
            else if (button == btnLuu)
            {
                Save();
            }
            else if (button == btnHuy)
            {
                Cancel();
            }
            else if(button == btnDLeft)
            {
                GridViewProducts.SelectedIndex = 0;
                memory = GridViewProducts.SelectedIndex;
                GetValueInformation(memory);
            }
            else if(button == btnLeft)
            {
                try
                {
                    memory = GridViewProducts.SelectedIndex - 1;
                    GridViewProducts.SelectedIndex = memory;
                    GetValueInformation(memory);
                }
                catch
                {
                    GridViewProducts.SelectedIndex = GridViewProducts.Rows.Count - 1;
                    memory = GridViewProducts.SelectedIndex;
                    GetValueInformation(memory);
                }
            }
            else if (button == btnRight)
            {
                try
                {
                    memory = GridViewProducts.SelectedIndex + 1;
                    GridViewProducts.SelectedIndex = memory;
                    GetValueInformation(memory);
                }
                catch
                {
                    GridViewProducts.SelectedIndex = 0;
                    memory = GridViewProducts.SelectedIndex;
                    GetValueInformation(memory);
                }
            }
            else if (button == btnDRight)
            {
                GridViewProducts.SelectedIndex = GridViewProducts.Rows.Count-1;
                memory = GridViewProducts.SelectedIndex;
                GetValueInformation(memory);
            }
        }

        protected void GridViewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LockControl(true);
            memory = GridViewProducts.SelectedIndex;
            GetValueInformation(memory);
            Alert("", 0);
        }

        protected void txtTuNgay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(txtTuNgay.Text) <= DateTime.Parse(txtDenNgay.Text))
                {
                    LoadData($"SELECT * FROM PRODUCT WHERE PRODUCT.CREATE_AT >= #{txtTuNgay.Text}# AND PRODUCT.CREATE_AT <= #{txtDenNgay.Text}#");
                }
            }
            catch { }
        }
    }
}