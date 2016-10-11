using System;
using Credit;
namespace Credit.Canada
{  
    /// <summary>
    /// Instances of this class can check attributes of 
    /// a billing address in Canada.
    /// </summary>
    public class BillingCheckCanada : IBillingCheck 
    {        
        /// <summary>
        /// Return true if this billing address is residential.
        /// </summary>
        /// <returns>true if this billing address is residential</returns>
        public bool IsResidential()
        {
            return true;
        }
    }
}
