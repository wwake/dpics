using System;
using System.Collections;
namespace Utilities
{
    /// <summary>
    /// Provide a collection that contains a group of unique
    /// objects.
    /// </summary>
    public class Set
    {
        private Hashtable h = new Hashtable();
        /// <summary>
        /// Return an enumerator for this set.
        /// </summary>
        /// <returns>An enumerator for this set</returns>
        public IEnumerator GetEnumerator()
        {
            return h.Keys.GetEnumerator();
        }
        /// <summary>
        /// Add the provided object to this set.
        /// </summary>
        /// <param name="o">the object to add</param>
        public void Add(Object o)
        {
            h[o] = null;
        }
        /// <summary>
        /// Return true if the set contains the presented object.
        /// </summary>
        /// <param name="o">the object of curiosity</param>
        /// <returns>true, if the set contains the presented object</returns>
        public bool Contains(Object o)
        {
            return h.Contains(o);
        }
    }
}
