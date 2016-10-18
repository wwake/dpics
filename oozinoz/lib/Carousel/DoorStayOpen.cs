namespace Carousel
{
    /// <summary>
    /// Model the behavior of a carousel door when it's been instructed
    /// to stay open.
    /// </summary>
    public class DoorStayOpen : DoorState 
    { 
        /// <summary>
        /// Construct a state for the provided door.
        /// </summary>
        /// <param name="door">a door that needs a state model </param>
        public DoorStayOpen(Door2 door) : base (door)
        {
        }

        /// <summary>
        /// Close the door.
        /// </summary>
        public override void Touch()
        {
            _door.SetState(_door.CLOSING);
        }
    }
}
