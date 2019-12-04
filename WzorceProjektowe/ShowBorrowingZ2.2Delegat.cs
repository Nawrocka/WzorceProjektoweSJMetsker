using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstracja wykorzystania delegacji BorrowReader i metody
/// lendReader() z klasy DataServices.
/// </summary>
public class ShowBorrowing
{
    public static void Main()
    {
        string sel = "SELECT * FROM ROCKET";
        DataServices.LendReader(sel, new BorrowReader(GetNames));
    }
    private static Object GetNames(IDataReader reader) //[M] Interfejs do odczytu z przynajmniej jednego strumienia danych baz relacyjnych
    {
        while (reader.Read()) //[M] Odczytuje kolejne rekordy
        {
            Console.WriteLine(reader["Name"]);
        }
        return null;
    }
}
