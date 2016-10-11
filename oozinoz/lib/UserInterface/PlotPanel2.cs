using System;
using System.Drawing;  
using System.Windows.Forms;
using Functions;
namespace UserInterface
{
    /// <summary>
    /// This class displays pair of functions in a panel. The functions
    /// are x and y functions, parameterized by time. As the panel plots,
    /// time goes 0 to 1.
    /// </summary>
    public class PlotPanel2 : Panel 
    {
        private int _nPoint;
        private Point[] points;
        private Frapper _x;
        private Frapper _y;
        
        double minx, miny, maxx, maxy;
        double aspectRatio;
        double left, bottom, right, top;

        /// <summary>
        /// Create a plot calculated from the provided x and y functions.
        /// These functions must be functions of time; time goes 0 to 1
        /// as the panel plots.
        /// </summary>
        /// <param name="nPoint">the number of points to plot</param>
        /// <param name="x">the x function</param>
        /// <param name="y">the y function</param>
        public PlotPanel2(int nPoint, Frapper x, Frapper y)
        {  
            _nPoint = nPoint;
            points = new Point[_nPoint];
            _x = x;
            _y = y;   
            BackColor = Color.White;
            Dock = DockStyle.Fill;
            FindExtrema();
            FindAspectRatio();
        }
        /// <summary>
        /// Find the limits of the supplied functions.
        /// </summary>
        protected void FindExtrema()
        {
            minx = maxx = _x.F(0);
            miny = maxy = _y.F(0);
            for (int i = 0; i < _nPoint; i++) 
            {
                double t = ((double) i) / (_nPoint - 1);
                double x = _x.F(t);
                double y = _y.F(t);

                minx = Math.Min(minx, x);
                miny = Math.Min(miny, y);
                maxx = Math.Max(maxx, x);
                maxy = Math.Max(maxy, y);
            }
        }
        /// <summary>
        /// Find the ratio or the plot's width to its height.
        /// </summary>
        protected void FindAspectRatio()
        {   
            double numer = maxx - miny;
            double denom = maxy - miny;
            if (numer == 0 || denom == 0) 
            {
                aspectRatio = 1;
            } 
            else 
            {
                aspectRatio = numer / denom;
            }
        }
        // Paint the desired functions when necessary
        protected override void OnPaint(PaintEventArgs pea)
        {
            SetCanvasArea();
            Scale sx = new Scale(minx, _x, maxx, left, right);
            Scale sy = new Scale(miny, _y, maxy, bottom, top);

            for (int i = 0; i < _nPoint; i++)
            {
                double t = ((double) i) / (_nPoint - 1);
                points[i].X = (int) sx.F(t);
                points[i].Y = (int) sy.F(t);
            }
            
            Pen pen = new Pen(ForeColor);
            Graphics g = pea.Graphics;
            g.DrawLines(pen, points); 
        }
        /// <summary>
        /// Set the canvas area (the values of left, bottom, right, and top)
        /// to use the greatest area that is consistent with the plot's 
        /// aspect ratio.
        /// </summary>
        protected void SetCanvasArea()
        {
            double w = Width - 1;
            double h = Height - 1;

            /* We can produce the plot using either the full width or full
             * height of the canvas, and calculate one of these dimensions
             * from the other. We initially guess that we can produce the 
             * plot at its full thickess (width); If that would be too tall, 
             * we produce the plot at its full tallness (height).
             */
            double thickness = w;
            double tallness = thickness / aspectRatio;
            if (tallness > h) // oops! too high
            {
                tallness = h;
                thickness = tallness * aspectRatio;
            }
         
            left   = w / 2 - thickness / 2;
            bottom = h / 2 + tallness / 2;
            right  = w / 2 + thickness / 2;
            top    = h / 2 - tallness / 2;
        }
        // Repaint the panel if the size changes.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
    }
}
