using System;
namespace Functions
{
    /// <summary>
    /// Wrap the Math.Exp() function around a given source. 
    /// </summary>
    public class Exp : Frapper 
    {
        /// <summary>
        /// Construct a exponent function that decorates the 
        /// provided source function.
        /// </summary>
        /// <param name="f">Another function wrapper</param>
        public Exp(Frapper f) : base (f)
        {
        }

        /// <summary>
        /// Return Math.Exp() applied to the source function's value
        /// at time t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>Math.E raised to the power of the source function 
        /// value at time t</returns>
        public override double F(double t)
        {
            return Math.Exp(_sources[0].F(t));
        }
    }
}
