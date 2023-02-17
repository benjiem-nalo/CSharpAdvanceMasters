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

        private static List<BmmVideoEventArgs>? GetVideos()
        {
            string dir = Path.Join(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName, @"Data\Videos.json");
            string videoFile = File.ReadAllText(dir);
            return JsonSerializer.Deserialize<List<BmmVideoEventArgs>>(videoFile);
        }

        public BmmVideoEventArgs GetVideo(string title)
        {
            return Videos?.FirstOrDefault(_ => _.Title == title);
        }
    }
}
