using System;

namespace Fireworks
{
    /// <summary>
    ///  A self-propelled firework.
    /// </summary>
    public class Rocket : Firework
    {
        private double _apogee;
        private double _thrust;

        /// Allow creation of empty objects to support reconstruction
        /// from persistent store.
        public Rocket()
        {
        }

        /// <summary>
        /// Create a rocket with all its expected properties.
        /// </summary>
        /// <param name="apogee">The height (in meters) that the rocket
        /// is expected to reach</param>
        /// <param name="thrust">The rated thrust (or force, in newtons) of this
        /// rocket</param>
        /// See the superclass for descriptions of other parameters
        public Rocket(string name, double mass, decimal price, double apogee, double thrust) : 
            base (name, mass, price)
        {
            Apogee = apogee;
            Thrust = thrust;
        }

        /// <summary>
        /// The height (in meters) that the rocket is expected to reach.
        /// </summary>
        public double Apogee 
        {
            get
            {
                return _apogee;
            }
            set  
            {
                _apogee = value;
            }
        }

        /// <summary>
        /// The rated thrust (or force, in newtons) of this rocket.
        /// </summary>
        public double Thrust 
        {
            get
            {
                return _thrust;
            }
            set  
            {
                _thrust = value;
            }
        }
    }
}
