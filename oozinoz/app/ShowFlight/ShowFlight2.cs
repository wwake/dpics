using System;
using System.Windows.Forms;
using Functions;
using UserInterface;

/// <summary>
/// This refactored version of ShowFlight contains just a small
/// Main() method and the X- and Y-functions of a dud's flight.
/// </summary>
public class ShowFlight2
{
    private static double X(double t)
    {
        return t;
    }

    private static double Y(double t)
    {
        // y is 0 at t = 0, 1; y is 1 at t = .5
        return 4 * t * (1 - t);
    }

    /// <summary>
    /// Show the flight path of a nonexploding aerial shell. 
    /// </summary>
    public static void Main()
    {
        PlotPanel p = new PlotPanel(
            101, new Function(X), new Function(Y)); 
        Panel p2 = UI.NORMAL.CreatePaddedPanel(p);
        GroupBox gb = 
            UI.NORMAL.CreateGroupBox("Flight Path", p2); 
        Form f = new Form();
        f.DockPadding.All = 10; 
        f.Font = UI.NORMAL.Font;
        f.Text = "Flight Path for Shell Duds";  
        f.Controls.Add(gb);      

        Application.Run(f);
    } 
}