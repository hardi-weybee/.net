using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceApplication
{
    public class conn
    {
        public static string cs;
        public SqlConnection sqlCon;

        private static void getConnection()
        {
            cs = ConfigurationManager.ConnectionStrings["invoiceConnectionString2"].ConnectionString;
        }

        public static SqlConnection GetSqlConnection()
        {
            if (string.IsNullOrEmpty(cs))
            {
                getConnection();
            }
            var sqlCon = new SqlConnection(cs);
            sqlCon.Open();
            return sqlCon;
        }

        public void CloseSqlConnection()
        {
            var close = new SqlConnection(cs);
            close.Close();
        }
    }
}