using System;
namespace Functions
{
    /// <summary>
    /// Wrap the Math.Cos() function around a given source.
    /// </summary>
    public class Cos : Frapper 
    {
        /// <summary>
        /// Construct a cosine function that decorates the 
        /// provided source function.
        /// </summary>
        /// <param name="f">Another function wrapper</param>
        public Cos(Frapper f) : base (f)
        {
        }

        /// <summary>
        /// Return Math.Cos() applied to the source function's value
        /// at time t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>the cos of the source function value at time t</returns>
        public override double F(double t)
        {
            return Math.Cos(_sources[0].F(t));
        }
    }
}
