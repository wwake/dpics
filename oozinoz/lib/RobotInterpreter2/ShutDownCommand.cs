using Machines;

namespace RobotInterpreter2
{
    /// <summary>
    /// This class represents a command to shut down a machine
    /// indicated by a provided term.
    /// </summary>
    public class ShutDownCommand : Command 
    {
        protected Term _term;

        /// <summary>
        /// Construct a command to shut down a machine indicated by 
        /// the provided term.
        /// </summary>
        /// <param name="term">a term to evaulate when this command executes;
        /// the machine it evaulates to will be shut down</param>
        public ShutDownCommand(Term term)
        {
            _term = term;
        }

        /// <summary>
        /// Evaluate this object's term to a machine and shut down
        /// that machine.
        /// </summary>
        public override void Execute()
        {
            Machine m = _term.Eval();
            m.ShutDown();
        }
    }
}
