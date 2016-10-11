using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Represent a specific machine.
    /// </summary>
    public class Constant : Term 
    {
        protected Machine _machine;

        /// <summary>
        /// Construct a term that always referst to a specific
        /// machine.
        /// </summary>
        /// <param name="machine"></param>
        public Constant(Machine machine)
        {
            _machine = machine;
        }

        /// <summary>
        /// Return true if the provided object equals this one.
        /// </summary>
        /// <param name="o">an object to compare to</param>
        /// <returns>true if the provided object equals this one</returns>
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            Constant c = o as Constant;
            if (c == null) 
            {
                return false; 
            }
            return _machine.Equals(c._machine);
        }

        /// <summary>
        /// Return a hash code for this object. 
        /// </summary>
        /// <returns>a hash code for this object</returns>
        public override int GetHashCode()
        {
            return _machine.GetHashCode();
        }

        /// <summary>
        /// Return the machine that this term wraps.
        /// </summary>
        /// <returns>the machine that this term wraps</returns>
        public override Machine Eval()
        {
            return _machine;
        }
        /// <summary>
        /// Returns a string description of this constant.
        /// </summary>
        /// <returns>a string description of this constant</returns>
        public override String ToString()
        {
            return _machine.ToString();
        }
    }
}
