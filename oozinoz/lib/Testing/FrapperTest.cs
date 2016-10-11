using System;
using NUnit.Framework;
using Functions;
namespace Testing
{
	/// <summary>
	/// A few tests of "Frappers"--Function Wrappers.
    /// </summary>
    [TestFixture]
	public class FrapperTest
    {
        [Test]
        public void TestConstant() 
        {
            Constant c = new Constant(42);
            Assertion.AssertEquals(42, c.F(0));
            Assertion.AssertEquals(42, c.F(0.5));
            Assertion.AssertEquals(42, c.F(1));
        }
        [Test]
        public void TestScale() 
        {
            Frapper c = new Scale(0, 100); // let Celsius go 0 to 100            
            Frapper f = new Scale(
                new Constant(0), c, new Constant(100), 
                new Constant(32), new Constant(212));
            Assertion.AssertEquals(32, f.F(0));
            Assertion.AssertEquals(-40, f.F(-0.4));
            Assertion.AssertEquals(212, f.F(1));
        }
        [Test]
        public void TestArithmetic() 
        {
            Frapper f = new Arithmetic('+', new Constant(3), new Constant(4));
            Assertion.AssertEquals(7, f.F(0));
            Assertion.AssertEquals(7, f.F(0.5));
            Assertion.AssertEquals(7, f.F(1));
        }
	}
}
