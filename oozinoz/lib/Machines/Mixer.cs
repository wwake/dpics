using System;

namespace Machines
{
    /// <summary>
    /// A mixer mixes chemicals.
    /// </summary>
    public class Mixer : Machine
    {
        /// <summary>
        /// Create a machine with the given id and with the supplied
        /// parent machine.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        public Mixer(int id) : base (id)
        {
        }
    }
}
