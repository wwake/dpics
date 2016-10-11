using System;
namespace Machines
{
    /// <summary>
    /// An unload buffer is a conveyor that contains bins of
    /// completed material.
    /// </summary>
    public class UnloadBuffer : Machine
    {
        /// <summary>
        /// Create a machine with the given id and with the supplied
        /// parent machine.
        /// </summary>
        /// <param name="id">the identity of this machine</param>
        public UnloadBuffer(int id) : base (id)
        {
        }
    }
}
