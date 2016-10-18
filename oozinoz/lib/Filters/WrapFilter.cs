using System;
using System.Text;
namespace Filters
{
    /// <summary>
    /// A WrapFilter object compresses whitespace and wraps 
    /// text at a specified width, optionally centering it. 
    /// </summary>
    public class WrapFilter : OozinozFilter 
    {
        protected int _width;
        protected StringBuilder lineBuf = new StringBuilder();
        protected StringBuilder wordBuf = new StringBuilder();
        protected bool _center = false;
        protected bool _inWhite = false;
        protected bool _needBlank = false;

        /// <summary>
        /// Construct a filter that will wrap its writes at the
        /// specified width.
        /// </summary>
        /// <param name="writer">a subordinate filter</param>
        /// <param name="width">where to wrap</param>
        public WrapFilter(ISimpleWriter writer, int width) : base (writer)
        {
            this._width = width;
        }

        /// <summary>
        /// Determines whether or not to center the output.
        /// </summary>
        public bool Center
        {
            get 
            {
                return _center;
            }
            set
            {
                _center = value;
            }
        }

        /// <summary>
        /// Flush and close the stream.
        /// </summary>
        public override void Close() 
        {
            Flush();
            base.Close();
        }

        /// <summary>
        /// Write out any characters that were being held, awaiting a full line.
        /// </summary>
        public void Flush()
        {
            if (wordBuf.Length > 0)
            {
                PostWord();
            }
            if (lineBuf.Length > 0)
            {
                PostLine();
            }
        }

        /// <summary>
        /// Write out the characters in the line buffer, optionally centering 
        /// this output.
        /// </summary>
        protected void PostLine()  
        {
            if (Center)
            {
                for (int i = 0; i < (_width - lineBuf.Length) / 2; i++)
                {
                    _writer.Write(' ');
                }
            }
            _writer.Write(lineBuf.ToString());
            _writer.WriteLine();
        }

        /// <summary>
        /// Add the word buffer to the line buffer, unless this
        /// would make the line buffer too long. In that case, 
        /// post the line buffer and then reset the line buffer 
        /// to the word buffer. 
        /// </summary>
        protected void PostWord()  
        {
            if (lineBuf.Length + 1 + wordBuf.Length > _width && (lineBuf.Length > 0))
            {
                PostLine();
                lineBuf = wordBuf;
                wordBuf = new StringBuilder();
            }
            else
            {
                if (_needBlank)
                {
                    lineBuf.Append(" ");
                }
                lineBuf.Append(wordBuf);
                _needBlank = true;
                wordBuf = new StringBuilder();
            }
        }

        /// <summary>
        /// Add the given character to the current word buffer, 
        /// unless the character is whitespace. Whitespace marks 
        /// the end of words. On seeing end of a word, "post" it.
        /// </summary>
        /// <param name="c">the character to write</param>
        public override void Write(char c)  
        {
            if (Char.IsWhiteSpace(c))
            {
                if (!_inWhite)
                {
                    PostWord();
                }
                _inWhite = true;
            }
            else
            {
                wordBuf.Append(c);
                _inWhite = false;
            }
        }
    }
}
