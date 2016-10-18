namespace Machines
{
    /// <summary>
    /// This class provides object models of a few of Oozinoz's
    /// factories, in terms of the factories' machines.
    /// </summary>
    public class ExampleMachine 
    {
        /// <summary>
        /// Return a plant (a factory) that is not a tree.
        /// </summary>
        /// <returns>a plant (a factory) that is not a tree</returns>
        public static MachineComposite Plant()
        {
            MachineComposite plant = new MachineComposite(100);
            MachineComposite bay = new MachineComposite(101);
            Machine m = new Mixer(102);
            Machine n = new StarPress(103);
            Machine o = new ShellAssembler(104);
            bay.Add(m);
            bay.Add(n);
            bay.Add(o);
            plant.Add(m);
            plant.Add(bay);
            return plant;
        }

        /// <summary>
        /// Return a sample manufacturing line.
        /// </summary>
        /// <returns>a sample manufacturing line</returns>
        public static MachineComposite DublinLine1()
        {
            MachineComposite c = new MachineComposite(1000, "Line 1"); 
            c.Add(new Mixer(1201));
            c.Add(new StarPress(1401));
            c.Add(new ShellAssembler(1301));
            c.Add(new Fuser(1101));
            c.Add(new UnloadBuffer(1501));
            return c;
        }
        /// <summary>
        /// Return a second sample manufacturing line.
        /// </summary>
        /// <returns>a sample manufacturing line</returns>
        public static MachineComposite DublinLine2()
        {
            MachineComposite c = new MachineComposite(2000, "Line 2"); 
            c.Add(new Mixer(2201));
            c.Add(new Mixer(2202));
            c.Add(new StarPress(2401));
            c.Add(new StarPress(2402));
            c.Add(new ShellAssembler(2301));
            c.Add(new Fuser(2101));
            c.Add(new UnloadBuffer(2501));
            return c;
        }
        /// <summary>
        /// Return a third sample manufacturing line.
        /// </summary>
        /// <returns>a sample manufacturing line</returns>
        public static MachineComposite DublinLine3()
        {
            MachineComposite c = new MachineComposite(3000, "Line 3"); 
            c.Add(new Mixer(3201));
            c.Add(new Mixer(3202));
            c.Add(new Mixer(3203));
            c.Add(new Mixer(3204));
            c.Add(new StarPress(3401));
            c.Add(new StarPress(3402));
            c.Add(new StarPress(3403));
            c.Add(new StarPress(3404));
            c.Add(new ShellAssembler(3301));
            c.Add(new ShellAssembler(3302));
            c.Add(new Fuser(3101));
            c.Add(new Fuser(3102));
            c.Add(new UnloadBuffer(3501));
            return c;
        }
        /// <summary>
        /// Return a model of the machines in our Dublin facility.
        /// </summary>
        /// <returns>a model of the machines in our Dublin facility</returns>
        public static MachineComposite Dublin()
        {
            MachineComposite c = new MachineComposite(0, "Factory Dublin"); 
            c.Add(DublinLine1());
            c.Add(DublinLine2());
            c.Add(DublinLine3());
            return c;
        }
    }
}
