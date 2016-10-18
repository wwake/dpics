using System;
using Processes;

/// <summary>
/// Show the use of the PrettyVisitor class.
/// </summary>
public class ShowPrettyVisitor
{    
    /// <summary>
    /// The main entry point to this program.
    /// </summary>
    public static void Main()
    {
        ProcessComponent p = ShellProcess.Make();
        PrettyVisitor v = new PrettyVisitor();
        Console.WriteLine(v.GetPretty(p));
    }
}