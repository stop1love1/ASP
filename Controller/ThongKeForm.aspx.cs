using HalBookstore.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace HalBookstore.Controller
{
    public partial class ThongKeForm : System.Web.UI.Page
    {
        private DAO dao;
        private string sql1, sql2;
        private List<int> listAmountImported = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            sql1= "SELECT ACCOUNT.ID, ACCOUNT.[NAME], ACCOUNT.USERNAME, COUNT(BILL.ID) AS COUNT_BILL, SUM(BILL.TOTAL) AS SUM_TOTAL\r\n" +
           "FROM ACCOUNT INNER JOIN BILL ON ACCOUNT.ID = BILL.ID_STAFF\r\n" +
            "GROUP BY ACCOUNT.ID, ACCOUNT.[NAME], ACCOUNT.USERNAME, BILL.ID_STAFF";
            LoadDataDTNV(sql1);
            sql2 = "SELECT * FROM BILL";
            LoadDataBill(sql2);
            listAmountImported = new List<int>();
            for (int i = 1; i <= 13; i++)
            {
                listAmountImported.Add(dao.GetAmountProductAMonth(i));
            }
            SetImportedChart(listAmountImported);
        }
        void Alert()
        {

        }
        private void LoadDataDTNV(string querry)
        {
            DataTable dataTable = dao.GetDataTable(querry + " ORDER BY SUM(BILL.TOTAL) DESC ");
            dataTable.Columns[0].ColumnName = "Mã nhân viên";
            dataTable.Columns[1].ColumnName = "Tên nhân viên";
            dataTable.Columns[2].ColumnName = "Tài khoản";
            dataTable.Columns[3].ColumnName = "Tổng số hóa đơn";
            dataTable.Columns[4].ColumnName = "Doanh thu";
            GridViewDTNV.DataSource = dataTable;
            GridViewDTNV.DataBind();
            if (GridViewDTNV.Rows.Count > 0)
            {
                GridViewDTNV.Rows[0].Cells[0].Width = 500;
                GridViewDTNV.Rows[0].Cells[1].Width = 500;
                GridViewDTNV.Rows[0].Cells[2].Width = 220;
                GridViewDTNV.Rows[0].Cells[3].Width = 500;
                GridViewDTNV.Rows[0].Cells[4].Width = 250;
            }
            if (GridViewDTNV.Rows.Count >= 3)
            {
                lblTop1.Text = $"Top 1: {GridViewDTNV.Rows[0].Cells[1].Text} - {GridViewDTNV.Rows[0].Cells[3].Text} hóa đơn -{GridViewDTNV.Rows[0].Cells[4].Text} vnd";
                lblTop2.Text = $"Top 2: {GridViewDTNV.Rows[1].Cells[1].Text} - {GridViewDTNV.Rows[1].Cells[3].Text} hóa đơn - {GridViewDTNV.Rows[1].Cells[4].Text} vnd";
                lblTop3.Text = $"Top 3: {GridViewDTNV.Rows[2].Cells[1].Text} - {GridViewDTNV.Rows[2].Cells[3].Text} hóa đơn - {GridViewDTNV.Rows[2].Cells[4].Text} vnd";
            }
            else
            {
                if (GridViewDTNV.Rows.Count == 2)
                {
                    lblTop1.Text = $"Top 1: {GridViewDTNV.Rows[0].Cells[1].Text} - {GridViewDTNV.Rows[0].Cells[3].Text} hóa đơn - {GridViewDTNV.Rows[0].Cells[4].Text} vnd";
                    lblTop2.Text = $"Top 2: {GridViewDTNV.Rows[1].Cells[1].Text} - {GridViewDTNV.Rows[1].Cells[3].Text} hóa đơn - {GridViewDTNV.Rows[0].Cells[4].Text} vnd";
                    lblTop3.Text = $"Top 3: Chưa có - 0 hóa đơn - 0 vnd";
                }
                else if (GridViewDTNV.Rows.Count == 1)
                {
                    lblTop1.Text = $"Top 1: {GridViewDTNV.Rows[0].Cells[1].Text} - {GridViewDTNV.Rows[0].Cells[3].Text} hóa đơn - {GridViewDTNV.Rows[0].Cells[4].Text} vnd";
                    lblTop2.Text = $"Top 2: Chưa có - 0 hóa đơn - 0 vnd";
                    lblTop3.Text = $"Top 3: Chưa có - 0 hóa đơn - 0 vnd";
                }
                else
                {
                    lblTop1.Text = $"Top 1: Chưa có - 0 hóa đơn - 0 vnd";
                    lblTop2.Text = $"Top 2: Chưa có - 0 hóa đơn - 0 vnd";
                    lblTop3.Text = $"Top 3: Chưa có - 0 hóa đơn - 0 vnd";
                }
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {

            if (txtSearch.Text.Trim() != "")
            {
                sql1 = $"SELECT ACCOUNT.ID, ACCOUNT.[NAME], ACCOUNT.USERNAME, COUNT(BILL.ID) AS COUNT_BILL, SUM(BILL.TOTAL) AS SUM_TOTAL " +
                    $"FROM ACCOUNT INNER JOIN BILL ON ACCOUNT.ID = BILL.ID_STAFF\r\n" +
                    $"WHERE (BILL.ID_STAFF LIKE '%{txtSearch.Text.Trim()}%' OR ACCOUNT.ID LIKE '%{txtSearch.Text.Trim()}%' OR ACCOUNT.[NAME] LIKE '%{txtSearch.Text.Trim()}%' OR ACCOUNT.USERNAME LIKE '%{txtSearch.Text.Trim()}%') " +
                    $"GROUP BY ACCOUNT.ID, ACCOUNT.[NAME], ACCOUNT.USERNAME, BILL.ID_STAFF";
                LoadDataDTNV(sql1);
            }
            else
            {
                txtSearch.Focus();
            }
        }

        private void LoadDataBill(string querry)
        {
            DataTable dataTable = dao.GetDataTable(querry);
            if (dataTable.Rows.Count > 0)
            {
                dataTable.Columns[0].ColumnName = "ID";
                dataTable.Columns[1].ColumnName = "Mã nhân viên";
                dataTable.Columns[2].ColumnName = "Tên nhân viên";
                dataTable.Columns[3].ColumnName = "Khách hàng";
                dataTable.Columns[4].ColumnName = "Tổng tiền";
                dataTable.Columns[5].ColumnName = "Tiền khách trả";
                dataTable.Columns[6].ColumnName = "Tiền thừa";
                dataTable.Columns[7].ColumnName = "Ngày tạo";
                lblCount.Text = $"Tổng {gridViewBill.Rows.Count} hóa đơn";
                    gridViewBill.DataSource = dataTable;
                gridViewBill.DataBind();
               for(int i=0; i < gridViewBill.Rows.Count; i++)
                {
                    gridViewBill.Rows[i].Cells[8].Text = DateTime.Parse(gridViewBill.Rows[i].Cells[8].Text).ToString("dd//MM/yyyy HH:mm:ss");
                }
                if (!IsPostBack)
                {
                    gridViewBill.SelectedIndex = 0;
                }
            }
            else
            {
                lblCount.Text = "Chưa có hóa đơn nào được bán.";
            }
        }

        private void SetImportedChart(List<int> list)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("X_Value", typeof(string));
            dataTable.Columns.Add("Y_Value", typeof(int));
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 12)
                {
                    dataTable.Rows.Add("Tổng ", list[i]);
                }
                else
                {
                    string num = $"{i + 1}";
                    if (num.Length < 2) num = "0" + num;
                    dataTable.Rows.Add("Tháng " + num, list[i]);
                }
            }
            chartProduct.Series.Clear();
            Series chartSeries = new Series();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                chartSeries.Points.AddXY(row.Field<string>(0), row.Field<int>(1));
            }
            chartProduct.Series.Add(chartSeries);
        }

        protected void menuTabs_MenuItemClick(object sender, MenuEventArgs e)
        {
            multiTabs.ActiveViewIndex = int.Parse(menuTabs.SelectedValue);
        }

        protected void gridViewBill_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            string idBill = gridViewBill.Rows[gridViewBill.SelectedIndex].Cells[1].Text;


        }

        protected void txtTuNgay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(txtTuNgay.Text) <= DateTime.Parse(txtDenNgay.Text))
                {
                    sql1 = $"SELECT ACCOUNT.ID, ACCOUNT.[NAME], ACCOUNT.USERNAME, COUNT(BILL.ID) AS COUNT_BILL, SUM(BILL.TOTAL) AS SUM_TOTAL " +
                        $"FROM ACCOUNT INNER JOIN BILL ON ACCOUNT.ID = BILL.ID_STAFF " +
                        $"WHERE BILL.CREATE_AT >= #{DateTime.Parse(txtTuNgay.Text).ToString("MM/dd/yyyy")}# AND BILL.CREATE_AT <= #{DateTime.Parse(txtDenNgay.Text).ToString("MM/dd/yyyy")}# " +
                        $"GROUP BY ACCOUNT.ID, ACCOUNT.[NAME], ACCOUNT.USERNAME, BILL.ID_STAFF ";
                    LoadDataDTNV(sql1);
                }
            }
            catch { }
        }

        void Export(GridView gridView)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "HalBookstore.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gridView.AllowPaging = false;
            gridView.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int i = 0; i < gridView.HeaderRow.Cells.Count; i++)
            {
                gridView.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            }
            gridView.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}