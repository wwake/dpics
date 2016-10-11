using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Represent the condition that a machine, referred to through
    /// a term, is not empty.
    /// </summary>
    public class HasMaterial : Term 
    {
        protected Term _term;

        /// <summary>
        /// Construct a term that represent a Boolean function
        /// regarding whether the term refers to a machine that
        /// has material.
        /// </summary>
        /// <param name="term">the term (usuaully a variable or machine)
        ///  to check</param>
        public HasMaterial(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Return null if this term's subterm evaluates to
        /// a machine that has no material.
        /// </summary>
        /// <returns>null if this term's subterm evaluates to
        /// a machine that has no material. Otherwise
        /// return the machine.</returns>
        public override Machine Eval()
        {
            Machine m = _term.Eval();
            return m.HasMaterial() ? m : null;
        }
    }
}
