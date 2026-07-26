using System.IO;

namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream partOneFileStream = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write))
            using (FileStream partTwoFileStream = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write))
            {
                long fileSize = sourceFileStream.Length;
                long partSize = fileSize / 2;

                byte[] buffer = new byte[4096];
                int bytesRead;
                long totalBytesWritten = 0;

                while ((bytesRead = sourceFileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (totalBytesWritten + bytesRead <= partSize)
                    {
                        partOneFileStream.Write(buffer, 0, bytesRead);
                    }
                    else
                    {
                        partTwoFileStream.Write(buffer, 0, bytesRead);
                    }

                    totalBytesWritten += bytesRead;
                }
            }
        }


        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {

            using (FileStream partOneFileStream = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream partTwoFileStream = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream joinedFileStream = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = partOneFileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedFileStream.Write(buffer, 0, bytesRead);
                }

                while ((bytesRead = partTwoFileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedFileStream.Write(buffer, 0, bytesRead);
                }
            }





        }
    }
}