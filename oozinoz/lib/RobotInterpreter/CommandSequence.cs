using System;
using System.Collections;
using System.Text;

namespace RobotInterpreter
{
    /// <summary>
    /// This class contains a sequence of other commands.
    /// </summary>
    public class CommandSequence : Command 
    {
        protected IList _commands = new ArrayList();

        /// <summary>
        /// Add a command to the sequence of commands to which this
        /// object will cascade an Execute() command.
        /// </summary>
        /// <param name="c">a command to add</param>
        public void AddCommand(Command c)
        {
            _commands.Add(c);
        }

        /// <summary>
        /// Returns a string description of this command sequence.
        /// </summary>
        /// <returns>a string description of this command sequence</returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool needLine = false;
            foreach (Command c in _commands) 
            {
                if (needLine)
                {
                    sb.Append("\n");
                }
                sb.Append(c);
                needLine = true;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Ask each command in the sequence to execute.
        /// </summary>
        public override void Execute()
        {
            foreach (Command c in _commands)
            {
                c.Execute();
            }
        }
    }
}
