namespace Machines
{
	/// <summary>
    /// This is a minimal model of a "bin," a large plastic
    /// rectangular basket that holds fireworks materials as
    /// they go through the factory.
	/// </summary>
	public class Bin
	{
        private int _id;
        /// <summary>
        /// Create a bin with the given id.
        /// </summary>
        /// <param name="id">A unique number for this bin.</param>
        public Bin(int id)
        {
            _id = id;
        }
	}
}
