using System;
using Fireworks;

namespace Recommendations
{
    /// <summary>
    ///  Implement the Advisor interface by relying on the LikeMyStuff
    ///  engine that models a customer's preferences on his or her
    ///  eariler purchases.
    /// </summary>
    public class ItemAdvisor : Advisor 
    {
        public static readonly ItemAdvisor singleton = new ItemAdvisor();
        private ItemAdvisor()
        {
        }

        /// <summary>
        /// Recommend a nice item for this customer, based on a model
        /// of the customer's recent spending with us.
        /// </summary>
        /// <param name="c">the customer to cross-sell</param>
        /// <returns>a nice item for the customer to buy</returns>
        public Firework Recommend(Customer c)
        {
            return (Firework) LikeMyStuff.Suggest(c);
        }
    }
}
