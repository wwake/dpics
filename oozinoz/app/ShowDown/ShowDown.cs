using Machines;
using RobotInterpreter2;

/// <summary>
/// Show the construction and use of a (tiny) interpreter that shuts
/// down all the machines at a particular plant.
/// </summary>
class ShowDown
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        MachineComposite dublin = ExampleMachine.Dublin();
        Variable v = new Variable("machine");
        Command c = new ForCommand(dublin, v, new ShutDownCommand(v));
        c.Execute();
    }
}