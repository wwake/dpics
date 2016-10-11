using System;
using NUnit.Framework;
using Machines;

namespace Testing
{
    /// <summary>
    /// Test the MachineComponent hierarchy, especially its ability
    /// to tell whether or not an object model is cyclic.
    /// </summary>
    [TestFixture]
    public class MachineTest 
    {
        /// <summary>
        /// Creates and returns a normal little tree with 3 leaves.
        /// </summary>
        /// <returns>A 3-leaf tree</returns>
        /*
         *   123
         *  /   \
         * 1     23
         *      /  \
         *     2    3
         */
         public static MachineComposite Tree()
        {
            Machine m1 = new Machine(1);
            Machine m2 = new Machine(2);
            Machine m3 = new Machine(3);
            MachineComposite m23 = new MachineComposite(23);
            m23.Add(m2);
            m23.Add(m3);
            MachineComposite m123 = new MachineComposite(123);
            m123.Add(m1);
            m123.Add(m23);
            return m123;
        }
        /// <summary>
        /// Return a tiny process flow that shows a composite that is
        /// not a tree. In this flow m1 contains m2, m2 contains m3,
        /// and m3 contains m1.
        /// </summary>
        /// <returns>Return a machine cycle m1->m2->m3->m1</returns>
        public static MachineComponent Cycle()
        {
            MachineComposite m1 = new MachineComposite(1);
            MachineComposite m2 = new MachineComposite(2);
            MachineComposite m3 = new MachineComposite(3);
            m1.Add(m2);
            m2.Add(m3);
            m3.Add(m1);
            return m1;
        }

        /// <summary>
        /// Return a tiny machine composite that shows a composite that is 
        /// not a tree. In this composite m1 contains m2 and m3, m2 contains m3.
        /// </summary>
        /// <returns>An acyclic non-tree m1->m2, m3; m3-> m2</returns>
       /*
        * m1
        * |\
        * | m3
        * |/
        * m2
        */
        public static MachineComponent NonTree()
        {
            MachineComposite m1 = new MachineComposite(1);
            MachineComposite m3 = new MachineComposite(3);
            Machine m2 = new Fuser(2);
            m1.Add(m2);
            m1.Add(m3);
            m3.Add(m2);
            return m1;
        }
        /// <summary>
        /// Test that we can count leaves.
        /// </summary>
        public void TestCount() 
        {
            Assertion.AssertEquals(3, Tree().GetMachineCount());
        }
        /// <summary>
        /// Test that a cycle is not a tree.
        /// </summary>
        public void TestCycle()
        {
            Assertion.Assert(!Cycle().IsTree());
            Assertion.Assert(!NonTree().IsTree());
            Assertion.Assert(Tree().IsTree());
            Assertion.Assert(!ExampleMachine.Plant().IsTree());
        }
        /// <summary>
        /// Test that a machine is a tree.
        /// </summary>
        public void TestOne()
        {
            Assertion.Assert(new Fuser(1).IsTree());
        }
    }
}
