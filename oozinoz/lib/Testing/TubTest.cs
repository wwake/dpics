using System;
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
            Assertion.AssertEquals(1, m1.GetTubs().Count);
            // move the tub by adding it to m2
            m2.AddTub(t);
            Assertion.AssertEquals(m2, t.Location);
            Assertion.AssertEquals(0, m1.GetTubs().Count);
            Assertion.AssertEquals(1, m2.GetTubs().Count);
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
            Assertion.Assert(m1.GetTubs().Contains(t));
            Assertion.Assert(!m2.GetTubs().Contains(t));
            // move the tub
            t.Location = m2;
            Assertion.Assert(!m1.GetTubs().Contains(t));
            Assertion.Assert(m2.GetTubs().Contains(t));
        }
	}
}
