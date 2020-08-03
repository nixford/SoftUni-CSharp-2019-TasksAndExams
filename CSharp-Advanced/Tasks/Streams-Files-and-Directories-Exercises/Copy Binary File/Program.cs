using System;
using System.IO;

namespace Copy_Binary_File
{
    class Program
    {
        const int DEF_SIZE = 4096;
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("./copyME2.png", FileMode.Open);

            using FileStream writer = new FileStream("../../../copied2.png", FileMode.Create);

            byte[] buffer = new byte[DEF_SIZE];

            while (reader.CanRead)
            {
                int bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
