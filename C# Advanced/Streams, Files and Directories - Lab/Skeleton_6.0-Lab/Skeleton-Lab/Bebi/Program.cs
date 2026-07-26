namespace Bebi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\input.txt";
            string outputPath = @"..\..\..\output.txt";

            CalculateWordCounts(wordPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int firstN = int.Parse(reader.ReadLine());
                    int secondN = int.Parse(reader.ReadLine());

                    for (int i = 1; i <= firstN; i++)
                    {
                        for (int j = 1; j <= secondN; j++)
                        {
                            writer.WriteLine($"{i}.{j}");
                        }
                    }
                }
            }
        }
    }
}
