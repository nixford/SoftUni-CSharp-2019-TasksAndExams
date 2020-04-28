using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("sliceMe.txt", FileMode.OpenOrCreate);

            int parts = 4;

             long length = (long)Math.Ceiling(stream.Length / (decimal)parts);

            byte[] buffer = new byte[length];

            for (int i = 0; i < parts; i++)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesRead).ToArray();
                }

                using FileStream currentPartStream = new FileStream($"Part{i + 1}.txt", FileMode.OpenOrCreate);

                currentPartStream.Write(buffer, 0, buffer.Length);               
            }
        }
    }
}
