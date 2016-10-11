using System;
using System.IO;

/// <summary>
/// Just showing that the idea of composing streams from streams
/// occurs in the .NET FCL.
/// </summary>
public class ShowDecorator
{
    public static void Main()
    {
        FileStream fs = new FileStream("sample.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("a small amount of sample text");
        sw.Close();
    }
}