using System;
namespace Functions
{
    /// <summary>
    /// Wrap the Math.Sin() function around a given source.
    /// </summary>
    public class Sin : Frapper 
    {
        /// <summary>
        /// Construct a sine function that decorates the 
        /// provided source function.
        /// </summary>
        /// <param name="f">Another function wrapper</param>
        public Sin(Frapper f) : base (f)
        {
        }
        /// <summary>
        /// Return Math.Sin() applied to the source function's value
        /// at time t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>the sin of the source function value at time t</returns>
        public override double F(double t)
        {
            return Math.Sin(_sources[0].F(t));
        }
    }
}
