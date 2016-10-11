using System;
namespace Machines
{
    /// <summary>
    /// Represent a tool cart.
    /// </summary>
    public class ToolCart : VisualizationItem
    {
        protected Engineer _responsible;

        /// <summary>
        /// Construct a tool cart, noting the engineer who
        /// is responsible for the tools on this cart.
        /// </summary>
        /// <param name="e">the responsible engineer</param>
        public ToolCart(Engineer e)
        {
            this._responsible = e;
        }
        /// <summary>
        /// The engineer who is responsible for tools in
        /// this tool's tool cart.
        /// </summary>
        public Engineer Responsible
        {
            get 
            {
                return _responsible;
            }
            set 
            {
                this._responsible = value;
            }
        }
    }
}
