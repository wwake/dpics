namespace Credit
{
    /// <summary>
    /// This interface defines the common behaviors for online
    /// and offline credit check classes.
    /// </summary>
    public interface ICreditCheck 
    {
        /// <summary>
        /// Return the acceptable credit limit for the person
        /// with the supplied identification number.
        /// </summary>
        /// <param name="id">the customer ID</param>
        /// <returns>the limit</returns>
        double CreditLimit(int id);
    }
}

 