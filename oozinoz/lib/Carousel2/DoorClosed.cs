namespace Carousel2
{
    /// <summary>
    /// Model the behavior of a carousel door when it's closed.
    /// </summary>
    public class DoorClosed : DoorState 
    { 
        /// <summary>
        /// Open the door.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.OPENING);
        }
    }
}
