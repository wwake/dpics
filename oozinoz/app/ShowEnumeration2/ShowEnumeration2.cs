using System;
using Machines;
/// <summary>
/// Show manual enumeration;
/// </summary>
class ShowEnumeration2
{
    /// <summary>
    /// The main entry point to the application.
    /// </summary>
    static void Main()
    {
        Machine[] machines = {new Machine(1), new Machine(2)};
        foreach (Machine m in machines) 
        {
            Console.WriteLine(m.ID);
        }
    }
}