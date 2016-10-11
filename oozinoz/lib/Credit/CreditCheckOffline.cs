using System;
namespace Credit
{
    /// <summary>
    /// Objects of this class check credit using a series of
    /// agent/customer dialogs.
    /// </summary>
    public class CreditCheckOffline : ICreditCheck 
    {
        /// <summary>
        /// Return the acceptable credit limit for the person
        /// with the supplied identification number.
        /// </summary>
        /// <param name="id">the customer id</param>
        /// <returns>the limit</returns>
        public double CreditLimit(int id)
        {
            // logic goes here to dialog with call center rep to
            // ascertain a reasonable credit limit
            return 0;
        }
    }
}
