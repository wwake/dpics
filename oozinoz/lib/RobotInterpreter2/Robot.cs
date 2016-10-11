using System;
using Machines;
namespace RobotInterpreter2
{
    /// <summary>
    /// This class models a track robot that slides along a track
    /// (a rail) and picks and places bins of material from
    /// processing machines.
    /// </summary>
    public class Robot 
    {
        public static readonly Robot singleton = new Robot();
        private Robot()
        {
        }

        /// <summary>
        /// Move to a machine, pick up a bin, move to another machine,
        /// and place the bin.
        /// </summary>
        /// <param name="m1">the "from" machine</param>
        /// <param name="m2">the "to" machine</param>
        public void Carry(Machine m1, Machine m2)
        {
            Console.WriteLine("Robot carrying from " + m1 + " to " + m2);
            Bin b = m1.Unload();
            if (b != null) 
            {
                m2.Load(b);
            }
        }
    }
}
