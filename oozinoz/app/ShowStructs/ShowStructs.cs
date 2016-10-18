using System;
using System.Drawing;

/// <summary>
/// A program from "Introducing Construction" that, unfortunately, crashes.
/// </summary>
public class ShowStructs
{ 
    static void Main(string[] args)
    {
        Point[] points = new Point[1];
        DateTime[] times = new DateTime[1];
        String[] strings = new String[1];

        Console.WriteLine("Which of the following statements will cause this program to crash?");
        Console.WriteLine(points[0].ToString());
        Console.WriteLine(times[0].ToString());
        Console.WriteLine(strings[0].Length);
    }
}