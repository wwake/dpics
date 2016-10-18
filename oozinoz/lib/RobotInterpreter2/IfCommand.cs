using System;

namespace RobotInterpreter2
{
    /// <summary>
    /// This class represents an "if" statement that will execute
    /// one of two commands depending on the value of a supplied
    /// conditional term.
    /// </summary>
    public class IfCommand : Command 
    {
        protected Term _term;
        protected Command _body;
        protected Command _elseBody;

        /// <summary>
        /// Construct an "if" command that will execute its "else" body
        /// if the supplied term is null, and will otherwise execute
        /// its regular body.
        /// </summary>
        /// <param name="term">the term to evaluate to determine which body to
        /// execute</param>
        /// <param name="body">the body to execute if the term is true</param>
        /// <param name="elseBody">the body to execute if the term is false</param>
        public IfCommand(Term term, Command body, Command elseBody)
        {
            _term = term;
            _body = body;
            _elseBody = elseBody;
        }

        /// <summary>
        /// Execute this object's "else" body if this object's term
        /// evaluates to null; otherwise execute the main body.
        /// </summary>
        public override void Execute()
        {
            if (_term.Eval() != null)
            {
                _body.Execute();
            }
            else
            {
                _elseBody.Execute();
            }
        }
    }
}
