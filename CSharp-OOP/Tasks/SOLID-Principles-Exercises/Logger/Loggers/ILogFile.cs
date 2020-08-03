﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Loggers
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
