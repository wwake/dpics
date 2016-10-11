using System;
using System.Text;

namespace Reservations
{
    /// <summary>
    /// Objects of this class represent reservations for fireworks
    /// displays, but note that this class in not fully developed.
    /// The classes in this package show how to use builders to
    /// class is just a target for the builders in this package.
    /// </summary>
    [Serializable]
    public class Reservation 
    {
        private DateTime _date;
        private int _headcount; 
        private String _city;
        private decimal _dollarsPerHead;
        private bool _hasSite;
        /// <summary>
        /// Construct a reservation with the given parameters. The
        /// proper way to construct a reservation is with one of the
        /// builders in this package, so this method is private.
        /// </summary>
        /// <param name="date">when to put on a display</param>
        /// <param name="headcount">how many people our customer will
        /// guarantee to be in attendance</param>
        /// <param name="city">the city (or nearest city) for the display</param>
        /// <param name="dollarsPerHead">the price per attendee the
        /// customer will pay</param>
        /// <param name="hasSite">true, if the customer has a display site
        /// in mind</param>
        internal Reservation(
            DateTime date,
            int headcount,
            String city,
            decimal dollarsPerHead,
            bool hasSite)
        {
            _date = date;
            _headcount = headcount;
            _city = city;
            _dollarsPerHead = dollarsPerHead;
            _hasSite = hasSite;
        }
        /// <summary>
        /// Returns a textual description of this reservation.
        /// </summary>
        /// <returns>A textual description of this reservation</returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Date: ");
            sb.Append(_date.ToString("d"));
            sb.Append(", Headcount: ");
            sb.Append(_headcount);
            sb.Append(", City: ");
            sb.Append(_city);
            sb.Append(", Dollars/Head: ");
            sb.Append(_dollarsPerHead);
            sb.Append(", Has Site: ");
            sb.Append(_hasSite);
            return sb.ToString();
        }  
        /// <summary>
        /// The scheduled or requested date for the event.
        /// </summary>
        public DateTime Date { get { return _date;}}
        /// <summary>
        /// The number of headcount the requester will guarantee.
        /// </summary>
        public int Headcount { get { return _headcount;}}
        /// <summary>
        /// The nearest city.
        /// </summary>
        public String City { get { return _city;}}
        /// <summary>
        /// The dollars/head the person will pay.
        /// </summary>
        public decimal DollarsPerHead { get { return _dollarsPerHead;}}
        /// <summary>
        /// Indicates whether the requester has a site in mind for
        /// the event.
        /// </summary>
        public bool HasSite { get { return _hasSite;}}
    }
}
