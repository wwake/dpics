namespace Aster 
{
    public delegate void AsterHook(AsterStarPress2 p);
    /// <summary>
    /// This class is a revision of the AsterStarPress class
    /// that uses the Command pattern to let a client modify
    /// its behavior.
    /// 
    /// The "Command" chapter in "Design Patterns in C#" 
    /// describes this class. 
    /// </summary>
    public class AsterStarPress2
    {
        public event AsterHook MoldIncomplete;
        protected int _currentMoldID;

        /// <summary>
        /// ID of the mold that is in the processing area.
        /// </summary>
        public int CurrentMoldID
        {
            get
            {
                return _currentMoldID;
            }
        }

        /// <summary>
        /// Extrude all of the chemical paste (used for firework
        /// stars) to waste area.
        /// </summary>
        public virtual void DischargePaste()
        {
        }

        /// <summary>
        /// Spray water over the processing and discharge areas,
        /// keeping the press from getting gunky.
        /// </summary>
        public virtual void Flush()
        {
        }

        /// <summary>
        /// Return true if the machine is processing a mold.
        /// </summary>
        /// <returns>true if the machine is processing a mold</returns>
        public virtual bool InProcess()
        {
            return false;
        }

        /// <summary>
        /// Stop processing, mark the current mold as incomplete,
        /// move off all molds, discharge any prepared paste, and
        /// flush the processing area with water.
        /// </summary>
        public virtual void ShutDown()
        {
            if (InProcess())
            {
                StopProcessing();
                if (MoldIncomplete != null) 
                {
                    MoldIncomplete(this); 
                }
            }
            UsherInputMolds();
            DischargePaste();
            Flush();
        }

        /// <summary>
        /// Stop the processing subassembly.
        /// </summary>
        public virtual void StopProcessing()
        {
        }

        /// <summary>
        /// Move all molds to the output conveyor.
        /// </summary>
        public virtual void UsherInputMolds()
        {
        }
    }
}
