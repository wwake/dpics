using System;
using System.Windows.Forms;
using UserInterface;
using Visualizations;

	/// <summary>
	/// Show the use of an alternative GUI kit (an alternative
	/// abstract factory).
	/// </summary>
public class ShowVisualization
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary> 
    static void Main() 
    {
        Application.Run(new Visualization(UI.NORMAL));
    }
}