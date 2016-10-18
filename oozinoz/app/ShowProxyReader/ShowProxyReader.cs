using System;
using System.Data;
using DataLayer;

/// <summary>
/// Demonstrate the use of the BorrowReader delegate and the
/// lendReader() method of the DataServices class.
/// </summary>
public class ShowProxyReader
{
    public static void Main()
    {
        string sel = "SELECT * FROM ROCKET";
        DataServices.LendReader(sel, new BorrowReader(GetNames));
    }

    private static Object GetNames(IDataReader reader)
    {
        LimitingReader proxy = new LimitingReader(reader);
        while (proxy.Read()) 
        {
            Console.Write("{0,10} ", proxy["Name"]);
            Console.Write("{0,7:C} ", proxy["price"]);
            Console.Write("{0,5}", proxy["apogee"]);
            Console.WriteLine();
        }
        return null;
    }
}