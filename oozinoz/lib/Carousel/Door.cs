using System;

namespace Carousel
{
    /// <summary>
    /// This class provides an initial model of a carousel door
    /// that manages its state without moving state-specific
    /// logic out to state classes.
    /// </summary>
    public class Door  
    {
        public const int CLOSED   = -1;
        public const int OPENING  = -2;
        public const int OPEN     = -3;
        public const int CLOSING  = -4;
        public const int STAYOPEN = -5;
        //
        public ChangeHandler Change;
        private int _state = CLOSED;

        /// <summary>
        ///  The carousel user has touched the carousel button. This "one
        ///  touch" button elicits different behaviors, depending on the
        ///  state of the door.
        /// </summary>
        public void Touch()
        {
            if (_state == CLOSED)
            {
                SetState(OPENING);
            }
            else if (_state == OPENING || _state == STAYOPEN)
            {
                SetState(CLOSING);
            }
            else if (_state == OPEN)
            {
                SetState(STAYOPEN);
            }
            else if (_state == CLOSING)
            {
                SetState(OPENING);
            }
        }

        /// <summary>
        /// This is a notification from the mechanical carousel that the
        /// door finished opening or shutting.
        /// </summary>
        public void Complete()
        {
            if (_state == OPENING)
            {
                SetState(OPEN);
            }
            else if (_state == CLOSING)
            {
                SetState(CLOSED);
            }
        }

        private void SetState(int state)
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
            switch (_state)
            {
                case OPENING :
                    return "Opening";
                case OPEN :
                    return "Open";
                case CLOSING :
                    return "Closing";
                case STAYOPEN :
                    return "StayOpen";
                default :
                    return "Closed";
            }
        }

        /// <summary>
        /// This is a notification from the mechanical carousel that the
        /// door got tired of being open.
        /// </summary>
        public void Timeout()
        {
            SetState(CLOSING);
        }
    }
}
