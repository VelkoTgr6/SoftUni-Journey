namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader words=new StreamReader(wordsFilePath))
            {
                Dictionary<string, int> containingWords = new Dictionary<string, int>();
                string[] wordsLine = words.ReadLine().Split();
                using (StreamReader text=new StreamReader(textFilePath))
                {
                    while (!text.EndOfStream)
                    {
                        
                        string line = text.ReadLine().ToLower();
                        string[] wordsRegex = Regex.Split(line, @"\W+");

                        for (int i = 0; i < wordsRegex.Length; i++)
                        {
                            for (int j = 0; j < wordsLine.Length; j++)
                            {
                                if (wordsLine[j] == wordsRegex[i])
                                {
                                    if (!containingWords.ContainsKey(wordsLine[j]))
                                    {
                                        containingWords.Add(wordsLine[j], 1);
                                    }
                                    else if (containingWords.ContainsKey(wordsLine[j]))
                                    {
                                        containingWords[wordsLine[j]] += 1;
                                    }   
                                    
                                }
                            }
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        foreach (var item in containingWords.OrderByDescending(x=>x.Value))
                        {
                            writer.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                }
            }
            
        }
    }
}
