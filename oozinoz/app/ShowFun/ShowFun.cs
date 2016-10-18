using System;
using System.Windows.Forms;
using Functions;
using UserInterface;

/// <summary>
/// This class shows off how to create new functions at
/// runtime, under the pretext of showing the outline of a
/// chrysanthemum shell.
/// </summary>
public class ShowFun
{
    /// <summary>
    /// Show a design for a new chrysanthemum shell. 
    /// </summary>
    public static void Main()
    {
        Frapper theta  = new Arithmetic('*', new T(), new Constant(2 * Math.PI));
        Frapper theta2 = new Arithmetic('*', new T(), new Constant(2 * Math.PI * 5));
        Frapper x = new Arithmetic('+', new Cos(theta), new Cos(theta2));
        Frapper y = new Arithmetic('+', new Sin(theta), new Sin(theta2));
           
        PlotPanel2 p = new PlotPanel2(300, x, y); 
        Form f = new Form();
        f.DockPadding.All = 10;
        f.Text = "Chrysanthemum";  
        f.Controls.Add(p);  
        Application.Run(f);
    } 
}