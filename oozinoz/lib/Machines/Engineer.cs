using System;

namespace Machines
{
    /// <summary>
    /// This isn't much of a model, but it provides a data type
    /// that represents the role of a person that can be
    /// responsible for a machine.
    /// </summary>
    public class Engineer 
    {
        protected int _employeeID;

        /// <summary>
        /// Model an engineer with the given employee id.
        /// </summary>
        /// <param name="_employeeID">the employee id for the engineer</param>
        public Engineer(int _employeeID)
        {
            this._employeeID = _employeeID;
        }
 
        /// <summary>
        /// This engineer's employee ID.
        /// </summary>
        public int EmployeeID 
        {
            get
            {
                return _employeeID;
            }
        }
    }
}
