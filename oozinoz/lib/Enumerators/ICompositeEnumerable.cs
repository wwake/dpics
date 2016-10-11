using System;
using System.Collections;
using Utilities;
namespace Enumerators
{
    /// <summary>
    /// Define a type of object that can produce an iterator.
    /// </summary>
    public interface ICompositeEnumerable: IEnumerable
    {
        /// <summary>
        /// Return a component iterator;
        /// </summary>
        ComponentEnumerator GetEnumerator(Set visited);
    }
}
