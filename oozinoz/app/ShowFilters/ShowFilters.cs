using System;
using System.IO;
using Filters;

/// <summary>
/// This class shows how to compose a few filters.
/// </summary>
public class ShowFilters
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("usage: ShowFilters input output");
            return;
        }
        StreamReader   r = new StreamReader(args[0]);
        ISimpleWriter w1 = new SimpleStreamWriter(args[1]);
        ISimpleWriter w2 = new TitleCaseFilter(w1);
        WrapFilter    w3 = new WrapFilter(w2, 40);
        w3.Center = true;
        String line;
        while ((line = r.ReadLine()) != null)
        {
            w3.Write(line);
        }
        r.Close();
        w3.Close();
    }
}