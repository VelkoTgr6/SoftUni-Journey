using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title,content,author);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ",StringSplitOptions.RemoveEmptyEntries);


                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }

                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }

                else if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
            }
            Console.WriteLine(article.ToString());
        }

        public class Article
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


            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }

        }
    }
}
