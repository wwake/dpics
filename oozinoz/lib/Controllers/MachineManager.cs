using System;

namespace Controllers
{
	/// <summary>
	/// An example for the Bridge chapter. This is an abstract
	/// class and an example of an abstraction--a class with 
	/// concrete methods that rely on other, abstract methods.
	/// </summary>
	public abstract class MachineManager
    {
        public abstract void StartMachine();
        public abstract void StopMachine();
        public abstract void StartProcess();
        public abstract void StopProcess();
        public abstract void ConveyIn();
        public abstract void ConveyOut();

        public void Shutdown() 
        {
            StopProcess();
            ConveyOut();
            StopMachine();
        }
	}
}
