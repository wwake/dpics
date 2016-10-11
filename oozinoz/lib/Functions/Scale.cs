using System;
namespace Functions
{
    /// <summary>
    /// The Scale function represents a linear interpolation. For example,
    /// Fahrenheit temperature goes 32 to 212 as Celsius goes 0 to 100. If we
    /// have a Frapper c that tells Celsius as a function of time, we can 
    /// calculate Fahrenheit with:
    /// Frapper f = new Scale(
    ///      new Constant(0), c, new Constant(100), 
    ///      new Constant(32), new Constant(212));
    /// </summary>
    public class Scale : Frapper 
    {
        /// <summary>
        /// Construct a Scale that goes from "from" to "to" as
        /// time goes 0 to 1.
        /// </summary>
        /// <param name="from">the "from" number</param>
        /// <param name="to">the "to" number</param>
        public Scale(double from, double to) : this(new Constant(from), new Constant(to))
        {           
        }
        /// <summary>
        /// Construct a Scale that goes from "from" to "to" as
        /// time goes 0 to 1.
        /// </summary>
        /// <param name="f1">the "from" function</param>
        /// <param name="f2">the "to" function</param>
        public Scale(Frapper f1, Frapper f2) : 
            this(new Constant(0), new T(), new Constant(1), f1, f2)
        {            
        }

        /// <summary>
        /// </summary>
        /// <param name="aFrom">the "from" value on the "a" scale (usually constant)</param>
        /// <param name="a">the "a" function that typical varies with time</param>
        /// <param name="aTo">the "to" value ont the "a" scale</param>
        /// <param name="bFrom">the "from" value on the "b" scale</param>
        /// <param name="bTo">the "to" value on the "b" scale</param>
        public Scale(
            Frapper aFrom, Frapper a, Frapper aTo, Frapper bFrom, Frapper bTo) :
            base(new Frapper[] { aFrom, a, aTo, bFrom, bTo })
        {            
        }
        /// <summary>
        /// 
        /// Construct a Scale that goes from "aFrom" to "aTo" as
        /// function b goes from "bFrom" to "bTo". 
        /// </summary>
        /// <param name="aFrom">the "from" value on the "a" scale (usually constant)</param>
        /// <param name="a">the "a" function that typical varies with time</param>
        /// <param name="aTo">the "to" value ont the "a" scale</param>
        /// <param name="bFrom">the "from" value on the "b" scale</param>
        /// <param name="bTo">the "to" value on the "b" scale</param>
        public Scale(double aFrom, Frapper a, double aTo, double bFrom, double bTo) :
            this(new Constant(aFrom), a, new Constant(aTo), new Constant(bFrom), new Constant(bTo))
        {
        }
        /// <summary>
        /// Return "b" as a linear function that g
        /// to bTo as "a" goes from aFrom to aTo.
        /// </summary>
        /// <param name="t">a normalized "time" between 0 and 1</param>
        /// <returns></returns>
        public override double F(double t)
        {
            double aFrom = _sources[0].F(t);
            double a     = _sources[1].F(t);
            double aTo   = _sources[2].F(t);
            double bFrom = _sources[3].F(t);
            double bTo   = _sources[4].F(t);
            double denom = aTo - aFrom;
            if (denom == 0)
            {
                return (bTo + bFrom) / 2;
            }
            else
            {
                return (a - aFrom) / denom * (bTo - bFrom) + bFrom;
            }
        }
    }
}
