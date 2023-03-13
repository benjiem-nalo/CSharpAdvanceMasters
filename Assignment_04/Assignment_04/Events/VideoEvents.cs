using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_04.DAL;
using Assignment_04.Model;
using Assignment_04.Service;

namespace Assignment_04.Events
{
    public class VideoEvents
    {
        private readonly IVideosDAL _videosDAL;

        private event EventHandler<VideoEventArgs>? OnTriggered;
        public void VideoOutEvent(VideoEventArgs bmmVideo)
        {
            var videoOut = new VideoEvents();
            videoOut.OnTriggered += MailService.Send;
            videoOut.OnTriggered += NotifyService.Notify;

            videoOut.Triggered(bmmVideo);
        }

        private void Triggered(VideoEventArgs bmmVideo)
        {
            Console.WriteLine("VideoOutEvent triggered.");

            //Raise an Event
            OnTriggered?.Invoke(this, bmmVideo);
        }
    }
}
