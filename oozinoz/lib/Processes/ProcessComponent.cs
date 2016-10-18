using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Objects of this class represent either individual 
    /// process steps or compositions of process steps. A process
    /// is essentially a recipe for manufacturing something,
    /// notably fireworks.
    /// </summary>
    public abstract class ProcessComponent : ICompositeEnumerable
    {
        protected String _name;

        /// <summary>
        /// Create a process component with the given name.
        /// </summary>
        /// <param name="name">this process component's name </param>
        public ProcessComponent(String name)
        {
            _name = name;
        }

        /// <summary>
        /// Accept a "visitor".
        /// </summary>
        /// <param name="v">the visitor</param>
        public abstract void Accept(IProcessVisitor v);

        /// <summary>
        /// Return this component's name.
        /// </summary>
        public String Name
        {
            get 
            {
                return _name;
            }
        }
        
        /// <summary>
        /// Return an enumerator that will safely walk this composite.
        /// </summary>
        /// <returns>an enumerator that will safely walk this composite</returns>
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator(new Set());
        }
        
        /// <summary>
        /// Return an appropriate type of component iterator.
        /// </summary>
        /// <param name="visited">A set of previously iterated-over nodes</param>
        /// <returns>an appropriate type of component iterator</returns>
        public abstract ComponentEnumerator GetEnumerator(Set visited);

        /// <summary>
        /// Return the number of leaf node steps in this
        /// composite.
        /// </summary>
        /// <returns>the number of leaf node steps in this
        /// composite.
        /// </returns>
        public int GetStepCount()
        {
            return GetStepCount(new Hashtable());
        }

        /// <summary>
        /// Return the number of leaf node steps in this
        /// composite.
        /// </summary>
        /// <param name="visited">components already visited while 
        /// traversing this component</param>
        /// <returns>the number of leaf node steps in this
        /// composite.
        /// </returns>
        public abstract int GetStepCount(Hashtable visited);

        /// <summary>
        /// Return a textual representation of this component.
        /// </summary>
        /// <returns>a textual representation of this component</returns>
        public override String ToString()
        {
            return _name;
        }
    }
}
