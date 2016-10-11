using System;
namespace Functions
{
    /// <summary>
    /// Wrap the Math.Abs() function around a given source.
    /// </summary>
    public class Abs : Frapper 
    {
        /// <summary>
        /// Construct an absolute value function that decorates the 
        /// provided source function.
        /// </summary>
        /// <param name="f">Another function wrapper</param>
        public Abs(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Return Math.Abs() applied to the source function's value
        /// at time t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>the abolute value of the source function value at time t</returns>
        public override double F(double t)
        {
            return Math.Abs(_sources[0].F(t));
        }
    }
}
