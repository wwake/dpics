using System;
using System.IO;
//using System.Xml;
using System.Xml.Serialization;
using Fireworks;
using Utilities;
 
namespace Recommendations
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer 
    {
        private Advisor _advisor;
        public static readonly int BIG_SPENDER_DOLLARS = 1000;

        /// <summary>
        /// Return true if this customer has registered (or entered)
        /// his or her preference profile.
        /// </summary>
        /// <returns>true if this customer has registered (or entered)
        /// his or her preference profile. This method is not
        /// actually implemented.</returns>
        public bool IsRegistered()
        {
            return false;
        }

        /// <summary>
        /// I just used this to ensure I was actually finding the 
        /// properties file that lists a strategic promotion. If you 
        /// set your classpath to include the "oozinoz" directory that 
        /// you can download from oozinoz.com, this program will find 
        /// the strategy.dat file that lists a promoted firework. In 
        /// short it's an example of finding and reading from a 
        /// properties file.
        /// </summary>
        public static void Main() 
        {
            new Customer().GetRecommended();
        }

        /// <summary>
        /// Return the amount of dough this customer has spent with
        /// us since the provided date.
        /// </summary>
        /// <param name="date">Since when?</param>
        /// <returns>the amount of dough this customer has spent with
        /// us since the provided date; not actually implemented.
        /// </returns>
        public double SpendingSince(DateTime date)
        {
            return 1000;
        }

        private Advisor GetAdvisor()
        {
            if (_advisor == null)
            {
                if (PromotionAdvisor.singleton.HasItem())
                {
                    _advisor = PromotionAdvisor.singleton;
                }
                else if (IsRegistered())
                {
                    _advisor = GroupAdvisor.singleton;
                }
                else if (IsBigSpender())
                {
                    _advisor = ItemAdvisor.singleton;
                }
                else
                {
                    _advisor = RandomAdvisor.singleton;
                }
            }
            return _advisor;
        }

        /// <summary>
        /// Return a firework to recommend to this customer.
        /// </summary>
        /// <returns>a firework to recommend to this customer</returns>
        public Firework GetRecommended()
        {
            // if we're promoting a particular firework, return it
            try
            {
                String s = FileFinder.GetFileName("config", "strategy.xml");
                StreamReader r = new StreamReader(s);
                XmlSerializer xs = new XmlSerializer(typeof(String));
                String promotedName = (String) xs.Deserialize(r);
                r.Close();

                Firework f = Firework.Lookup(promotedName);
                if (f != null)
                {
                    return f;
                }
            }
            catch {}

            // if registered, compare to other customers
            if (IsRegistered())
            {
                return (Firework) Rel8.Advise(this);
            }
            // check spending over the last year
            if (SpendingSince(DateTime.Now.AddYears(-1)) > 1000)
            {
                return (Firework) LikeMyStuff.Suggest(this);
            }
            // oh well!
            return Firework.GetRandom();
        }

        /// <summary>
        /// Return a firework to recommend to this customer.
        /// </summary>
        /// <returns>a firework to recommend to this customer. This
        /// method is refactored to employ the Strategy
        /// pattern.</returns>
        public Firework GetRecommended_2()
        {
            return GetAdvisor().Recommend(this);
        }

        private bool IsBigSpender()
        {
            return SpendingSince(DateTime.Now.AddYears(-1)) > BIG_SPENDER_DOLLARS;
        }
    }
}
