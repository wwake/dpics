namespace Credit
{
    /// <summary>
    /// This interface defines the common behaviors for verifying
    /// a billing address.
    /// </summary>
    public interface IBillingCheck 
    {
        /// <summary>
        /// Return .
        /// </summary>
        /// <returns>true if a customer's address is residential</returns>
        bool IsResidential();
    }
}

 