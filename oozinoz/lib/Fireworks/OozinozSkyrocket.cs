using System;
using Simulation;

namespace Fireworks
{
	/// <summary>
	/// Instances of this class qualify as Skyrocket objects, but use
	/// information from a PhysicalRocket object. This class is an
	/// "object adapter" that adapts the PhysicalRocket class to meet
	/// the needs of clients of the Skyrocket class.
	/// </summary>
	public class OozinozSkyrocket : Skyrocket
    {
        private PhysicalRocket _rocket;
        public OozinozSkyrocket(PhysicalRocket r) : 
            base (r.GetMass(0), r.GetThrust(0), r.GetBurnTime())
		{
            _rocket = r;
		}

        /// <summary>
        /// Use a PhysicalRocket object to model a rocket's mass at simulation time.
        /// </summary>
        /// <returns>mass</returns>
        public override double GetMass()   
        {
            return _rocket.GetMass(_simTime);
        }

        /// <summary>
        /// Use a PhysicalRocket object to model a rocket's thrust at simulation time.
        /// </summary>
        /// <returns>thrust</returns>
        public override double GetThrust()  
        {
            return _rocket.GetThrust(_simTime);
        }
	}
}
