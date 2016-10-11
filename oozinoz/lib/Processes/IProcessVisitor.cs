using System;
namespace Processes
{
    /// <summary>
    /// This interface defines the type of object that process 
    /// steps and process composites will accept. The 
    /// ProcessComponent hierarchy classes call back a Visiting 
    /// object's Visit() methods; In so doing they identify their 
    /// type. Implementors of this interface can create algorithms 
    /// that operate differently on different type of process 
    /// components. 
    /// </summary>
    public interface IProcessVisitor 
    {
        /// <summary>
        /// Visit a process alternation.
        /// </summary>
        /// <param name="a">the process alternation to isit</param>
        void Visit(ProcessAlternation a);
        /// <summary>
        /// Visit a process sequence.
        /// </summary>
        /// <param name="s">the process sequence to visit</param>
        void Visit(ProcessSequence s);
        /// <summary>
        /// Visit a process step.
        /// </summary>
        /// <param name="s">the process step to visit</param>
        void Visit(ProcessStep s);
    }
}
