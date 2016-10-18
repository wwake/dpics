using System;

namespace Machines
{ 
    /// <summary>
    /// A tub is a standard, rubber container that contains 
    /// about four liters of a chemical. This class is a minimal
    /// model that helps show how to manage a one-to-many
    /// relation in an object model.
    /// </summary>
    public class Tub 
    {
        private String _id;
        private TubMediator _mediator = TubMediator.SINGLETON;

        /// <summary>
        /// Create a tub with the given id and managed by the given
        /// mediator.
        /// </summary>
        /// <param name="id">the identity of this tub</param>
        ///  relations</param>
        public Tub(String id)
        {
            _id = id;
        }

        /// <summary>
        /// Use a mediator to control getting and setting the location
        /// of this tub. This prevents a tub from ever being modeled as
        /// being on two machines at once.
        /// </summary>
        public Machine Location
        {
            get
            {
                return _mediator.GetMachine(this);
            }
            set
            {
                _mediator.Set(this, value);
            }
        }

        /// <summary>
        /// Return a textual representation of this tub.
        /// </summary>
        /// <returns>a textual representation of this tub</returns>
        public override String ToString()
        {
            return _id;
        }

        /// <summary>
        /// Return a unique id for this tub.
        /// </summary>
        /// <returns>a unique id for this tub</returns>
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        /// <summary>
        /// Return true if, according to business rules, this
        /// component and the supplied object refer to the same
        /// thing.
        /// </summary>
        /// <param name="o">The candidate to compare to</param>
        /// <returns>true, if this object and the supplied object represent
        /// the same machine</returns>
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (!(o is Tub))
            {
                return false;
            }                                                    
            Tub t = (Tub) o;
            return _id.Equals(t._id);
        }
    }
}
