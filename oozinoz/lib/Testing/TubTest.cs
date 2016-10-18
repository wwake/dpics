using NUnit.Framework;
using Machines;

namespace Testing
{
	/// <summary>
	/// Test Machine/Tub relationships.
    /// </summary>
    [TestFixture]
	public class TubTest
    {
        [Test]
        public void TestAddTub() 
        {
            // setup
            Tub t = new Tub("T402");
            Machine m1 = new Machine(1);
            Machine m2 = new Machine(2);
            // place the tub on m1
            t.Location = m1;
            Assert.AreEqual(1, m1.GetTubs().Count);
            // move the tub by adding it to m2
            m2.AddTub(t);
            Assert.AreEqual(m2, t.Location);
            Assert.AreEqual(0, m1.GetTubs().Count);
            Assert.AreEqual(1, m2.GetTubs().Count);
        }

        [Test]
        public void TestLocationChange() 
        {
            // setup
            Tub t = new Tub("T403");
            Machine m1 = new Machine(1001);
            Machine m2 = new Machine(1002);
            // place the tub on m1
            t.Location = m1;
            Assert.IsTrue(m1.GetTubs().Contains(t));
            Assert.IsFalse(m2.GetTubs().Contains(t));
            // move the tub
            t.Location = m2;
            Assert.IsFalse(m1.GetTubs().Contains(t));
            Assert.IsTrue(m2.GetTubs().Contains(t));
        }
	}
}
