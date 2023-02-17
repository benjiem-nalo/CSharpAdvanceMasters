using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class BmmMessageService
    {

        public static void Notify(object? sender, BmmVideoEventArgs e)
        {
            Console.WriteLine($"Notification: {e.Year.Categorize()} video with title {e.Title} was rented.");
        }
    }
}
