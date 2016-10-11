using System;
namespace Filters
{
    /// <summary>
    /// This "filter" directs its characters to the console.
    /// </summary>
    public class ConsoleWriter : ISimpleWriter
    {
        public void Write(char c)
        {
            Console.Write(c);
        }       
        public void Write(string s)
        {
            Console.Write(s);
        }
        public void WriteLine()
        {
            Console.WriteLine();
        }
        public void Close()
        {
        }
    }
}
