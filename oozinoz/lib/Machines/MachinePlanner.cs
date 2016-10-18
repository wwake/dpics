using System;
using Machines;
namespace Machines
{
	/// <summary>
	/// Abstract superclass for classes that plan the expected
	/// behavior of machines.
	/// </summary>
	public abstract class MachinePlanner 
	{
        protected Machine _machine;
		
        public MachinePlanner(Machine m)
		{
			_machine = m;
		}

        public abstract DateTime GetAvailable 
        {
            get;
        }
	}
}
