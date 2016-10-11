using System;
namespace Credit
{
    /// <summary>
    /// This factory produces objects that can check credit.
    /// </summary>
    public abstract class CreditCheckFactory 
    {
        /// <summary>
        /// Return an ICreditCheck object; the actual class of the
        /// object depends on whether the credit agency is up.
        /// </summary>
        /// <returns>an ICreditCheck object</returns>
        public static ICreditCheck CreateCreditCheck()
        {
            if (IsAgencyUp())
            {
                return new CreditCheckOnline();
            }
            else
            {
                return new CreditCheckOffline();
            }
        }
        /// <summary>
        /// Return true if the service bureau is accessible. This
        /// method is not yet actually implemented.
        /// </summary>
        /// <returns>true if the service bureau is accessible</returns>
        public static bool IsAgencyUp()
        {
            return true;
        }
        /// <summary>
        /// Return an IBillingCheck object; the actual class of the
        /// object depends on subclasses.
        /// </summary>
        /// <returns>an IBillingCheck object</returns>
        public abstract IBillingCheck CreateBillingCheck();
        /// <summary>
        /// Return an ICreditCheck object; the actual class of the
        /// object depends on subclasses.
        /// </summary>
        /// <returns>an ICreditCheck object</returns>
        public abstract ICreditCheck CreateCreditCheck2();
        /// <summary>
        /// Return an IShippingCheck object; the actual class of the
        /// object depends on subclasses.
        /// </summary>
        /// <returns>an IShippingCheck object</returns>
        public abstract IShippingCheck CreateShippingCheck();
    }
}
