namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            
            using (StreamReader reader= new StreamReader(inputFilePath))
            {
                int count = 0;
                string line = reader.ReadLine();
                using (StreamWriter writer=new StreamWriter(outputFilePath))
                {
                    while(!reader.EndOfStream)
                    {
                        if (count % 2 == 0)
                        {
                            writer.WriteLine(line);
                        }
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
