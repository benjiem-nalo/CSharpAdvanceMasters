using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class BmmVideoOut
    {
        //declare an event associated with the delegate
        private event EventHandler<BmmVideoEventArgs>? OnTriggered;

        public static void VideoOutEvent(string title)
        {
            var videoOut = new BmmVideoOut();
            videoOut.OnTriggered += BmmMailService.Send;
            videoOut.OnTriggered += BmmMessageService.Notify;

            videoOut.Triggered(title);
        }

        private void Triggered(string title)
        {
            Console.WriteLine("VideoOutEvent triggered.");

            BmmAvailableVideos bmmAV = new();
            var bmmVideoToRent = bmmAV.GetVideo(title);

            //Raise an Event
            OnTriggered?.Invoke(this, bmmVideoToRent);
        }
    }
}
