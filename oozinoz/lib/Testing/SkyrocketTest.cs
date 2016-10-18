using NUnit.Framework; 
using Fireworks;

namespace Testing
{
    /// <summary>
    /// Test the Simulation package and the Fireworks classes that support it.
    /// </summary>
    [TestFixture]
    public class SkyrocketTest 
    {
        private static double SPECIFIC_IMPULSE = 620; // Newtons/Kg
        private static double FUEL_DENSITY = 1800; // Kg/M**3

        /// <summary>
        /// Test that mass varies linearly from start mass to 0, over the
        /// time it takes the fuel to burn.
        /// </summary>
        [Test]
        public void TestPhysicalRocket() 
        {
            double burnArea = .0030;
            double burnDepth = .06;
            double burnVolume = burnArea * burnDepth;
            double fuelMass = burnVolume * FUEL_DENSITY;
            double totalMass = fuelMass * 1.1;
            double burnRate = .020;

            PhysicalRocket r = new PhysicalRocket(burnArea, burnRate, fuelMass, totalMass);

            double bt = burnDepth / burnRate;
            double tol = 0.01;
            Assert.AreEqual(bt, r.GetBurnTime(), tol, "check burn time");

            Assert.AreEqual(totalMass, r.GetMass(0), tol, "initial mass");
            Assert.AreEqual(totalMass - fuelMass, r.GetMass(bt), tol, "burnt out mass");
            Assert.AreEqual(totalMass - fuelMass * .5, r.GetMass(bt/2), tol,"half mass");
            Assert.AreEqual(SPECIFIC_IMPULSE * FUEL_DENSITY * burnArea * burnRate, r.GetThrust(bt/2), tol, "thrust");
        }
        
        /// <summary>
        /// Test that mass varies linearly from start mass to 0, over the
        /// time it takes the fuel to burn.
        /// </summary>
        [Test]
        public void TestOozinozSkyocket() 
        {
            double burnArea = .0030;
            double burnDepth = .06;
            double burnVolume = burnArea * burnDepth;
            double fuelMass = burnVolume * FUEL_DENSITY;
            double totalMass = fuelMass * 1.1;
            double burnRate = .020;

            PhysicalRocket pr = new PhysicalRocket(burnArea, burnRate, fuelMass, totalMass);

            OozinozSkyrocket or = new OozinozSkyrocket(pr);

            double tol = 0.01;

            or.SetSimTime(0);    
            Assert.AreEqual(totalMass, or.GetMass(), tol, "initial mass");
            Assert.AreEqual(SPECIFIC_IMPULSE * FUEL_DENSITY * burnArea * burnRate, or.GetThrust(), tol, "thrust");
            
            double bt = burnDepth / burnRate;
            or.SetSimTime(bt * 1.01); 
            Assert.AreEqual(totalMass - fuelMass, or.GetMass(), tol, "end mass");
            Assert.AreEqual(0, or.GetThrust(), tol, "thrust");
        }
    }
}
