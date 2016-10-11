namespace Machines
{
	/// <summary>
	/// Define the operations that a visitor class for the MachineComponent
	/// class must implement.
	/// </summary>
	public interface IMachineVisitor
    {
        void Visit(Machine m);
        void Visit(MachineComposite c);
	}
}
