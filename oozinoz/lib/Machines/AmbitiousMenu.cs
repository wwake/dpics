using System;

namespace Machines
{
    /// <summary>
    /// This (dysfunctional) class shows a method from an overly 
    /// ambitious menu that figures out who the responsible engineer 
    /// is for a piece of equipment. In the "Chain of Responsibility" 
    /// chapter of "Design Patterns in C#," this code is 
    /// refactored so that the domain objects determine who is the 
    /// responsible engineer. 
    /// </summary>
    public class AmbitiousMenu 
    {
        /// <summary>
        /// Return the engineer that is responsible for the machine
        /// or tool that a simulated item represents.
        /// </summary>
        /// <param name="item">the interesting item</param>
        /// <returns>the responsible engineer</returns>
        public Engineer GetResponsible(VisualizationItem item)
        {
            if (item is Tool)
            {
                Tool t = (Tool) item;
                return t.ToolCart.Responsible;
            }
            if (item is ToolCart)
            {
                ToolCart tc = (ToolCart) item;
                return tc.Responsible;
            }
            if (item is MachineComponent)
            {
                MachineComponent c = (MachineComponent) item;
                if (c.Responsible != null) 
                {
                    return c.Responsible;
                }
                if (c.Parent != null)
                {
                    return c.Parent.Responsible;
                }
            }
            return null;
        }
    }
}
