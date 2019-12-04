using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;
using Utilities;

namespace DataLayer
{
    public class DataServices
    {
        public static object LendReader(string sql, IBorrow borrower)
        {
            using (OleDbConnection conn = CreateConnection())
            {
                conn.Open();
                OleDbCommand c =new OleDbCommand(sql, conn);
                OleDbDataReader r = c.ExecuteReader();
                return borrower.BorrowReader(r);
            }
        }

        public static OleDbConnection CreateConnection()
        {
            String dbName = FileFinder.GetFileName("db","oozinoz.mdb");
            OleDbConnection c = new OleDbConnection();
            c.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + dbName;
            return c;
        }
    }

    public interface IBorrow
    {
        object BorrowReader (IDataReader reader);
    }
}