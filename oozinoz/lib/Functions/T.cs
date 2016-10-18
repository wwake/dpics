using System;
namespace Functions
{
    /// <summary>
    /// This is the identity function--t itself. This is often useful; 
    /// for example if you want the x coordinates of a Cartesion function
    /// to vary 0 to 1 you can use T directly.
    /// </summary>
    public class T : Frapper 
    {
        /// <summary>
        /// Construct the identity function that returns the value
        /// of t.
        /// </summary>
        public T() : base (new Frapper[]{})
        {
        }

        /// <summary>
        /// Return the current value of t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>time</returns>
        public override double F(double t)
        {
            return t;
        }
    }
}
