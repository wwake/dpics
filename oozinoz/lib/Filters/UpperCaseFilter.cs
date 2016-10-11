using System;
namespace Filters
{
    /// <summary>
    /// This filter makes characters that pass through it upper case.
    /// </summary>
    public class UpperCaseFilter : OozinozFilter 
    {
        /// <summary>
        /// Construct a filter that pass upper case characters
        /// to the supplied stream.
        /// </summary>
        /// <param name="writer">a stream to pass bytes to</param>
        public UpperCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Pass an upper case version of the supplied character
        /// to the underlying stream.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            _writer.Write(Char.ToUpper(c));
        }
    }
}
