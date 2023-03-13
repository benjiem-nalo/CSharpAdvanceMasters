using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_04.DAL;
using Assignment_04.Events;
using Assignment_04.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Assignment_04.Service
{
    internal class VideoService : IVideoService
    {
        private readonly IVideosDAL dal;

        public VideoService(IVideosDAL dal)
        {
            this.dal = dal;
        }
        public void GetVideos()
        {
            Console.WriteLine($"Videos available:");
            var results = dal.GetVideos();
            results.ToList().ForEach(video => { Console.WriteLine($"{video.Title} - {video.Year} - {video.Quantity}"); });
        }

        public void GetVideos(string year)
        {
            Console.WriteLine($"Videos on year: {year}");
            var results = dal.GetVideos(year);

            results.ToList().ForEach(video => { Console.WriteLine($"{video.Title} - {video.Year}"); });
        }

        public void AddVideo(string title, string year, int qty)
        {
            Console.WriteLine($"Add video");
            dal.AddVideos(new VideoDto { Title = title, Year = year, Qty = qty });
        }

        public VideoEventArgs RentVideo(string title)
        {
            Console.WriteLine($"Rent Video...");
            if (IsVideoExisting(title))
            {
                Console.WriteLine("Updating inventory");
                dal.UpdateVideoQty(title);
            }
            else
            {
                Console.WriteLine("Video not available");
            }
            
            return GetVideoEventArgs(title);
        }

        public void DeleteVideo(string title)
        {
            if (IsVideoExisting(title))
            {
                Console.WriteLine("Deleting video");
                dal.DeleteVideo(title);
            }
            else
            {
                Console.WriteLine("Video deleted");
            }
        }

        private VideoEventArgs GetVideoEventArgs(string title)
        {
            var s =  dal.GetVideo(title);
            return new VideoEventArgs { Title = s.Title, Year = int.Parse(s.Year) };

        }

        private bool IsVideoExisting(string title)
        {
            Console.WriteLine($"Checking video...:");
            var results = dal.GetVideo(title);
            return results != null;
        }
    }
}
