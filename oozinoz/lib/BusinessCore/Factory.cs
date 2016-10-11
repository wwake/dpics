using System;
using System.Collections;
namespace BusinessCore
{  
    /// <summary>
    /// This class supports various examples that rely on the idea
    /// of a central object that represents an Oozinoz factory.
    /// </summary>
    public class Factory 
    {
        private static Factory _factory; 
        private static Object _classLock = typeof(Factory);
        private long _wipMoves;
        private Factory()
        {
            _wipMoves = 0;
        }
        public static Factory GetFactory()
        {
            lock (_classLock)
            {
                if (_factory == null)
                {
                    _factory = new Factory();
                }
                return _factory;
            }
        }
        public void RecordWipMove()
        {
            lock (_classLock)
            {
                _wipMoves++;
            }
        }
        // for the Aster star press example; not implemented
        public void CollectPaste() 
        {
        }

        /// <summary>
        /// Return an example list of "up" machines, supporting "ShowConcurrentWhile"
        /// and other examples).
        /// </summary>
        /// <returns>an example list of "up" machines</returns>
        public static ArrayList UpMachineNames()
        {
            return new ArrayList(
                new String[] {
                                 "Mixer:1201",
                                 "ShellAssembler:1301",
                                 "StarPress:1401",
                                 "UnloadBuffer:1501" } );
        }
    }
}
