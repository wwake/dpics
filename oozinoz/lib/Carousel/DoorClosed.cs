namespace Carousel
{
    /// <summary>
    /// Model the behavior of a carousel door when it's closed.
    /// </summary>
    public class DoorClosed : DoorState 
    { 
        /// <summary>
        /// Construct a state for the provided door.
        /// </summary>
        /// <param name="door">a door that needs a state model </param>
        public DoorClosed(Door2 door) : base (door)
        {
        }
        /// <summary>
        /// Open the door.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.OPENING);
        }
    }
}
