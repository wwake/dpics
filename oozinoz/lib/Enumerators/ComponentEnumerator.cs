using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// This is the abstract superclass of enmerators that can walk across leaf 
    /// nodes and composite nodes in a composite structure.
    /// </summary>
    public abstract class ComponentEnumerator : IEnumerator
    {
        protected Object _head;
        protected Set _visited;
        protected Object _current;
        protected bool _returnInterior = true;

        /// <summary>
        /// Return the current node.
        /// </summary>
        public Object Current 
        {
            get
            {
                return _current;
            }
        }

        /// <summary>
        /// Determines whether interior (non-leaf) nodes should
        /// appear in iteration.
        /// </summary>
        public bool ReturnInterior
        {
            get
            {
                return _returnInterior;
            }
            set 
            {
                _returnInterior = value;
            }
        }
        /// <summary>
        /// Create an enumerator over a node in a composite.
        /// </summary>
        /// <param name="node">the node to iterate over</param>
        /// <param name="visited">a set to track visited nodes</param>
        public ComponentEnumerator(Object head, Set visited)
        {
            _head = head;
            _visited = visited;
        }

        /// <summary>
        /// Return the current depth of the iteration
        /// </summary>
        /// <returns>the current depth of the iteration (that is, for
        /// the current node the number of nodes above it)</returns>
        public abstract int Depth();

        /// <summary>
        /// Advance the enumerator. 
        /// </summary>
        /// <returns>true, if there is another node to see.</returns>
        public abstract bool MoveNext();

        /// <summary>
        /// Not yet supported.
        /// </summary>
        public void Reset() 
        { 
            throw new InvalidOperationException("Reset is not yet supported"); 
        }
    }
}
