using System;
using Filters;
using Machines;
using Utilities;
/// <summary>
/// Show an example of using a RakeVisitor.
/// </summary>
public class ShowRakeVisitor
{
    public static void Main() 
    {
        MachineComponent dublin = ExampleMachine.Dublin(); 
        OozinozFilter w = new CommaListFilter(new WrapFilter(new ConsoleWriter(), 60));
        Set leaves = new RakeVisitor().GetLeaves(dublin);
        foreach (MachineComponent mc in leaves)
        {
            w.Write(mc.ID.ToString());
        }
        w.Close(); 
    }
}