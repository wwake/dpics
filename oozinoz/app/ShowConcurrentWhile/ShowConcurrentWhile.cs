using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Show that iterations over a "synchronized" list may 
/// spot a multi-threading problem.
/// </summary>
public class ShowConcurrentWhile   
{
    private ArrayList _list;
    protected void DisplayUpMachines()
    {
        _list = ArrayList.Synchronized(Factory.UpMachineNames());
        IEnumerator i = _list.GetEnumerator();
        int counter = 0;
        while (i.MoveNext())
        {
            if (++counter == 2)
            { // simulate wake-up
                new Thread(new ThreadStart(NewMachineComesUp)).Start();
            }
            Thread.Sleep(100); // give other threads a chance
            Console.WriteLine(i.Current);
        }
    }
    /// <summary>
    /// Simulate that a machine comes up while we're iterating
    /// over the list that this routine changes.
    /// </summary>
    public void NewMachineComesUp()
    {
        _list.Insert(0, "Fuser:1101");
    }
    /// <summary>
    /// The main entry point into the program.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine(
            @"This program crashes, to demonstrated the effects of modifying
a 'synchronized' list while iterating over the list.");
        new ShowConcurrentWhile().DisplayUpMachines();
    }
}