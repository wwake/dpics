using System;
using System.Collections;

namespace Chemicals
{
    /// <summary>
    ///  This class creates and returns IChemical objects. This is
    ///  a refactoring that ensures that the factory class is the
    ///  only class that can instantiate the Chemical class.
    /// </summary>
    public class ChemicalFactory2 
    {
        private static Hashtable _chemicals = new Hashtable();
        private class ChemicalImpl : IChemical
        {
            private String _name;
            private String _symbol;
            private double _atomicWeight;

            internal ChemicalImpl (
                String name, String symbol, double atomicWeight)
            {
                _name = name;
                _symbol = symbol;
                _atomicWeight = atomicWeight;
            }

            public string Name
            {
                get { return _name; }
            }
            
            public string Symbol
            {
                get { return _symbol; }
            }
            
            public double AtomicWeight
            {
                get { return _atomicWeight; }
            }
        }

        static ChemicalFactory2 ()
        {          
            _chemicals["carbon"] = new ChemicalImpl("Carbon", "C", 12);
            _chemicals["sulfur"] = new ChemicalImpl("Sulfur", "S", 32);
            _chemicals["saltpeter"] = new ChemicalImpl("Saltpeter", "KN03", 101);
            //...
        }

        /// <summary>
        /// Return the IChemical object for the given name.
        /// </summary>
        /// <param name="name">the name of the interesting chemical</param>
        /// <returns>the IChemical object for the given name</returns>
        public static IChemical GetChemical(String name)
        {
            return (IChemical) _chemicals[name.ToLower()];
        }
    }
}
