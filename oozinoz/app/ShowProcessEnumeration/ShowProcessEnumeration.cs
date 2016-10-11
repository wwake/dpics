using System;
using Enumerators;
using Processes;
/// <summary>
/// This class shows the use of a composite iterator, with the 
/// example of a fireworks process.
/// </summary>
public class ShowProcessEnumeration 
{
    public static void Main() 
    {
        foreach (ProcessComponent pc in ShellProcess.Make())
        {
            Console.WriteLine(pc);
        }
    }
}