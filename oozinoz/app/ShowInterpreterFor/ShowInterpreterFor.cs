using System;
using System.Collections;
using Machines;
using RobotInterpreter2;
	/// <summary>
	/// This demo program just shows a ForCommand object in 
	/// action.
	/// </summary>
class ShowInterpreterFor
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        Variable v = new Variable("machine");
        Command c = new ForCommand(ExampleMachine.Dublin(), v, new PrintCommand(v));
        c.Execute();
    }
}