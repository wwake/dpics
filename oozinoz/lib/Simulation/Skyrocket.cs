using System;

namespace Simulation
{
    /// <summary>
    /// Instances of this class simulate rockets. The simulation depends
    /// mainly on the internal ballistics of the burning fuel.
    /// </summary>
    public class Skyrocket
    {
        private double _mass;
        private double _thrust;
        private double _burnTime;
        protected double _simTime;

        /// <summary>
        /// Create a model of a rocket.
        /// </summary>
        /// <param name="mass">the rocket's initial mass</param>
        /// <param name="thrust">the rocket's initial thrust</param>
        /// <param name="burnTime">the rocket fuel's burn time</param>
        public Skyrocket (
            double mass, double thrust, double burnTime) 
        {
            _mass = mass;
            _thrust = thrust;
            _burnTime = burnTime;
        }

        /// <summary>
        /// Model mass as reducing linearly from the initial mass down to 0 during 
        /// the life of the fuel.
        /// </summary>
        /// <returns>mass</returns>
        public virtual double GetMass()   
        {
            if (_simTime > _burnTime) return 0;            
            return _mass * (1 - (_simTime / _burnTime));
        }

        /// <summary>
        /// Model thrust as constant for the life of the fuel.
        /// </summary>
        /// <returns>thrust</returns>
        public virtual double GetThrust()  
        {
           if (_simTime > _burnTime) return 0;   
           return _thrust;
        }

        /// <summary>
        /// When the simulation updates its clock, hang onto the current time.
        /// </summary>
        /// <param name="t">the time in the simulation</param>
        public virtual void SetSimTime(double t)
        {
            _simTime = t;
        }
    }
}
