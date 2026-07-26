namespace ExtractSpecialBytes
{
   
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] targetBytes = File.ReadLines(bytesFilePath)
                     .Select(byteString => Convert.ToByte(byteString))
                     .ToArray();

            using (FileStream inputFileStream = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        if (targetBytes.Contains(buffer[i]))
                        {
                            // Write the matching byte to the output file
                            outputFileStream.WriteByte(buffer[i]);
                        }
                    }
                }
            }

           
        }
           
}
    }