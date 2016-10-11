using System;
using System.Collections;

namespace Machines
{ 
    /// <summary>
    /// Objects of this class represent either individual 
    /// machines or composites of machines.
    /// </summary>
    public abstract class MachineComponent : VisualizationItem
    {
        protected int _id;
        protected string _name;
        private MachineComponent _parent;
        private Engineer _responsible;
        /// <summary>
        /// A machine component may have an associated engineer who
        /// is responsible for the component.
        /// </summary>
        public Engineer Responsible
        {
            get
            {
                if (_responsible != null)
                {
                    return _responsible;
                }
                if (_parent != null)
                {
                    return _parent.Responsible;
                }
                return null;
            }
            set
            {
                this._responsible = value;
            }
        }
        /// <summary>
        /// Some machine groups belong in others; for example a
        /// machine may belong in a bay that belongs in a factory.
        /// This "belonging" means that the machine (group) has
        /// a "parent."
        /// </summary>
        public MachineComponent Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                this._parent = value;
            }
        }
        /// <summary>
        /// A unique identifier for this machine or group of machines.
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// Create a machine or group of machines.
        /// </summary>
        /// <param name="id">The unique identifier for this machine or group</param>
        public MachineComponent(int id) 
        {
            _id = id;
        }
        /// <summary>
        /// Create a machine or group of machines and record a name for t.
        /// </summary>
        /// <param name="id">The unique identifier for this machine or group</param>
        /// <param name="name">A name for this machine or group</param>
        public MachineComponent(int id, string name): this(id)
        {
            _name = name;
        }
        /// <summary>
        /// Support external visitors that want to add behavior to this
        /// hierarchy. (See "Visitor" in "Design Patterns in C#")
        /// </summary>
        /// <param name="v">a visitor</param>
        public abstract void Accept(IMachineVisitor v);
        /// <summary>
        /// Return the number of leaf node machines in this
        /// composite.
        /// </summary>
        /// <returns>the number of leaf node machines in this
        ///  composite</returns>
        public abstract int GetMachineCount();
        /// <summary>
        /// Return true if this component is atop an acyclic graph in 
        /// which no node has two parents (two references to it).
        /// </summary>
        /// <returns>true if this component is atop an acyclic graph in 
        /// which no node has two parents
        /// </returns>
        public bool IsTree()
        {
            return IsTree(new Hashtable());
        }
        /// <summary>
        /// Subclasses implement this to support the isTree()
        ///  algorithm.
        /// </summary>
        /// <param name="s">A set of visited nodes</param>
        /// <returns>True, if this object is a tree</returns>
        public abstract bool IsTree(Hashtable visited);
        /// <summary>
        /// Return true if, according to business rules, this
        /// component and the supplied object refer to the same
        /// thing.
        /// </summary>
        /// <param name="o">The candidate to compare to</param>
        /// <returns>true, if this object and the supplied object represent
        /// the same machine</returns>
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (!(o is MachineComponent))
            {
                return false;
            }                                                    
            MachineComponent mc = (MachineComponent) o;
            return _id == mc.ID;
        }
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
        /// <summary>
        /// Provided a textual description of this component.
        /// </summary>
        /// <returns>a textual description of this component</returns>
        public override String ToString()
        {
            if (_name != null)
            {
                return _name;
            }
            return GetType().Name + ":" + ID.ToString("0000");
        }
        /// <summary>
        /// Find a machine within this machine graph, given its ID.
        /// </summary>
        /// <param name="id">the machine id to search for</param>
        /// <returns>a machine with the given id</returns>
        public abstract MachineComponent Find(int id);
        
        /// <summary>
        /// Find a machine within this machine graph, given its name.
        /// </summary>
        /// <param name="id">the machine name to search for</param>
        /// <returns>a machine with the given name</returns>
        public abstract MachineComponent Find(String name);

    }
}
