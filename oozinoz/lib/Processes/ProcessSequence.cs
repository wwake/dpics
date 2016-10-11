using System;
using System.Collections;

namespace Processes
{
    /// <summary>
    /// Represent a "sequence" (a series) of process steps.
    /// </summary>
    public class ProcessSequence : ProcessComposite 
    {
        /// <summary>
        /// Create a sequence with the given name.
        /// </summary>
        /// <param name="name">the name of this process sequence</param>
        public ProcessSequence(String name) : base(name)
        {
        }
        /// <summary>
        /// Create a sequence with the given name and containing 
        /// the given subprocesses.
        /// </summary>
        /// <param name="name">the name of this sequence</param>
        /// <param name="subprocesses">the children of this sequence</param>
        public ProcessSequence(
            String name, params ProcessComponent[] subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// Create a sequence with the given name and containing 
        /// the given subprocesses.
        /// </summary>
        /// <param name="name">the name of this sequence</param>
        /// <param name="subprocesses">the children of this sequence</param>
        public ProcessSequence(String name, IList subprocesses) : 
            base(name, subprocesses)
        {
        }
        /// <summary>
        /// This hook lets visitors add behaviors to the process
        /// composite. The point here is to call back the visitor
        /// indicating the type of this node, namely 
        /// ProcessSequence.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
    }
}
