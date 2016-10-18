using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstrate the use of the BorrowReader delegate and the
/// lendReader() method of the DataServices class.
/// </summary>
public class ShowBorrowing
{
    public static void Main()
    {
        string sel = "SELECT * FROM ROCKET";
        DataServices.LendReader(sel, new BorrowReader(GetNames));
    }

    private static Object GetNames(IDataReader reader)
    {
        while (reader.Read()) 
        {
            Console.WriteLine(reader["Name"]);
        }
        return null;
    }
}