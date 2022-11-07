using System.Data.OleDb;
namespace HalBookstore.Connect
{
    internal class DBMySQLUtils
    {
        public static OleDbConnection GetDBConnection(/*string host, string database, int port, string username, string password*/)
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ASP.NET\1\HalBookstore\Database\HalBookstore.accdb";
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connString;
            return conn;
        }
    }
}
