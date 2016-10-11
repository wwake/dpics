using System;
using Machines;
using RobotInterpreter2;
/// <summary>
/// Show the use of a "while" interpreter.
/// </summary>
public class ShowInterpreterWhile 
{
    public static void Main()
    {            
        MachineComposite dublin = ExampleMachine.Dublin();
        Term sp = new Constant((Machine) dublin.Find("StarPress:1401"));
        Term ub = new Constant((Machine) dublin.Find("UnloadBuffer:1501"));
        WhileCommand wc = new WhileCommand(
            new HasMaterial(sp),
            new CarryCommand(sp, ub));
        wc.Execute();
    }
}