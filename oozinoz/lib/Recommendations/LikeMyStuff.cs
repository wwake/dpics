using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// This class is just a mock-up, acting as if it were a
    /// recommendation engine that relies on customer purchasing
    /// history for its suggestions. 
    /// </summary>
    public class LikeMyStuff 
    {
        /// <summary>
        /// Recommend a nice item for this customer, based on his
        /// or her previous purchases.
        /// </summary>
        /// <param name="c">the customer</param>
        /// <returns>the best item to suggest to this customer</returns>
        public static Object Suggest(Customer c)
        {
            return new Firework();
        }
    }
}
