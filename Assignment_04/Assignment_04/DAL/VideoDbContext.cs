using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_04.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment_04.DAL
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Videos> Videos { get; set; }
    }
}
