namespace Carousel2
{
    /// <summary>
    /// Model the behavior of a carousel door when it's opening.
    /// </summary>
    public class DoorOpening : DoorState 
    {
        /// <summary>
        /// We're done opening so the door is, uh, open.
        /// </summary>
        public override void Complete(Door door)
        {
            door.SetState(DoorState.OPEN);
        }

        /// <summary>
        /// Start closing the door instead.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }
    }
}
