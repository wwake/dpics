using System;
using System.Collections;
using Fireworks;
/// <summary>
/// From "Template Method" -- show the use of a comparator in sorting
/// a collection (of rockets).
/// </summary>
public class ShowComparator  
{
	/// <summary>
	/// The main entry point to the application.
	/// </summary>
    public static void Main()
    {
        Rocket r1 = new Rocket("Mach-it",  1.1, 22.95m, 1000, 70);
        Rocket r2 = new Rocket("Pocket",   0.3,  4.95m,  150, 20);
        Rocket r3 = new Rocket("Sock-it",  0.8, 11.95m,  320, 25);
        Rocket r4 = new Rocket("Sprocket", 1.5, 22.95m,  270, 40);
        Rocket[] rockets = new Rocket[] { r1, r2, r3, r4 };
        Array.Sort(rockets, new ApogeeCompare());        
        foreach (Rocket r in rockets)
        {
            Console.WriteLine(r);
        }
    }
    private class ApogeeCompare : IComparer 
    {
        public int Compare(Object o1, Object o2)
        {
            Rocket r1 = (Rocket)o1;
            Rocket r2 = (Rocket)o2;
            return r1.Apogee.CompareTo(r2.Apogee);
        }
    }     
}

   