using System;
using System.Data;
using DataLayer;

public class ShowBorrowing : IBorrow
{
    public static void Main()
    {
        string select = "SELECT * FROM ROCKET"; 
        DataServices.LendReader(select, new ShowBorrowing());
    }

    private static object GetName(IDataReader reader)
    {
        while(reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }
        return null;
    }

    public object BorrowReader(IDataReader reader)
    {
        return GetName(reader);
    }
}