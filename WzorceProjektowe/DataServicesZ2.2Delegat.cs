using System;
using System.Data;
using System.Data.OleDb;
using Utilities;

namespace DataLayer
{
    public delegate object BorrowReader(IDataReader reader);
    public class DataServices
    {        
        public static object LendReader(string sql, BorrowReader borrower)
        {
            using (OleDbConnection conn = CreateConnection())
            {
                conn.Open();
                OleDbCommand c = new OleDbCommand(sql, conn);
                OleDbDataReader r = c.ExecuteReader();
                return borrower(r);
            }
        }

        public static OleDbConnection CreateConnection()
        {
            String dbName = FileFinder.GetFileName("db", "oozinoz.mdb");
            OleDbConnection c = new OleDbConnection();
            c.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + dbName;
            return c;
        }
    }
}