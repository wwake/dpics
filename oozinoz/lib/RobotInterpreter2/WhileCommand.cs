using System;

namespace RobotInterpreter2
{
    /// <summary>
    /// This class represents a "while" statement that will execute
    /// its body so long as its term evaluates to a non-null value.
    /// </summary>
    public class WhileCommand : Command 
    {
        protected Term _term;
        protected Command _body;

        /// <summary>
        /// Construct a "while" command that will execute its body
        /// as long as the supplied term evaulates to a non-null value.
        /// </summary>
        /// <param name="_term">the term to evaluate on each loop of the while</param>
        /// <param name="body">the body to execute</param>
        public WhileCommand(Term term, Command body)
        {
            _term = term;
            _body = body;
        }

        /// <summary>
        /// Evalulate this object's term; if it's not null,
        /// execute the body. Repeat.
        /// </summary>
        public override void Execute()
        {
            while (_term.Eval() != null)
            {
                _body.Execute();
            }
        }
    }
}
