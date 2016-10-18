using System;
namespace Processes
{
    /// <summary>
    /// This class provides an object model of Oozinoz's process
    /// for making an aerial shell.
    /// </summary>
    public class ShellProcess 
    {
        protected static ProcessSequence make;

        /// <summary>
        /// Return an object model of Oozinoz's process for making 
        /// an aerial shell.
        /// </summary>
        /// <returns>an object model of Oozinoz's process for making 
        /// an aerial shell</returns>
        public static ProcessSequence Make()
        {
            if (make == null)
            {
                make = new ProcessSequence("Make an aerial shell");
                make.Add(BuildInnerShell());
                make.Add(Inspect());
                make.Add(ReworkOrFinish());
            }
            return make;
        }

        protected static ProcessStep BuildInnerShell()
        {
            return new ProcessStep("Build inner shell");
        }

        protected static ProcessStep Inspect()
        {
            return new ProcessStep("Inspect");
        }
        
        protected static ProcessAlternation ReworkOrFinish()
        {
            return new ProcessAlternation(
                "Rework inner shell, or complete shell", Rework(), Finish());
        }
        
        protected static ProcessSequence Rework()
        {
            return new ProcessSequence("Rework", Disassemble(), Make());
        }
        
        protected static ProcessStep Disassemble()
        {
            return new ProcessStep("Disassemble");
        }
        
        protected static ProcessStep Finish()
        {
            return new ProcessStep("Finish: Attach lift, insert fusing, wrap");
        }
    }
}
