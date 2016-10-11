using System;

namespace Credit
{
    /// <summary>
    /// Objects of this class check credit by dialing out to
    /// credit service bureaus.
    /// </summary>
    public class CreditCheckOnline : ICreditCheck 
    {
        /// <summary>
        /// Return the acceptable credit limit for the person
        /// with the supplied identification number.
        /// </summary>
        /// <param name="id">the customer ID</param>
        /// <returns>the limit</returns>
        public double CreditLimit(int id)
        {
            // logic goes here to contact a credit agency
            return 0;
        }
    }
}
