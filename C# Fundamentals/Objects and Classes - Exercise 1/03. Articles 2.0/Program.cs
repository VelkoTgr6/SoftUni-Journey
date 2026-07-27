using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i <n; i++)
            {
                string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries) ;
                string title = input[0];
                string content = input[1];
                string author = input[2];
                Article article = new Article(title,content,author);
                articles.Add(article);
            }
            foreach (Article article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }

    }
    class Article
    {
        public Article(object title, object content, object author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public object Title { get; set; }
        public object Content { get; set; }
        public object Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
