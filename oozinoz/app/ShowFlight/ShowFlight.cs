using System;
using System.Drawing;  
using System.Windows.Forms;
using UserInterface;
/// <summary>
/// This class displays the flight path of a dud, but it needs 
/// refactoring. When you refactor it, you should see a facade 
/// emerge for displaying Windows controls.
/// </summary>
public class ShowFlight : Panel 
{
    public ShowFlight()
    {  
        BackColor = Color.White;
        Dock = DockStyle.Fill;
    }
    /// <summary>
    /// Create a new panel that wraps a titled border around a padded
    /// panel, and wraps the padded panel around a given control.
    /// </summary>
    /// <param name="title">The words to show in the title border tab</param>
    /// <param name="control">The control that the border goes around</param>
    /// <returns>A group box panel with a title, wrapped around the 
    /// supplied control</returns>
    public static GroupBox CreateGroupBox(String title, Control control)
    {
        GroupBox gb = new GroupBox();
        gb.Text = title;
        gb.Dock = DockStyle.Fill;
                
        Panel p = new Panel();
        p.Dock = DockStyle.Fill;
        p.DockPadding.All = 10;
        p.Controls.Add(control);

        gb.Controls.Add(p);
        return gb;
    }  
    // Paint a parabola. In this method, t goes 0 to 1,
    // and x goes 0 to w (the width of the graphics area).
    // The values of y must be h at t = 0 and t = 1, and 
    // must be 0 at t = .5.
    protected override void OnPaint(PaintEventArgs pea)
    {
        int nPoint = 101;
        double w = Width - 1;
        double h = Height - 1;
        Point[] points = new Point[nPoint];
        for (int i = 0; i < nPoint; i++)
        {
            double t = ((double) i) / (nPoint - 1);
            points[i].X = (int) (t * w);
            points[i].Y = (int) (4 * h * (t - .5) * (t - .5));
        }            
        Pen p = new Pen(ForeColor);
        Graphics g = pea.Graphics;
        g.DrawLines(p, points); 
    }
    // Repaint the panel if the size changes.
    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        Refresh();
    }
    /// <summary>
    /// Show the flight path of a nonexploding aerial shell. 
    /// </summary>
    public static void Main()
    {
        ShowFlight sf = new ShowFlight(); 
        GroupBox gb = CreateGroupBox("Flight Path", sf);
        Form f = new Form();
        f.DockPadding.All = 10;
        f.Text = "Flight Path for Shell Duds";  
        f.Font = UI.NORMAL.Font;
        f.Controls.Add(gb);      

        Application.Run(f);
    } 
}