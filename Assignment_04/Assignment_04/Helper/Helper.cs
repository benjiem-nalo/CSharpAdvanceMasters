using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04
{
    public static class Helper
    {
        public static void WriteHeader()
        {
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("**********************************");
            Console.WriteLine("Author: Benjie Manalo");
            Console.WriteLine($"Date: {DateTime.Now}");
            Console.WriteLine("This is application is a video rental application wherein the user can view and rent videos based on titles.");
            Console.WriteLine("**********************************");
            Console.WriteLine("VIDEO RENTAL Inventory");
            Console.WriteLine("**********************************");
        }

        public static void WriteMenu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("1. Display aLl available video");
            Console.WriteLine("2. Get Video by Year");
            Console.WriteLine("3. Add a video");
            Console.WriteLine("4. Rent a video");
            Console.WriteLine("5. Delete a video");
            Console.WriteLine("6. Exit");
            Console.WriteLine("**********************************");
            Console.WriteLine("**********************************");
        }

        public static string Categorize(this int year)
        {
            return year < 2023 ? "Old" : "New-Released";
        }
    }
}
