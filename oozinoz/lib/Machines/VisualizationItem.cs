using System;
namespace Machines
{
    /// <summary>
    /// This interface represents part of a user interface for a 
    /// simulation that the "Chain of Responsibility" chapter in 
    /// "Design Patterns in C#" discusses.
    /// </summary>
    public interface VisualizationItem 
    {
        /// <summary>
        /// Return the engineer who is responsible for the machine
        /// that this simulated item represents.
        /// </summary>
        Engineer Responsible { get;}
    }
}
