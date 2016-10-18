using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Carry a bin from one machine to another, allowing for
    /// machines to be referred to with variable names.
    /// </summary>
    public class CarryCommand : Command 
    {
        protected Term _from;
        protected Term _to;

        /// <summary>
        /// Construct a "carry" command to carry a bin from one machine 
        /// to another.
        /// </summary>
        /// <param name="fromTerm">the variable or constant that points 
        /// to a machine to pick up a bin from</param>
        /// <param name="toTerm">the variable or constant that points to 
        /// a machine to place a bin on</param>
        public CarryCommand(Term fromTerm, Term toTerm)
        {
            _from = fromTerm;
            _to = toTerm;
        }

        /// <summary>
        /// Evaulate this object's terms into machines, and carry a bin 
        /// from the "from" machine to the "to" machine.
        /// </summary>
        public override void Execute()
        {
            Robot.singleton.Carry(_from.Eval(), _to.Eval());
        }
    }
}
