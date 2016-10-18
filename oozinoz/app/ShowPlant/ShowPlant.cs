using System;
using Machines;

/// <summary>
/// This class sets up a challenge in the Composite chapter.
/// </summary>
public class ShowPlant 
{
    public static void Main() 
    {
        MachineComponent c = ExampleMachine.Plant();
        Console.WriteLine(c.GetMachineCount());
    }
}