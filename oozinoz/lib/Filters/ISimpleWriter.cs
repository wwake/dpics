namespace Filters
{
    /// <summary>
    /// This interface defines the methods that Oozinoz filters must support.
    /// </summary>
    public interface ISimpleWriter
    {
        void Write(char c);
        void Write(string s);
        void WriteLine();
        void Close();
    }
}
