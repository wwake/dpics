using System;
using System.Collections;
using Machines;

/// <summary>
/// Show enumeration with 'foreach'.
/// </summary>
class ShowEnumeration
{
    /// <summary>
    /// The main entry point to the application.
    /// </summary>
    static void Main()
    {
        Machine[] machines = {new Machine(1), new Machine(2)};
        IEnumerator e = machines.GetEnumerator();
        while (e.MoveNext())
        {
            Machine m = (Machine) e.Current;
            Console.WriteLine(m.ID);
        }
    }
}