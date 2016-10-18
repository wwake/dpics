using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Represent either an alternation or a sequence of
    /// process steps.
    /// </summary>
    public abstract class ProcessComposite  : ProcessComponent
    {
        protected IList _subprocesses;

        /// <summary>
        /// This property returns the children of this composite.
        /// </summary>
        public IList Children
        {
            get 
            {
                return _subprocesses;
            }
        }

        /// <summary>
        /// Create a process composite with the given name.
        /// </summary>
        /// <param name="name">this process composite's name</param>
        public ProcessComposite(String name) : this (name, new ArrayList())
        {
        }

        /// <summary>
        /// Create a composite with the given name and containing the
        /// given subprocesses.
        /// </summary>
        /// <param name="name">the identity of this composite</param>
        /// <param name="subprocesses">the children of this composite</param>
        public ProcessComposite(
            String name, params ProcessComponent[] subprocesses) : base (name)
        {
            _subprocesses = new ArrayList();
            foreach (Object o in subprocesses) 
            {
                _subprocesses.Add(o);
            }         
        }

        /// <summary>
        /// Create a composite with the given name and containing the
        /// given subprocesses.
        /// </summary>
        /// <param name="name">the identity of this composite</param>
        /// <param name="subprocesses">the children of this composite</param>
        public ProcessComposite(String name, IList subprocesses) : base(name)
        {
            _subprocesses = subprocesses;
        }

        /// <summary>
        /// Add the given component as a child.
        /// </summary>
        /// <param name="c">the component to add</param>
        public void Add(ProcessComponent c)
        {
            _subprocesses.Add(c);
        }

        /// <summary>
        /// Return an enumerator for this composite.
        /// </summary>
        /// <param name="visited">a set of nodes already visited in this enumeration</param>
        /// <returns>an enumerator for this composite</returns>
        public override ComponentEnumerator GetEnumerator(Set visited)
        {
            return new CompositeEnumerator(this, _subprocesses, visited);
        }

        /// <summary>
        /// Return the number of steps (leaf nodes) in the tree
        /// that this composite represents.
        /// </summary>
        /// <param name="visited">components already visited while 
        /// traversing this component</param>
        /// <returns>the number of steps (leaf nodes) in the
        /// tree that this composite represents
        /// </returns>
        public override int GetStepCount(Hashtable visited)
        {
            visited.Add(Name, this);
            int count = 0;
            foreach (ProcessComponent pc in _subprocesses)
            {
                if (!visited.Contains(pc.Name))
                {
                    count += pc.GetStepCount(visited);
                }
            }
            return count;
        }
    }
}
