using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Represent a comparison of two terms.
    /// </summary>
    public class Equals : Term 
    {
        protected Term _term1;
        protected Term _term2;
              
        /// <summary>
        /// Construct a term that can compare the two provided terms.
        /// </summary>
        /// <param name="term1">a term to compare</param>
        /// <param name="term2">another term to compare</param>
        public Equals(Term term1, Term term2)
        {
            this._term1 = term1;
            this._term2 = term2;
        }

        /// <summary>
        /// Return null if this term's subterms evaluate to
        /// different machines.
        /// </summary>
        /// <returns>null if this term's subterms evaluate to
        /// different machines. Otherwise return the
        /// machine.</returns>
        public override Machine Eval()
        {
            Machine m1 = _term1.Eval();
            Machine m2 = _term2.Eval();
            bool b = m1.Equals(m2);
            return b ? m1 : null;
        }
    }
}
