using Processes;
using NUnit.Framework;

namespace Testing
{
    /// <summary>
    /// Test the ProcessComponent hierarchy, especially its ability
    /// to model cyclic processes.
    /// </summary>
    [TestFixture]
    public class ProcessTest
    {
        /*
         * a
         * |\
         * | b
         * |/
         * c
         */
        /// <summary>
        /// Return a tiny process flow that shows a composite that is
        /// not a tree (but also not a cycle, by the way). In this flow 
        /// A contains C and B, B contains C.
        /// </summary>
        /// <returns></returns>
        public static ProcessComponent Abc()
        {
            ProcessSequence a = new ProcessSequence("a");
            ProcessSequence b = new ProcessSequence("b");
            ProcessStep c = new ProcessStep("c");
            a.Add(c);
            a.Add(b);
            b.Add(c);
            return a;
        }
     
        /// <summary>
        /// Return a tiny process flow that shows a composite that is
        /// not a tree. In this flow A contains B, B contains C,
        /// and C contains A.
        /// </summary>
        /// <returns>a tiny process flow that shows a composite that is
        /// not a tree.
        /// </returns>
        public static ProcessComponent Cycle()
        {
            ProcessSequence a = new ProcessSequence("a");
            ProcessSequence b = new ProcessSequence("b");
            ProcessSequence c = new ProcessSequence("c");
            a.Add(b);
            b.Add(c);
            c.Add(a);
            return a;
        }
     
        /// <summary>
        /// Test step count of a short little cycle that doesn't
        /// have any steps.
        /// </summary>
        [Test]
        public void TestCycle()
        {
            Assert.AreEqual(0, Cycle().GetStepCount());
        }
      
        /// <summary>
        /// Test step count for one step and one (empty) sequence.
        /// </summary>
        [Test]
        public void TestOne()
        {
            ProcessStep uno = new ProcessStep("uno");
            Assert.AreEqual(1, uno.GetStepCount());
            ProcessSequence nil = new ProcessSequence("nil");
            Assert.AreEqual(0, nil.GetStepCount());
        }
       
        /// <summary>
        /// Test a process that repeats itself once, namely
        /// "shampoo, rinse, repeat."
        /// </summary>
        [Test]
        public void TestShampoo()
        {
            ProcessStep shampoo = new ProcessStep("shampoo");
            ProcessStep rinse = new ProcessStep("rinse");
            ProcessSequence once = new ProcessSequence("once");
            once.Add(shampoo);
            once.Add(rinse);
            ProcessSequence instructions =
                new ProcessSequence("instructions");
            instructions.Add(once);
            instructions.Add(once);
            Assert.AreEqual(2, instructions.GetStepCount());
        }
       
        /// <summary>
        /// Test step count for the aerial shell process.
        /// </summary>
        [Test]
        public void TestShell()
        {
            Assert.AreEqual(4, ShellProcess.Make().GetStepCount());
        }
        
        /// <summary>
        /// Test step count for a little directed acyclic graph that
        /// is not a tree.
        /// </summary>
        [Test]
        public void TestStepCount()
        {
            Assert.AreEqual(1, Abc().GetStepCount());
        }
        
        /*
         *   abc
         *  /   \
         * a     bc
         *      /  \
         *     b    c
         */
        /// <summary>
        /// Test a normal little tree.
        /// </summary>
        [Test]
        public void TestTree()
        {
            ProcessStep a = new ProcessStep("a");
            ProcessStep b = new ProcessStep("b");
            ProcessStep c = new ProcessStep("c");
            ProcessSequence bc = new ProcessSequence("bc"); 
            bc.Add(b);
            bc.Add(c);
            ProcessSequence abc = new ProcessSequence("abc");
            abc.Add(a);
            abc.Add(bc);
            Assert.AreEqual(3, abc.GetStepCount());
        }
    }
}
