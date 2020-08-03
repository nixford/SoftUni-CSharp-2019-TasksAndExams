using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WildFarm.IO
{
    public class FileReader : IReader
    {
        public string CustomReadLine()
        {
            return File.ReadAllText("file.txt");
        }
    }
}
