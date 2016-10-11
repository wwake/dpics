using System;
using Credit;
namespace Credit.Canada
{
    /// <summary>
    /// This factory supplies objects that can check credit, 
    /// billing addresses, and shipping addresses in Canada.
    /// </summary>
    public class CheckFactoryCanada : CreditCheckFactory 
    {
        /// <summary>
        /// Return an IBillingCheck object for Canadian customers.
        /// </summary>
        /// <returns>an IBillingCheck object for Canadian customers</returns>
        public override IBillingCheck CreateBillingCheck()
        {
            return new BillingCheckCanada();
        } 
        /// <summary>
        /// Return an ICreditCheck object for Canadian customers.
        /// </summary>
        /// <returns>an ICreditCheck object for Canadian customers</returns>
        public override ICreditCheck CreateCreditCheck2()
        {
            if (IsAgencyUp())
            {
                return new CreditCheckCanadaOnline();
            }
            else
            {
                return new CreditCheckOffline();
            }
        } 
        /// <summary>
        /// Return an IShippingCheck object for Canadian customers.
        /// </summary>
        /// <returns>an IShippingCheck object for Canadian customers</returns>
        public override IShippingCheck CreateShippingCheck()
        {
            return new ShippingCheckCanada();
        }
    }
}
