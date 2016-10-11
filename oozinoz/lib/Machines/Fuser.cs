using System;

namespace Machines
{
    /// <summary>
    /// A fuser inserts fusing in an aerial shell.
    /// </summary>
    public class Fuser : Machine
    {
        /// <summary>
        /// Create a machine with the given id and with the supplied
        /// parent machine.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        public Fuser(int id) : base (id)
        {
        }
    }
}
