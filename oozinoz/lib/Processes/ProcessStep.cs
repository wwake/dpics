using System;
using System.Collections;
using Enumerators;
using Utilities;
namespace Processes
{
    /// <summary>
    /// Represent an individual process step.
    /// </summary>
    public class ProcessStep : ProcessComponent 
    {
        /// <summary>
        /// Create a step with the given name.
        /// </summary>
        /// <param name="name">the name of this process step</param>
        public ProcessStep(String name) : base(name)
        {
        }
        /// <summary>
        /// This hook lets visitors add behaviors to the process
        /// composite. The point here is to call back the visitor
        /// indicating the type of this node, namely 
        /// ProcessStep.
        /// </summary>
        /// <param name="v"></param>
        public override void Accept(IProcessVisitor v)
        {
            v.Visit(this);
        }
        /// <summary>
        /// Return an enumerator that will "enumerate" this step,
        /// returning it once.
        /// </summary>
        /// <param name="visited">a set of already-visited nodes</param>
        /// <returns>an enumerator that will "enumerate" this step,
        /// returning it once</returns>
        public override ComponentEnumerator GetEnumerator(Set visited)
        {
            return new LeafEnumerator(this, visited);
        }
        /// <summary>
        /// Return the number of steps in this step, namely 1.
        /// </summary>
        /// <param name="visited">components already visited while traversing
        /// this component
        /// </param>
        /// <returns>1, the number of steps in this step</returns>
        public override int GetStepCount(Hashtable visited)
        {
            visited.Add(_name, this);
            return 1;
        }
    }
}
