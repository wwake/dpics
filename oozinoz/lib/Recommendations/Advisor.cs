using System; 
using Fireworks;

namespace Recommendations
{
    /// <summary>
    /// Defines a standard service for recommending a purchasable
    /// item to a customer.
    /// </summary>
    public interface Advisor 
    {
        Firework Recommend(Customer c);
    }
}
 