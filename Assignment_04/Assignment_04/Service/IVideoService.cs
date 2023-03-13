using Assignment_04.Events;
using Assignment_04.Model;

namespace Assignment_04.Service
{
    public interface IVideoService
    {
        void GetVideos();
        void GetVideos(string year);
        void AddVideo(string title, string year, int qty);
        void DeleteVideo(string title);
    }
}