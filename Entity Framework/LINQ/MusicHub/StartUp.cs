namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumInfo = context.Producers
                .Include(a=>a.Albums)?
                .ThenInclude(s=>s.Songs)?
                .ThenInclude(w=>w.Writer)?
                .FirstOrDefault(p => p.Id == producerId)?
                .Albums.Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    TotalAlbumPrice=a.Price,

                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name

                    }).OrderByDescending(s => s.SongName)
                      .ThenBy(s => s.SongWriter)
                })
                .OrderByDescending(a=>a.TotalAlbumPrice)
                .AsEnumerable();

            StringBuilder sb= new StringBuilder();
            

            foreach(var album in albumInfo)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                

                if (album.Songs.Any())
                {
                    int counter = 1;

                    foreach (var song in album.Songs)
                    {
                        sb.AppendLine($"---#{counter++}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.SongPrice:F2}");
                        sb.AppendLine($"---Writer: {song.SongWriter}");
                        
                    }
                }
                
                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
                
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.SongPerformers)
                    .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                    .ThenInclude(a => a.Producer)
                .AsEnumerable() // ||.ToList() Fetch all songs to memory,otherwise filtering will fail!!!
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers.Select(s => s.Performer.FirstName + " " + s.Performer.LastName)
                    .OrderBy(fullName=>fullName)
                    .AsEnumerable(),
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s=>s.Name)
                .ThenBy(s=>s.Writer)
                .AsEnumerable();

            StringBuilder sb = new StringBuilder();
            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.Writer}");

                if (song.Performers.Any())
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
                    
        }
    }
}
