using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_04.Model;

namespace Assignment_04.DAL
{
    public class VideosDAL : IVideosDAL
    {
        private readonly VideoDbContext bmmVideoDBContext;

        public VideosDAL(VideoDbContext videoDbContext)
        {
            this.bmmVideoDBContext = videoDbContext;
        }

        /// <summary>
        /// Get All available videos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Videos> GetVideos()
        {
            return bmmVideoDBContext.Videos.Where(v => v.Quantity != 0).ToList();
        }

        /// <summary>
        /// Get specific videos by year
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public IEnumerable<Videos> GetVideos(string year)
        {
            return bmmVideoDBContext.Videos.Where(v => v.Quantity != 0 && v.Year == year).OrderBy(o => o.Year);
        }

        public Videos GetVideo(string title) 
        {
            return bmmVideoDBContext.Videos.FirstOrDefault(_ => _.Title.ToLower() == title.ToLower());
        }

        /// <summary>
        /// Add video
        /// </summary>
        /// <param name="videoDto"></param>
        public void AddVideos(VideoDto videoDto)
        {
            bmmVideoDBContext.Videos.Add(new Videos { Title = videoDto.Title, Year= videoDto.Year, Quantity = videoDto.Qty });
            bmmVideoDBContext.SaveChanges();
        }

        /// <summary>
        /// Update video qty
        /// </summary>
        /// <param name="videoDto"></param>
        public void UpdateVideoQty(string vTitle)
        {
            var currentQty = bmmVideoDBContext.Videos.FirstOrDefault(v => v.Quantity != 0 && v.Title == vTitle).Quantity;
            bmmVideoDBContext.Videos.FirstOrDefault(v => v.Title == vTitle && v.Quantity != 0).Quantity = currentQty - 1;
            bmmVideoDBContext.SaveChanges();
        }

        /// <summary>
        /// Delete video
        /// </summary>
        /// <param name="vTitle"></param>
        public void DeleteVideo(string vTitle)
        {
            var toRemove = bmmVideoDBContext.Videos.FirstOrDefault(v => v.Quantity != 0 && v.Title == vTitle);
            if (toRemove is not null)
            {
                bmmVideoDBContext.Videos.Remove(toRemove);
                bmmVideoDBContext.SaveChanges(); 
            }
        }
    }
}
