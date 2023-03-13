using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_04.Events;

namespace Assignment_04.Service
{
    public class NotifyService
    {
        public static void Notify(object? sender, VideoEventArgs e)
        {
            Console.WriteLine($"Notification: {e.Year.Categorize()} video with title {e.Title} was rented.");
        }
    }
}
