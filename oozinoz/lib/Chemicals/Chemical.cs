using System; 

namespace Chemicals
{
    /// <summary>
    /// This class represents a type of chemical. 
    /// </summary>
    public class Chemical
    {
        private String _name;
        private String _symbol;
        private double _atomicWeight;

        /// <summary>
        /// Model a chemical such as saltpeter.
        /// </summary>
        /// <param name="name">The name of this chemical, such as "Saltpeter."</param>
        /// <param name="symbol">The chemical symbol for this substance, such as "KNO3."</param>
        /// <param name="atomicWeight">The atomic weight of this substance (101 for saltpeter).</param>
        internal Chemical(
            String name,
            String symbol,
            double atomicWeight)
        {
            _name = name;
            _symbol = symbol;
            _atomicWeight = atomicWeight;
        }

        /// <summary>
        /// The name of this chemical, such as "Saltpeter."
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// The symbol for this chemical, such as "KNO3."
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        /// <summary>
        /// The atomic weight of this chemical (e.g. 101 for saltpeter).
        /// </summary>
        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }

        /// <summary>
        /// Describe this chemical.
        /// </summary>
        /// <returns>a textual description of this chemical</returns>
        public override String ToString()
        {
            return _name + "(" + _symbol + ")[" + _atomicWeight + "]";
        }
    }
}
