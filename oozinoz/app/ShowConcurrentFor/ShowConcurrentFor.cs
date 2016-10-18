using System;
using System.Collections;
using System.Threading;
using BusinessCore;
/// <summary>
/// Show that a "synchronized" list does not ensure that
/// iteration over the list with a "for" loop is thread safe.
/// </summary>
public class ShowConcurrentFor   
{
    private ArrayList _list;
    protected void DisplayUpMachines()
    {
        _list = ArrayList.Synchronized(Factory.UpMachineNames()); 
        for (int i = 0; i < _list.Count; i++)
        {
            if (i == 2)
            { // simulate wake-up
                new Thread(new ThreadStart(NewMachineComesUp)).Start();
            }
            Thread.Sleep(100); // give other threads a chance
            Console.WriteLine(_list[i]);
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
        new ShowConcurrentFor().DisplayUpMachines();
    }
}