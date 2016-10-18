using System;
using System.Collections;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// This class represents a "for" loop that will execute its
    /// body for each machine in a provided composite, assigning a 
    /// variable to a different machine in each pass through the 
    /// loop.
    /// </summary>
    public class ForCommand : Command 
    {
        protected MachineComponent _root;
        protected Variable _variable;
        protected Command _body;

        /// <summary>
        /// Construct a "for" interpreter that will execute the
        /// provided body, looping through the machines in a context,
        /// assigning the provided variable to each machine.
        /// </summary>
        /// <param name="root">The machine component over which to iterate</param>
        /// <param name="v">the variable to set for each loop</param>
        /// <param name="body">the body of the for command</param>
        public ForCommand(MachineComponent mc, Variable v, Command body)
        {
            _root = mc;
            _variable = v;
            _body = body;
        }

        /// <summary>
        /// For each machine in the context, assign this object's
        /// variable to the machine, and execute this object's
        /// body.
        /// </summary>
        public override void Execute()
        {
            Execute(_root);
        } 

        private void Execute(MachineComponent mc) 
        {
            Machine m = mc as Machine;
            if (m != null)
            {
                _variable.Assign(new Constant(m));
                _body.Execute();
                return;
            }
            MachineComposite comp = mc as MachineComposite;
            foreach (MachineComponent child in comp.Children)
            {
                Execute(child);
            }
        } 
    }
}
