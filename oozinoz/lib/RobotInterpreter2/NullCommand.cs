using System;
namespace RobotInterpreter2
{
    /// <summary>
    /// This class does nothing when it executes.
    /// </summary>
    public class NullCommand : Command 
    {
        /// <summary>
        /// Do nothing.
        /// </summary>
        public override void Execute()
        {
        }
    }
}
