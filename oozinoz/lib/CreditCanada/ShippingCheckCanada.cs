using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// Instances of this class can check attributes of 
    /// a shipping address in Canada.
    /// </summary>
    public class ShippingCheckCanada : IShippingCheck 
    { 
        /// <summary>
        /// Return true if this shipping address incurs a tariff.
        /// </summary>
        /// <returns>true if this shipping address incurs a tariff</returns>
        public bool HasTariff()
        {
            return true;
        }
    }
}
