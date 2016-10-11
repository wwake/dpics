using System;

namespace Reservations
{
    /// <summary>
    /// Signals a problem while building a reservation from its
    /// attributes.
    /// </summary>
    public class BuilderException : Exception 
    {                                
        /// <summary>
        ///   Constructs a BuilderException with no detail
        ///   message.
        /// </summary>
        public BuilderException() : base()
        {
        }
        /// <summary>
        /// Constructs a BuilderException with the 
        /// specified detail message. 
        /// </summary>
        /// <param name="s">detail message</param>
        public BuilderException(String s) : base(s)
        {
        }
    }
}
