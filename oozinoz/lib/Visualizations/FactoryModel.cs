using System;
using System.Drawing;
using System.Collections;

namespace Visualizations
{
    /// <summary>
    /// A model of a factory; at the moment this model just contains
    /// machine locations. However, the factory also provides support
    /// for undo's by storing off mementos each time the factory 
    /// configuration changes.
    /// </summary>
    public class FactoryModel
    {
        private Stack _mementos;   
        public event AddHandler AddEvent; 
        public event DragHandler DragEvent; 
        public event RebuildHandler RebuildEvent; 
        public static readonly Point DEFAULT_LOCATION = new Point(10, 10);

        /// <summary>
        /// Create a new factory model.
        /// </summary>
        public FactoryModel()
        {
            // start out with an empty list (of machine locations)
            _mementos = new Stack();
            _mementos.Push(new ArrayList());
        }

        /// <summary>
        /// Add a machine to the model; the machine starts out at
        /// a default location.
        /// </summary>
        public void AddMachine()
        {
            // put the new location up front so its Z order is on top
            IList newLocs = new ArrayList();
            Point newP = DEFAULT_LOCATION;
            newLocs.Add(newP);
            foreach (Point p in (IList)_mementos.Peek())
            {
                newLocs.Add(new Point(p.X, p.Y));
            }
            _mementos.Push(newLocs);
            if (AddEvent != null) AddEvent(newP);
        }

        /// <summary>
        /// Move a machine from an old location to a new one. A side
        /// effect is that the new location will be the first in this
        /// model's list of locations. This helps the GUI handle Z order.
        /// In particular, just clicking a machine will move it the the
        /// head of the list and will thus bring it to the "front" of
        /// the display.
        /// </summary>
        /// <param name="oldP">where the machine was</param>
        /// <param name="newP">the new spot for the machine</param>
        public void Drag(Point oldP, Point newP) 
        {
            // put the new location up front so its Z order is on top
            IList newLocs = new ArrayList(); 
            newLocs.Add(newP);
            // create a new list, copying in all except the dragee
            bool foundDragee = false;
            foreach (Point p in (IList)_mementos.Peek())
            {
                if ( !foundDragee && p.Equals(oldP)) 
                {
                    foundDragee = true;
                }
                else
                {
                    newLocs.Add(new Point(p.X, p.Y)); 
                }
            }
            _mementos.Push(newLocs);
            if (DragEvent != null) DragEvent(oldP, newP);
        }
 
        /// <summary>
        /// Change the factory model back the the previous version.
        /// </summary>
        public void Pop()
        {
            if (_mementos.Count > 1) 
            {
                _mementos.Pop(); // pop the current state 
                if (RebuildEvent != null) RebuildEvent();
            }
        }

        /// <summary>
        /// Add a new configuration.
        /// </summary>
        /// <param name="list">A list of Point objects representing machine locations</param>
        public void Push(IList list)
        {
            _mementos.Push(list);
            if (RebuildEvent != null) RebuildEvent();
        }

        /// <summary>
        /// Return the current set of machine locations.
        /// </summary>
        public IList Locations
        {
            get
            {
                return (IList)_mementos.Peek();
            }
        }

        /// <summary>
        /// Return the number of saved configurations. This helps the GUI
        /// decide whether to offer "undo".
        /// </summary>
        public int MementoCount
        {
            get 
            {
                return _mementos.Count;
            }
        }

    }
}