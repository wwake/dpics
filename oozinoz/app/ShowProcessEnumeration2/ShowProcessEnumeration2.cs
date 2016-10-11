using System;
using Enumerators;
using Processes;
/// <summary>
/// This class shows the use of a composite iterator, with the 
/// example of a fireworks process.
/// </summary>
public class ShowProcessEnumeration2
{
    public static void Main() 
    {
        CompositeEnumerator e = (CompositeEnumerator) ShellProcess.Make().GetEnumerator();
        while (e.MoveNext())
        {
            for (int i = 0; i < e.Depth(); i ++)
            {
                Console.Write("    ");
            }
            Console.WriteLine(e.Current);
        }
    }
}