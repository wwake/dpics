using System;
using Machines;
namespace RobotInterpreter
{
    /// <summary>
    /// Carry a bin from one machine to another, allowing for
    /// machines to be referred to with variable names.
    /// </summary>
    public class CarryCommand : Command 
    {
        protected Machine _fromMachine;
        protected Machine _toMachine;

        /// <summary>
        /// Construct a "carry" command to carry a bin from
        /// one machine to another.
        /// </summary>
        /// <param name="fromMachine">the machine to pick up a bin from</param>
        /// <param name="toMachine">the machine to place a bin on</param>
        public CarryCommand(Machine fromMachine, Machine toMachine)
        {
            _fromMachine = fromMachine;
            _toMachine = toMachine;
        }

        /// <summary>
        /// Evaulate this object's terms into machines, and carry a bin 
        /// from the "from" machine to the "to" machine.
        /// </summary>
        public override void Execute()
        {
            Robot.singleton.Carry(_fromMachine, _toMachine);
        }
    }
}
