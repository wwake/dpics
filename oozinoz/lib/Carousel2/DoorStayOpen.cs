namespace Carousel2
{
    /// <summary>
    /// Model the behavior of a carousel door when it's been instructed
    /// to stay open.
    /// </summary>
    public class DoorStayOpen : DoorState 
    { 
        /// <summary>
        /// Close the door.
        /// </summary>
        public override void Touch(Door door)
        {
            door.SetState(DoorState.CLOSING);
        }
    }
}
