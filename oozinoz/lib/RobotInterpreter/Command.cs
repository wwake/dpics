using System;
namespace RobotInterpreter
{
    /// <summary>
    /// This abstract class represents a hierarchy of classes
    /// that encapsulate commands. A command object is a request
    /// that is dormant until a caller asks it to execute.
    /// 
    /// Subclasses typically encapsulate some primary function, 
    /// and allow for parameters that tailor a command to a 
    /// purpose. All subclasses must implement an execute()
    /// command, which is abstract here.
    /// </summary>
    public abstract class Command 
    {
        /// <summary>
        /// Perform the request encapsulated in this command.
        /// </summary>
        public abstract void Execute();
    }
}
