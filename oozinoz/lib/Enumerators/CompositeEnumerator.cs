using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Iterate over a component that has children.
    /// </summary>
    public class CompositeEnumerator : ComponentEnumerator 
    {
        protected IEnumerator _childEnumerator;
        protected ComponentEnumerator _subEnumerator;
        /// <summary>
        /// Create an enumerator over a component that has children.
        /// </summary>
        /// <param name="node">the node to enumerate</param>
        /// <param name="children">the node's children</param>
        /// <param name="visited">a set to track visited nodes</param>
        public CompositeEnumerator(Object node, IList children, Set visited) : base (node, visited)
        {
            _childEnumerator = children.GetEnumerator();
        }
        /// <summary>
        /// Return the current depth of the iteration. Iterators walk
        /// down a tree, so the depth of this iterator is the depth
        /// of a subiterator plus one.
        /// </summary>
        /// <returns>the current depth of the iteration (that is, for
        /// the current node the number of nodes above it)</returns>
        public override int Depth()
        {
            if (_subEnumerator != null)
            {
                return _subEnumerator.Depth() + 1;
            }
            return 0;
        }
        /// <summary>
        /// Advances the enumerator.
        /// </summary>
        /// <returns>true, if there is another node to see</returns>
        public override bool MoveNext()
        {
            if (!_visited.Contains(_head))
            {
                _visited.Add(_head);
                if (ReturnInterior)
                {
                    _current = _head;
                    return true;
                }
            }
            return SubenumeratorNext();
        }
        /// <summary>
        /// Usually just move to the subiterator's next element. But
        /// if the subiterator doesn't exist or doesn't have a
        /// next element, create an enumerator for the next child.
        /// (If there is no next child, just return false.) Create
        /// an enumerator for this child and return that enumerator's
        /// next element. 
        /// </summary>
        /// <returns>true, if there is another node to see</returns>
        protected bool SubenumeratorNext()
        {
            while (true)
            {
                if (_subEnumerator != null)
                {
                    if (_subEnumerator.MoveNext())
                    {
                        _current = _subEnumerator.Current;
                        return true;
                    }
                }
                if (!_childEnumerator.MoveNext())
                {
                    _current = null;
                    return false;
                }
                ICompositeEnumerable c = (ICompositeEnumerable) _childEnumerator.Current;
                if (!_visited.Contains(c))
                {
                    _subEnumerator = c.GetEnumerator(_visited);
                    _subEnumerator.ReturnInterior = ReturnInterior;
                }
            }
        }
    }
}
