using System;
using System.Text;
using Processes;
using Utilities;
/// <summary>
/// This class uses the visitor mechanics of the process
/// hierarchy to add a behavior that pretty-prints a
/// process composite. The prettiness is basically indentation,
/// although alternations are prefixed with a question mark
/// to note that they're alternations.
/// 
/// This visitor takes care not to print any component twice, 
/// if the original component is cyclic. On encountering a node 
/// a second time, this visitor will print an ellipsis (...). 
/// </summary>
public class PrettyVisitor : IProcessVisitor 
{
    public static readonly string INDENT_STRING = "    ";
    private StringBuilder _buf;
    private int _depth;
    private Set _visited;    
    /// <summary>
    /// Returns a pretty (that is, indented) description of the
    /// supplied process component.
    /// </summary>
    /// <param name="pc">the process component to portray</param>
    /// <returns>an indented description of the supplied process 
    /// component</returns>
    public StringBuilder GetPretty(ProcessComponent pc)
    {
        _buf = new StringBuilder();
        _visited = new Set();
        _depth = 0;
        pc.Accept(this);
        return _buf;
    }
    protected void PrintIndentedString(String s)
    {
        for (int i = 0; i < _depth; i++)
        {
            _buf.Append(INDENT_STRING);
        }
        _buf.Append(s);
        _buf.Append("\n");
    }
    /// <summary>
    /// Add a step to the output buffer.
    /// </summary>
    /// <param name="s">the step</param>
    public void Visit(ProcessStep s)
    {
        PrintIndentedString(s.Name);
    }
    /// <summary>
    /// Add an alternation to the output buffer.
    /// </summary>
    /// <param name="a">the alternation</param>
    public void Visit(ProcessAlternation a)
    {
        VisitComposite("?", a);
    }
    /// <summary>
    /// Add a sequence to the output buffer.
    /// </summary>
    /// <param name="s">the sequence</param>
    public void Visit(ProcessSequence s)
    {
        VisitComposite("", s);
    }
    /// <summary>
    /// Print the prefix and name of this composite, and print its 
    /// children. If we've printed this element before, just print 
    /// an ellipsis instead of printing the children again.
    /// </summary>
    /// <param name="prefix">a possible prefix</param>
    /// <param name="c">the composite to display</param>
    protected void VisitComposite(String prefix, ProcessComposite c)
    {
        if (_visited.Contains(c))
        {
            PrintIndentedString(prefix + c.Name + "...");
        }
        else
        {
            _visited.Add(c);
            PrintIndentedString(prefix + c.Name);
            _depth++;
            foreach (ProcessComponent child in c.Children)
            {
                child.Accept(this);
            }
            _depth--;
        }
    }
}