using System;
using NUnit.Framework;
using Reservations;

namespace Testing
{
    /// <summary>
    /// Test that a forgiving builder builds correctly.
    /// </summary>
    [TestFixture]
    public class ForgivingBuilderTest
    {
        /// <summary>
        /// Test that we disallow a too low figure for dollars/head.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestLowDollars()
        {
            String s =
                "Date, November 5, Headcount, 250, "
                + "City, Springfield, DollarsPerHead, 1.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build();// should throw an exception
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
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build(); // should throw an exception
        }
        /// <summary>
        /// Test that we disallow a missing city.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestNoCity()
        {
            String s =
                "Date, November 5, Headcount, 250, "
                + "DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build();// should throw an exception
        }
        /// <summary>
        /// Test that we disallow a missing date.
        /// </summary>
        [ExpectedException(typeof(BuilderException))]
        public void TestNoDate()
        {
            String s =
                "Headcount, 250, "
                + "City, Springfield, DollarsPerHead, 9.95, "
                + "HasSite, false";
            ReservationBuilder b = new ForgivingBuilder();
            new ReservationParser(b).Parse(s);
            Reservation r = b.Build();// should throw an exception
        }
        /// <summary>
        /// Test that if there is a headcount but no dollars/head value, 
        /// set the dollars/head value to be high enough to generate 
        /// the minimum take.
        /// </summary>
        public void TestNoDollar() 
        {
            String s =
                "Date, November 5, Headcount, 250, City, Springfield, "
                + "  HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.AssertEquals(250, r.Headcount);
            Assertion.Assert(r.Headcount * r.DollarsPerHead >= ReservationBuilder.MINTOTAL);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals(false, r.HasSite);
        }
        /// <summary>
        /// Test that if there is no headcount but there is a dollars/head value, 
        /// set the headcount to be at least the minimum attendance and at least 
        /// enough to generate enough money for the event. 
        /// </summary>
        public void TestNoHeadcount()  
        {
            String s =
                "Date, November 5,   City, Springfield, "
                + "DollarsPerHead, 9.95, HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.Assert(r.Headcount >= ReservationBuilder.MINHEAD);
            Assertion.Assert(r.Headcount * r.DollarsPerHead >= ReservationBuilder.MINTOTAL);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals(9.95, (double)r.DollarsPerHead, .01);
            Assertion.AssertEquals(false, r.HasSite); 
        }
        /// <summary>
        /// Test that if the reservation request specifies no headcount and no 
        /// dollars/head, set the headcount to the minimum and set dollars/head 
        /// to the minimum total divided by the headcount. 
        /// </summary>
        public void TestNoHeadcountNoDollar() 
        {
            String s =
                "Date, November 5,   City, Springfield, "
                + "  HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
            ReservationParser p = new ReservationParser(b);
            p.Parse(s);
            Reservation r = b.Build();
            //
            DateTime d = new DateTime(2000, 11, 5);
            d = ReservationBuilder.Futurize(d);
            //
            Assertion.AssertEquals(d, r.Date);
            Assertion.AssertEquals(ReservationBuilder.MINHEAD, r.Headcount);
            Assertion.AssertEquals("Springfield", r.City);
            Assertion.AssertEquals((double)(ReservationBuilder.MINTOTAL/r.Headcount), (double)r.DollarsPerHead, .01);
            Assertion.AssertEquals(false, r.HasSite);
        }
        /// <summary>
        /// Test a normal reservation.
        /// </summary>
        public void TestNormal() 
        {
            String s =
                "Date, November 5, Headcount, 250, City, Springfield, "
                + "DollarsPerHead, 9.95, HasSite, false";
            ForgivingBuilder b = new ForgivingBuilder();
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
    }
}
