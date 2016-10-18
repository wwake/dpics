using System;
using System.Data;
using System.Data.OleDb;
using NUnit.Framework;
using Fireworks;
using DataLayer;

namespace Testing
{
    /// <summary>
    /// NUnit tests for the data layer.
    /// </summary>
    [TestFixture]
    public class DataLayerTest 
    {
        /// <summary>
        /// Just check that the database is there.
        /// </summary>
        [Test]
        public void TestDatabaseAccess() 
        {
            string select = "SELECT * FROM Rocket";
            OleDbDataAdapter adapter = DataServices.CreateAdapter(select);
            adapter.Fill(new DataSet(), "Rocket");
            adapter.Dispose();
        }

        /// <summary>
        /// Check that a reader is closed after borrowing it.
        /// </summary>
        [Test]
        public void TestReaderCloses() 
        { 
            string sel = "SELECT * FROM ROCKET";
            // 
            OleDbDataReader r = (OleDbDataReader) 
                DataServices.LendReader(sel, new BorrowReader(UseReader));
            Assert.IsTrue(r.IsClosed);
        }  
      
        // Make a minimal use of a reader, and return it; normally
        // you wouldn't want to do that, but we need to test the reader
        // in the test method.
        private static Object UseReader(IDataReader reader)
        {
            reader.Read(); 
            return reader;
        }
        
        /// <summary>
        /// Test that find calls execute.
        /// </summary>
        [Test]
        public void TestFinding()
        {
            DataServices.FindAll(typeof(Rocket));
            DataServices.Find(typeof(Rocket), "Orbit");
        }
    }
}
