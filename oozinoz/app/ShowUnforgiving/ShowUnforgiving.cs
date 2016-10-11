using System;
using Reservations;
/// <summary>
/// This class shows a builder that throws an exception if there
/// is any problem while parsing its input.
/// </summary>
public class ShowUnforgiving 
{    
    public static void Main() 
    {
        String sample =
            "Date, November 5, Headcount, 250, "
            + "City, Springfield, DollarsPerHead, 9.95, "
            + "HasSite, False";
        ReservationBuilder b = new UnforgivingBuilder();
        new ReservationParser(b).Parse(sample);
        try 
        {
            Reservation r = b.Build();
            Console.WriteLine(r);
        } 
        catch (BuilderException e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}