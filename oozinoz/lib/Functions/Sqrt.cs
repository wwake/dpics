using System;
namespace Functions
{
    /// <summary>
    /// Wrap the Math.Sqrt() function around a given source.
    /// </summary>
    public class Sqrt : Frapper 
    {
        /// <summary>
        /// Construct a square root function that decorates the 
        /// provided source function.
        /// </summary>
        /// <param name="f">Another function wrapper</param>
        public Sqrt(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Return Math.Sqrt() applied to the source function's value
        /// at time t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>the square root of the source function value 
        /// at time t</returns>
        public override double F(double t)
        {
            return Math.Sqrt(_sources[0].F(t));
        }
    }
}
