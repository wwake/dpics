using System;
namespace Functions
{
    /// <summary>
    /// Wrap an arithmetic function around a pair of supplied sources.
    /// </summary>
    public class Arithmetic : Frapper 
    {
        protected char _op;
        /// <summary>
        /// Construct an arithmetic function that decorates the 
        /// provided source functions.
        /// </summary>
        /// <param name="f1">Another function wrapper</param>
        /// <param name="f2">Yet another function wrapper</param>
        public Arithmetic(Char op, Frapper f1, Frapper f2) : base (new Frapper[]{f1, f2})
        {
            _op = op;
        }

        /// <summary>
        /// Return an arithmetic operation (as indicated in the constructor) 
        /// applied to the source functions' values at time t.
        /// </summary>
        /// <param name="t">time</param>
        /// <returns>the cos of the source function value at time t</returns>
        public override double F(double t)
        {
            switch (_op)
            {
                case '+' :
                    return _sources[0].F(t) + _sources[1].F(t);
                case '-' :
                    return _sources[0].F(t) - _sources[1].F(t);
                case '*' :
                    return _sources[0].F(t) * _sources[1].F(t);
                case '/' :
                    return _sources[0].F(t) / _sources[1].F(t);
                default :
                    return 0;
            }
        }
    }
}
