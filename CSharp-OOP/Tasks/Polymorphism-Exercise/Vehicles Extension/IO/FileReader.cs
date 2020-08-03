using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vehicles.IO
{
    public class FileReader : IReader
    {
        public string CustomReadLine()
        {
            return File.ReadAllText("file.txt");
        }
    }
}
