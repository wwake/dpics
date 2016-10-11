using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;

/// I created this just to check out the use of an interface instead
/// of the BorrowReader delegate.

namespace DataLayer
{
    /// <summary>
    /// Provide basic services for accessing the Oozinoz
    /// database. This refactoring shows how an interface can replace 
    /// the use of a delegate.
    /// </summary>
    public class DataServices2
    {
        /// <summary>
        /// Create a reader from the supplied SQL statment. Execute
        /// the supplied IBorrower object's BorrowReader method
        /// and close the reader.
        /// </summary>
        /// <param name="sql">The SQL select statement to execute.</param>
        /// <param name="borrower">An implementation of IBorrower.</param>
        /// <returns>The supplied method's return value.</returns>
        public static object LendReader2(string sql, IBorrower borrower) 
        {
            using (OleDbConnection conn = DataServices.CreateConnection())
            {
                conn.Open(); 
                OleDbCommand c = new OleDbCommand(sql, conn);  
                OleDbDataReader r = c.ExecuteReader();
                return borrower.BorrowReader(r);
            }     
        }
    }
}
