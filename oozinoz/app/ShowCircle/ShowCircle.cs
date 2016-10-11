using System;
using System.Drawing;  
using System.Windows.Forms;

    /// <summary>
    /// Show a set of parametric equations that plot a circle.
    /// </summary>
public class ShowCircle : Form
{
    // Draw a circle, given the chance.
    protected override void OnPaint(PaintEventArgs pea)
    {   
        int nPoint = 101;
        double w = ClientSize.Width - 1;
        double h = ClientSize.Height - 1;
        double r = Math.Min(w, h) / 2.0 - 10.0;
        Point[] points = new Point[nPoint];
        for (int i = 0; i < nPoint; i++) 
        {
            double t = ((double) i) / (nPoint - 1);
            double theta = Math.PI * 2.0 * t;
            points[i].X = (int) (w / 2 + r * Math.Cos(theta));
            points[i].Y = (int) (h / 2 - r * Math.Sin(theta));
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
    /// The main entry point for this circle-drawing program.
    /// </summary>
    public static void Main()
    {
        Form f = new ShowCircle(); 
        f.ClientSize = new Size(500, 500);
        f.Text = "A Circle from Parametric Equations";
        Application.Run(f);
    }   
}