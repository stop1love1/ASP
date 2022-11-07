
using System.Data.OleDb;
namespace HalBookstore.Connect
{
    internal class DBUtils
    {
        public DBUtils() { }
        public static OleDbConnection getDBConnection()
        {
            /*  string host = "sql6.freemysqlhosting.net";
              int port = 3306;
              string database = "sql6505613";
              string username = "sql6505613";
              string password = "N9ukhxrZtm";*/

            /* string host = "localhost";
             int port = 3306;
             string database = "halbookstore";
             string username = "stop1love1";
             string password = "docaolong";*/
            return DBMySQLUtils.GetDBConnection(/*host, database, port, username, password*/);
        }
    }
}
