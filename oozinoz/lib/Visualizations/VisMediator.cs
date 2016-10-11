using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap; 
using System.Windows.Forms;

namespace Visualizations
{
    /// <summary>
    /// This class handles the UI events for the Visualization class
    /// </summary>
    public class VisMediator 
    {
        protected int initX;
        protected int initY;
        protected Point initLocation;
        protected bool isMouseDown = false;
         
        protected FactoryModel _factoryModel;

        /// <summary>
        /// Create a new mediator for a visualization that uses the provided
        /// factory model.
        /// </summary>
        /// <param name="m">The model that tracks equipment locations</param>
        public VisMediator(FactoryModel m)
        {
            _factoryModel = m; 
        } 

        // The user clicked "Add"
        internal void Add(object sender, System.EventArgs e)
        {
            _factoryModel.AddMachine();
        }

        // The user has clicked "Undo"
        internal void Undo(object sender, System.EventArgs e)
        {
            _factoryModel.Pop();
        }

        // A click on a picture box
        internal void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            { 
                PictureBox pb = (PictureBox) sender;
                initLocation = pb.Location;
                initX = Control.MousePosition.X;
                initY = Control.MousePosition.Y;             
                isMouseDown = true;
            }    
        }

        // A drag while a picture box is clicked
        internal void MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown) 
            {
             
                PictureBox pb = (PictureBox) sender;
                pb.Location = new Point(initLocation.X + Control.MousePosition.X - initX,
                    initLocation.Y + Control.MousePosition.Y - initY);
            }
        }

        // leggo of a picture box. Let the factory model know about this change
        internal void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                isMouseDown = false;
                PictureBox pb = (PictureBox) sender;
                _factoryModel.Drag(initLocation, pb.Location); 
            }
        }

        // User clicked "Save As..." menu item
        internal void Save(object sender, System.EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {   
                using (FileStream fs = File.Create(d.FileName))
                {
                    new SoapFormatter().Serialize(fs, _factoryModel.Locations);
                }             
            }
        }

        // User clicked "Restore from..." menu item
        internal void Restore(object sender, System.EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Open(d.FileName, FileMode.Open))
                {
                    IList list = (IList)(new SoapFormatter().Deserialize(fs));    
                    _factoryModel.Push(list);             
                } 
            }
        }
    }
}