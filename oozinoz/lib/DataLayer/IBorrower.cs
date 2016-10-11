using System.Data;
namespace DataLayer 
{
    /// <summary>
    /// Define the interface for clients that borrow a database
    /// reader without having to worry about disposing of it.
    /// </summary>
    public interface IBorrower
    {
        /// <summary>
        /// Use the supplied reader, understaning the the caller will
        /// dispose of it after this method executes. Return a result 
        /// of the usage, or null.
        /// </summary>
        /// <param name="reader">The database reader to use</param>
        object BorrowReader(IDataReader reader);
    }
}