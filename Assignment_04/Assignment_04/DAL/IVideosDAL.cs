using Assignment_04.Model;

namespace Assignment_04.DAL
{
    public interface IVideosDAL
    {
        IEnumerable<Videos> GetVideos();
        IEnumerable<Videos> GetVideos(string year);
        Videos GetVideo(string title);
        void AddVideos(VideoDto videoDto);
        void UpdateVideoQty(string vTitle);
        void DeleteVideo(string vTitle);
    }
}