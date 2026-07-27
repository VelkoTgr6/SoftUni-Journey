using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('_');

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song(type,name,time);

              // song.TypeList = type;
              // song.Name = name;
              // song.Time = time;

                songs.Add(song);
            }
            string inputOption = Console.ReadLine();
           //List<Song> filteredSong = songs    
           //.Where(x => x.TypeList == inputOption).ToList();
           //
            if (inputOption == "all")
            {
                foreach (Song song in songs) 
                {
                    
                        Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == inputOption)
                        Console.WriteLine(song.Name);
                }
            }
        }
    }
    class Song
    {
        public Song(string type, string name,string time)
        {
            TypeList = type;
            Name = name;
            Time = time;
        }
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}
