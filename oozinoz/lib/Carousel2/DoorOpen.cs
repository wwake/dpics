namespace Carousel2
{
    /// <summary>
    /// Model the behavior of a carousel door when it's open.
    /// </summary>
    public class DoorOpen : DoorState 
    {
        /// <summary>
        /// Start closing if the door is open and the door machinery
        /// sends a timeout signal.
        /// </summary>
        public override void Timeout(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }

        /// <summary>
        /// This is a nonintuitive behavior of the "one touch" system. Once
        /// open the door will begin closing automatically after a few seconds
        /// (the timeout). You can prevent this with an extra touch that 
        /// indicates the door should remain open.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.STAYOPEN);
        }
    }
}
