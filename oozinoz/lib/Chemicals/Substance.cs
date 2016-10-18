using System;

namespace Chemicals
{
    /// <summary>
    /// This class represents a batch of chemical.
    /// </summary>
    public class Substance 
    {
        private string _name;
        private string _symbol;
        private double _atomicWeight;
        private double _grams;

        /// <summary>
        /// Model a batch of stuff.
        /// </summary>
        /// <param name="name">The name of this substance, such as "Saltpeter."</param>
        /// <param name="symbol">The chemical symbol for this substance, such as "KNO3."</param>
        /// <param name="atomicWeight">The atomic weight of this substance (101 for saltpeter).</param>
        /// <param name="grams">The mass of this batch of substance.</param>
        public Substance (
            string name,
            string symbol,
            double atomicWeight,
            double grams)
        {
            _name = name;
            _symbol = symbol;
            _atomicWeight = atomicWeight;
            _grams = grams; 
        }

        /// <summary>
        /// The name of this substance, such as "Saltpeter."
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The chemical symbol for this substance, such as "KNO3."
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        /// <summary>
        /// The atomic weight of this substance (e.g. 101 for saltpeter).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }

        /// <summary>
        /// The mass of this batch of substance.
        /// </summary>
        public double Grams
        {
            get
            {
                return _grams;
            }
        }

        /// <summary>
        /// The number of moles in this batch.
        /// </summary>
        public double Moles
        {
            get
            {
                return _grams / _atomicWeight;
            }
        }
    }
}
