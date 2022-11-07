
using HalBookstore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HalBookstore.Connect
{
    public class DAO
    {
        #region DAO
        OleDbConnection connection = DBUtils.getDBConnection();
        OleDbCommand command = new OleDbCommand();
        OleDbDataReader dbDataReader = null;
        OleDbDataAdapter adapter = null;
        string querry = null;
        #endregion
        #region HOME
        public List<SoldProduct> GetSoldProducts(string sql)
        {
            List<SoldProduct> products = new List<SoldProduct>();
            try
            {
                connection.Open();
            }
            catch { connection.Close(); connection.Open(); }
            command.Connection = connection;
            command.CommandText = sql;
            using (dbDataReader = command.ExecuteReader())
            {
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        SoldProduct product = new SoldProduct();
                        product.ID = dbDataReader.GetInt32(0);
                        product.Id_Product = dbDataReader.GetInt32(1);
                        product.ID_BILL = dbDataReader.GetString(2);
                        product.Product = dbDataReader.GetString(3);
                        product.Price = dbDataReader.GetInt32(4);
                        product.Amount = dbDataReader.GetInt32(5);
                        product.Deal = dbDataReader.GetInt32(6);
                        product.Total = dbDataReader.GetInt32(7);
                        product.Create_at = dbDataReader.GetDateTime(8).ToString("dd/MM/yyyy");
                        products.Add(product);
                    }
                }
            }
            connection.Close();
            return products;
        }
        public List<SoldProduct> GetTop5SoldProduct(string sql)
        {
            List<SoldProduct> list = new List<SoldProduct>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            using (dbDataReader = command.ExecuteReader())
            {
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        list.Add(new SoldProduct(dbDataReader.GetString(0), (int)dbDataReader.GetDouble(1), (int)dbDataReader.GetDouble(2)));
                    }
                }
            }
            if (list.Count < 5)
            {
                for (int i = 5 - list.Count; i >= 0; i--)
                {
                    SoldProduct soldProduct = new SoldProduct("Chưa có sản phẩm được bán.", 0, 0);
                    list.Add(soldProduct);
                }
            }
            connection.Close();
            return list;
        }
        #endregion

        #region PRODUCT
        public List<Product> GetProducts(string sql)
        {
            List<Product> products = new List<Product>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            using (dbDataReader = command.ExecuteReader())
            {
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Product product = new Product();
                        product.Id = dbDataReader.GetInt32(0);
                        product.Name = dbDataReader.GetString(1);
                        product.Image = dbDataReader.GetString(2);
                        product.Price = dbDataReader.GetInt32(3);
                        product.Amount = dbDataReader.GetInt32(4);
                        product.Category = dbDataReader.GetInt32(5);
                        try
                        {
                            product.Create_at = dbDataReader.GetDateTime(6).ToString("hh:mm:ss dd/MM/yyyy");
                        }
                        catch { product.Create_at = "null"; }
                        try
                        {
                            product.Updated_at = dbDataReader.GetDateTime(7).ToString("hh:mm:ss dd/MM/yyyy");
                        }
                        catch { product.Updated_at = "null"; }

                        products.Add(product);
                    }
                }
            }
            connection.Close();
            return products;
        }

        public List<Category> GetCategories(string sql)
        {
            List<Category> categories = new List<Category>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            using (dbDataReader = command.ExecuteReader())
            {
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Category category = new Category();
                        category.Id = dbDataReader.GetInt32(0);
                        category.Name = dbDataReader.GetString(1);
                        categories.Add(category);
                    }
                }
            }
            connection.Close();
            return categories;
        }

        #endregion

        #region ACCOUNT
        public List<Account> GetAccounts(string sql)
        {
            List<Account> accounts = new List<Account>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            using (dbDataReader = command.ExecuteReader())
            {
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Account account = new Account();
                        account.ID = dbDataReader.GetInt32(0);
                        account.Username = dbDataReader.GetString(1);
                        account.Password = dbDataReader.GetString(2);
                        account.Name = dbDataReader.GetString(3);
                        account.MaBaoMat = dbDataReader.GetString(4);
                        account.IsStaff = dbDataReader.GetInt32(5);
                        account.IsAdmin = dbDataReader.GetInt32(6);
                        try
                        {
                            account.Create_at = dbDataReader.GetDateTime(7).ToString("HH:mm:ss dd/MM/yyyy");
                        }
                        catch
                        {
                            account.Create_at = "null";
                        }

                        try
                        {
                            account.Update_at = dbDataReader.GetDateTime(8).ToString("HH:mm:ss dd/MM/yyyy");
                        }
                        catch { account.Update_at = "null"; }
                        accounts.Add(account);
                    }
                }
            }
            connection.Close();
            return accounts;
        }
        #endregion

        #region STAFF
        public List<Staff> GetStaffs(string sql)
        {
            List<Staff> staffs = new List<Staff>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            using (dbDataReader = command.ExecuteReader())
            {
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Staff staff = new Staff();
                        staff.Id = dbDataReader.GetInt32(0);
                        staff.Name = dbDataReader.GetString(1);
                        staff.Gender = dbDataReader.GetString(2);
                        staff.Birthday = dbDataReader.GetString(3);
                        staff.Country = dbDataReader.GetString(4);
                        staff.NumberPhone = dbDataReader.GetString(5);
                        staff.Email = dbDataReader.GetString(6);
                        staff.Start_day_work = dbDataReader.GetString(7);
                        staff.Username = dbDataReader.GetString(8);
                        staff.Note = dbDataReader.GetString(9);
                        staffs.Add(staff);
                    }
                }
            }
            connection.Close();
            return staffs;
        }
        #endregion

        #region CUSTOM
        #endregion

        #region STATISFICAL
        #endregion

        #region ALL
        public void StoreInCookie(
            string cookieName,
            string keyName,
            string value,
            DateTime? expirationDate,
            bool httpOnly = false,
            SameSiteMode sameSite = (SameSiteMode)(-1),
            bool secure = false)
        {
            // NOTE: we have to look first in the response, and then in the request.
            // This is required when we update multiple keys inside the cookie.
            HttpCookie cookie = HttpContext.Current.Response.Cookies.AllKeys.Contains(cookieName)
                ? HttpContext.Current.Response.Cookies[cookieName]
                : HttpContext.Current.Request.Cookies[cookieName];

            if (cookie == null) cookie = new HttpCookie(cookieName);
            if (!String.IsNullOrEmpty(keyName)) cookie.Values.Set(keyName, value);
            else cookie.Value = value;
            if (expirationDate.HasValue) cookie.Expires = expirationDate.Value;
            if (!String.IsNullOrEmpty("localhost")) cookie.Domain = "localhost";
            if (httpOnly) cookie.HttpOnly = true;
            cookie.Secure = secure;
            cookie.SameSite = sameSite;
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public bool CookieExist(string cookieName, string keyName)
        {
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
            return (String.IsNullOrEmpty(keyName))
                ? cookies[cookieName] != null
                : cookies[cookieName] != null && cookies[cookieName][keyName] != null;
        }
        public string GetFromCookie(string cookieName, string keyName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                string val = (!String.IsNullOrEmpty(keyName)) ? cookie[keyName] : cookie.Value;
                if (!String.IsNullOrEmpty(val)) return Uri.UnescapeDataString(val);
            }
            return null;
        }
        public void RemoveCookie(string cookieName, string keyName, string domain = "localhost")
        {
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

                // SameSite.None Cookies won't be accepted by Google Chrome and other modern browsers if they're not secure, which would lead in a "non-deletion" bug.
                // in this specific scenario, we need to avoid emitting the SameSite attribute to ensure that the cookie will be deleted.
                if (cookie.SameSite == SameSiteMode.None && !cookie.Secure)
                    cookie.SameSite = (SameSiteMode)(-1);

                if (String.IsNullOrEmpty(keyName))
                {
                    cookie.Expires = DateTime.UtcNow.AddYears(-1);
                    if (!String.IsNullOrEmpty(domain)) cookie.Domain = domain;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    HttpContext.Current.Request.Cookies.Remove(cookieName);
                }
                else
                {
                    cookie.Values.Remove(keyName);
                    if (!String.IsNullOrEmpty(domain)) cookie.Domain = domain;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }
        public DataTable GetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            adapter = new OleDbDataAdapter(sql, connection);
            adapter.Fill(dataTable);
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                for(int j = 0; j < dataTable.Columns.Count; j++)
                {
                    string value = dataTable.Rows[i][j].ToString();
                    dataTable.Rows[i][j] = CompactString(value, 30);
                }
            }
            return dataTable;
        }
        public void InsertOrUpdateOrDelete(string sql)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            command.ExecuteNonQuery();
            connection.Close();

        }
        string CompactString(string str, int limit)
        {
            string tmp = "";
            if (str.Length > limit)
            {
                char[] chars = str.ToCharArray();
                for (int c = 0; c < limit; c++)
                {
                    tmp += chars[c];
                }
                return tmp + " ...";
            }
            return str;
        }
        public string StringToNumber(string str)
        {
            string newStr = "";
            char[] chars = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                char c = chars[i];
                if (IsNumber(c.ToString()))
                {
                    newStr = newStr + chars[i];
                }
            }
            return newStr.Replace(" ", "");
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    
        #endregion
    }
}
