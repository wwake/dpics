namespace Carousel2
{
    /// <summary>
    /// Model the behavior of a carousel door when it's closing.
    /// </summary>
    public class DoorClosing : DoorState 
    {
        /// <summary>
        /// The door is closed now, eh?
        /// </summary>
        public override void Complete(Door door)
        {
            door.SetState(DoorState.CLOSED);
        }

        /// <summary>
        /// Open the door.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.OPENING);
        }
    }
}
