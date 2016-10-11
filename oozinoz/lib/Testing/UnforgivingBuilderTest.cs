using System;
using NUnit.Framework;
using Reservations;

namespace Testing
{
    /// <summary>
    /// Test UnforgivingBuilder.
    /// </summary>
    [TestFixture]
    public class UnforgivingBuilderTest
    {
        /// <summary>
        /// Test that we disallow a too low figure for dollars/head.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestLowDollars()
        {
            String sample =
                "Date, November 5, Headcount, 250, "
                + "City, Springfield, DollarsPerHead, 1.95, "
                + "HasSite, false";
            ReservationBuilder b = new UnforgivingBuilder();
            new ReservationParser(b).Parse(sample);
            Reservation r = b.Build(); // throws BuilderException
        }
        /// <summary>
        /// Test that we disallow a too low figure for headcount.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestLowHeadCount()
        {
            String s =
                "Date, November 5, Headcount, 2, "
                + "City, Springfield, DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new UnforgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build(); // throws BuilderException
          
        }
        /// <summary>
        /// Test that we disallow missing dollars.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestNoDollars()
        {
            String sample =
                "Date, November 5, Headcount, 250, "
                + "City, Springfield, "
                + "HasSite, false";
            ReservationBuilder b = new UnforgivingBuilder();
            new ReservationParser(b).Parse(sample);
            Reservation r = b.Build(); // throws BuilderException
        }
        /// <summary>
        /// Test that we disallow missing headcount.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestNoHeadCount()
        {
            String s =
                "Date, November 5, "
                + "City, Springfield, DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new UnforgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build(); // throws BuilderException
        }
        /// <summary>
        /// Test a normal reservation.
        /// </summary>
        public void TestNormal() 
        {
            String s =
                "Date, November 5, Headcount, 250, City, Springfield, "
                + "DollarsPerHead, 9.95, HasSite, false";
            UnforgivingBuilder b = new UnforgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.AssertEquals(250, r.Headcount);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals(9.95, (double)r.DollarsPerHead, .01);
            Assertion.AssertEquals(false, r.HasSite);
        }
        /// <summary>
        /// Test that we disallow missing city.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestUnforgivingNoCity()
        {
            String s =
                "Date, November 5, Headcount, 250, "
                + "DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new UnforgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build(); // should throw
        }
        /// <summary>
        /// Test that we disallow missing date.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestUnforgivingNoDate()
        {
            String s =
                "Headcount, 250, "
                + "City, Springfield, DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new UnforgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build(); // throws BuilderException

        }
    }
}
