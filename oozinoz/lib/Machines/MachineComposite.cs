using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Represent a collection of machines: a manufacturing line,
    /// a bay, or a factory.
    /// </summary>
    public class MachineComposite : MachineComponent 
    {
        protected IList _components = new ArrayList();

        /// <summary>
        /// Support the Visitor pattern.
        /// </summary>
        /// <param name="v">a visitor</param>
        public override void Accept(IMachineVisitor v) 
        {
            v.Visit(this);
        }

        /// <summary>
        /// Add the given component as a child.
        /// </summary>
        /// <param name="component">the component to add</param>
        public void Add(MachineComponent component)
        {
            _components.Add(component);
        }

        /// <summary>
        /// Return the number of machines (leaf nodes) in the tree
        /// that this composite represents.
        /// </summary>
        /// <returns></returns>
        public override int GetMachineCount()
        {
            int count = 0;
            foreach (MachineComponent mc in _components)
            {
                count += mc.GetMachineCount();
            }
            return count;
        }

        /// <summary>
        /// Create a composite with the given id.
        /// </summary>
        /// <param name="id">the identity of this composite</param>
        public MachineComposite(int id) : base (id)
        {
        }

        /// <summary>
        /// Create a composite with the given id and name.
        /// </summary>
        /// <param name="id">the identity of this composite</param>
        /// <param name="name">a name for this composite</param>
        public MachineComposite(int id, string name) : base (id, name)
        {
        }

        /// <summary>
        /// This property returns the children of this composite.
        /// </summary>
        public IList Children
        {
            get 
            {
                return _components;
            }
        }

        /// <summary>
        /// Add the given components as children.
        /// </summary>
        /// <param name="children">the components to add</param>
        public void Add(MachineComponent[] children)
        {
            for (int i = 0; i < children.Length; i++)
            {
                _components.Add(children[i]);
            }
        } 

        /// <summary>
        /// Return true if this composite is a tree.
        /// </summary>
        /// <param name="visited">a set of visited nodes</param>
        /// <returns>true if this composite is a tree</returns>
        public override bool IsTree(Hashtable visited)
        {
            visited.Add(this.ID, this);
            foreach (MachineComponent mc in _components)
            {
                if (visited.Contains(mc.ID) || !mc.IsTree(visited))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Return a component in this machine graph whose id
        /// matches the provided one.
        /// </summary>
        /// <param name="id">an id to search for</param>
        /// <returns>a machine component whose id matches the provided one</returns>
        public override MachineComponent Find(int id) 
        {
            if (_id == id) 
            {
                return this;
            }
            foreach (MachineComponent child in _components)
            {
                MachineComponent mc = child.Find(id);
                if (mc != null) 
                {
                    return mc;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a component in this machine graph whose name
        /// matches the provided one.
        /// </summary>
        /// <param name="id">a name to search for</param>
        /// <returns>a machine component whose name matches the provided one</returns>
        public override MachineComponent Find(String name) 
        {
            if (name.Equals(ToString()))
            {
                return this;
            }
            foreach (MachineComponent child in _components)
            {
                MachineComponent mc = child.Find(name);
                if (mc != null) 
                {
                    return mc;
                }
            }
            return null;
        }
    }
}
