using System;
namespace Filters
{
    /// <summary>
    /// This filter makes characters that pass through it random case.
    /// </summary>
    public class RandomCaseFilter : OozinozFilter 
    {
        protected Random ran = new Random();
        /// <summary>
        /// Construct a filter that pass random case characters
        /// to the supplied stream.
        /// </summary>
        /// <param name="writer">a stream to pass bytes to</param>
        public RandomCaseFilter(ISimpleWriter writer) : base (writer)
        {
        }  
        
        /// <summary>
        /// Pass a lower case version of the supplied character
        /// to the underlying stream.
        /// </summary>
        /// <param name="c">the character</param>
        public override void Write(char c) 
        {
            _writer.Write(ran.NextDouble() > .5
                ? Char.ToLower(c)
                : Char.ToUpper(c));
        }
    }
}
