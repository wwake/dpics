using System;

namespace Fireworks
{
    /// <summary>
    /// A physical model of a rocket for use in simulations.
    /// </summary>
    public class PhysicalRocket
    { 
        private double _burnArea; 
        private double _burnRate;
        private double _initialFuelMass;
        private double _totalMass;

        private double _totalBurnTime;

        private static double SPECIFIC_IMPULSE = 620; // Newtons/Kg
        private static double FUEL_DENSITY = 1800; // Kg/M**3

        public PhysicalRocket(
            double burnArea, double burnRate, double fuelMass, double totalMass)
        {
            _burnArea = burnArea;
            _burnRate = burnRate;
            _initialFuelMass = fuelMass;
            _totalMass = totalMass;
            
            double _initialFuelVolume = _initialFuelMass / FUEL_DENSITY;
            _totalBurnTime = _initialFuelVolume / (_burnRate * _burnArea);
        }

        /// <summary>
        /// The remaining mass of the rocket after burning off a portion
        /// of its fuel.
        /// </summary>
        /// <param name="time">time since ignition</param>
        /// <returns></returns>
        public double GetMass(double t)
        {
            if (t > _totalBurnTime) return _totalMass - _initialFuelMass;
            double burntFuelVolume = _burnRate * _burnArea * t;
            return _totalMass - burntFuelVolume * FUEL_DENSITY;
        }

        /// <summary>
        /// Calculate thrust with the standard Oozinoz formula.
        /// </summary>
        /// <param name="time">time since ignition</param>
        /// <returns></returns>
        public double GetThrust(double time)
        {  
            if (time > _totalBurnTime) return 0;
            return FUEL_DENSITY * SPECIFIC_IMPULSE * _burnRate * _burnArea;
        }

        /// <summary>
        /// Return the time this rocket's fuel burns.
        /// </summary>
        /// <returns>the time this rocket's fuel burns</returns>
        public double GetBurnTime()
        {
            return _totalBurnTime;
        }
    }
}
