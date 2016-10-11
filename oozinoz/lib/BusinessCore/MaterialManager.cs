using System;

namespace BusinessCore
{
    /// <summary>
    /// This class is a mock up of a class that would run on an
    /// an Aster star press and that would somehow connect 
    /// Oozinoz systems that store information about material.
    /// </summary>
    public class MaterialManager 
    {
        // force use of the singleton
        private MaterialManager()
        {
        }

        /// <summary>
        /// In fact this is not implemented, but only shows the role of a
        /// method that would return a singleton MaterialManager.
        /// </summary>
        /// <returns>the material manager singleton</returns>
        public static MaterialManager GetManager()
        {
            return null;
        }

        /// <summary>
        /// This method is not implemented; if it were it tell the Oozinoz 
        /// systems that the provided star press mold was not completely 
        /// processed.
        /// </summary>
        /// <param name="id"></param>
        public void SetMoldIncomplete(int id)
        {
        }
    }
}
