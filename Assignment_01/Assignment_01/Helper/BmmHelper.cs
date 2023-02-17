using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public static class BmmHelper
    {
        public static string Categorize(this int year)
        {
            return year < 2023 ? "Old" : "New-Released";
        }
    }
}
