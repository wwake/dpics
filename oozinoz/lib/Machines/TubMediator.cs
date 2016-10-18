using System;
using System.Collections;

namespace Machines
{
    /// <summary>
    /// This class manages the relation of tubs to machines.
    /// </summary>
    public class TubMediator 
    {        
        public static readonly TubMediator SINGLETON = new TubMediator();

        private Hashtable _tubMachine = new Hashtable();

        /// <summary>
        /// Return the machine where a tub is placed.
        /// </summary>
        /// <param name="t">the tub</param>
        /// <returns>the machine where a tub is placed</returns>
        public Machine GetMachine(Tub t)
        {
            return (Machine) _tubMachine[t];
        }
        
        /// <summary>
        /// Return a list of the tubs at a machine.
        /// </summary>
        /// <param name="m">the machine</param>
        /// <returns>a list of the tubs at a machine</returns>
        public IList GetTubs(Machine m)
        {
            ArrayList al = new ArrayList();
            IDictionaryEnumerator e = _tubMachine.GetEnumerator();
            while (e.MoveNext()) 
            {
                if (e.Value.Equals(m))
                {
                    al.Add(e.Key);
                }
            }
            return al;
        }
        
        /// <summary>
        /// Set a tub's location to be the given machine.
        /// </summary>
        /// <param name="t">the tub</param>
        /// <param name="m">the machine</param>
        public void Set(Tub t, Machine m)
        {
            _tubMachine[t] = m;
        }
    }
}
