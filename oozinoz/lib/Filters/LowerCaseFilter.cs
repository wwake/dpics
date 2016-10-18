namespace Filters
{
    /// <summary>
    /// This filter makes characters that pass through it lower case.
    /// </summary>
    public class LowerCaseFilter : OozinozFilter 
    {
        /// <summary>
        /// Construct a filter that pass lower case characters
        /// to the supplied stream.
        /// </summary>
        /// <param name="writer">another writer to pass bytes to</param>
        public LowerCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Pass a lower case version of the supplied character
        /// to the underlying stream.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            _writer.Write(char.ToLower(c));
        }
    }
}
