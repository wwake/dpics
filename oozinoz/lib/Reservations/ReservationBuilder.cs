using System;

namespace Reservations
{
    /// <summary>
    /// Subclasses of this abstract class validate a reservation's
    /// attributes before constructing a Reservation object.
    /// </summary>
    public abstract class ReservationBuilder      
    {
        public static readonly int MINHEAD = 25;
        public static readonly decimal MINTOTAL = 495.95M;

        protected DateTime _date = DateTime.MinValue;
        protected String _city;
        protected int _headcount;
        protected decimal _dollarsPerHead;
        protected bool _hasSite;

        /// <summary>
        /// Push a date into the future by rolling forward the year.
        /// </summary>
        /// <param name="inDate">a date to push forward</param>
        /// <returns>a date like the one provided but with a year
        /// that makes the date in the future</returns>
        public static DateTime Futurize(DateTime inDate)
        {
            DateTime outDate = inDate;
            while (outDate.CompareTo(DateTime.Now) < 0)
            {
                outDate = outDate.AddYears(1);
            }
            return outDate;
        }
        /// <summary>
        /// Construct a valid reservation from attributes that have
        /// been presumably been set for this builder. Subclasses may
        /// throw an exception if a valid reservation cannot
        /// be formed.
        /// </summary>
        /// <returns>a valid reservation</returns>
        public abstract Reservation Build();

        /// <summary>
        /// The city for a reservation
        /// </summary>
        public String City
        {
            get { return _city; }
            set { _city = value;}
        }
        /// <summary>
        /// The date for a reservation.
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value;}
        }
        /// <summary>
        /// The dollars/head that a customer will pay for a display.
        /// </summary>
        public decimal DollarsPerHead
        {
            get { return _dollarsPerHead; }
            set { _dollarsPerHead = value;}
        }
        /// <summary>
        /// Indicates whether a customer has a site in mind for a
        /// display.
        /// </summary>
        public bool HasSite
        {
            get { return _hasSite; }
            set { _hasSite = value;}
        }
        /// <summary>
        /// The number of people that a customer will guarantee for 
        /// a display.
        /// </summary>
        public int Headcount
        {
            get { return _headcount; }
            set { _headcount = value;}
        }
    }
}
