using System;
using System.Windows.Forms;
using Machines;
using UserInterface;
/// <summary>
/// Show an example of using a TreeNodeVisitor.
/// </summary>
public class ShowTreeNodeVisitor : Form
{
    public ShowTreeNodeVisitor()
    {
        TreeView view = new TreeView();
        view.Dock = DockStyle.Fill;
        view.Font = UI.NORMAL.Font; 
        TreeNodeVisitor v = new TreeNodeVisitor();
        v.Visit(ExampleMachine.Dublin());
        view.Nodes.Add(v.TreeNode);
        Controls.Add(view);        
        Text = "Show Tree Node View"; 
    }
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public static void Main() 
    {
        Application.Run(new ShowTreeNodeVisitor());
    }
}