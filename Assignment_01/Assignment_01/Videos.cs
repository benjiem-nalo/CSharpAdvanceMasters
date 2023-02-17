using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class BmmAvailableVideos
    {
        public List<BmmVideoEventArgs>? Videos { get; set; } = GetVideos();

        public BmmVideoEventArgs GetVideo(string title)
        {
            return Videos?.FirstOrDefault(_ => _.Title == title);
        }

        public void RemoveVideo(BmmVideoEventArgs video)
        {
            Console.Write($"Removing video title [{video.Title}]");
            Console.WriteLine();
            Videos?.Remove(video);
            var videosJson = JsonSerializer.Serialize(Videos);
            File.WriteAllText(GetFile(), videosJson);
            Console.Write($"Video title [{video.Title}] removed.");
            Console.WriteLine();
        }
        private static List<BmmVideoEventArgs>? GetVideos()
        {
            string videoFile = File.ReadAllText(GetFile());
            return JsonSerializer.Deserialize<List<BmmVideoEventArgs>>(videoFile);
        }

        private static string GetFile()
        {
            return Path.Join(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName, @"Data\Videos.json");
        }
    }
}
