using Assignment_04;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Assignment_04.Service;
using Microsoft.Extensions.Configuration;
using System;
using Assignment_04.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Assignment_04.Events;

namespace Assignment_04
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ConsoleKey key;
            ConsoleKey exitKey = new ConsoleKey();

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var sp = scope.ServiceProvider;
                var context = sp.GetRequiredService<VideoDbContextInitialiser>();
                await context.InitialiseAsync();
                //await context.TrySeedAsync();
            }

            var servicedal = serviceProvider.GetService<IVideosDAL>();

            //Display Header
            Helper.WriteHeader();

            do
            {

                while (!Console.KeyAvailable && exitKey != ConsoleKey.Escape)
                {



                    //Display Menu
                    Helper.WriteMenu();

                    //Select Option
                    Console.Write($"Select Option: ");
                    var selected = Console.ReadLine();

                    VideoService vs = new VideoService(servicedal);

                    if (selected == "1")
                    {
                        vs?.GetVideos();
                    }
                    else if (selected == "2")
                    {
                        Console.Write($"Enter video year: ");
                        var vyear = Console.ReadLine();
                        vs?.GetVideos(vyear);
                    }
                    else if (selected == "3")
                    {
                        Console.Write($"Enter video title: ");
                        var vTitle = Console.ReadLine();
                        Console.Write($"Enter video year: ");
                        var vYear = Console.ReadLine();
                        Console.Write($"Enter video qty: ");
                        var vQty = Console.ReadLine();
                        vs?.AddVideo(vTitle, vYear, int.Parse(vQty));
                        Console.WriteLine($"Video added");
                    }
                    else if (selected == "4")
                    {
                        Console.Write($"Enter video title to rent: ");
                        var vTitle = Console.ReadLine();
                        var bmmVEA = vs.RentVideo(vTitle);
                        VideoEvents videoEvents = new VideoEvents();
                        videoEvents.VideoOutEvent(bmmVEA);

                    }
                    else if (selected == "5")
                    {
                        Console.Write($"Enter video title to delete: ");
                        var vTitle = Console.ReadLine();
                        vs.DeleteVideo(vTitle);
                    }
                    else if (selected == "6")
                    {
                        exitKey = ConsoleKey.Escape;
                    }
                    else
                    {
                        Console.Write($"Invalid choice");
                    }
                }
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Escape && exitKey != ConsoleKey.Escape);
        }
    }
}