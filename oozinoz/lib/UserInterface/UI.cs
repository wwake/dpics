using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Functions;
using Utilities;

namespace UserInterface
{
    /// <summary>
    /// User interface utilities.
    /// </summary>
    public class UI
    {
        protected Font _font = new Font("Book Antiqua", 18F);
        public static readonly int STANDARD_PAD = 10;
        public static readonly UI NORMAL = new UI();
        /// <summary>
        /// Set up a standard font that subclasses can override.
        /// </summary>
        public virtual Font Font
        {
            get
            {
                return _font;
            }
        }
        /// <summary>
        /// Set up a standard pad amount that subclasses can override.
        /// </summary>
        public virtual int Pad
        {
            get
            {
                return STANDARD_PAD;
            }
        }
        /// <summary>
        /// Create a standard Ok! (or affirmation) button.
        /// </summary>
        /// <returns>a standard Ok! (or affirmation) button</returns>
        public virtual Button CreateButtonOk()
        {
            Button b = CreateButton();
            b.Image = GetImage("rocket-large.gif");
            b.Text = "Ok!";
            return b;
        }
        /// <summary>
        /// Create a standard Cancel! (or negation) button.
        /// </summary>
        /// <returns>a standard Cancel! (or negation) button</returns>
        public virtual Button CreateButtonCancel()
        {
            Button b = CreateButton();
            b.Image = GetImage("rocket-large-down.gif");
            b.Text = "Cancel!";
            return b;
        }
        
        /// <summary>
        /// Create a standard button.
        /// </summary>
        /// <returns>a standard button</returns>
        public virtual Button CreateButton()
        {
            Button b = new Button();
            b.Size = new Size(128, 128);
            b.ImageAlign = ContentAlignment.TopCenter;
            b.Font = Font;
            b.TextAlign = ContentAlignment.BottomCenter;
            return b;
        }
		/// <summary>
		/// Create a panel that adds a standard amount of padding around
		/// any controls that are added to it.
		/// </summary>
		/// <returns>the panel</returns>
		public virtual Panel CreatePaddedPanel()
		{
			Panel p = new Panel();
			p.Dock = DockStyle.Fill;
			p.DockPadding.All = Pad;
			return p;
		} 
		/// <summary>
		/// Create a panel that adds a standard amount of padding around
		/// a given control.
		/// </summary>
		/// <param name="c">the control</param>
		/// <returns>the panel</returns>
		public virtual Panel CreatePaddedPanel(Control c)
		{
			Panel p = CreatePaddedPanel(); 
			p.Controls.Add(c);
			return p;
		}  
        /// <summary>
        /// Create a group box that wraps a titled border around a 
        /// given component.
        /// </summary>
        /// <param name="title">The words to show in the title border tab</param>
        /// <param name="control">The control that the border goes around</param>
        /// <returns>A group box panel with a title, wrapped around the 
        /// supplied control</returns>
        public virtual GroupBox CreateGroupBox(
            String title, Control control)
        {
            GroupBox gb = new GroupBox();
            gb.Text = title;
			gb.Dock = DockStyle.Fill;
            gb.Controls.Add(control);
            return gb;
        }        
        /// <summary>
        /// Create a standard panel for plotting y as a function of
        /// time t.
        /// </summary>
        /// <param name="nPoint">The number of points to plot</param>
        /// <param name="yFunc">The y function</param>
        /// <returns>The plotting panel</returns>
        public virtual PlotPanel CreatePlotPanel(int nPoint, Function yFunc)
        {
            PlotPanel pp = new PlotPanel(nPoint, yFunc);
            pp.BackColor = Color.White;
            return pp;
        }  
        /// <summary>
        /// Create a standard panel for plotting x and y as parametric
        /// equations of time t.
        /// </summary>
        /// <param name="nPoint">The number of points to plot</param>
        /// <param name="xFunc">The x function</param>
        /// <param name="yFunc">The y function</param>
        /// <returns>The plotting panel</returns>
        public virtual PlotPanel CreatePlotPanel(int nPoint, Function xFunc, Function yFunc)
        {
            PlotPanel pp = new PlotPanel(nPoint, xFunc, yFunc);
            pp.BackColor = Color.White;
            return pp;
        }  
        /// <summary>
        /// Create a standard grid for displaying, in particular,
        /// database tables.
        /// </summary>
        /// <returns>A standard data grid</returns>
        public virtual DataGrid CreateGrid()
        {			
            DataGrid g = new DataGrid();
            g.Dock = DockStyle.Fill;
            g.CaptionVisible = false;
            return g;
        }
        /// <summary>
        /// Create a standard list, where each list item has an accompanying
        /// image/icon.
        /// </summary>
        /// <param name="size">the size for images</param>
        /// <param name="images">the images</param>
        /// <returns>a standard list view</returns>
        public virtual ListView CreateListView(Size size, params Image[] images)
        {
            ListView lv = new ListView();
            lv.Font = Font;
            lv.View = View.Details;
            lv.Columns.Add(new ColumnHeader());
            lv.Columns[0].Width = -2; // autosize
            lv.HeaderStyle = ColumnHeaderStyle.None;
            lv.SmallImageList = CreateImageList(size, images);
            return lv;
        }
        // Create an ImageList object given the images and the desired
        // size for them.
        protected virtual ImageList CreateImageList (Size size, params Image[] images) 
        { 
            ImageList il = new ImageList();
            il.ColorDepth = ColorDepth.Depth32Bit;
            il.ImageSize = size;
            foreach (Image i in images) 
            {
                il.Images.Add(i);
            }
            return il; 
        } 
        /// <summary>
        /// This method looks up an image file and returns the image
        /// contained therein. This method expects all images to be
        /// in a path relative to the directory that this assembly
        /// is in, namely ..\images.
        /// </summary>
        /// <param name="imageName">the image to look up</param>
        /// <returns>the image</returns>
        public static Image GetImage(String imageName) 
        {
            return Image.FromFile(FileFinder.GetFileName("images", imageName));
        }
    }
}
