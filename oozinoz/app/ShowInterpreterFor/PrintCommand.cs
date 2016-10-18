using System;
using RobotInterpreter2;

/// <summary>
/// An interpreter class that upon execution prints out the ToString()
/// value of a supplied variable.
/// </summary>
public class PrintCommand : Command
{
    private Variable _v;

    public PrintCommand(Variable v)
    {
        _v = v;
    }
    
    public override void Execute()
    {
        Console.WriteLine(_v);
    }
}