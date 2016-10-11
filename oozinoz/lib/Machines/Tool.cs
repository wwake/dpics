using System;

namespace Machines
{
    /// <summary>
    ///  Represent a tool in an Oozinoz factory. Tools are like
    ///  machines but are less stationary. They roll around on
    ///  tool carts.
    /// </summary>
    public class Tool : VisualizationItem
    {
        protected ToolCart _toolCart;

        /// <summary>
        /// The tool cart to which this tool belongs.
        /// </summary>
        public ToolCart ToolCart            
        {
            get
            {
                return _toolCart;
            }         
            set
            {
                _toolCart = value;
            }
        }

        /// <summary>
        /// The engineer who is responsible for tools in
        /// this tool's tool cart.
        /// </summary>
        public Engineer Responsible
        {
            get
            {
                return _toolCart.Responsible;
            }
        }
        
    }
}