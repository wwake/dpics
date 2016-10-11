using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// Implement the Advisor interface by relying on the Rel8
    /// engine that relates a customer's preferences to other
    /// customers' tastes.
    /// </summary>
    public class GroupAdvisor : Advisor 
    {
        public static readonly GroupAdvisor singleton = new GroupAdvisor();

        private GroupAdvisor()
        {
        }

        /// <summary>
        /// Recommend a nice item for this customer, based on how
        /// this customer's taste in music and extreme sports correlates
        /// with other customers and with their fireworks preferences.
        /// </summary>
        /// <param name="c">the customer to cross-sell</param>
        /// <returns>a nice item for the customer to buy</returns>
        public Firework Recommend(Customer c)
        {
            return (Firework) Rel8.Advise(c);
        }
    }
}
