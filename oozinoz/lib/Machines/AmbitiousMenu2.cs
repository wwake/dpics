using System;

namespace Machines
{
    /// <summary>
    /// This class shows the value of refactoring the AmbitiousMenu
    /// class using Chain of Responsibility.
    /// </summary>
    public class AmbitiousMenu2 
    {
        /// <summary>
        /// Return the engineer that is responsible for the machine
        /// or tool that a simulated item represents.
        /// </summary>
        /// <param name="item">the interesting item</param>
        /// <returns>the responsible engineer</returns>
        public Engineer GetResponsible(VisualizationItem item)
        {
            return item.Responsible;
        }
    }
}
