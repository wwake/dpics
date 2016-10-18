using System;

namespace Controllers
{
	/// <summary>
	/// A machine manager that adapts the common interface of
	/// the MachineManager class to the specific protocol of
	/// a star press controller.
	/// </summary>
	public class StarPressManager : MachineManager
	{
        private StarPressController _controller = new StarPressController();
        
        public override void StartMachine() 
        {
            _controller.Start();
        }
        
        public override void StopMachine() 
        {
            _controller.Stop();
        }
        
        public override void StartProcess() 
        {
            _controller.StartProcess();
        }
        
        public override void StopProcess() 
        {
            _controller.EndProcess();
        }
        
        public override void ConveyIn() 
        {
            _controller.Index();
        }
        
        public override void ConveyOut() 
        {
            _controller.Discharge();
        }
	}
}
