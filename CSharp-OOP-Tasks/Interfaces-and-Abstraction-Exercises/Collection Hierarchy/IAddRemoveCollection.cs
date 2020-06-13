using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
