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
    public class PlotPanel : Panel 
    {
        private int _nPoint;
        private Point[] points;
        private Function _xFunc;
        private Function _yFunc;
        /// <summary>
        /// Create a plot of a y function versus time (which goes 0 to 1).
        /// </summary>
        /// <param name="nPoint">the number of points to plot</param>
        /// <param name="yFunc">the y function</param>
        public PlotPanel (int nPoint, Function yFunc) : 
            this (nPoint, new Function(T), yFunc)
        {
        }
        /// <summary>
        /// Create a plot calculated from the provided x and y functions.
        /// These functions must be functions of time; time goes 0 to 1
        /// as the panel plots.
        /// </summary>
        /// <param name="nPoint">the number of points to plot</param>
        /// <param name="xFunc">the x function</param>
        /// <param name="yFunc">the y function</param>
        public PlotPanel(int nPoint, Function xFunc, Function yFunc)
        {  
            _nPoint = nPoint;
            points = new Point[_nPoint];
            _xFunc = xFunc;
            _yFunc = yFunc;   
            BackColor = Color.White;
			Dock = DockStyle.Fill;
        }
        // Paint the desired functions when necessary
        protected override void OnPaint(PaintEventArgs pea)
        {
            double w = Width - 1;
            double h = Height - 1;
            for (int i = 0; i < _nPoint; i++)
            {
                double t = ((double) i) / (_nPoint - 1);
                points[i].X = (int) (_xFunc(t) * w);
                points[i].Y = (int) (h * (1 - _yFunc(t)));
            }
            
            Pen p = new Pen(ForeColor);
            Graphics g = pea.Graphics;
            g.DrawLines(p, points); 
        }
        // Repaint the panel if the size changes.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
        // default x values are just t itself
        private static double T(double t)
        {
            return t;
        }
    }
}
