using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Core
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
