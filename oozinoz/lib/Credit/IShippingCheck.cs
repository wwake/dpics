namespace Credit
{
    /// <summary>
    /// This interface defines the common behaviors for verifying
    /// a shipping address.
    /// </summary>
    public interface IShippingCheck 
    {
        /// <summary>
        /// Return .
        /// </summary>
        /// <returns>true if a customer's address is residential</returns>
        bool HasTariff();
    }
}

 