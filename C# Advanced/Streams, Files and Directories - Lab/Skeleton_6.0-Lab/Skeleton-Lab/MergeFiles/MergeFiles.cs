namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> merged = new List<string>();
            
            using (StreamReader firstInput=new StreamReader(firstInputFilePath))
            {
                while (!firstInput.EndOfStream)
                {
                    merged.Add(firstInput.ReadLine());
                }
                using (StreamReader secondInput=new StreamReader(secondInputFilePath))
                {
                    while (!secondInput.EndOfStream)
                    {
                        merged.Add(secondInput.ReadLine());
                    }
                }
                using(StreamWriter writer=new StreamWriter(outputFilePath))
                {
                    foreach (var item in merged.OrderBy(x => x).ToList())
                    {
                       writer.WriteLine(item);
                    }
                }
                
            }
        }
    }
}
