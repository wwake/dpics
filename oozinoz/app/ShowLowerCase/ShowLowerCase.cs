using System;
using Filters;
/// <summary>
/// Show how to use a lower case filter.
/// </summary>
public class ShowLowerCase
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
        ISimpleWriter w = new SimpleStreamWriter("sample.txt");
        ISimpleWriter x = new LowerCaseFilter(w);
        x.Write("This Text, notably ALL in LoWeR casE!");
        x.Close();
    }
}