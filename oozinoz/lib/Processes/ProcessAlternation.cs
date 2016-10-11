using System;
using System.Collections;

namespace Processes
{
    /// <summary>
    /// Represent an "alternation" (a choice) of process steps.
    /// </summary>
    public class ProcessAlternation : ProcessComposite 
    {
        /// <summary>
        /// Create an alternation with the given name.
        /// </summary>
        /// <param name="name">the name of this process alternation</param>
        public ProcessAlternation(String name) : base(name)
        {
        }
        /// <summary>
        /// Create an alternation with the given name and containing 
        /// the given subprocesses.
        /// </summary>
        /// <param name="name">the name of this alternation</param>
        /// <param name="subprocesses">the children of this alternation</param>
        public ProcessAlternation(
            String name,
            params ProcessComponent[] subprocesses) : base (name, subprocesses)
        {
        }
        /// <summary>
        /// Create an alternation with the given name and containing 
        /// the given subprocesses.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subprocesses"></param>
        public ProcessAlternation(String name, IList subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// This hook lets visitors add behaviors to the process
        /// composite. The point here is to call back the visitor
        /// indicating the type of this node, namely 
        /// ProcessAlternation.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
    }
}
