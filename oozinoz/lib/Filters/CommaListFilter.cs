namespace Filters
{
    /// <summary>
    /// This filter adds comma separators between writes.
    /// </summary>
    public class CommaListFilter : OozinozFilter 
    {
        protected bool needComma = false;
        /// <summary>
        /// Construct a filter that pass random case characters
        /// to the supplied stream.
        /// </summary>
        /// <param name="writer">a stream to pass bytes to</param>
        public CommaListFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        ///  Plug a comma and a blank in front of this character if need be.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            if (needComma) 
            {
                _writer.Write(',');
                _writer.Write(' ');
            }
            _writer.Write(c);
            needComma = true;
        }
        /// <summary>
        /// Plug a comma and a blank in front of this string if need be.
        /// </summary>
        /// <param name="s">the string to write</param>
        public override void Write(string s)
        {
            if (needComma) 
            {
                _writer.Write(", ");
            }
            _writer.Write(s);
            needComma = true;
        }
    }
}
