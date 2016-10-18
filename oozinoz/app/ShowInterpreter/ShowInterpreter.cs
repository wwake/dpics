using System;
using Machines;
using RobotInterpreter;

/// <summary>
/// Demonstrate an initial carry command.
/// </summary>
public class ShowInterpreter
{
    public static void Main()
    {
        MachineComposite dublin = ExampleMachine.Dublin();
        ShellAssembler sa = (ShellAssembler) dublin.Find("ShellAssembler:3302");
        StarPress      sp = (StarPress)      dublin.Find("StarPress:3404");
        UnloadBuffer   ub = (UnloadBuffer)   dublin.Find("UnloadBuffer:3501");

        sa.Load(new Bin(11011));
        sp.Load(new Bin(11015));

        CarryCommand c1 = new CarryCommand(sa, ub);
        CarryCommand c2 = new CarryCommand(sp, ub);

        CommandSequence seq = new CommandSequence();
        seq.AddCommand(c1);
        seq.AddCommand(c2);

        seq.Execute();
    }
}