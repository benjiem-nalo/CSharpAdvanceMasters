using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public static class BmmHeader
    {
        public static void Write()
        {
            Console.WriteLine("Author: Benjie Manalo");
            Console.WriteLine($"Date: {DateTime.Now}");
            Console.WriteLine("This is application is a video rental application wherein the user can view and rent videos based on titles.");
            Console.WriteLine("**********************************");
            Console.WriteLine("VIDEO TITLES and YEAR Released");
            Console.WriteLine("**********************************");
        }
    }
}
