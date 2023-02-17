using Assignment_01;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Session_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //write header 
            BmmHeader.Write();
            //instantiate avaialble videos
            BmmAvailableVideos bmmAV = new();

            //fetching and display available videos
            Console.Write("Fetching available videos...");
            Console.WriteLine();
            bmmAV?.Videos?.ForEach(_ =>
            {
                Console.WriteLine($"Title: {_.Title}");
                Console.WriteLine($"Year: {_.Year}");
                Console.WriteLine();
            });

            //taking user input
            Console.WriteLine("Please enter video to rent:");
            var videoTitle = Console.ReadLine() ?? "";
            Console.WriteLine();

            //fetch the video from data source
            var bmmVideoRented = bmmAV?.GetVideo(videoTitle);

            if (bmmVideoRented is not null)
            {
                //invoke video out event
                BmmVideoOut.VideoOutEvent(videoTitle);
                //delete video in database when successfully rented
                bmmAV?.RemoveVideo(bmmVideoRented);
            }
            else
                Console.WriteLine("Video is not available.");
        }
    }
}