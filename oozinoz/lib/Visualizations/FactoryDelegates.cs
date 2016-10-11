namespace Visualizations
{
    using System.Drawing;
    public delegate void AddHandler(Point p);
    public delegate void DragHandler(Point oldP, Point newP);
    public delegate void RebuildHandler(); 
}