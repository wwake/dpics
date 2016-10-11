using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Implement the Advisor interface, recommending a random
    /// firework.
    /// </summary>
    public class RandomAdvisor : Advisor 
    {
        public static readonly RandomAdvisor singleton = new RandomAdvisor();
        private RandomAdvisor()
        {
        }

        /// <summary>
        /// Just recommend a random firework.
        /// </summary>
        /// <param name="c">the customer</param>
        /// <returns>any firework, chosen at random</returns>
        public Firework Recommend(Customer c)
        {
            return Firework.GetRandom();
        }
    }
}
