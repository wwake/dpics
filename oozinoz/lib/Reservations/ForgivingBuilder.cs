using System;

namespace Reservations
{
    /// <summary>
    /// This class builds a valid reservation from its attributes,
    /// and fills in values where it can if the attributes are not
    /// set. This builder must receive a city and a date, but it
    /// will set reasonable values for the other reservation values.
    /// </summary>
    public class ForgivingBuilder : ReservationBuilder 
    {
        public override Reservation Build()  
        {
            bool noHeadcount = (_headcount == 0);
            bool noDollarsPerHead = (_dollarsPerHead == 0M);
            //
            if (noHeadcount && noDollarsPerHead)
            {
                _headcount = MINHEAD;
                _dollarsPerHead = MINTOTAL / _headcount;
            }
            else if (noHeadcount)
            {
                _headcount = (int) Math.Ceiling((double)(MINTOTAL / _dollarsPerHead));
                _headcount = Math.Max(_headcount, MINHEAD);
            }
            else if (noDollarsPerHead)
            {
                _dollarsPerHead = MINTOTAL / _headcount;
            }
            //
            Check();
            return new Reservation(
                _date,
                _headcount,
                _city,
                _dollarsPerHead,
                _hasSite);
        }

        protected void Check() 
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
        }
    }
}