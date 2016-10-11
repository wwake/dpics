using System.IO;
namespace Filters
{
	/// <summary>
	/// This class provides a version StreamWriter that implements ISimpleWriter. Instances
	/// of this class can be used in constructors for subclasses of OozinozFilter.
	/// SimpleStreamWriter inherits (from the StreamWriter class) the Write() methods that the
	/// ISimpleWriter interface requires.
	/// </summary>
	public class SimpleStreamWriter : StreamWriter, ISimpleWriter
	{
        /// <summary>
        /// This constructor allows creating a SimpleStreamWriter object from any
        /// sort of stream.
        /// </summary>
        /// <param name="s">the base stream to pass writes to</param>
        public SimpleStreamWriter(Stream s) : base (s) 
        {
        }
        /// <summary>
        /// This constructor is for convenience; the superclass will create a
        /// FileStream object from the provided path.
        /// </summary>
        /// <param name="path">the name of a file to write to</param>
        public SimpleStreamWriter(string path) : base (path)
        {
        }
	}
}
