using System.Windows.Forms;
using Visualizations;

	/// <summary>
	/// Show the use of an alternative GUI kit (an alternative
	/// abstract factory).
	/// </summary>
public class ShowBetaVis
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary> 
    public static void Main()
    {
        Application.Run(new Visualization(new BetaUI()));
    }
}