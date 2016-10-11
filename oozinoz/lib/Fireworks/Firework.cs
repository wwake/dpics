using System;

namespace Fireworks
{
    /// <summary>
    /// Objects of this class represent types of fireworks.
    /// </summary>
    public class Firework
    {
        private string _name;
        private double _mass;
        private decimal _price;
        /// <summary>
        /// Allow creation of empty objects to support reconstruction
        /// from persistent store.
        /// </summary>
        public Firework()
        {
        }
        /// <summary>
        /// Create a firework, providing all of its properties.
        /// </summary>
        /// <param name="name">The unique name of this type of firework</param>
        /// <param name="mass">The mass, in kilograms, of one instance of this type</param>
        /// <param name="price">The price (in dollars) of one instance of this type</param>
        public Firework (string name, double mass, decimal price)
        {
            Name = name;
            Mass = mass;
            Price = price;
        }       
        /// <summary>
        /// The unique name of this type of firework
        /// </summary>
        public string Name 
        {
            get
            {
                return _name;
            }
            set  
            {
                _name = value;
            }
        }
        /// <summary>
        /// The mass, in kilograms, of one instance of this type
        /// </summary>
        public double Mass
        {
            get 
            {
                return _mass;
            }
            set 
            { 
                _mass = value;
            }
        }
        /// <summary>
        /// The price (in dollars) of one instance of this type
        /// </summary>
        public decimal Price 
        {
            get
            {
                return _price;
            }
            set  
            {
                _price = value;
            }
        }    
        /// <summary>
        /// Provide a textual representation of this firework.
        /// </summary>
        /// <returns>The firework's name</returns>
        public override string ToString() 
        {
            return Name;
        }

        /// <summary>
        /// Return a firework of the given name. This method supports a 
        /// "Strategy" example, but it isn't really implemented.
        /// </summary>
        /// <param name="name">a name to lookup</param>
        /// <returns>a firework of the given name; not actually 
        /// implemented</returns>
        public static Firework Lookup(String name)
        {
            return new Firework();
        }
 
        /// <summary>
        /// Return a random firework from our shelves. This method is
        /// not actually implemented -- it's here as part of a "Strategy"
        /// example.
        /// </summary>
        /// <returns></returns>
        public static Firework GetRandom()
        {
            return new Firework();
        }
    }
}
