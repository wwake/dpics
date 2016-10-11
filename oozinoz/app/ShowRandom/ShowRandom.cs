using System;
using Filters;

/// <summary>
/// Show the effects of randomizing text.
/// </summary>
public class ShowRandom
{
    public static void Main()
    {
        ISimpleWriter w = new RandomCaseFilter(
            new ConsoleWriter());
        w.Write(
            "buy two packs now and get a " + 
            "zippie pocket rocket -- free!");
        w.WriteLine();
        w.Close();
    }
}