using System;
using System.IO.Compression;

namespace Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "copyMe.png";
            //ZipFile.CreateFromDirectory("./", destinationArchiveFileName: "../../../myZip.zip");
            using ZipArchive zipArch = ZipFile.Open(archiveFileName:"../../../arhiv.zip", ZipArchiveMode.Create);
            zipArch.CreateEntryFromFile(filePath, entryName: filePath);
        }
    }
}
 