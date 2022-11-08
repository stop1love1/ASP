using HalBookstore.Connect;
using HalBookstore.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace HalBookstore
{
    public partial class _Default : Page
    {
        private DAO dao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao = new DAO();
            Run();
        }
        public void Run()
        {
            lblLeftDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblSanPhamDaBan.Text = GetSoldProducts().ToString();
            lblTongDoanhThu.Text = GetTotalRevenue().ToString() + " đ";
            lblTongKhachHang.Text = GetTotalCustom().ToString();
            LoadLeftChart(DateTime.Today.ToString("MM/dd/yyyy"), null);
            LoadRightChart(DateTime.Today.ToString("MM/dd/yyyy"), null);
        }
        #region Methods
        void LoadLeftChart(string startDATE, string endDATE)
        {
            string sql = null;
            List<SoldProduct> soldProducts = null;
            if (startDATE != null && endDATE == null)
            {
                lblLeftDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                sql = $"SELECT * FROM SOLD_PRODUCT WHERE CREATE_AT >= #{startDATE}#";
                soldProducts = dao.GetSoldProducts(sql);
            }
            else if (startDATE != null && endDATE != null)
            {
                if (cbLeftRevenue.SelectedIndex == 1)
                {
                    lblLeftDate.Text = cbLeftRevenue.Text;
                    sql = $"SELECT * FROM SOLD_PRODUCT WHERE (CREATE_AT >= #{startDATE}# AND CREATE_AT <= #{endDATE}#)";
                    soldProducts = dao.GetSoldProducts(sql);

                }
                else if (cbLeftRevenue.SelectedIndex == 2)
                {
                    lblLeftDate.Text = cbLeftRevenue.Text;
                    sql = $"SELECT * FROM SOLD_PRODUCT WHERE (CREATE_AT >= #{startDATE}# AND CREATE_AT <= #{endDATE}#)";
                    soldProducts = dao.GetSoldProducts(sql);
                }
            }
            else if (endDATE == null && startDATE == null)
            {
                lblLeftDate.Text = "Tất cả";
                sql = $"SELECT * FROM SOLD_PRODUCT";
                soldProducts = dao.GetSoldProducts(sql);
            }
            int revenue = 0;
            foreach (SoldProduct item in soldProducts)
            {
                revenue += item.Total;
            }
            lblLeftRevenue.Text = revenue.ToString() + " đ";
            int percent = (int)Math.Round((double)revenue / 71000, 0);
            panelLeftRevenue.Width = percent;
        }
        void LoadRightChart(string startDATE, string endDATE)
        {
            string sql = "";
            List<SoldProduct> list = null;
            if (startDATE != null && endDATE == null)
            {
                sql = $"SELECT TOP 5  PRODUCT, SUM(PRICE) AS SUM_PRICE,SUM(AMOUNT) AS SUM_AMOUNT" +
                    $" FROM SOLD_PRODUCT\r\nWHERE CREATE_AT >= #{startDATE}# " +
                    $"GROUP BY PRODUCT  ORDER BY SUM(AMOUNT) DESC";
                list = dao.GetTop5SoldProduct(sql);
            }
            else if (startDATE != null && endDATE != null)
            {
                if (cbRightChart.SelectedIndex == 1)
                {

                    sql = $"SELECT TOP 5 PRODUCT, SUM(PRICE) AS SUM_PRICE, SUM(AMOUNT) AS SUM_AMOUNT FROM SOLD_PRODUCT" +
                        $" WHERE (CREATE_AT >= #{startDATE}# AND CREATE_AT <= #{endDATE}#) GROUP BY PRODUCT ORDER BY SUM(AMOUNT) DESC";
                    list = dao.GetTop5SoldProduct(sql);


                }
                else if (cbRightChart.SelectedIndex == 2)
                {
                    sql = $"SELECT TOP 5 PRODUCT, SUM(PRICE) AS SUM_PRICE, SUM(AMOUNT) AS SUM_AMOUNT FROM SOLD_PRODUCT" +
                         $" WHERE (CREATE_AT >= #{startDATE}# AND CREATE_AT <= #{endDATE}#) GROUP BY PRODUCT ORDER BY SUM(AMOUNT) DESC";
                    list = dao.GetTop5SoldProduct(sql);
                }
            }
            else if (endDATE == null && startDATE == null)
            {
                sql = $"SELECT TOP 5 PRODUCT, SUM(PRICE) AS SUM_PRICE, SUM(AMOUNT) AS SUM_AMOUNT" +
                    $" FROM SOLD_PRODUCT\r\nGROUP BY PRODUCT ORDER BY SUM(AMOUNT) DESC";
                list = dao.GetTop5SoldProduct(sql);
            }
            SetRightChart(list[0].Sum_amount, list[1].Sum_amount, list[2].Sum_amount, list[3].Sum_amount, list[4].Sum_amount);
            lbl1.Text = $"1. {list[0].Product}";
            lbl2.Text = $"2. {list[1].Product}";
            lbl3.Text = $"3. {list[2].Product}";
            lbl4.Text = $"4. {list[3].Product}";
            lbl5.Text = $"5. {list[4].Product}";
        }
        void SetRightChart(int value1, int value2, int value3, int value4, int value5)
        {
            chartTopProducts.Series.Clear();
            Series chartSeries = new  Series();
            chartSeries.Points.AddXY(1, value1);
            chartSeries.Points.AddXY(2, value2);
            chartSeries.Points.AddXY(3, value3);
            chartSeries.Points.AddXY(4, value4);
            chartSeries.Points.AddXY(5, value5);
            /* chartSeries.Points.Add("MAX", 60);*/
            chartTopProducts.Series.Add(chartSeries);
        }
        int GetSoldProducts()
        {
            List<SoldProduct> ls = dao.GetSoldProducts("SELECT * FROM SOLD_PRODUCT");
            int count = 0;
            foreach (SoldProduct s in ls)
            {
                count += s.Amount;
            }
            return count;
        }
        int GetTotalRevenue()
        {
            int sum = 0;
            List<SoldProduct> soldProducts = dao.GetSoldProducts("SELECT * FROM SOLD_PRODUCT");
            foreach (SoldProduct soldProduct in soldProducts)
            {
                sum += soldProduct.Total;
            }
            return sum;
        }
        int GetTotalCustom()
        {
            return dao.GetAccounts($"SELECT * FROM ACCOUNT WHERE ISSTAFF = 0 AND ISADMIN = 0").Count;
        }
        #endregion

        protected void cbLeftRevenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemSelected = cbLeftRevenue.Text;
            switch (itemSelected)
            {
                case "Hôm nay":
                    LoadLeftChart(DateTime.Today.ToString("MM/dd/yyyy"), null);
                    break;
                case "1 tuần":
                    LoadLeftChart(DateTime.Today.AddDays(-7).ToString("MM/dd/yyyy"), DateTime.Today.ToString("MM/dd/yyyy"));
                    break;
                case "1 tháng":
                    LoadLeftChart(DateTime.Today.AddDays(-30).ToString("MM/dd/yyyy"), DateTime.Today.ToString("MM/dd/yyyy"));
                    break;
                case "Từ trước đến nay":
                    LoadLeftChart(null, null);
                    break;
                default:
                    cbLeftRevenue.SelectedIndex = 0;
                    LoadLeftChart(DateTime.Today.ToString("MM/dd/yyyy"), null);
                    break;
            }
        }

        protected void cbRightChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemSelected = cbRightChart.Text;
            switch (itemSelected)
            {
                case "Hôm nay":
                    LoadRightChart(DateTime.Today.ToString("MM/dd/yyyy"), null);
                    break;
                case "1 tuần":
                    LoadRightChart(DateTime.Today.AddDays(-7).ToString("MM/dd/yyyy"), DateTime.Today.ToString("MM/dd/yyyy"));
                    break;
                case "1 tháng":
                    LoadRightChart(DateTime.Today.AddDays(-30).ToString("MM/dd/yyyy"), DateTime.Today.ToString("MM/dd/yyyy"));
                    break;
                case "Từ trước đến nay":
                    LoadRightChart(null, null);
                    break;
                default:
                    cbRightChart.SelectedIndex = 0;
                    LoadRightChart(DateTime.Today.ToString("MM/dd/yyyy"), null);
                    break;
            }
        }
    }
}