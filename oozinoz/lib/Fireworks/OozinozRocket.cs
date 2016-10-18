using System;
using Simulation;

namespace Fireworks
{
	/// <summary>
	/// An adapter that lets a rocket participate in a simulation.
	/// </summary>
	public class OozinozRocket : PhysicalRocket, IRocketSim
	{
        private double _time;
		public OozinozRocket(
            double burnArea, double burnRate, double fuelMass, double totalMass)
            : base (burnArea, burnRate, fuelMass, totalMass)
		{
        }

        public double GetMass()
        {
            return GetMass(_time);
        }

        public double GetThrust()
        {
            return GetThrust(_time);
        }

        public void SetSimTime (double time)
        {
            _time = time;
        }
	}
}
