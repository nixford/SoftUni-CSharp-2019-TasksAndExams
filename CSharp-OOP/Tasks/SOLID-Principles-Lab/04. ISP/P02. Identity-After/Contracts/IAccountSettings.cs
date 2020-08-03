using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Identity_After.Contracts
{
    public interface IAccountSettings
    {
        bool RequireUniqueEmail { get; }

        int MinRequiredPasswordLength { get; }

        int MaxRequiredPasswordLength { get; }
    }
}
