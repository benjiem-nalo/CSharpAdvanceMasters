using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04.Events
{
    public class VideoEventArgs : EventArgs
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
