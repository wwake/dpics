using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// A planner for estimating when a shell assembler will
	/// become available.
	/// </summary>
	public class StarPressPlanner : MachinePlanner
	{
		public StarPressPlanner(Machine m) : base (m)
		{
		}
        /// <summary>
        /// Say when this planner's machine will be available; this
        /// method is not yet actually implemented.
        /// </summary>    
        public override DateTime GetAvailable 
        {
            get { return DateTime.Now; }
        }
	}
}
