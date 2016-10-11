using System;
using NUnit.Framework; 
using Fireworks;
using Simulation;

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
            Assertion.AssertEquals("check burn time", bt, r.GetBurnTime(), tol);

            Assertion.AssertEquals("initial mass", totalMass, r.GetMass(0), tol);
            Assertion.AssertEquals("burnt out mass", totalMass - fuelMass, r.GetMass(bt), tol);
            Assertion.AssertEquals("half mass", totalMass - fuelMass * .5, r.GetMass(bt/2), tol);
            Assertion.AssertEquals("thrust", SPECIFIC_IMPULSE * FUEL_DENSITY * burnArea * burnRate, r.GetThrust(bt/2), tol);
        }           /// <summary>
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
            Assertion.AssertEquals("initial mass", totalMass, or.GetMass(), tol);
            Assertion.AssertEquals("thrust", SPECIFIC_IMPULSE * FUEL_DENSITY * burnArea * burnRate, or.GetThrust(), tol);
            
            double bt = burnDepth / burnRate;
            or.SetSimTime(bt * 1.01); 
            Assertion.AssertEquals("end mass", totalMass - fuelMass, or.GetMass(), tol);
            Assertion.AssertEquals("thrust", 0, or.GetThrust(), tol);
        }      
    }
}
