using System;
using System.Collections;

namespace Chemicals
{
    /// <summary>
    ///  This class creates and returns Chemical objects. We will
    ///  refactor this class to make Chemical an interface.
    /// </summary>
    public class ChemicalFactory 
    {
        private static Hashtable _chemicals = new Hashtable();
        static ChemicalFactory ()
        {          
            _chemicals["carbon"] = new Chemical("Carbon", "C", 12);
            _chemicals["sulfur"] = new Chemical("Sulfur", "S", 32);
            _chemicals["saltpeter"] = new Chemical("Saltpeter", "KN03", 101);
            //...
        }

        /// <summary>
        /// Return the Chemical object for the given name.
        /// </summary>
        /// <param name="name">the name of the interesting chemical</param>
        /// <returns>the Chemical object for the given name</returns>
        public static Chemical GetChemical(String name)
        {
            return (Chemical) _chemicals[name.ToLower()];
        }
    }
}
