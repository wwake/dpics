using System;
using System.Text.RegularExpressions;

namespace Reservations
{
    /// <summary>
    /// This class parses a request for a fireworks exhibition.
    /// The request must be a comma-separated list of parameter
    /// names and values. The expected parameters for an
    /// exhibition are: date, heacount, city, dollarsPerHead,
    /// and hasSite. For example, a valid request is:
    /// 
    /// <blockquote><pre>
    ///   Date, November 5, Headcount, 250, City, Springfield,
    ///   DollarsPerHead, 9.95, HasSite, No      	   
    ///</pre></blockquote>
    ///
    /// The format for dates is the name of the month followed by
    /// the day. This parser assumes the year for the date is the
    /// year in which the date next occurs.
    /// </summary>
    public class ReservationParser 
    {
        private ReservationBuilder _builder;

        /// <summary>
        /// Parse a reservation request, passing its information to
        /// the builder.
        /// </summary>
        /// <param name="s">the request</param>
        public void Parse(String s)
        {         
            string[] tokens = new Regex(@",\s*").Split(s);
            for (int i = 0; i < tokens.Length; i += 2 ) 
            {
                String type = tokens[i];
                String val = tokens[i + 1];

                if (String.Compare("date", type, true) == 0)
                { 
                    DateTime d = DateTime.Parse(val);
                    _builder.Date = ReservationBuilder.Futurize(d);
                }
                else if (String.Compare("headcount", type, true) == 0)
                {
                    _builder.Headcount = Int32.Parse(val);
                }
                else if (String.Compare("City", type, true) == 0)
                {
                    _builder.City = val.Trim();
                }
                else if (String.Compare("DollarsPerHead", type, true) == 0)
                {
                    _builder.DollarsPerHead = (decimal)Double.Parse(val);
                }
                else if (String.Compare("HasSite", type, true) == 0)
                {
                    _builder.HasSite = Boolean.Parse(val);
                     
                } 
            }
        }

        /// <summary>
        /// Create a parser that will pass its results to the specified
        /// builder.
        /// </summary>
        /// <param name="builder">the builder to pass parameters to</param>
        public ReservationParser(ReservationBuilder builder) 
        {
            _builder = builder;
        }
    }
}
