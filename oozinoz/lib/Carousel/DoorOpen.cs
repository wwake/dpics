namespace Carousel
{
    /// <summary>
    /// Model the behavior of a carousel door when it's open.
    /// </summary>
    public class DoorOpen : DoorState 
    {
        /// <summary>
        /// Construct a state for the provided door.
        /// </summary>
        /// <param name="door">a door that needs a state model </param>
        public DoorOpen(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Start closing if the door is open and the door machinery
        /// sends a timeout signal.
        /// </summary>
        public override void Timeout()
        {
            _door.SetState(_door.CLOSING);
        }

        /// <summary>
        /// This is a nonintuitive behavior of the "one touch" system. Once
        /// open the door will begin closing automatically after a few seconds
        /// (the timeout). You can prevent this with an extra touch that 
        /// indicates the door should remain open.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.STAYOPEN);
        }
    }
}
