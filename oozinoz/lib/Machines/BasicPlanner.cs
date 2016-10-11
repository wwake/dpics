using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// A generic planner for machines that don't have a 
	/// machine-specific planner.
	/// </summary>
	public class BasicPlanner : MachinePlanner
	{
		public BasicPlanner(Machine m) : base (m)
		{
		}
        
        public override DateTime GetAvailable 
        {
            get { return DateTime.Now; }
        }
	}
}
