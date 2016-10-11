using System;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// "Enumerate" a leaf, returning it just once.
    /// </summary>
    public class LeafEnumerator: ComponentEnumerator 
    {
        /// <summary>
        /// Create an "enumerator" for a childless node in a composite.
        /// </summary>
        /// <param name="node">the node over which to "iterate"</param>
        /// <param name="visited">a collection of previously visited nodes</param>
        public LeafEnumerator(Object node, Set visited) : base(node, visited)
        {        
        }

        /// <summary>
        /// Return zero, as the depth of iterators below a leaf is
        /// always zero.
        /// </summary>
        /// <returns>zero, as the depth of iterators below a leaf is
        /// always zero</returns>
        public override int Depth()
        {
            return 0;
        }

        /// <summary>
        /// Make this node "current" if we haven't moved previously;
        /// otherwise return false.
        /// </summary>
        /// <returns>true, if we haven't moved onto this node yet</returns>
        public override bool MoveNext()
        {
            if (_visited.Contains(_head))
            {
                _current = null;
                return false;
            }
            _visited.Add(_head);
            _current = _head;
            return true;
        }
    }
}
