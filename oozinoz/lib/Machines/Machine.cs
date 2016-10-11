using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    public class Machine : MachineComponent
    { 
        private MachinePlanner _planner;
        private TubMediator _mediator = TubMediator.SINGLETON;
        protected Queue _bins = new Queue();
        /// <summary>
        /// Create a machine with the given id.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        public Machine(int id) : base (id)
        {
        }      
        /// <summary>
        /// Create a machine with the given id and with the supplied
        /// name.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        /// <param name="name">a name for this machine</param>
        public Machine(int id, string name) : base (id, name)
        {
        }        
        /// <summary>
        /// Support the Visitor pattern.
        /// </summary>
        /// <param name="v">a visitor</param>
        public override void Accept(IMachineVisitor v) 
        {
            v.Visit(this);
        }
        /// <summary>
        /// Return the number of machines in this machine, namely 1
        /// </summary>
        /// <returns>one, since there's only one machine here</returns>
        public override int GetMachineCount()
        {
            return 1;
        }

        /// <summary>
        /// Return true; individual machines are always "trees."
        /// </summary>
        /// <param name="visited">A collection of visited nodes</param>
        /// <returns>true; individual machines are always "trees"</returns>
        public override bool IsTree(Hashtable visited)
        {
            visited.Add(ID, this);
            return true;
        }
        /// <summary>
        /// Place the given tub at this machine (and at no other machine).
        /// </summary>
        /// <param name="t">the tub</param>
        public void AddTub(Tub t) 
        {
            _mediator.Set(t, this);
        }
        /// <summary>
        /// Return a list of tubs that are at this machine.
        /// </summary>
        /// <returns>the tubs</returns>
        public IList GetTubs()
        {
            return _mediator.GetTubs(this);
        }

        /// <summary>
        /// Enqueue the given bin on the input conveyor for this machine.
        /// </summary>
        /// <param name="b">the bin</param>
        public void Load(Bin b) 
        {
            _bins.Enqueue(b);
        }

        /// <summary>
        /// Remove the first on bin this machine's output conveyor.
        /// </summary>
        /// <returns>the first bin on this machine's output conveyor</returns>
        public Bin Unload()
        {
            if (_bins.Count == 0) 
            {
                return null;
            }
            return (Bin)_bins.Dequeue();
        }
        /// <summary>
        /// Provide a planner for this machine.
        /// </summary>
        /// <returns>a planner for this machine</returns>
        public virtual MachinePlanner CreatePlanner() 
        {
            return new BasicPlanner(this);
        }
        /// <summary>
        /// Get a planner for this machine.
        /// </summary>
        /// <returns>a planner for this machine</returns>
        public MachinePlanner GetPlanner() 
        {
            if (_planner == null) 
            {
                _planner = CreatePlanner();
            }
            return _planner;
        }
        
        /// <summary>
        /// Return this machine if the id matches.
        /// </summary>
        /// <param name="id">an id to search for</param>
        /// <returns>this machine, if the id matches</returns>
        public override MachineComponent Find(int id)
        {
            if (_id == id) 
            {
                return this;
            }
            return null;
        }
        /// <summary>
        /// Return this machine if the name matches.
        /// </summary>
        /// <param name="id">a name to search for</param>
        /// <returns>this machine, if the name matches</returns>
        public override MachineComponent Find(String name)
        {
            if (name.Equals(ToString())) 
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Return true if this machine has material in its input, processing,
        /// or output areas.
        /// </summary>
        /// <returns>true, if there is any material on this machine</returns>
        public bool HasMaterial()
        {
            return _bins.Count > 0;
        }

        /// <summary>
        /// This method, if it were actually implemented, would interact with
        /// a physical machine to start it up.
        /// </summary>
        public void StartUp()
        {
        }

        /// <summary>
        /// This method, if it were actually implemented, would interact with
        /// a physical machine to shut it down.
        /// </summary>
        public void ShutDown()
        {
        }
    }
}
