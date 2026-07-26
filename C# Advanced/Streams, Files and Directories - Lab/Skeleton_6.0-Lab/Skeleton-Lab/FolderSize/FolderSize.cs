namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            using (FileStream folder = new FileStream(folderPath, FileMode.Open))
            {
                double sum = 0;
                DirectoryInfo dir = new DirectoryInfo("TestFolder");
                FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);
                foreach (FileInfo fileInfo in infos)
                {
                    sum += fileInfo.Length;
                }
                sum = sum / 1024 / 1024;
                File.WriteAllText("оutput.txt", sum.ToString());
            }
        }
    }
}
