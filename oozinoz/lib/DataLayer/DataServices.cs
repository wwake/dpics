using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Reflection;

namespace DataLayer
{
    /// <summary>
    /// This delegate defines the interface for methods that receive
    /// (or "borrow") a database reader. A "lender" can call this 
    /// delegate, opening the reader before the call and disposing
    /// the reader's resources after the call.
    /// </summary>
    public delegate object BorrowReader(IDataReader reader);

    /// <summary>
    /// Provide basic services for accessing the Oozinoz
    /// database.
    /// </summary>
    public class DataServices
    {
        /// <summary>
        /// Create a reader from the supplied SQL statment. Execute
        /// the supplied delegate--a method that "borrows" the reader--
        /// and close the reader.
        /// </summary>
        /// <param name="sql">The SQL select statement to execute.</param>
        /// <param name="borrower">The method to call that uses a reader.</param>
        /// <returns>The supplied method's return value.</returns>
        public static object LendReader(string sql, BorrowReader borrower) 
        {
            using (OleDbConnection conn = CreateConnection())
            {
                conn.Open(); 
                OleDbCommand c = new OleDbCommand(sql, conn);  
                OleDbDataReader r = c.ExecuteReader();
                return borrower(r);
            }     
        }

        /// <summary>
        /// Create and return a connection to the Oozinoz Access
        /// database.
        /// </summary>
        /// <returns>the connection</returns>
        public static OleDbConnection CreateConnection()
        {
            OleDbConnection c = new OleDbConnection();
       
            // String dbName = FileFinder.GetFileName("db", "oozinoz.mdb");
            // c.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + dbName;
            // Data Source=.\SQLEXPRESS;Initial Catalog=Customers;Integrated Security=True;
            const string provider = "SQLOLEDB";
            const string server = ".\\SQLExpress";
            const string dbName = "oozinoz";
            c.ConnectionString = string.Format("Provider={0};Server={1};Database={2};Trusted_Connection=Yes;", provider, server, dbName);
            return c;
        }

        /// <summary>
        /// Create and return a database adapter for the supplied
        /// select statement.
        /// </summary>
        /// <param name="select">The SQL select statement to execute</param>
        /// <returns>The adapter.</returns>
        public static OleDbDataAdapter CreateAdapter(string select) 
        {   
            return new OleDbDataAdapter(select, CreateConnection());  
        }   
     
        /// <summary>
        /// Create and return a DataTable object that holds the results
        /// of the supplied select statement.
        /// </summary>
        /// <param name="select">The SQL to generate results</param>
        /// <returns>The DataTable</returns>
        public static DataTable CreateTable(string select) 
        {   
            return (DataTable) LendReader(select, new BorrowReader(CreateTable));
        } 

        // Create a DataTable from the given reader
        internal static object CreateTable(IDataReader reader) 
        {
            DataTable table = new DataTable(); 
            for (int i = 0; i < reader.FieldCount; i++) 
            { 
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }   
            while (reader.Read()) 
            {
                DataRow dr = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++) 
                {
                    dr[i] = reader.GetValue(i);
                }     
                table.Rows.Add(dr);
            }
            return table;
        }
        /// <summary>
        /// Return an instance of the supplied type, populated with data
        /// from the Oozinoz database.
        /// </summary>
        /// <param name="t">The datatype to instantiate.</param>
        /// <param name="name">The name of the object to lookup in the 
        /// database</param>
        /// <returns>The instantiated object</returns>
        public static Object Find(Type t, string name)         
        {
            string sel = "SELECT * FROM " + t.Name + " WHERE NAME = '" + name + "'";
            return LendReader(sel, new BorrowReader(new ObjectLoader(t).LoadObject));
        } 

        /// <summary>
        /// Find all objects of the given type in the database.
        /// </summary>
        /// <param name="t">The type to instantiate</param>
        /// <returns>A list of the objects that represents rows of data
        /// in the database table whose name matches the given type.
        /// </returns>
        public static IList FindAll(Type t)         
        {
            string sel = "SELECT * FROM " + t.Name;
            return (IList) LendReader(sel, new BorrowReader(new ObjectLoader(t).LoadAll));
        } 
        //
        // Instances of this class hold a type to instantiate and to populate from
        // a database reader.
        //
        internal class ObjectLoader
        {
            private Type _type;
            //
            // Create an ObjectLoader object for the given type.
            //
            public ObjectLoader(Type t)
            {
                this._type = t;
            }
            //
            // Advance the reader and populate a single object.
            //
            internal Object LoadObject(IDataReader reader)
            {
                if (reader.Read()) 
                { 
                    return LoadFromCurrent(reader);
                }
                return null;
            }
            //
            // Create a list of objects, where each object represents a 
            // row in a database. 
            //
            internal Object LoadAll(IDataReader reader)
            {
                ArrayList list = new ArrayList();
                while (reader.Read()) 
                {
                    list.Add(LoadFromCurrent(reader));
                }
                return list;
            }
            //
            // Instantiate and load a single object from the current
            // record in the supplied reader.
            //
            internal Object LoadFromCurrent(IDataReader reader) 
            {
                ConstructorInfo c = _type.GetConstructor(new Type[]{});
                Object o = c.Invoke(new Object[]{});
                foreach (PropertyInfo p in _type.GetProperties()) 
                {
                    MethodInfo m = p.GetSetMethod();
                    try 
                    {
                        m.Invoke(o, new Object[]{reader[p.Name]});
                    }
                    catch (System.IndexOutOfRangeException) {}
                }
                return o;
            }
        }
    }
}
