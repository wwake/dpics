using System;

namespace Carousel2
{
    /// <summary>
    /// This refactoring of the Door class moves state-specific logic
    /// to a separate class hierarchy.
    /// </summary>
    public class Door
    {
        public ChangeHandler Change;
        private DoorState _state; 

        /// <summary>
        /// Initialize this door.
        /// </summary>
        public Door()
        {
            _state = DoorState.CLOSED;
        }

        /// <summary>
        ///  The carousel user has touched the carousel button. This "one
        ///  touch" button elicits different behaviors, depending on the
        ///  state of the door.
        /// </summary>
        public void Touch()
        {
            _state.Touch(this);
        }

        /// <summary>
        /// This is a notification from the mechanical carousel that the
        /// door finished opening or shutting.
        /// </summary>
        public void Complete()
        {
            _state.Complete(this);
        }

        internal void SetState(DoorState state)
        {
            this._state = state;
            if (Change != null) Change();
        }

        /// <summary>
        /// Return a textual description of the door's state.
        /// </summary>
        /// <returns>a textual description of the door's state</returns>
        public String Status()
        {
            return _state.Status();
        }

        /// <summary>
        /// This is a notification from the mechanical carousel that the
        /// door got tired of being open.
        /// </summary>
        public void Timeout()
        {
            _state.Timeout(this);
        }
    }
}
