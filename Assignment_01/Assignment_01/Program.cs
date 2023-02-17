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
            BmmHeader.Write();
            BmmAvailableVideos bmmAV = new();

            bmmAV?.Videos?.ForEach(_ =>
            {
                Console.WriteLine($"Title: {_.Title}");
                Console.WriteLine($"Year: {_.Year}");
                Console.WriteLine();
            });


            Console.WriteLine("PLease enter video to rent:");
            var videoTitle = Console.ReadLine() ?? "";


            //fetch video from data source
            var bmmVideoToRent = bmmAV?.GetVideo(videoTitle);

            //invoke video out event 
            if (bmmVideoToRent is not null)
                BmmVideoOut.VideoOutEvent(videoTitle);
                //TODO: delete video in database when successfully rented
            else
                Console.WriteLine("Video is not available.");



        }
    }
}