using System;
namespace Filters
{
    /// <summary>
    /// This class provides the basic idea of passing Write() calls to an inner filter. This
    /// class requires another filter in its constructor. This class also implements the
    /// required (by ISimpleWriter) Write(string) method. However, this class leaves Write(char) 
    /// abstract -– it is the critical method that subclasses implement in interesting ways.
    /// </summary>
    public abstract class OozinozFilter : ISimpleWriter 
    {
        protected ISimpleWriter _writer;

        /// <summary>
        /// Construct a filter that passes characters
        /// to the supplied stream.
        /// </summary>
        /// <param name="writer">a writer to pass bytes to</param>
        public OozinozFilter(ISimpleWriter writer) 
        {
            _writer = writer;
        }  
        /// <summary>
        /// Pass this request to the subordinate stream.
        /// </summary>
        public abstract void Write(char c);

        /// <summary>
        /// Write an entire string, passing it to the subordinate stream.
        /// </summary>
        /// <param name="s">the string to write</param>
        public virtual void Write(string s)
        {
            foreach(char c in s.ToCharArray())
            {
                Write(c);
            }
        }
        /// <summary>
        /// Put a good ol' carriage return out there.
        /// </summary>
        public virtual void WriteLine()
        {
            _writer.WriteLine();
        }
        /// <summary>
        /// Close the inner filter.
        /// </summary>
        public virtual void Close()
        {
            _writer.Close();
        }
    }
}
