using System;

/// <summary>
/// Show the use of a web service -- from the "Proxy" chapter.
/// 
/// NOTE by Bill Wake, Oct 16, 2016: This code will currently generate 
/// an InvalidOperationException unless you can figure out how to get Web Services running
/// in this older style. The code is left here for study purposes. 
/// 
/// </summary>
class ShowClient
{
    static void Main()
    {
        Rocket r = new DataWebService().RocketHome("jsquirrel");
        Console.WriteLine(
            "Rocket {0}, Thrust: {1} Price: {2:C}", 
            r.Name, r.Thrust, r.Price);
    }
}