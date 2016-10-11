namespace Processes
{
    /// <summary>
    /// This class just supports an accessibility exercise in 
    /// "Introducing Responsibility".
    /// </summary>
    public class Process 
    { 
        internal string _name = ""; 
    }
}

namespace Materials
{
    /// <summary>
    /// This class just supports an accessibility exercise in 
    /// "Introducing Responsibility".
    /// </summary>
    public class Bin   
    {
        private string _current;
        public void setCurrentStep(Processes.Process p)
        {
            _current = p._name;
        }
    }
}
