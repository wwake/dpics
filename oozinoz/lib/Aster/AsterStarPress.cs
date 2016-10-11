namespace Aster 
{
    /// <summary>
    /// This class runs on the (fictional) Aster star press and 
    /// aids communication with the factory in which the star press 
    /// runs. In fact this class is a mock-up that shows how a client 
    /// might supply a template method. 
    /// 
    /// The "Template Method" chapter in "Design Patterns in C#"
    /// describes this class. 
    /// </summary>
    public abstract class AsterStarPress 
    {
        protected int _currentMoldID;

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
        /// Subclasses have to fill in how the host factory can
        /// deal with the problem of an incompletely processed
        /// mold.
        /// </summary>
        /// <param name="id">which mold is incomplete</param>
        public abstract void MarkMoldIncomplete(int id);

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
                MarkMoldIncomplete(_currentMoldID);
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
