using System;
namespace Reservations
{
    /// <summary>
    /// This class builds a valid reservation from its attributes.
    /// The <code>build</code> method throws an exception if asked 
    /// to build in advance of having valid parameters for a
    /// reservation.
    /// </summary>
    public class UnforgivingBuilder : ReservationBuilder 
    {
        /// <summary>
        /// Create a valid reservation. Throw an exception if any
        /// required attribute of a reservation is missing.
        /// </summary>
        public override Reservation Build() 
        {
            if (_date == DateTime.MinValue) 
            {
                throw new BuilderException("Valid date not found");
            }
            if (_city == null) 
            {
                throw new BuilderException("Valid city not found");
            }
            if (_headcount < MINHEAD) 
            {
                throw new BuilderException(
                    "Minimum headcount is " + MINHEAD); 
            }
            if (_dollarsPerHead * _headcount < MINTOTAL) 
            {
                throw new BuilderException(
                    "Minimum total cost is " + MINTOTAL); 
            }
            return new Reservation(
                _date, 
                _headcount, 
                _city, 
                _dollarsPerHead, 
                _hasSite); 
        }
    }
}
