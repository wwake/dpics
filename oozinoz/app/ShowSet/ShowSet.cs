using System;
using Utilities;
/// <summary>
/// Just a little demo that shows that a set contains only 
/// different (unequal) elements.
/// </summary>
public class ShowSet
{
    public static void Main()
    {
        Set set = new Set();
        set.Add("Shooter");
        set.Add("Orbit");
        set.Add("Shooter");
        set.Add("Biggie");
        foreach (string s in set)
        {
            Console.WriteLine(s);
        }
    }
}