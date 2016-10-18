using System;

namespace Chemicals
{
    /// <summary>
    /// This class represents a batch of chemical.
    /// </summary>
    public class Substance2
    {
        private double _grams;
        private Chemical _chemical;

        /// <summary>
        /// Model a batch of stuff, revised from the original Substance class to
        /// rely on an (immutable) Chemical class.
        /// </summary>
        /// <param name="grams">The mass of this batch of substance.</param>
        /// <param name="chemical">This batch's chemical composition</param>
        public Substance2 (double grams, Chemical chemical)
        {
            _grams = grams; 
            _chemical = chemical;
        }

        /// <summary>
        /// The name of this substance, such as "Saltpeter."
        /// </summary>
        public string Name
        {
            get
            {
                return _chemical.Name;
            }
        }

        /// <summary>
        /// The chemical symbol for this substance, such as "KNO3."
        /// </summary>
        public string Symbol
        {
            get
            {
                return _chemical.Symbol;
            }
        }

        /// <summary>
        /// The atomic weight of this substance (e.g. 101 for saltpeter).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _chemical.AtomicWeight;
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
                return _grams / AtomicWeight;
            }
        }
    }
}
