using System;
namespace Functions
{
    /// <summary>
    /// Provide a "function" that ignores the time t parameter
    /// and always returns a constant value.
    /// </summary>
    public class Constant : Frapper 
    {
        protected double _constant;
        /// <summary>
        /// Construct a "function" that ignores the time t parameter
        /// and always returns a constant value.
        /// </summary>
        /// <param name="constant">the constant</param>
        public Constant(double constant) : base (new Frapper[]{})
        {
            _constant = constant;
        }

        /// <summary>
        /// Return this object's constant value.
        /// </summary>
        /// <param name="t">time, ignored</param>
        /// <returns>the object's constant value</returns>
        public override double F(double t)
        {
            return _constant;
        }
    }
}
