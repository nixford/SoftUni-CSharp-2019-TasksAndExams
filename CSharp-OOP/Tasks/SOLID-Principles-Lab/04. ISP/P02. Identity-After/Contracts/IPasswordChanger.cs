using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Identity_After.Contracts
{
    public interface IPasswordChanger
    {
        void ChangePassword(string oldPass, string newPass);
    }
}
