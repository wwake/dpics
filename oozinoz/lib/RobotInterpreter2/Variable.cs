using System;
using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// Record a name that can be used to assign and look up a
    /// machine.
    /// </summary>
    public class Variable : Term 
    {
        protected String _name;
        protected Term _value;

        /// <summary>
        /// Construct a variable with the provided name.
        /// </summary>
        /// <param name="name">the variable's name</param>
        public Variable(String name)
        {
            this._name = name;
        }

        /// <summary>
        /// Return this variable's name.
        /// </summary>
        /// <returns>this variable's name</returns>
        public String Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Set the value of this variable.
        /// </summary>
        /// <param name="value">the value of this variable</param>
        public void Assign(Term value)
        {
            _value = value;
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
            Variable v = o as Variable;
            if (v == null) 
            {
                return false;
            }
            return _name.Equals(v._name);
        }

        /// <summary>
        /// Return a hash code for this object. 
        /// </summary>
        /// <returns>a hash code for this object</returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        /// <summary>
        /// Return the machine that this variable refers to in
        /// the provide context.
        /// </summary>
        /// <returns>the machine that this variable refers to in
        /// the provided context</returns>
        public override Machine Eval()
        {
            return _value.Eval();
        }

        /// <summary>
        /// Returns a string description of this variable.
        /// </summary>
        /// <returns>a string description of this variable</returns>
        public override String ToString()
        {
            return _name + ": " + _value;
        }
    }
}
