using System;
using System.Windows.Forms;
using Functions;
using UserInterface;

/// <summary>
/// An example from the "Decorator" chapter, this class shows that a
/// complex new function can be constructed at runtime.
/// </summary>
public class ShowBrightness
{
    /// <summary>
    /// The main entry point to the application.
    /// </summary>
    public static void Main()
    {
        Frapper brightness =
            new Arithmetic(
            '*',
            new Exp(
                 new Arithmetic(
                      '*', new Constant(-4), new T())),
            new Sin(
                 new Arithmetic(
                      '*', new Constant(Math.PI), new T())));
           
        PlotPanel2 p = new PlotPanel2(100, new T(), brightness); 
		Panel p2 = UI.NORMAL.CreatePaddedPanel(p);
        GroupBox gb = UI.NORMAL.CreateGroupBox("Brightness vs. Total Burn Time", p2); 
        gb.Font = UI.NORMAL.Font;
        Form f = new Form();
        f.DockPadding.All = 10;
        f.Text = "Brightness";  
        f.Controls.Add(gb);  
        Application.Run(f);
    } 
}