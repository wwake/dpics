namespace Carousel
{
    /// <summary>
    /// Model the behavior of a carousel door when it's opening.
    /// </summary>
    public class DoorOpening : DoorState 
    {
        /// <summary>
        /// Construct a state for the provided door.
        /// </summary>
        /// <param name="door">a door that needs a state model </param>
        public DoorOpening(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// We're done opening so the door is, uh, open.
        /// </summary>
        public override void Complete()
        {
            _door.SetState(_door.OPEN);
        }

        /// <summary>
        /// Start closing the door instead.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.CLOSING);
        }
    }
}
