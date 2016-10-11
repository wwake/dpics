using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Objects of this class check credit by dialing out to
    /// a (Canadian) credit service bureau.
    /// </summary>
    public class CreditCheckCanadaOnline : ICreditCheck 
    {
        /// <summary>
        /// Return the acceptable credit limit for the person
        /// with the supplied identification number.
        /// </summary>
        /// <param name="id">a customer's ID number</param>
        /// <returns>an acceptable credit limit</returns>
        public double CreditLimit(int id)
        {
            // logic goes here to contact a Canadian credit agency
            return 0;
        }
    }
}
