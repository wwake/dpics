using System;

namespace Carousel
{
	/// <summary>
	/// The superclass of specific states, such as DoorOpen. This class
	/// estalishes the interface of a door state class, and provides
	/// an instance variable that holds a reference to a particular door.
	/// </summary>
	public abstract class DoorState
	{
		protected Door2 _door;

        /// <summary>
        /// Construct a state for the provided door.
        /// </summary>
        /// <param name="door">a door that needs a state model</param>
        public DoorState(Door2 door)
        {
            _door = door;
        }

        /// <summary>
        /// Subclasses must decide what to do when the user
        /// clicks the physical carousel button.
        /// </summary>
        public abstract void Touch();

        /// <summary>
        /// By default, discard notifications that the door
        /// finished opening or closing.
        /// </summary>
        public virtual void Complete()
        {
        }

        /// <summary>
        /// By default, discard notifications that the door
        /// began closing after having been open for a while.
        /// </summary>
        public virtual void Timeout()
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
