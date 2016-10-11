namespace Carousel
{
    /// <summary>
    /// Model the behavior of a carousel door when it's closing.
    /// </summary>
    public class DoorClosing : DoorState 
    {
        /// <summary>
        /// Construct a state for the provided door.
        /// </summary>
        /// <param name="door">a door that needs a state model </param>
        public DoorClosing(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// The door is closed now, eh?
        /// </summary>
        public override void Complete()
        {
            _door.SetState(_door.CLOSED);
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
