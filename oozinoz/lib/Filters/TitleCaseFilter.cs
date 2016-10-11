using System;
namespace Filters
{
    /// <summary>
    /// This filter makes characters that pass through it title case
    /// (meaning that characters after whitespace are in upper case.)
    /// </summary>
    public class TitleCaseFilter : OozinozFilter 
    {
        protected bool inWhite = true;
        /// <summary>
        /// Construct a filter that pass title case characters
        /// to the supplied writer.
        /// </summary>
        /// <param name="writer">a writer to pass bytes to</param>
        public TitleCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Pass a title case version of the supplied character
        /// to the underlying stream.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            _writer.Write(inWhite
                ? Char.ToUpper(c)
                : Char.ToLower(c));
            inWhite = Char.IsWhiteSpace(c) || c == '\"';
        }
        /// <summary>
        /// Override this method just to note that it causes a return to
        /// whitespace.
        /// </summary>
        public override void WriteLine()
        {
            base.WriteLine();
            inWhite = true;
        }
    }
}
