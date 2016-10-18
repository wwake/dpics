using System;

namespace ShowNew
{
    /// <summary>
    /// A class of rockets whose thrust is always 1.
    /// </summary>
    public class DemoRocket 
    {
        public double Thrust() { return 1; }         
    } 

    /// <summary>
    /// A subclass of DemoRocket -- these object always have a thrust of 2.
    /// </summary>
    public class DemoShell : DemoRocket 
    {
        /// <summary>
        /// Note the use of "new" in this method's declaration. Does this
        /// method override the superclass Thrust() method?
        /// </summary>
        /// <returns>2</returns>
        public new double Thrust() { return 2; }
    } 
    
    /// <summary>
    /// The straightman in this demo, this class just supplies a method
    /// that prints out a rocket's thrust.
    /// </summary>
    public class DemoEvent 
    {
        public void Add(DemoRocket r) 
        {
            Console.WriteLine(
                "Adding rocket with thrust " + r.Thrust());
        }
    }
    
    /// <summary>
    /// This class instantiates a DemoShell and sends it to the Add()
    /// method of a DemoEvent object. The Add() method is expected a DemoRocket
    /// object, but that's Ok: DemoShell is a subclass of DemoRocket. 
    /// 
    /// Challenge: What does this program print out?
    /// </summary>
    public class ShowNewModifier 
    {
        public static void Main() 
        {  
            DemoEvent e = new DemoEvent();
            e.Add(new DemoShell());
        }
    }
}
