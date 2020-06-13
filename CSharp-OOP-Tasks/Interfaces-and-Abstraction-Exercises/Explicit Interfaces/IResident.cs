using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
