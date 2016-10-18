using System;

namespace Machines
{
    /// <summary>
    /// A shell assembler assemebles stars, gunpowder and paper
    /// casing into an aerial shell.
    /// </summary>
    public class ShellAssembler : Machine
    {
        // private ShellPlanner _planner; refactored out in "Template Method"
        /// <summary>
        /// Create a machine with the given id and with the supplied
        /// parent machine.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        public ShellAssembler(int id) : base (id)
        {
        }

        /// <summary>
        /// Provide a planner for this shell assembler.
        /// </summary>
        /// <returns>a planner for this shell assembler</returns>
        public override MachinePlanner CreatePlanner() 
        {
            return new ShellPlanner(this);
        }

        /* (the following code gets refactored out in "Template Method")
        public ShellPlanner GetPlanner() 
        {
            if (_planner == null) 
            {
                _planner = new ShellPlanner(this);
            }
            return _planner;
        }
        */
    }
}
