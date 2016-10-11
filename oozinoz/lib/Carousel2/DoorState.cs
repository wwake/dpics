using System;

namespace Carousel2
{
	/// <summary>
	/// A refactoring of DoorState from the initial Carousel namespace. Here
	/// we pass a Door object from transition to transition, rather than having
	/// all the states refer to a particular door.
	/// </summary>
	public abstract class DoorState
	{
        public static readonly DoorState CLOSED   = new DoorClosed();
        public static readonly DoorState OPENING  = new DoorOpening();
        public static readonly DoorState OPEN     = new DoorOpen();
        public static readonly DoorState CLOSING  = new DoorClosing();
        public static readonly DoorState STAYOPEN = new DoorStayOpen();

        /// <summary>
        /// Subclasses must decide what to do when the user
        /// clicks the physical carousel button.
        /// </summary>
        public abstract void Touch(Door door);

        /// <summary>
        /// By default, discard notifications that the door
        /// finished opening or closing.
        /// </summary>
        public virtual void Complete(Door door)
        {
        }

        /// <summary>
        /// By default, discard notifications that the door
        /// began closing after having been open for a while.
        /// </summary>
        public virtual void Timeout(Door door)
        {
        }

        /// <summary>
        /// Return a textual desciption of this state.
        /// </summary>
        /// <returns>a textual desciption of this state</returns>
        public String Status()
        {
            return this.GetType().Name;
        }
	}    
}
