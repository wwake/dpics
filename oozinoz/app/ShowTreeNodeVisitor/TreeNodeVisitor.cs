using System;
using System.Windows.Forms;
using Machines;

    /// <summary>
    /// This visitor class produces a TreeNode structure that mirrors 
    /// the machine composite that it visits.
    /// </summary>
public class TreeNodeVisitor : IMachineVisitor
{
    private TreeNode _tree = null;
    private TreeNode _current = null;

    /// <summary>
    /// The resulting TreeNode object.
    /// </summary>
    public TreeNode TreeNode 
    {
        get 
        {
            return _tree;
        }
    }

    /// <summary>
    /// Visit a machine: add a TreeNode object to the current spot
    /// in the tree.
    /// </summary>
    /// <param name="m">the machine to visit</param>
    public void Visit(Machine m)
    {
        AddNode(m);
    }

    /// <summary>
    /// Visit a machine composite: add a TreeNode object to the current
    /// spot, make the current spot this new node, visit the composite's
    /// children, and replace the "current" with its old value.
    /// </summary>
    /// <param name="c">the composite to visit</param>
    public void Visit(MachineComposite c)
    {
        TreeNode oldCurrent = _current;
        _current = AddNode(c);
        foreach (MachineComponent mc in c.Children)
        {
            mc.Accept(this);
        }
        _current = oldCurrent;
    }

    /// <summary>
    /// Add a tree node for this component.
    /// </summary>
    /// <param name="m">the component to add</param>
    /// <returns>the new tree node</returns>
    protected TreeNode AddNode(MachineComponent m) 
    {
        TreeNode newNode = new TreeNode(m.ToString());
        if (_current == null) 
        {
            _tree = newNode;
        }
        else
        {
            _current.Nodes.Add(newNode);
        }
        return newNode;
    }
}