using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public interface IMyList<T> : IAddRemoveCollection<T>
    {
        IReadOnlyCollection<T> Used { get; }
    }
}
