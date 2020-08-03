using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Identity_After.Contracts
{
    interface IAccountAuthenticator
    {
        void Register(string username, string password);

        void Login(string username, string password);
    }
}
