using System;
namespace Machines
{
    /// <summary>
    /// A star press takes a chemical mixture and extrudes
    /// explosive pellets or "stars".
    /// </summary>
    public class StarPress : Machine
    {
       // private StarPressPlanner _planner; // refactored out in "Template Method"
        
        /// <summary>
        /// Create a machine with the given id and with the supplied
        /// parent machine.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        public StarPress(int id) : base (id)
        {
        }

        /// <summary>
        /// Provide a planner for this star press.
        /// </summary>
        /// <returns>a planner for this star press</returns>
        public override MachinePlanner CreatePlanner() 
        {
            return new StarPressPlanner(this);
        }

        /* (the following code gets refactored out in "Template Method")
        public StarPressPlanner GetPlanner() 
        { 
            if (_planner == null) 
            {
                _planner = new StarPressPlanner(this);
            }
            return _planner;
        }
        */ 
    }
}
