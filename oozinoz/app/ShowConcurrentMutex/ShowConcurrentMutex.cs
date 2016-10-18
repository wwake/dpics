using System;
using System.Collections;
using System.Threading;
using BusinessCore;

/// <summary>
/// Show the use of the lock of a "mutex" object for ensuring the
/// "mutual exclusion" of two threads. See "Iterator" for a discussion
/// of mutual exclusion.
/// </summary>
public class ShowConcurrentMutex 
{
    private ArrayList _list;
    private Object _mutex = new Object();

    protected void DisplayUpMachines() 
    {
        _list = Factory.UpMachineNames();
        lock (_mutex) 
        {
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
    }

    public void NewMachineComesUp() 
    {
        lock (_mutex) 
        {
            _list.Insert(0, "Fuser:1101");
        }
    }
    
    public static void Main() 
    {
        new ShowConcurrentMutex().DisplayUpMachines();
    }
}