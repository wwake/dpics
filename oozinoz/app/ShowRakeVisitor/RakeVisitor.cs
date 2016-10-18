using System;
using Machines;
using Utilities;	

/// <summary>
/// This class collects (that is, rakes up) all of the leaves in a
/// machine composite.
/// </summary>
public class RakeVisitor : IMachineVisitor 
{
    protected Set _leaves;

    public Set GetLeaves(MachineComponent mc) 
    {
        _leaves = new Set();
        mc.Accept(this);
        return _leaves;
    }

    public void Visit(Machine m) 
    {
        _leaves.Add(m);
    }

    public void Visit(MachineComposite mc) 
    {
        foreach (MachineComponent child in mc.Children) 
        {
            child.Accept(this);
        }
    }
}