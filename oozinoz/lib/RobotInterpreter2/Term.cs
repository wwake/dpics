using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// A term is usually either a machine or a variable that
    /// refers to a machine. 
    /// </summary>
    public abstract class Term 
    {
        /// <summary>
        /// Evaluate this term.
        /// </summary>
        /// <returns>an evaluation of this term</returns>
        public abstract Machine Eval();
    }
}
