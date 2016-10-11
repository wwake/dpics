using System;
using System.Text;

namespace Functions
{
    /// <summary>
    /// This abstract superclass defines the role of a function
    /// that wraps itself around (or "decorates") another function.
    /// 
    /// The signature of function methods in this hierarchy is
    /// double F(double time). Each class defines this function in a
    /// way that is consistent with the class name. 
    /// 
    /// The "time" argument is a value from 0 to 1 that represents
    /// a normalized notion of time. For example, in the arc of a 
    /// parabola, time goes 0 to 1 as x goes 0 to the base of the arc
    /// and y goes 0 to the apogee (at t = .5) and back to 0.
    /// </summary>
    public abstract class Frapper 
    {
        protected Frapper[] _sources;
        /// <summary>
        /// Construct a function that decorates the provided source
        /// functions.
        /// </summary>
        /// <param name="sources">the source functions that this function
        /// wraps</param>
        public Frapper(Frapper[] sources)
        {
            _sources = sources;
        }
        /// <summary>
        /// Construct a function that decorates the provided source
        /// function.
        /// </summary>
        /// <param name="f">the source function that this function
        /// wraps</param>
        public Frapper(Frapper f) : this(new Frapper[] { f })
        {   
        }
        /// <summary>
        /// The function that subclasses must implement -- see the
        /// subclases for examples.
        /// </summary>
        /// <param name="t">normalized time, a value between 0 and 1</param>
        /// <returns>a function value</returns>
        public abstract double F(double t);

        /// <summary>
        /// Return a textual representation of this function.
        /// </summary>
        /// <returns>a textual representation of this function</returns>
        public override String ToString()
        {
            String name = this.GetType().Name;
            StringBuilder buf = new StringBuilder(name);
            if (_sources.Length > 0)
            {
                buf.Append('(');
                for (int i = 0; i < _sources.Length; i++)
                {
                    if (i > 0)
                    {
                        buf.Append(", ");
                    }
                    buf.Append(_sources[i]);
                }
                buf.Append(')');
            }
            return buf.ToString();
        }
    }
}
