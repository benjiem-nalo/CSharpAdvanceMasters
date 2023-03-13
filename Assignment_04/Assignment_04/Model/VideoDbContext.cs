using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment_04.Model
{
    public class MyDBContext : DbContext
    {

        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Videos> Videos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        //{
        //    opBuilder.UseSqlServer(Config);
        //}
    }
}
