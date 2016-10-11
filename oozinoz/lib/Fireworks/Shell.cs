using System;

namespace Fireworks
{
	/// <summary>
    /// A firework designed to be launched from a mortar 
    /// and explode high in the sky.
	/// </summary>
	public class Shell : Firework
	{
        private double _muzzleVelocity;
        /// <summary>
        /// Create an empty shell.
        /// </summary>
        public Shell()
        {
        }
        /// <summary>
        /// Create a shell with all its expected properties
        /// </summary>
        /// <param name="muzzleVelocity">The speed (in meters/second) of
        /// this shell as it leaves the mortar</param>
        /// See the superclass for descriptions of other parameters.
        public Shell (
            string name, double mass, decimal price, double muzzleVelocity) : 
            base (name, mass, price)
        {
            MuzzleVelocity = muzzleVelocity;
        }
        /// <summary>
        /// The speed (in meters/second) of this shell as it leaves 
        /// the mortar.
        /// </summary>
        public double MuzzleVelocity
        {
            get
            {
                return _muzzleVelocity;
            }
            set
            {
                _muzzleVelocity = value;
            }
        }
	}
}
