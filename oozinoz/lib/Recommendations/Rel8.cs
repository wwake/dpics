using System;
using Fireworks;
namespace Recommendations
{
    /// <summary>
    /// This class is just a mock-up, acting as if it were a
    /// recommendation engine that relies on customer profiling
    /// for its suggestions. 
    /// </summary>
    public class Rel8 
    {
        /// <summary>
        /// Recommend a nice item for this customer, based on how
        /// this customer's taste in music and extreme sports correlates
        /// with other customers and with their fireworks preferences.
        /// </summary>
        /// <param name="c">the customer</param>
        /// <returns>a suggested firework</returns>
        public static Object Advise(Customer c)
        {
            return new Firework();
        }
    }
}
